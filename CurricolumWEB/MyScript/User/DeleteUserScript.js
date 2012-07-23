var linkObj;
$(function () {

    $(".deleteLink").button();

    $('.DeleteDiv').dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        modal: true,
        buttons: {
            "Sei sicuro che vuoi eliminare il dipendente?": function () {
                var Id = $('#id-hidden-field').val();
                DataString = '?id=' + Id;
                var urlView = 'User/DeleteConfirmUser' + DataString;
                $.post(urlView, function () {

                });

                $(".DeleteDiv").dialog("close");
                alert('dio');
                $(".resultSearch").load("User/SearchRememberUpdating");
                alert('santo')
            },
            "Annulla": function () {
                $(this).dialog("close");
            }
        }
    });

    $(".deleteLink").click(function () {
        //change the title of the dialgo
        linkObj = $(this);
        var dialogDiv = $('.DeleteDiv');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);
            dialogDiv.dialog('open');
        });
        return false;
    });

});
