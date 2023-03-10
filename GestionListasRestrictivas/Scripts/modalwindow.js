var BstrapModal = function (title, body, buttons) {
    var title = title || "Lorem Ipsum History", body = body ||
        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. ", buttons = buttons || [{ Value: "CLOSE", 
    Css: "btn-primary", Callback: function (event) { BstrapModal.Close(); }
}];
var GetModalStructure = function () {
    var that = this;
    that.Id = BstrapModal.Id = Math.random();
    var buttonshtml = "";
    for (var i = 0; i < buttons.length; i++) {
        buttonshtml += "<button type='button' class='btn " +
            (buttons[i].Css || "") + "' name='btn" + that.Id +
            "'>" + (buttons[i].Value || "CLOSE") +
            "</button>";
    }
    return "<div class='modal fade' name='dynamiccustommodal'  id = '" + that.Id + "' tabindex = '-1' role = 'dialog'  data-backdrop='static' data-keyboard='false' aria-labelledby='" + 
    that.Id + "Label'><div class='modal-dialog'>   < div class='modal-content' > <div class='modal-header'>     <button type='button' class='close modal-white-close'  onclick='BstrapModal.Close()'><span aria-hidden='true'>&times;   </span></button><h4 class='modal-title'>" + title +
        "</h4></div> <div class='modal-body'> <div class='row'><div class='col-xs-12 col-md-12 col-sm-12 col-lg-12'>" +
        body + "</div></div></div> <div class='modal-footer bg-default'>   <div class='col-xs-12 col-sm-12 col-lg-12'>" + buttonshtml +
        "</div></div></div ></div ></div > ";
}();
BstrapModal.Delete = function () {
    var modals = document.getElementsByName("dynamiccustommodal");
    if (modals.length > 0)
        document.body.removeChild(modals[0]);
};
BstrapModal.Close = function () {
    $(document.getElementById(BstrapModal.Id)).modal('hide');
    BstrapModal.Delete();
};
    this.Show = function () {
        debugger;
    BstrapModal.Delete();
    document.body.appendChild($(GetModalStructure)[0]);
    var btns = document.querySelectorAll("button[name='btn" + BstrapModal.Id + "']");
    for (var i = 0; i < btns.length; i++) {
        btns[i].addEventListener("click", buttons[i].Callback || BstrapModal.Close);
    }
    $(document.getElementById(BstrapModal.Id)).modal('show');
};
};



function createModal() {


    bootbox.dialog({
        title: "Validacion Paciente",
        message:    "<input type='text' id='mensaje' class='col-sm-10 border border-white mb-2' name='mensaje' style='display: none;'/>" +
                    "<div id='content-capture' style='display: none;'> <div id='status'>" +
                    "</div> <div id='imagediv' class='mb-2'></div> </div> <div id='Scores'>" +
                    "<input type='hidden' id='qualityInputBox' size='10' style='background-color: #DCDCDC; text-align: center;'> </div>",        
        buttons: {
            main: {
                label: "Continuar",
                className: "btn-primary",
                callback: function () {
                    debugger;
                    
                    

                    var ControlId = $("[id$=controlID]").val();
                    var nhc = $("input[name*='lblnhc']")[0].value;

                    var sender = document.getElementById(ControlId);
					var type = $(sender).prev().prevObject[0].nodeName;
					
					if (type === "INPUT")
                    {
                        if (ControlId === "MasterPageHolder_FV_basalespaciente_btn_circuito_in") {

                            onInitCircuit();
                            checkStatePatient();
                            //$("input[id*=btn_circuito_in]").attr("disabled", "disabled");
                            //$("input[id*=btn_circuito_out]").removeAttr("disabled");       
                        }
                        if (ControlId === "MasterPageHolder_FV_basalespaciente_btn_circuito_out") {

                            onFinishCircuit();
                            $("#MasterPageHolder_FV_basalespaciente_btn_circuito_in").attr('disabled', true);
                            $("#MasterPageHolder_FV_basalespaciente_btn_circuito_out").attr('disabled', true);
                            window.location = "PacientesEnAtencion.aspx";
                            //$("input[id*=btn_circuito_in]").attr("disabled", "disabled");
                            //$("input[id*=btn_circuito_out]").attr("disabled", "disabled");
                            Sys.WebForms.PageRequestManager.getInstance().remove_initializeRequest(BeginRequest);
                        }
                    }

                    else if (type === "table") {

                        Sys.WebForms.PageRequestManager.getInstance().remove_initializeRequest(BeginRequest);
                        var rowIndex = $("input[name*='rowIndex']")[0].value;

                        if (ControlId === "MasterPageHolder_gvPacsEnAtencion") {
                            __doPostBack('ctl00$MasterPageHolder$btn_navegar', JSON.stringify({ rowIndex: rowIndex, nhc: nhc }));

                        }

                    }

                    

                   
                }
            }
        }
    });

    $('.bootbox').on('shown.bs.modal', function ()
    {
        debugger;
        $("#modal-header").css("align-text", "left");
        $('.btn-primary').hide();
        onLoad();

        
    });

    $(document).on("hidden.bs.modal", ".bootbox.modal", function (e) {
        debugger;
        onStop();
    });


 


    //$("#bootbox").on("click", function (event) {
    //    var modal = bootbox.dialog({
    //        message: $(".form-content").html(),
    //        title: "Your awesome modal",
    //        buttons: [
    //            {
    //                label: "Save",
    //                className: "btn btn-primary pull-left",
    //                callback: function () {

    //                    alert($('form #email').val());

    //                    return false;
    //                }
    //            },
    //            {
    //                label: "Close",
    //                className: "btn btn-default pull-left",
    //                callback: function () {
    //                    console.log("just do something on close");
    //                }
    //            }
    //        ],
    //        show: false,
    //        onEscape: function () {
    //            modal.modal("hide");
    //        }
    //    });

    //    modal.modal("show");
    //});

}


function onErrorHandler(messageHandled)
{
    bootbox.alert({
        message: messageHandled,
        callback: function () {
            console.log('This was logged in the callback!');
        }
    });
}