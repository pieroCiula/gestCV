$(document).ready(function () {
    $('.submit-user-button').click(function (event) {
        event.preventDefault();

        var valore_email = $('.editor-field-email input').val();
        var valore_id = $('.user-id-hidden').val();
        indirizzo = $('.editor-field-email').data('url');
        if (valore_id == null) {
            valore_id = 0;
        }
        $.ajax({
            url: indirizzo,
            type: 'GET',
            data: { email: valore_email, id: valore_id },
            success: function (data) {
                alert(data);
                if (valore_email == "") {
                    data = true;
                }
                if (data == true) {
                    $('.failed-icon-class').fadeToggle(1500, 'linear');
                    $('.failed-icon-class').fadeOut(1500, function () {
                        var string = '<p style="color:Red">L\'email è già stato scelto da un\' altro utente o non è valido, scegline un\'altro</p>';
                        $('.failed-dettails-email-field').html(string);
                        $('.failed-dettails-email-field').fadeIn(5000, 'linear')
                        $('.failed-dettails-email-field p').fadeOut(3000, 'linear');
                    });

                    return false;

                } else {
                    $('.success-icon-class').fadeToggle(1500, 'linear');
                    $('.success-icon-class').fadeOut(1500, function () {
                        var string = '<p style="color:Green">L\'email è univoca!</p>';
                        $('.failed-dettails-email-field').html(string);
                        $('.failed-dettails-email-field').fadeIn(5000, 'linear')
                        $('.failed-dettails-email-field p').fadeOut(3000, 'linear');
                    });
                    $('.success-icon-class').fadeIn('fast', 'swing');
                    $('.UserForm').submit();
                }
            }
        });


    });
});