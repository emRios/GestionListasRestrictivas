
Sys.Application.add_endRequest(onEndRequest);


function onEndRequest(sender, args) {

    debugger;
    var error = args.get_error();
    if (error !== null) {
        // Set the error handled flag to avoid a runtime error
        // reaching the user.
        args.set_errorHandled(true);
        // Remove the error name from the message
        var msg = error.message.replace("Sys.WebForms.PageRequestManagerServerErrorException: ", "");
        // alert(msg);
        onErrorHandler(msg);

    }
}