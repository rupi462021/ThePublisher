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
            "Token": "xY_MBMHq2EjIVIvmiS_FR4crNINgHkBv"
        },
    });
}


//var settings = {
//    "url": "http://10.120.17.160:8701/VelaEncompassService/API/GetPlayback?callsign=26cf1d0b-0e71-420b-ae78-b023e62d0a41&start_datetime=2021-03-15T07:15&end_datetime=2021-03-16T08:21:00",
//    "method": "GET",
//    "timeout": 0,
//    "headers": {
//        "Token": "xY_MBMHq2EjIVIvmiS_FR4crNINgHkBv"
//    },
//};

//$.ajax(settings).done(function (response) {
//    console.log(response);
//});