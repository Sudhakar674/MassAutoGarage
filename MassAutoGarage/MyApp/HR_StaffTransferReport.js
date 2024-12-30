
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
$("#DateofJoining").datepicker(options);

$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var _VoucherNo = $("#VoucherNo").val();
    var _EmployeeId = $("#EmployeeId").val();
    var _Date = $("#Date").val();
    var _DesignationId = $("#DesignationId").val();
    var _EmpNo = $("#EmpNo").val();
    var _DateofJoining = $("#DateofJoining").val();
    var _BranchDeptFrom = $("#BranchDeptFrom").val();
    var _BranchDeptTo = $("#BranchDeptTo").val();
    var _TimeofJoining = $("#TimeofJoining").val();
    var _Idincrept = $("#Idincrept").val();


    if (_EmployeeId != "" && _Date != "" && _DesignationId != "" && _EmpNo != "" && _DateofJoining != "" && _BranchDeptFrom != "" && _BranchDeptTo != "" && _TimeofJoining != "") {

        var ResumingDutyDetails = {
            VoucherNo: _VoucherNo,
            EmployeeId: _EmployeeId,
            Date: _Date,
            DesignationId: _DesignationId,
            EmpNo: _EmpNo,
            DateofJoining: _DateofJoining,
            BranchDeptFrom: _BranchDeptFrom,
            BranchDeptTo: _BranchDeptTo,
            TimeofJoining: _TimeofJoining,
            Idincrept: _Idincrept
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HR_StaffTransferReport/SaveStaffTransferReport',
                data: JSON.stringify(ResumingDutyDetails),
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
                                window.location.href = '/HR_StaffTransferReport/StaffTransferReport';
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
        if (_EmployeeId == "") {
            swal("Warning", "Please Enter Employee Name !", "warning");
            return false;
        }
        if (_Date == "") {
            swal("Warning", "Please Enter Date!", "warning");
            return false;
        }
        if (_DesignationId == "") {
            swal("Warning", "Please Enter Designation !", "warning");
            return false;
        }
        if (_EmpNo == "") {
            swal("Warning", "Please Enter EmpNo !", "warning");
            return false;
        }
        if (_DateofJoining == "") {
            swal("Warning", "Please Enter Date Of Joining !", "warning");
            return false;
        }
        if (_TimeofJoining == "") {
            swal("Warning", "Please Enter Time Of Joining !", "warning");
            return false;
        }  
        if (_BranchDeptFrom == "") {
            swal("Warning", "Please Enter Branch/Dept From !", "warning");
            return false;
        }
        if (_BranchDeptTo == "") {
            swal("Warning", "Please Enter _Branch/Dept To !", "warning");
            return false;
        }
        
    }
});



function DeleteStaffTransferReport(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_StaffTransferReport/DeleteStaffTransferReport',
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