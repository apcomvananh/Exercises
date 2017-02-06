$(function () {
    var listrolecbholder = 'span.listrolecbholder';
    $(listrolecbholder).click(function () {
        var checkedRoles = [];
        $(this).find('input[type=radio]:checked').each(function () {
            checkedRoles.push($(this).val());
        });

        var userId = $(this).find('#userId').val();

        // Make a view model instance
        var ajaxRoleUpdateViewModel = new Object();
        ajaxRoleUpdateViewModel.Id = userId;
        ajaxRoleUpdateViewModel.Roles = checkedRoles;

        // Ajax call to post the view model to the controller
        var strung = JSON.stringify(ajaxRoleUpdateViewModel);

        $.ajax({
            url: $('#UpdateUserRoles').val(),
            type: 'POST',
            data: strung,
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                ShowGenericMessage("Roles updated");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                ShowGenericMessage("Error: " + xhr.status + " " + thrownError);
            }
        });
    });
});

var Role = {
    CreateRole: function () {
        var url = $('#CreateRoleUrl').val();
        CallAjaxGetFunction(url, {}, function (data) {
            $('#roleModal').html(data);
            $('#roleModal').modal('show');
        })
    },

    EditRole: function (id) {
        var url = $('#EditRoleUrl').val();
        CallAjaxGetFunction(url, { id: id }, function (data) {
            $('#roleModal').html(data);
            $('#roleModal').modal('show');
        })
    },

    Success: function (data) {
        if (data.success == true) {
            $('#roleModal').modal('hide');
            location.reload();
        }
        else {
            $('#roleModal').html(data);
            $('#roleModal').modal('show');
        }
    }
}

var AdminTopic = {
    CreateTopic: function () {
        var url = $('#CreateTopicUrl').val();
        CallAjaxGetFunction(url, {}, function (data) {
            $('#topicModal').html(data);
            $('#topicModal').modal('show');
        })
    },

    EditTopic: function (id) {
        var url = $('#EditTopicUrl').val();
        CallAjaxGetFunction(url, { id: id }, function (data) {
            $('#topicModal').html(data);
            $('#topicModal').modal('show');
        })
    },

    Success: function (data) {
        if (data.success == true) {
            $('#topicModal').modal('hide');
            location.reload();
        }
        else {
            $('#topicModal').html(data);
            $('#topicModal').modal('show');
        }
    }
}

var AdminLesson = {
    CreateLesson: function () {
        var url = $('#CreateLessonUrl').val();
        CallAjaxGetFunction(url, {}, function (data) {
            $('#lessonModal').html(data);
            $('#lessonModal').modal('show');
        })
    },

    EditLesson: function (id) {
        var url = $('#EditLessonUrl').val();
        CallAjaxGetFunction(url, { id: id }, function (data) {
            $('#lessonModal').html(data);
            $('#lessonModal').modal('show');
        })
    },

    Success: function (data) {
        if (data.success == true) {
            $('#lessonModal').modal('hide');
            location.reload();
        }
        else {
            $('#lessonModal').html(data);
            $('#lessonModal').modal('show');
        }
    }
}

var AdminWord = {
    CreateWord: function () {
        var url = $('#CreateWordUrl').val();
        CallAjaxGetFunction(url, {}, function (data) {
            $('#wordModal').html(data);
            $('#wordModal').modal('show');
        })
    },

    EditWord: function (id) {
        var url = $('#EditWordUrl').val();
        CallAjaxGetFunction(url, { id: id }, function (data) {
            $('#wordModal').html(data);
            $('#wordModal').modal('show');
        })
    },

    Success: function (data) {
        if (data.success == true) {
            $('#wordModal').modal('hide');
            location.reload();
        }
        else {
            $('#wordModal').html(data);
            $('#wordModal').modal('show');
        }
    }
}