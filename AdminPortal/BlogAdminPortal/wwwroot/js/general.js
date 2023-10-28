function readFromUrl(key)
{
	var urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(key);
}

function goToUrl(url) {
    window.location.href = url;
}

function fillCategories(selector) {
    $.get('http://localhost:5000/geek-yapar-api/categories', function (response) {
        $(response.categories).each(function (i, category) {
            $(selector).append("<option value='" + category.id + "'>" + category.name + "</option>");
        });
    });
}

function logout() {
    localStorage.removeItem("Token"); //LocalStorage'den Token'ý siliyoruz ki çýkýþ yaptýðýnda tekrardan giriþ istesin.
    window.location.href = "/login";
}

$.ajaxSetup({
    beforeSend: function (xhr) {
        var token = localStorage.getItem("Token");
        xhr.setRequestHeader('Token', token);
    }
});

function showPageLoading() {
    $(".page").hide();
    $(".page-loading").show();
}

function hidePageLoading() {
    $(".page-loading").hide();
    $(".page").fadeIn(300);
}

function showModalLoading(modalId) {
    $("#" + modalId + " .modal-body").hide();
    $("#" + modalId + " .modal-footer").hide();
    $("#" + modalId + " .modal-content").append("<div class='modalLoading'><div class='spinner-border'></div></div>");
}

function hideModalLoading(modalId) {
    $("#" + modalId + " .modal-body").show();
    $("#" + modalId + " .modal-footer").show();
    $("#" + modalId + " .modalLoading").remove();
}
