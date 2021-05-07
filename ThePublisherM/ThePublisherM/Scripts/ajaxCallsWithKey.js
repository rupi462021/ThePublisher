function ajaxCall(method, api, data, successCB, errorCB) {
    $.ajax({
        type: method,
        url: api,
        data: data,
        cache: false,
		headers: {
            'user-key': 'c6c04a72f038e32b876ef3c943944597',
        },
        contentType: "application/json",
        dataType: "json",
        success: successCB,
        error: errorCB
    });
}