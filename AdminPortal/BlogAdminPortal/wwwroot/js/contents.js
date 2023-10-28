$(document).ready(function () {
    $(".topnav #contents").addClass("active");
    getContents();
});

function getContents() {
    $("#contents tbody").empty();

    showPageLoading();

    $.ajax({
        url: portalApiEndpoint + '/geek-yapar-api/contents',
        method: 'GET',
        complete: function () {
            hidePageLoading();
        },
        success: function (response) {
            $(response.contents).each(function (i, content) {
                var template = $("#contentTemplate").html();
                template = template.replace("#ContentName#", content.name);
                template = template.replace("#ContentAuthor#", content.author);
                template = template.replace('#Id#', content.id);
                template = template.replace('#Id#', content.id);

                $('#contents tbody').append(template);
            });

        },
        error: function (xhr, status, error) {
            alert("Hata Oluştu");
        }
    });
}