
var test = null;

var state = document.getElementById('content-capture');

var myVal = ""; // Drop down selected value of reader 
var myVal2 = "";
var reader = "";
var disabled = true;
var startEnroll = false;
var currentFormat = Fingerprint.SampleFormat.PngImage;
var dataToSend = "";
var begin = new Boolean(true);
var count = "0";

var deviceTechn = {
               0: "Unknown",
               1: "Optical",
               2: "Capacitive",
               3: "Thermal",
               4: "Pressure"
            }

var deviceModality = {
               0: "Unknown",
               1: "Swipe",
               2: "Area",
               3: "AreaMultifinger"
            }

var deviceUidType = {
               0: "Persistent",
               1: "Volatile"
            }

var FingerprintSdkTest = (function () {
    function FingerprintSdkTest() {
        var _instance = this;
        this.operationToRestart = null;
        this.acquisitionStarted = false;
        this.sdk = new Fingerprint.WebApi;
        this.sdk.onDeviceConnected = function (e) {
            debugger;
            // Detects if the deveice is connected for which acquisition started
            showMessage("Scan your finger");
        };
        this.sdk.onDeviceDisconnected = function (e) {
            // Detects if device gets disconnected - provides deviceUid of disconnected device
            showMessage("Device disconnected");
        };
        this.sdk.onCommunicationFailed = function (e) {
            // Detects if there is a failure in communicating with U.R.U web SDK
            showMessage("Communinication Failed")
        };
        this.sdk.onSamplesAcquired = function (s) {
            debugger;
            // Sample acquired event triggers this function
                sampleAcquired(s);
        };
        this.sdk.onQualityReported = function (e) {
            // Quality of sample aquired - Function triggered on every sample acquired
                document.getElementById("qualityInputBox").value = Fingerprint.QualityCode[(e.quality)];
        }

    }

    FingerprintSdkTest.prototype.startCapture = function ()
    {
        debugger;
        if (this.acquisitionStarted) // Monitoring if already started capturing
            return;
        var _instance = this;
        showMessage("");
        this.operationToRestart = this.startCapture;

        this.sdk.startAcquisition(currentFormat, myVal).then(function () {
            debugger;
            _instance.acquisitionStarted = true;

            //Disabling start once started
            disableEnableStartStop();

        }, function (error) {
            showMessage(error.message);
        });
    };

    FingerprintSdkTest.prototype.startingCapture = function () {
        debugger;
       
        var _instance = this;
       
        this.operationToRestart = this.startCapture;

        this.sdk.startAcquisition(currentFormat, myVal).then(function () {
            debugger;
            _instance.acquisitionStarted = true;

            //Disabling start once started
            disableEnableStartStop();

        }, function (error) {
            showMessage(error.message);
        });
    };

    FingerprintSdkTest.prototype.stopCapture = function () {
        if (!this.acquisitionStarted) //Monitor if already stopped capturing
            return;
        var _instance = this;
        showMessage("");
        this.sdk.stopAcquisition().then(function () {
            _instance.acquisitionStarted = false;

            //Disabling stop once stoped
            disableEnableStartStop();

        }, function (error) {
            showMessage(error.message);
        });
    };

    FingerprintSdkTest.prototype.stopingCapture = function () {
       
        var _instance = this;
        showMessage("");
        this.operationToRestart = this.startCapture;
        this.sdk.stopAcquisition().then(function () {
            _instance.acquisitionStarted = false;

            //Disabling stop once stoped
            disableEnableStartStop();

        }, function (error) {
            showMessage(error.message);
        });

    
    };


    FingerprintSdkTest.prototype.getInfo = function () {
        var _instance = this;
        return this.sdk.enumerateDevices();
    };

    FingerprintSdkTest.prototype.getDeviceInfoWithID = function (uid) {
        var _instance = this;
        return  this.sdk.getDeviceInfo(uid);
    };

    
    return FingerprintSdkTest;
})();

function showMessage(message){
    var _instance = this;
    //var statusWindow = document.getElementById("status");
    x = state.querySelectorAll("#status");
    if(x.length != 0){
        x[0].innerHTML = message;
    }
}

window.onload = function ()
{

    debugger;

    localStorage.clear();
    test = new FingerprintSdkTest();
    readersDropDownPopulate(true); //To populate readers for drop down selection
    disableEnable(); // Disabling enabling buttons - if reader not selected

    localStorage.setItem("countReaders", "0");
    
    //initDB();
};


function onStart() {
    debugger;    
    if(currentFormat == ""){
        alert("Please select a format.")
    }else{        
        test.startCapture();
    }
}

function onStop() {
    debugger;
    test.stopCapture();
}


function stopingCapture() {

    debugger;
    assignFormat();
    test.stopingCapture();

}

function startingCapture() {

    debugger;
    test.startingCapture();

}


function onGetInfo() {
    var allReaders = test.getInfo();    
    allReaders.then(function (sucessObj) {
        populateReaders(sucessObj);
    }, function (error){
        showMessage(error.message);
    });
}
function onDeviceInfo(id, element){
    var myDeviceVal = test.getDeviceInfoWithID(id);
    myDeviceVal.then(function (sucessObj) {
            var deviceId = sucessObj.DeviceID;
            var uidTyp = deviceUidType[sucessObj.eUidType];
            var modality = deviceModality[sucessObj.eDeviceModality];
            var deviceTech = deviceTechn[sucessObj.eDeviceTech];
            //Another method to get Device technology directly from SDK
            //Uncomment the below logging messages to see it working, Similarly for DeviceUidType and DeviceModality
            //console.log(Fingerprint.DeviceTechnology[sucessObj.eDeviceTech]);            
            //console.log(Fingerprint.DeviceModality[sucessObj.eDeviceModality]);
            //console.log(Fingerprint.DeviceUidType[sucessObj.eUidType]);
            var retutnVal = //"Device Info -"
                 "Id : " +  deviceId
                +"<br> Uid Type : "+ uidTyp
                +"<br> Device Tech : " +  deviceTech
                +"<br> Device Modality : " +  modality;

            document.getElementById(element).innerHTML = retutnVal;

        }, function (error){
            showMessage(error.message);
        });

}
function onClear() {
         var vDiv = document.getElementById('imagediv');
         vDiv.innerHTML = "";
         localStorage.setItem("imageSrc", "");
		 //localStorage.setItem("raw", "");
        // localStorage.setItem("wsq", "");         
         /*localStorage.setItem("intermediate", "");*/
         //disableEnableExport(true);
}

function toggle_visibility(ids) {
    debugger;
    document.getElementById("qualityInputBox").value = "";
    onStop();
    enableDisableScanQualityDiv(ids[0]); // To enable disable scan quality div
    for (var i=0;i<ids.length;i++) {        
       var e = document.getElementById(ids[i]);
        if(i == 0){
            e.style.display = 'block';
            state = e;
            disableEnable();
        }
      
   }
}


function save() {

    debugger;


    var counterReaders = localStorage.getItem("countReaders");
    if (counterReaders > "0")
        localStorage.setItem("huella_" + counterReaders, dataToSend);

	/*if (localStorage.getItem("imageSrc") == "" || localStorage.getItem("imageSrc") == null || document.getElementById('imagediv').innerHTML == "") {
		alert("Error -> Fingerprint not available");
	} else {
		//var vDiv = document.getElementById('imageGallery');
		if (vDiv.children.length < 5) {
			var image = document.createElement("img");
			image.id = "galleryImage";
			image.className = "img-thumbnail";
			image.src = localStorage.getItem("imageSrc");
			vDiv.appendChild(image);


		} else {
			document.getElementById('imageGallery').innerHTML = "";
			$("#save").click();
		}
	} */
	
	//addfingerPrint()	;

}
function populateReaders(readersArray) {
        var _deviceInfoTable = document.getElementById("deviceInfo");
        _deviceInfoTable.innerHTML = "";
        if(readersArray.length != 0){
            _deviceInfoTable.innerHTML += "<h4>Available Readers</h4>"
            for (i=0;i<readersArray.length;i++){ 
                _deviceInfoTable.innerHTML += 
                "<div id='dynamicInfoDivs' align='left'>"+
                    "<div data-toggle='collapse' data-target='#"+readersArray[i]+"'>"+
                        "<img src='images/info.png' alt='Info' height='20' width='20'> &nbsp; &nbsp;"+readersArray[i]+"</div>"+
                        "<p class='collapse' id="+'"' + readersArray[i] + '"'+">"+onDeviceInfo(readersArray[i],readersArray[i])+"</p>"+
                    "</div>";
            }
        }
		
		
};

function sampleAcquired(s) {

    debugger;

    if (currentFormat == Fingerprint.SampleFormat.PngImage) {
        // If sample acquired format is PNG- perform following call on object recieved 
        // Get samples from the object - get 0th element of samples as base 64 encoded PNG image         
        localStorage.setItem("imageSrc", "");
        var samples = JSON.parse(s.samples);
        localStorage.setItem("imageSrc", "data:image/png;base64," + Fingerprint.b64UrlTo64(samples[0]));
        if (state == document.getElementById("content-capture")) {
            var vDiv = document.getElementById('imagediv');
            vDiv.innerHTML = "";
            var image = document.createElement("img");
            image.id = "image";
            image.src = localStorage.getItem("imageSrc");
            vDiv.appendChild(image);
        }

       
    }

    else if (currentFormat == Fingerprint.SampleFormat.Compressed) {
        // If sample acquired format is Compressed- perform following call on object recieved 
        // Get samples from the object - get 0th element of samples and then get Data from it.
        // Returned data is Base 64 encoded, which needs to get decoded to UTF8,
        // after decoding get Data key from it, it returns Base64 encoded wsq image
        //localStorage.setItem("wsq", "");
        var samples = JSON.parse(s.samples);
     
        var sampleData = Fingerprint.b64UrlTo64(samples[0].Data);
        var decodedData = JSON.parse(Fingerprint.b64UrlToUtf8(sampleData));

        dataToSend = JSON.stringify(decodedData);

        
    }

    
    save();
    var counterReaders = localStorage.getItem("countReaders");
    if (counterReaders == "0" && begin) {
        count = parseInt(counterReaders) + 1;
        localStorage.setItem("countReaders", count);
        stopingCapture();
        startingCapture();
        begin = false;
        localStorage.setItem("countReaders", "0");
    }

    var counterReaders = localStorage.getItem("countReaders");
    count = parseInt(counterReaders) + 1;
    localStorage.setItem("countReaders", count);
    
}

// Check for redirecting is a boolean value which monitors to redirect to content tab or not
function readersDropDownPopulate(checkForRedirecting)
{  
    myVal = "";

    debugger;
    var allReaders = test.getInfo();
    allReaders.then(function (sucessObj)
    {   

        debugger;
       

        reader = sucessObj[0];
        //Check if readers are available get count and  provide user information if no reader available, 
        //if only one reader available then select the reader by default and sennd user to capture tab
        checkReaderCount(sucessObj,checkForRedirecting);

    }, function (error){
        showMessage(error.message);
    });
}

function checkReaderCount(sucessObj, checkForRedirecting) {
    debugger;
   if(sucessObj.length == 0){
    alert("No reader detected. Please insert a reader.");
   }else if(sucessObj.length == 1){
      //  document.getElementById("readersDropDown").selectedIndex = "1";
        if(checkForRedirecting){
            toggle_visibility(['content-capture']);    
            enableDisableScanQualityDiv("content-capture"); // To enable disable scan quality div
           // setActive('Capture','Reader'); // Set active state to capture
        }
   }

    selectChangeEvent(); // To make the reader selected
}

function selectChangeEvent() {
    debugger;
   // var readersDropDownElement = document.getElementById("readersDropDown");
    myVal = reader;//readersDropDownElement.options[readersDropDownElement.selectedIndex].value;
    myVal2 = reader;
    disableEnable();
    onClear();
   // document.getElementById('imageGallery').innerHTML = "";
   // document.getElementById('imageGallery').innerHTML = "";

   
}


//Enable disable buttons
function disableEnable() {
    debugger;
    if(myVal != ""){
        disabled = false;
        $('#start').prop('disabled', false);
        $('#stop').prop('disabled', false);
        showMessage("");
        disableEnableStartStop();
    }else{
        disabled = true;
        $('#start').prop('disabled', true);
        $('#stop').prop('disabled', true);
        showMessage("Please select a reader");
        onStop();
    }
}


// Start-- Optional to make GUi user frindly 
//To make Start and stop buttons selection mutually exclusive
$('body').click(function(){disableEnableStartStop();});

function disableEnableStartStop(){
     if(!myVal == ""){
        if(test.acquisitionStarted){
            $('#start').prop('disabled', true);
            $('#stop').prop('disabled', false);
        }else{
            $('#start').prop('disabled', false);
            $('#stop').prop('disabled', true); 
        }
    }
}

// Stop-- Optional to make GUI user freindly


function enableDisableScanQualityDiv(id){
    if(id == "content-reader"){
        document.getElementById('Scores').style.display = 'none';
    }else{
        document.getElementById('Scores').style.display = 'block';
    }
}



// For Download and formats starts

function onImageDownload(){
    if(currentFormat == Fingerprint.SampleFormat.PngImage){
        if(localStorage.getItem("imageSrc") == "" || localStorage.getItem("imageSrc") == null || document.getElementById('imagediv').innerHTML == "" ){
           alert("No image to download");
        }else{
            //alert(localStorage.getItem("imageSrc"));
            downloadURI(localStorage.getItem("imageSrc"), "sampleImage.png", "image/png");
        }
    }

    else if(currentFormat == Fingerprint.SampleFormat.Compressed){
         if(localStorage.getItem("wsq") == "" || localStorage.getItem("wsq") == null || document.getElementById('imagediv').innerHTML == "" ){
           alert("WSQ data not available.");
        }else{
            downloadURI(localStorage.getItem("wsq"), "compressed.wsq","application/octet-stream");
        }
    }

    else if(currentFormat == Fingerprint.SampleFormat.Raw){
         if(localStorage.getItem("raw") == "" || localStorage.getItem("raw") == null || document.getElementById('imagediv').innerHTML == "" ){
           alert("RAW data not available.");
        }else{

            downloadURI("data:application/octet-stream;base64,"+localStorage.getItem("raw"), "rawImage.raw", "application/octet-stream");
        }
    }

    else if(currentFormat == Fingerprint.SampleFormat.Intermediate){
         if(localStorage.getItem("intermediate") == "" || localStorage.getItem("intermediate") == null || document.getElementById('imagediv').innerHTML == "" ){
           alert("Intermediate data not available.");
        }else{

            downloadURI("data:application/octet-stream;base64,"+localStorage.getItem("intermediate"), "FeatureSet.bin", "application/octet-stream");
        }
    }

    else{
        alert("Nothing to download.");
    }
}


function downloadURI(uri, name, dataURIType) {
    if (IeVersionInfo() > 0){ 
    //alert("This is IE " + IeVersionInfo());
    var blob = dataURItoBlob(uri,dataURIType);
    window.navigator.msSaveOrOpenBlob(blob, name);

    }else {
        //alert("This is not IE.");
        var save = document.createElement('a');
        save.href = uri;
        save.download = name;
        var event = document.createEvent("MouseEvents");
            event.initMouseEvent(
                    "click", true, false, window, 0, 0, 0, 0, 0
                    , false, false, false, false, 0, null
            );
        save.dispatchEvent(event);
    }
}

dataURItoBlob = function(dataURI, dataURIType) {
    var binary = atob(dataURI.split(',')[1]);
    var array = [];
    for(var i = 0; i < binary.length; i++) {
        array.push(binary.charCodeAt(i));
    }
    return new Blob([new Uint8Array(array)], {type: dataURIType});
}


function IeVersionInfo() {
  var sAgent = window.navigator.userAgent;
  var IEVersion = sAgent.indexOf("MSIE");

  // If IE, return version number.
  if (IEVersion > 0) 
    return parseInt(sAgent.substring(IEVersion+ 5, sAgent.indexOf(".", IEVersion)));

  // If IE 11 then look for Updated user agent string.
  else if (!!navigator.userAgent.match(/Trident\/7\./)) 
    return 11;

  // Quick and dirty test for Microsoft Edge
  else if (document.documentMode || /Edge/.test(navigator.userAgent))
    return 12;

  else
    return 0; //If not IE return 0
}


jQuery(document).ready(function(){
  $('[data-toggle="tooltip"]').tooltip();   
});


function assignFormat()
{
    var countReaders = localStorage.getItem("countReaders");

    if (countReaders == "0")
        currentFormat = Fingerprint.SampleFormat.PngImage;
    if (countReaders > "0")
        currentFormat = Fingerprint.SampleFormat.Compressed;

}



function disableEnableSaveThumbnails(val){
    if(val){
        $('#save').prop('disabled', true);
    }else{
        $('#save').prop('disabled', false); 
    }
}


function delayAnimate(id,visibility)
{
   document.getElementById(id).style.display = visibility;
}

function openDB ()
{
    var dbSize = 5 * 1024 * 1024; // 5MB
    db = openDatabase("huellas", "1", "huellas DB", dbSize);

    return db;
}
function createTable (db)
{
    db.transaction(function (tx)
    {
        tx.executeSql("CREATE TABLE IF NOT EXISTS " +
            "huellas(Id INTEGER PRIMARY KEY ASC, nhc str, huella str)", []);
    });
}

function dropTable(db) {
    db.transaction(function (e) {
        e.executeSql("DROP TABLE huellas");
    });
}

function initDB() {
    
    if (window.openDatabase)
    {   
        db = openDB();
        dropTable(db);
        createTable(db);
    }

}

function insertData(db, nhc, huella)
{

    db.transaction(function (tx) {
       
        tx.executeSql("INSERT INTO huellas(nhc, huella) VALUES (?, ?)", [nhc, huella], onSuccess, onError);
    });
}



function addfingerPrint() {
    db = openDB();
    if (db) {
        
        var data = localStorage.getItem("imageSrc");
        var huella = data.substr(data.search(",") + 1, data.length);
        var  nhc = "151617";        
        if (huella !== "" && nhc !== "") {

            insertData(db, nhc, huella);
           
        } 
    } else {
        alert("db not found, your browser does not support web sql!");
    }
}




function onSuccess(e) { }
function onError(e) { }


// For Download and formats ends