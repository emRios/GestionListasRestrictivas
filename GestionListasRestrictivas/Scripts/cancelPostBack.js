
class MyRegExp extends RegExp {
    [Symbol.split](str, limit) {
        var result = RegExp.prototype[Symbol.split].call(this, str, limit);
        return result.map(x => "(" + x + ")");
    }
}

function aContainsB(a, b) {
    return a.indexOf(b) >= 0;
}


function validateEventContainsControlId(Event, controlId) {
    if (aContainsB(Event, controlId)) {
        return true;
    } else {
        return false;
    }
}


debugger;
Sys.Application.add_load(ApplicationLoadHandler);
Sys.Application.add_init(appl_init);



function beforeAsyncPostBack(controlId) {


}

function afterAsyncPostBack(sender, e)
{
    debugger;

   

    if (sender._postBackSettings.sourceElement.computedRole !== "button") {

        if (sender._postBackSettings.panelsToUpdate !== null)
        {
        
        ShowGridViewColumn(7, false);
        }
    }
    checkStatePatient();

}

function ApplicationLoadHandler(sender, args)
{
    debugger;
    Sys.WebForms.PageRequestManager.getInstance().remove_initializeRequest(BeginRequest);
    Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(BeginRequest);

}

function getRowClicked()
{
    var rows = document.getElementById('MasterPageHolder_gvCitasPacientes').getElementsByTagName('tbody')[0].getElementsByTagName('tr');
    //var rows = $(this).closest("tr");
    var este = $("td", rows).eq(3)[0].innerText;

}

function abortPostBack(prm1, prm2)
{
    if (prm1.get_isInAsyncPostBack() || prm2._postBackSettings.async) {

        debugger;

        if (args.get_postBackElement().id === "MasterPageHolder_FV_basalespaciente_btn_circuito_in"
            ||
            args.get_postBackElement().id === "MasterPageHolder_FV_basalespaciente_btn_circuito_out") {

            $("input[id=ctl00_ContentPlaceHolder1_controlID]").val(args.get_postBackElement().id);

            prm.abortPostBack();
            args.set_cancel(true);
            createModal();
        }
    }

}

function BeginRequest(sender, args) {

    debugger; 
    var prm1 = Sys.WebForms.PageRequestManager.getInstance();
    var prm2 = Sys.WebForms.PageRequestManager.getInstance();

    

    if (onEvaluateExclude() === true) {
        checkStatePatient();
        return;
    }

    if (prm1.get_isInAsyncPostBack() || prm2._postBackSettings.async) {

        debugger;

        if (args.get_postBackElement().id === "MasterPageHolder_FV_basalespaciente_btn_circuito_in"
            ||
            args.get_postBackElement().id === "MasterPageHolder_FV_basalespaciente_btn_circuito_out") {

            $("input[id=ctl00_ContentPlaceHolder1_controlID]").val(args.get_postBackElement().id);

            prm1.abortPostBack();
            args.set_cancel(true);
            createModal();
        }
    }

   

}

function appl_init(sender, args) {
    debugger;
    var prm = Sys.WebForms.PageRequestManager.getInstance();

    prm.add_beginRequest(function (sender, args)
    {

        debugger;
        
        var pgRegMgr = Sys.WebForms.PageRequestManager.getInstance();
        //Event raised when the Async Postback is started.
        //sender.abortPostBack();
        // args.set_cancel(true);

        //Detect whether the request is Async
        var isAsync = sender._postBackSettings.async;

        //Detect Id of the control that caused the postback.
        var controlId = sender._postBackSettings.sourceElement.id;
       

        //Id of the updatepanel that caused the postback
       // var updatePanelId = sender._postBackSettings.panelID.split('|')[0];

        BeginHandler(controlId);
    });

    prm.add_endRequest(EndHandler);
}

function BeginHandler(controlId) {
    debugger;

    beforeAsyncPostBack(controlId);
}

function EndHandler(sender, e) {
    debugger;
   
    afterAsyncPostBack(sender, e);
}



