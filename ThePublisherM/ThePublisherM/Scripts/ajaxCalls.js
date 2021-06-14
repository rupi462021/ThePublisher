function ajaxCall(method, api, data, successCB, errorCB) {
    $.ajax({
        type: method,
        url: api,
        data: data,
        cache: false,
        contentType: "application/json",
        dataType: "json",
        success: successCB,
        error: errorCB,
        headers: {
            "Authorization": "Bearer AAAAAAAAAAAAAAAAAAAAALrtPAEAAAAAPe1Z6GbQLJkZZo%2FQMFlm5X9LCo0%3Dg2AgGSF6X8xGvwaJ43oRJWdhy2ufP6NsuKap3BlRmFae7bvTen"

        },
        
    });
}
function ajaxCallLocal(method, api, data, successCB, errorCB) {
    $.ajax({
        type: method,
        url: api,
        data: data,
        cache: false,
        contentType: "application/json",
        dataType: "json",
        success: successCB,
        error: errorCB
    });
}

