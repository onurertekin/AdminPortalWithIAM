$(document).ready(function () {
    $(".topnav #roles").addClass("active");
    getRoles();
});

function getRoles()
{
    showPageLoading();
    $("#roles tbody").empty();
    $.get(portalApiEndpoint+ '/iam/roles', function (response) {

        $(response.roles).each(function (i, role) {

            var template = $("#roleTemplate").html();
            template = template.replace("#RoleName#", role.name);
            template = template.replace("#Id#", role.id);
            template = template.replace("#Id#", role.id);

            $('#roles tbody').append(template);
            hidePageLoading();
        });
    });
}