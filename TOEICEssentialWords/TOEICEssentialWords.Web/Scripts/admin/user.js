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