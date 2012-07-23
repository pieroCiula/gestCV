//on load pagina index, carica l'elenco dei ruoli nell'INDEX, per la dropdown list di ricerca user
$(document).ready(function () {

    $.ajax({
        url: 'Ruolo/AllRuoloForDropDown',
        type: 'GET',
        success: function (data) {
            
            //
            var drop_ruolo = $('.dropdown_ruolo');
            var domRuolo = drop_ruolo.get(0); // $('#id') != document.getElementById('id')
            //Empty the ruolo dropdown list
            for (var i = domRuolo.options.length - 1; i > 0; i--) {
                domRuolo.remove(i);
            }
            for (var i = 0; i < data.length; i++) {
                var item = data[i];
                var RuoloOption = new Option(item.Name, item.Id);
                drop_ruolo.append(RuoloOption);
            }
        }
    });


});