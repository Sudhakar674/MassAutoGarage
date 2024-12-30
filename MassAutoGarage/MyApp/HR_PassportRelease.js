


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
    var _BranchId = $("#BranchId").val();
    var _DepartmentId = $("#DepartmentId").val();
    var _ReasonForReleasePassReq = $("#ReasonForReleasePassReq").val();
    var _ExpectedReturnDate = $("#ExpectedReturnDate").val();
    var _EmployeeUndertaking = $("#EmployeeUndertaking").val();
    var _SignDate = $("#SignDate").val();
    var _Idincrept = $("#Idincrept").val();

    if (_EmployeeId != "" && _Date != "" && _DesignationId != "" && _EmpNo != "" && _BranchId != "" && _DepartmentId != "" && _ReasonForReleasePassReq != "" && _ExpectedReturnDate != "" && _EmployeeUndertaking != "" && _SignDate != "") {

        var GeneralRequestDetails = {
            VoucherNo: _VoucherNo,
            EmployeeId: _EmployeeId,
            Date: _Date,
            DesignationId: _DesignationId,
            EmpNo:_EmpNo,
            BranchId: _BranchId,
            DepartmentId: _DepartmentId,
            ReasonForReleasePassReq: _ReasonForReleasePassReq,
            ExpectedReturnDate: _ExpectedReturnDate,
            EmployeeUndertaking: _EmployeeUndertaking,
            SignDate: _SignDate,
            Idincrept: _Idincrept
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HR_PassportRelease/SavePassportRelease',
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
                                window.location.href = '/HR_PassportRelease/PassportRelease';
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
        if (_BranchId == "") {
            swal("Warning", "Please Enter Branch !", "warning");
            return false;
        }
        if (_DepartmentId == "") {
            swal("Warning", "Please Enter Department !", "warning");
            return false;
        }
        if (_ReasonForReleasePassReq == "") {
            swal("Warning", "Please Enter Reason For Passport Release Request !", "warning");
            return false;
        }
        if (_ExpectedReturnDate == "") {
            swal("Warning", "Please Enter Expected Date Of Return !", "warning");
            return false;
        }
        if (_EmployeeUndertaking == "") {
            swal("Warning", "Please Enter Fill This Area !", "warning");
            return false;
        }
        if (_SignDate == "") {
            swal("Warning", "Please Enter Date !", "warning");
            return false;
        }
    }
});


function DeletePassportRelease(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_PassportRelease/DeletePassportRelease',
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