
function Reset() {
    window.location.href = "/HRMS_Holiday/Holiday";
}


$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var FK_DepartmentId_ = $("#FK_DepartmentId").val();
    var HolidayDate_ = $("#HolidayDate").val();
    var HolidayName_ = $("#HolidayName").val();
    var HolidayId_ = $("#HolidayId").val();
 


    if (FK_DepartmentId_ != "" && HolidayDate_ != "" && HolidayName_ != "") {

        var HolidayDetails = {
            FK_DepartmentId: FK_DepartmentId_,
            HolidayDate: HolidayDate_,
            HolidayName: HolidayName_,
            HolidayId: HolidayId_
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HRMS_Holiday/SaveHoliday',
                data: JSON.stringify(HolidayDetails),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    debugger;
                    if (data.Result == "yes") {
                        swal({
                            title: "Success",
                            text: "Records Successfully Saved",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                window.location.reload();
                            }
                            else {

                            }
                        });
                    }
                    else if (data.Result == "yes1") {
                        swal({
                            title: "Success",
                            text: "Records Successfully Updated",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                window.location.reload();
                            }
                            else {

                            }
                        });
                    }

                    else {
                        swal("Warning", "Record not save!", "warning");
                    }
                },
                error: function (httpResponse) {
                    swal("Warning", "Something Went to Wrong!", "warning");
                }
            })
        }
    }
    else {

        if (FK_DepartmentId_ == "") {
            swal("Warning", "Please Enter Department !", "warning");
            return false;
        }
        if (HolidayDate_ == "") {
            swal("Warning", "Please Enter Holiday Date !", "warning");
            return false;
        }
        if (HolidayName_ == "") {
            swal("Warning", "Please Enter Holiday Name !", "warning");
            return false;
        }
    }
});



function HolidayList() {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HRMS_Holiday/HolidayList",
        data: "{}",
        dataType: "json",
        success: function (result) {
            $.each(result, function (i, v) {
                debugger;
                var tableLength = $("#tBodyId tr").length;

                var SerialNo = tableLength + 1;
                var tr = "<tr>";
                tr += "<td>" + SerialNo + "</td>";
                tr += "<td style='Display:none' class='HolidayId_" + v.HolidayId + "'>" + v.HolidayId + "</td>";
               /* tr += "<td style='Display:none' class='FK_DepartmentId_" + v.HolidayId + "'>" + v.FK_DepartmentId + "</td>";*/
                tr += "<td class='DepartmentName_" + v.HolidayId + "'>" + v.DepartmentName + "</td>";
                tr += "<td class='HolidayDate_" + v.HolidayId + "'>" + v.HolidayDate + "</td>";
                tr += "<td class='HolidayName_" + v.HolidayId + "'>" + v.HolidayName + "</td>";
                tr += "<td><a onclick='return EditHoliday(" + v.HolidayId + ")' class='btn btn-sm btn-success edit-item-btn'>Edit<i class='fa fa-edit'></i></a> <a onclick='return DeleteHoliday(" + v.HolidayId + ")' class='btn btn-sm btn-danger remove-item-btn DeleteContactTr'><i class='fa fa-trash' aria-hidden='true'></i>Delete</a></td>";


                //tr += "<td class='FK_DepartmentId_" + v.HolidayId + "'>" + Option(v.DepartmentName, v.FK_DepartmentId) + "</td>";
               

                tr += "</tr>";
                $("#tBodyId").append(tr);
            });
        }
    });
}





//success: function (data) {

//    for (var i = 0; i < data.length; i++) {
//        var opt = new Option(data[i].stu_name, data[i].stu_id);
//        $('#op1').append(opt);

//    }

//}









function EditHoliday(Id) {
    debugger;
    var HolidayId_ = $(".HolidayId_" + Id).text();
    var FK_DepartmentId_ = $(".FK_DepartmentId_" + Id).text();
    var DepartmentName_ = $(".DepartmentName_" + Id).text();
    var HolidayDate_ = $(".HolidayDate_" + Id).text();
    var HolidayName_ = $(".HolidayName_" + Id).text();

    $("#HolidayId").val(HolidayId_);
    $("#FK_DepartmentId").val(FK_DepartmentId_);
    $("#FK_DepartmentId").val(DepartmentName_);
    $("#HolidayDate").val(HolidayDate_);
    $("#HolidayName").val(HolidayName_);
    $("#btnsave").val('Update');
}


function DeleteHoliday(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_Holiday/DeleteHoliday',
            data: { HolidayId: Id },
            dataType: 'json',
            success: function (data) {
                if (data.Result == "yes") {
                    swal({
                        title: "Success",
                        text: "Records Successfully Deleted",
                        type: "success",
                    }).then(function (isConfirm) {
                        if (isConfirm) {
                            window.location.reload();
                        } else {
                        }
                    });
                }
                else {
                    swal("Warning", "Records not Deleted", "warning");
                }
            },
            error: function (xhr, status) {
                console.log(status);
                console.log(xhr);
            },
            complete: function () {
            }
        });
    }
    else {
        return false;
    }

}


$('#HolidayName').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});