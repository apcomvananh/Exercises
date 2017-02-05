function CallAjaxFunction(action, type, params, success, error) {
    $.ajax({
        async: true,
        type: (type) ? type : 'get',
        url: action,
        data: params,
        crossDomain: false,
        cache: false,
        success: function (data) {
            if (success) {
                success(data);
            }
        },
        error: function (xmlHttpRequest, txtStatus, errorThrown) {
            if (xmlHttpRequest.status != 401 && error) {
                error(xmlHttpRequest, txtStatus, errorThrown);
            }
        }
    });
};

function CallAjaxGetFunction(action, params, success, error) {
    CallAjaxFunction(action, 'GET', params, success, error);
}

function CallAjaxPostFunction(action, params, success, error) {
    CallAjaxFunction(action, 'POST', params, success, error);
}

function BindEventForControl(elmId, eventType, eventFunc, selectorType) {
    if (selectorType == null) {
        selectorType = "#";
    }

    var $elm = $(selectorType + elmId);
    if ($elm.length > 0) {
        //Remove event first
        $elm.off(eventType);
        //Bind event
        $elm.on(eventType, eventFunc);
    }
}

function ShowGenericMessage(message) {
    if (message != null) {
        var jsMessage = $('#jsquickmessage');
        var toInject = "<div class=\"alert alert-info fade in\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;<\/span><\/button>" + message + "<\/div>";
        jsMessage.html(toInject);
        jsMessage.show();
        $('div.alert').delay(2200).fadeOut();
    }
}