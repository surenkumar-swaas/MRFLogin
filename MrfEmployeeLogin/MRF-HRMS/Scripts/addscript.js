

$(document).ready(function () {
    loadData();

});

$(document).on('click', '#back', function () {
    parent.history.back();
});

function loadData() {
    var UserID = $('#getdata').val();
    console.log(UserID);
    $.ajax({
        url: "/UserMrf/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            var html = '';
            $.each(result, function (key, item) {

                html += '<tr>';
                html += '<td>' + item.ID + '</td>';

                html += '<td>' + item.PositionName + '</td>';

                html += '<td>' + item.CreatedByID + '</td>';

                html += '<td>' + item.VacancyFor + '</td>';

                html += '<td>' + item.Territory + '</td>';

                html += '<td><a href="#" onclick="return GetByID(' + item.ID + ')">Edit</a> | <a href="#" onclick="Delete(' + item.ID + ')">Delete</a></td>';

                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function GetByID(ID) {

    window.location = "../UserMrf/EditUserView?MrfID=" + ID;

}

function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/UserMrf/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}