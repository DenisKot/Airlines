$(document).ready(function () {
    $('body').on('mousedown', 'tr[url]', function (e) {
        var click = e.which;
        var url = $(this).attr('url');
        if (url) {
            if (click == 1) {
                window.location.href = url;
            }
            else if (click == 2) {
                window.open(url, '_blank');
                window.focus();
            }
            return true;
        }
    });

    document.getElementById('iban').addEventListener('input', function (e) {
        e.target.value = e.target.value.replace(/[^\dA-Z]/g, '').replace(/(.{4})/g, '$1 ').trim();
    });
});

document.getElementById('iban').addEventListener('input', function (e) {
    e.target.value = e.target.value.replace(/[^\dA-Z]/g, '').replace(/(.{4})/g, '$1 ').trim();
});
