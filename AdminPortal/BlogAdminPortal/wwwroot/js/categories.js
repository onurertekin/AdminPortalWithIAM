$(document).ready(function () {
    //Sayfa ilk açıldığında yapılması gereken işlemleri buraya yazın
    $(".topnav #categories").addClass("active");
    getCategories();
});

function getCategories() {

    $("#categories tbody").empty(); // Sayfayı boşalt ki yeni gelen veriler ardına gelmesin.
    showPageLoading();

    $.ajax({
        url: portalApiEndpoint + '/geek-yapar-api/categories',
        method: 'GET',
        complete: function () {
            hidePageLoading();
        },
        success: function (response) {

            $(response.categories).each(function (i, category) {
                var template = $("#categoryTemplate").html();
                template = template.replace('#Id#', category.id);
                template = template.replace('#Id#', category.id);
                template = template.replace('#CategoryName#', category.name);
                $('#categories tbody').append(template);
            });
        },
        error: function (xhr, status, error) {
            alert("Hata Oluştu");
        }
    });
}
