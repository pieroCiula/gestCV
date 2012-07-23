$(document).ready(function () {
    $('.submit-user-button').click(function (event) {
        event.preventDefault();

        var valore_username = $('.editor-field-username input').val();
        indirizzo = $('.editor-field-username').data('url');
        $.ajax({
            url: indirizzo,
            type: 'GET',
            data: { username: valore_username },
            success: function (data) {
                if (valore_username == "") {
                    //se username è una stringa vuota
                    data = true;
                    var stringa = "Il nome non può essere un campo vuoto, scegline un\'altro!";
                    var Container = $('.username-general-div');
                    display_failed_img(Container, stringa);

                    return false;
                }
                //se username è presente nel DB allora un messaggio di errore
                if (data == true) {
                    var stringa = "Il nome è già stato scelto da un\' altro utente, scegline un\'altro!";
                    display_failed_img(stringa);

                    return false;

                } else {
                    var stringa = "Il tuo username è corretto!";
                    display_success_img(stringa);
                    $('.success-icon class').fadeIn('fast', 'swing');
                    $('.UserForm').submit();
                }
            }
        });



    });
});





//Se il nome non è ancora presente nel DB
function display_success_img( stringa) {
    $(' .success-icon-class').fadeToggle(1500, 'linear');
    $('.success-icon-class').fadeOut(1500, function () {
        var string = '<p style="color:Green">' + stringa + '</p>';
        $('.failed-dettails-username-field').html(string);
        $('.failed-dettails-username-field').fadeIn(5000, 'linear')
        $('.failed-dettails-username-field p').fadeOut(3000, 'linear');
    });
}


//se il nome è già presente nel DB
function display_failed_img( stringa) {
    
    $(Container,' .failed-icon-class').fadeToggle(1500, 'linear');
    $(Container, '.failed-icon-class').fadeOut(1500, function () {
        var string = '<p style="color:Red">'+stringa+'</p>';
        $('.failed-dettails-username-field').html(string);
        $('.failed-dettails-username-field').fadeIn(5000, 'linear')
        $('.failed-dettails-username-field p').fadeOut(3000, 'linear');
    });
}


