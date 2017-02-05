var role = {
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