//$(document).ready(function () {
//    loadData();
//});

////Load Data function
//function loadData() {
//    $.ajax({
//        url: "/MRF/List",
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function (result) {
//            //$(function () {
//            //    $('#Grid').ejGrid({
//            //        dataSource: result,
//            //        allowPaging: true,
//            //        pageSettings: { pageSize: 3 }
//            //    });
//            //});
//            var html = '';
//            $.each(result, function (key, item) {
//                var date = item.CreatedDate;
//                var nowdate = new Date(parseInt(date.substr(6)));

//                var FilledBefore = item.FilledBefore;
//                var filledbefore_formated = new Date(parseInt(FilledBefore.substr(6)));


//                html += '<tr>';
//                if (item.StatusID == 1 && item.UserID != $('#CreatedByID').val()) {
//                    html += '<td><a href="#" onclick="return UserStatus(' + item.ID + ',2)">Approved</a> | <a href="#" onclick="UserStatus(' + item.ID + ',3)">Rejected</a></td>';


//                    html += '<td><a href="#" onclick="return GetByID(' + item.ID + ')">Edit</a> | <a href="#" onclick="Delete(' + item.ID + ')">Delete</a></td>';
//                }
//                else {
//                    html += '<td colspan="2">' + item.StatusDetails + '</td>';

//                }
//                html += '<td>' + item.ID + '</td>';
//                html += '<td>' + item.PositionName + '</td>';
//                html += '<td>' + item.UserID + '</td>';
//                html += '<td>' + item.CreatedBy + '</td>';
//                html += '<td>' + nowdate.toDateString() + '</td>';
//                html += '<td>' + filledbefore_formated.toDateString() + '</td>';
//                html += '<td>' + item.VacancyFor + '</td>';
//                html += '<td>' + item.VacancyType + '</td>';
//                html += '<td>' + item.Territory + '</td>';
//                html += '<td>' + item.Division + '</td>';
//                html += '<td>' + item.MinYear + '</td>';
//                html += '<td>' + item.MaxYear + '</td>';
//                html += '<td>' + item.MinCTC + '</td>';
//                html += '<td>' + item.MaxCTC + '</td>';
//                html += '<td>' + item.AdditionalRequirements + '</td>';

//                html += '</tr>';
//            });
//            $('.tbody').html(html);
//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

$(document).on('click', '#back', function () {
    parent.history.back();
});

function SubmitData() {
    
    var objbd = {
        PositionName: $('#PositionName').val(),
        CreatedByID: $('#CreatedByID').val(),
        CreatedDate: $('#CreatedByDate').val(),
        FilledBefore: $('#FilledBefore').val(),
        VacancyForID: $('input[name="field"]:checked').val(),
        VacancyTypeID: $('input[name="field1"]:checked').val(),
        Territory: $('#Territory').val(),
        Division: $('#Division').val(),
        MinYear: $('#MinYear').val(),
        MaxYear: $('#MaxYear').val(),
        MinCTC: $('#MinCTC').val(),
        MaxCTC: $('#MaxCTC').val(),
        AdditionalRequirements: $('#AdditionalRequirements').val(),

    };

    $.ajax({
        url: "/MRF/Add",
        data: JSON.stringify(objbd),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //alert("successfully stored");
            //window.location = "../UserMrf/ViewMyMrf";
            viewmymrf();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

var UserID = $('#CreatedByID').val();


function viewmymrf() {
    window.location = "../UserMrf/ViewMyMrf";    
}



//function UserStatus(ID, ireqstatus) {
//    var ans = true;
//    if (ireqstatus == 3) {
//        ans = confirm("Are you sure you want to delete this Record?");
//    }
//    if (ans) {
//        $.ajax({
//            url: "/UserLogin/UserStatus/",
//            data: { ID: ID, ireqstatus: ireqstatus },
//            type: "GET",
//            contentType: "application/json;charset=UTF-8",
//            dataType: "json",
//            success: function (result) {
//                loadData();

//            },
//            error: function (errormessage) {
//                alert(errormessage.responseText);
//            }
//        });
//    }
//}

