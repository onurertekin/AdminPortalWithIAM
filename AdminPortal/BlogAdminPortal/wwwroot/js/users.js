$(document).ready(function () {
    //Sayfa ilk açıldığında yapılması gereken işlemleri buraya yazın
    $(".topnav #users").addClass("active");
    getUsers();
});

function getUsers() {

    showPageLoading();

    $("#users tbody").empty();

    $.ajax({
        url: portalApiEndpoint + '/iam/users',
        method: 'GET',
        complete: function () {
            hidePageLoading();
        },
        success: function (response) {

            $(response.users).each(function (i, user) {
                var template = $("#userTemplate").html();
                template = template.replace("#UserFirstName#", user.firstName);
                template = template.replace("#UserSurname#", user.lastName);
                template = template.replace("#UserName#", user.userName);
                template = template.replace("#UserEmail#", user.email);
                template = template.replace("#Id#", user.id);
                template = template.replace("#Id#", user.id);
                template = template.replace("#Id#", user.id);
                $('#users tbody').append(template);
            });
        },
        error: function (xhr, status, error) {

            if (xhr.status == 401) {
                window.location.href = "/login";
                return;
            }
            console.error("status: " + status);
            console.error("API isteği başarısız oldu:", error);
        }
    });


}