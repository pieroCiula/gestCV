$(document).ready(function () {

    $('.autocomplete_text').each(function () {
        var target = $(this);
        target.autocomplete({ source: target.attr('data-autocomplete-source') });
    });

    $('.autocomplete_text').focus(function () {
        $(this).css('background-color', 'yellow');
    }).blur(function () {
        $(this).css('background-color', '');
    })



    $('.autocomplete_form').submit(function (event) {
        event.preventDefault();
        var form = $(this);

        $('.resultSearch').load(form.attr('action'), form.serialize(), function (data) {
            
            //$('#dipendenteTemplate').tmpl(data).appendTo('#dipendente-list');
        })
    });





});

//Se show All ha un'errore
function report_no_ShowAll() {
    $('#All_dipendenti').htlm('Errore_ non è stato possibile mostrare tutti i dipendenti');
}
//se La ricerca ha un errore
function ricerca_fallita() {
    $('#res_dip_search').html('Spiacente, si è verificato un problema con la ricerca.');
}
