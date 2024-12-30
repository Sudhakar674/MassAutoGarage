

function isNumberOrDecimal(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function isNumberKey(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
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
$("#DateofJoining").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#DateofResumingDuty").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#PeriodofFromLeave").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#PeriodofToLeave").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#SignDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#ExpectedReturnDate").datepicker(options);



$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var _VoucherNo = $("#VoucherNo").val();
    var _EmployeeId = $("#EmployeeId").val();
    var _Date = $("#Date").val();
    var _DesignationId = $("#DesignationId").val();
    var _EmpNo = $("#EmpNo").val();
    var _CompanyId = $("#CompanyId").val();
    var _DepartmentId = $("#DepartmentId").val();
    var _BranchId = $("#BranchId").val();
    var _DateofJoining = $("#DateofJoining").val();
    var _DateofResumingDuty = $("#DateofResumingDuty").val();
    var _Time = $("#Time").val();
    var _PeriodofFromLeave = $("#PeriodofFromLeave").val();
    var _PeriodofToLeave = $("#PeriodofToLeave").val();
    var _OtherReasons = $("#OtherReasons").val();
    var _Idincrept = $("#Idincrept").val();

    if (_EmployeeId != "" && _Date != "" && _DesignationId != "" && _EmpNo != "" && _CompanyId != "" && _DepartmentId != "" && _BranchId != "" && _DateofJoining != "" && _DateofResumingDuty != "" && _Time != "" && _PeriodofFromLeave != "" && _PeriodofToLeave != "" && _OtherReasons != "") {

        var ResumingDutyDetails = {
            VoucherNo: _VoucherNo,
            EmployeeId: _EmployeeId,
            Date: _Date,
            DesignationId: _DesignationId,
            EmpNo: _EmpNo,
            CompanyId: _CompanyId,
            DepartmentId: _DepartmentId,
            BranchId: _BranchId,
            DateofJoining: _DateofJoining,
            DateofResumingDuty: _DateofResumingDuty,
            Time: _Time,
            PeriodofFromLeave: _PeriodofFromLeave,
            PeriodofToLeave: _PeriodofToLeave,
            OtherReasons: _OtherReasons,
            Idincrept: _Idincrept
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HR_ResumingDuty/SaveResumingDuty',
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
                                window.location.href = '/HR_ResumingDuty/ResumingDuty';
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
        
        if (_CompanyId == "") {
            swal("Warning", "Please Enter Company !", "warning");
            return false;
        }
        if (_DepartmentId == "") {
            swal("Warning", "Please Enter Department !", "warning");
            return false;
        }
        if (_BranchId == "") {
            swal("Warning", "Please Enter Branch !", "warning");
            return false;
        }
        if (_DateofJoining == "") {
            swal("Warning", "Please Enter Date Of Joining !", "warning");
            return false;
        }
        if (_DateofResumingDuty == "") {
            swal("Warning", "Please Enter Date Of Resuming Duty !", "warning");
            return false;
        }
        if (_Time == "") {
            swal("Warning", "Please Enter Time !", "warning");
            return false;
        }
        if (_PeriodofFromLeave == "") {
            swal("Warning", "Please Enter Period Of From Leave !", "warning");
            return false;
        }

        if (_PeriodofToLeave == "") {
            swal("Warning", "Please Enter Period Of To Leave !", "warning");
            return false;
        }
        if (_OtherReasons == "") {
            swal("Warning", "Please Enter Other Reasons !", "warning");
            return false;
        }
     
    }
});


function DeleteResumingDutyDetails(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_ResumingDuty/DeleteResumingDuty',
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