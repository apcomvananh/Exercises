$(function () {
    $('#btnAddToWordList').click(function () {
        $.ajax({
            url: $('#AddToWordListUrl').val(),
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                ShowGenericMessage("Word was added to wordlist");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                ShowGenericMessage("Error: " + xhr.status + " " + thrownError);
            }
        });
    });
});