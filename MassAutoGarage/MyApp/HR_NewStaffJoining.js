
function onlyAlphabets(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 32))
            return true;
        else
            return false;
    }
    catch (err) {
        alert(err.Description);
    }
}
                           
var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#Date").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#JoiningDate").datepicker(options);

$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var _VoucherNumber = $("#VoucherNumber").val();
    var _EmployeeName = $("#EmployeeName").val();
    var _Date = $("#Date").val();
    var _DesignationId = $("#DesignationId").val();
    var _EmpNo = $("#EmpNo").val();
    var _DepartmentId = $("#DepartmentId").val();
    var _JoiningDate = $("#JoiningDate").val();
    var _JoiningTime = $("#JoiningTime").val();
    var _FilledByEmployee = $("#FilledByEmployee").val();
    var _Idincrept = $("#Idincrept").val();

    if (_EmployeeName != "" && _Date != "" && _DepartmentId != "" && _EmpNo != "" && _DesignationId != "" && _JoiningDate != "" && _JoiningTime != "" && _FilledByEmployee != "") {

        var GeneralRequestDetails = {
            VoucherNumber: _VoucherNumber,
            EmployeeName: _EmployeeName,
            Date: _Date,
            DesignationId: _DesignationId,
            EmpNo: _EmpNo,
            DepartmentId: _DepartmentId,
            JoiningDate: _JoiningDate,
            JoiningTime: _JoiningTime,
            FilledByEmployee: _FilledByEmployee,
            Idincrept: _Idincrept
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HR_NewStaffJoining/SaveNewStaffJoining',
                data: JSON.stringify(GeneralRequestDetails),
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
                                window.location.href = '/HR_NewStaffJoining/NewStaffJoining';
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
        if (_EmployeeName == "") {
            swal("Warning", "Please Enter Employee Name !", "warning");
            return false;
        }
        if (_Date == "") {
            swal("Warning", "Please Enter Date!", "warning");
            return false;
        }
        if (_DepartmentId   == "") {
            swal("Warning", "Please Enter Department  !", "warning");
            return false;
        }
        if (_DesignationId == "") {
            swal("Warning", "Please Enter  Designation !", "warning");
            return false;
        }
        if (_EmpNo == "") {
            swal("Warning", "Please Enter EmpNo !", "warning");
            return false;
        }
        if (_JoiningDate == "") {
            swal("Warning", "Please Enter Joining Date !", "warning");
            return false;
        }
        if (_JoiningTime == "") {
            swal("Warning", "Please Enter Joining Time !", "warning");
            return false;
        }
        if (_FilledByEmployee == "") {
            swal("Warning", "Please Enter Filled By Employee !", "warning");
            return false;
        }
    }
});


function DeleteNewStaffJoining(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_NewStaffJoining/DeleteNewStaffJoining',
            data: { Id: Id },
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