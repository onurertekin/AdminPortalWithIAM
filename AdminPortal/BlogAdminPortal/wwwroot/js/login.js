
function login() {

    var username = $('#username').val();
    var password = $('#password').val();

    $.ajax({
        url: portalApiEndpoint + '/iam/authentication',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({
            "username": username,
            "password": password
        }),
        success: function (response) {
            localStorage.setItem("Token", response.token);
            window.location.href = "/users";
        },
        error: function (error, xhr, status) {
            alert("Hata Oluştu!");
        }
    });
}