﻿


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
$("#LastWorkingDay").datepicker(options);


$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var _VoucherNo = $("#VoucherNo").val();
    var _EmployeeId = $("#EmployeeId").val();
    var _Date = $("#Date").val();
    var _DesignationId = $("#DesignationId").val();
    var _DepartmentId = $("#DepartmentId").val();
    var _EmpNo = $("#EmpNo").val();
    var _LastWorkingDay = $("#LastWorkingDay").val();
    var _Replacement = $("#Replacement").val();

    var Vehichle = $("input[name=Vehichle]:checked").val();
    if (Vehichle == "true") {
        var _Vehichle = 1;
    }
    else {
        var _Vehichle = 0;
    }

    var Laptop = $("input[name=Laptop]:checked").val();
    if (Laptop == "true") {
        var _Laptop = 1;
    }
    else {
        var _Laptop = 0;
    }

    var CompanySim = $("input[name=CompanySim]:checked").val();
    if (CompanySim == "true") {
        var _CompanySim = 1;
    }
    else {
        var _CompanySim = 0;
    }

    var MedicalInsurance = $("input[name=MedicalInsurance]:checked").val();
    if (MedicalInsurance == "true") {
        var _MedicalInsurance = 1;
    }
    else {
        var _MedicalInsurance = 0;
    }

    var C3Card = $("input[name=C3Card]:checked").val();
    if (C3Card == "true") {
        var _C3Card = 1;
    }
    else {
        var _C3Card = 0;
    }
    var _Idincrept = $("#Idincrept").val();

    if (_EmployeeId != "" && _Date != "" && _DesignationId != "" && _EmpNo != ""  && _DepartmentId != ""  && _LastWorkingDay != "" && _Replacement != "" ) {

        var GeneralRequestDetails = {
            VoucherNo: _VoucherNo,
            EmployeeId: _EmployeeId,
            Date: _Date,
            DesignationId: _DesignationId,
            EmpNo: _EmpNo,
            DepartmentId: _DepartmentId,
            LastWorkingDay: _LastWorkingDay,
            Replacement: _Replacement,
            Vehichle: _Vehichle,
            Laptop: _Laptop,
            CompanySim: _CompanySim,
            MedicalInsurance: _MedicalInsurance,
            C3Card: _C3Card,
            Idincrept: _Idincrept
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HR_FinalClearanceReport/SaveFinalClearanceReport',
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
                                window.location.href = '/HR_FinalClearanceReport/FinalClearanceReport';
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
        if (_BranchId == "") {
            swal("Warning", "Please Enter Branch !", "warning");
            return false;
        }
        if (_DepartmentId == "") {
            swal("Warning", "Please Enter Department !", "warning");
            return false;
        }
        if (_EmpNo == "") {
            swal("Warning", "Please Enter EmpNo !", "warning");
            return false;
        }
        if (_DepartmentId == "") {
            swal("Warning", "Please Enter Department !", "warning");
            return false;
        }
        if (_LastWorkingDay == "") {
            swal("Warning", "Please Enter Last Working Day  !", "warning");
            return false;
        }
        if (_Replacement == "") {
            swal("Warning", "Please Enter Replacement/Handing Over Assigned To !", "warning");
            return false;
        }
       
    }
});


function DeleteFinalClearanceReport(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_FinalClearanceReport/DeleteFinalClearanceReport',
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