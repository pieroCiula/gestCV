$(document).ready(function () {


//    $.ajax({
//        url: 'Ruolo/AllRuoloForDropDown',
//        type: 'GET',
//        success: function (data) {
//            alert("caricamento drop di addUser");
//            var drop_ruolo = $('#dr');
//            var domRuolo = drop_ruolo.get(0); // $('#id') != document.getElementById('id')
//            //Empty the ruolo dropdown list
//            for (var i = domRuolo.options.length - 1; i > 0; i--) {
//                domRuolo.remove(i);
//            }
//            for (var i = 0; i < data.length; i++) {
//                var item = data[i];
//                var RuoloOption = new Option(item.Name, item.Id);
//                drop_ruolo.append(RuoloOption);
//            }
//        }
//    });



    $('.UserForm').submit(function () {
        var valore_drop_ruolo = $('.dropdown_ruolo').val();
        if (valore_drop_ruolo == 0) {
            alert('L\' utente deve avere un ruolo!');
            return false;
        }
    });
});

//$('#commessa_search_form').submit(function (event) {
//    event.preventDefault();
//    var form = $(this);
//    $('#MostraCommesse').load(form.attr('action'), form.serialize(), function (data) {

//        //$('#dipendenteTemplate').tmpl(data).appendTo('#dipendente-list');
//    })
//});