
function Reset() {
    window.location.href = "/HRMS_LeaveType/LeaveType";
}


$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var LeaveType_ = $("#LeaveType").val();
    var LeaveID_ = $("#LeaveID").val();


    if (LeaveType_ != "") {

        var LeaveTypeDetails = {
            LeaveType: LeaveType_,
            LeaveID: LeaveID_
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HRMS_LeaveType/SaveLeaveType',
                data: JSON.stringify(LeaveTypeDetails),
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

        if (LeaveType_ == "") {
            swal("Warning", "Please Enter Leave Type !", "warning");
            return false;
        }
    }
});


function LeaveTypeList() {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HRMS_LeaveType/LeaveTypeList",
        data: "{}",
        dataType: "json",
        success: function (result) {
            $.each(result, function (i, v) {
                debugger;
                var tableLength = $("#tBodyId tr").length;

                var SerialNo = tableLength + 1;
                var tr = "<tr>";
                tr += "<td>" + SerialNo + "</td>";
                tr += "<td style='Display:none' class='LeaveID_" + v.LeaveID + "'>" + v.LeaveID + "</td>";
                tr += "<td class='LeaveType_" + v.LeaveID + "'>" + v.LeaveType + "</td>";
                tr += "<td><a onclick='return EditLeaveType(" + v.LeaveID + ")' class='btn btn-sm btn-success edit-item-btn'>Edit<i class='fa fa-edit'></i></a> <a onclick='return DeleteLeaveType(" + v.LeaveID + ")' class='btn btn-sm btn-danger remove-item-btn DeleteContactTr'><i class='fa fa-trash' aria-hidden='true'></i>Delete</a></td>";
                tr += "</tr>";
                $("#tBodyId").append(tr);
            });
        }
    });
}

function EditLeaveType(Id) {
    debugger;
    var LeaveID_ = $(".LeaveID_" + Id).text();
    var LeaveType_ = $(".LeaveType_" + Id).text();

    $("#LeaveID").val(LeaveID_);
    $("#LeaveType").val(LeaveType_);
    $("#btnsave").val('Update');
}


function DeleteLeaveType(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_LeaveType/DeleteLeaveType',
            data: { LeaveID: Id },
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


$('#LeaveType').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});