$(document).ready(function () {
    $('#searchInput').on('keyup', function () {
        var value = $(this).val().toLowerCase();
        $('.veiculo-row').hide(); 
        $('.veiculo-row').filter(function () { 
            return $(this).text().toLowerCase().indexOf(value) > -1;
        }).show(); 
    });
});

