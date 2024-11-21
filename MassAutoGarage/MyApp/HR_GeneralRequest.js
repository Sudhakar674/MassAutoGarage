
var options = $.extend({},
    $.datepicker.regional["es"], {
     dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#Date").datepicker(options);

$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var _VoucherNumber = $("#VoucherNumber").val();
    var _EmployeeId = $("#EmployeeId").val();
    var _Date = $("#Date").val();
    var _DesignationId = $("#DesignationId").val();
    var _BranchId = $("#BranchId").val();
    var _DepartmentId = $("#DepartmentId").val();
    var _EmpId = $("#EmpId").val();
    var _SalaryCertificate = $("input[name=SalaryCertificate]:checked").val();
    var _SalaryTransferLetter = $("#SalaryTransferLetter").val();
    var _NOC = $("#NOC").val();
    var _ExperienceCertificate = $("#ExperienceCertificate").val();
    var _BankEstablishment = $("#BankEstablishment").val();
    var _AcctNoIBANNo = $("#AcctNoIBANNo").val();
    var _OpneNewBankAcct = $("#OpneNewBankAcct").val();
    var _TransferLoanToOtherBank = $("#TransferLoanToOtherBank").val();
    var _PersonalLoan = $("#PersonalLoan").val();
    var _NOCToEmbassy = $("#NOCToEmbassy").val();
    var _ConfirmationLettrToBank = $("#ConfirmationLettrToBank").val();
    var _LoanTopUp = $("#LoanTopUp").val();
    var _Others = $("#Others").val();
    var _CashAdvance = $("#CashAdvance").val();
    var _InitialNewEmp = $("#InitialNewEmp").val();
    var _Against = $("#Against").val();
    var _BehalfAgainst = $("#BehalfAgainst").val();
    var _Reason = $("#Reason").val();
    var _MonthlyDeduction = $("#MonthlyDeduction").val();
    var _SalarySlips3Months = $("#SalarySlips3Months").val();
    var _SalarySlips6Months = $("#SalarySlips6Months").val();
    var _TrafficFineDeductionAmt = $("#TrafficFineDeductionAmt").val();
    var _SalaryCard = $("#SalaryCard").val();
    var _EmpSignature = $("#EmpSignature").val();
    var _MobileNumber = $("#MobileNumber").val();

    if (_EmployeeId != "") {

        var GeneralRequestDetails = {
            VoucherNumber: _VoucherNumber,
            EmployeeId: _EmployeeId,
            Date: _Date,
            DesignationId: _DesignationId,
            BranchId: _BranchId,
            DepartmentId: _DepartmentId,
            EmpId: _EmpId,
            SalaryCertificate: _SalaryCertificate,
            SalaryTransferLetter: _SalaryTransferLetter,
            NOC: _NOC,
            ExperienceCertificate: _ExperienceCertificate,
            BankEstablishment: _BankEstablishment,
            AcctNoIBANNo: _AcctNoIBANNo,
            OpneNewBankAcct: _OpneNewBankAcct,
            TransferLoanToOtherBank: _TransferLoanToOtherBank,
            PersonalLoan: _PersonalLoan,
            NOCToEmbassy: _NOCToEmbassy,
            ConfirmationLettrToBank: _ConfirmationLettrToBank,
            LoanTopUp: _LoanTopUp,
            Others: _Others,
            CashAdvance: _CashAdvance,
            InitialNewEmp: _InitialNewEmp,
            Against: _Against,
            BehalfAgainst: _BehalfAgainst,
            Reason: _Reason,
            MonthlyDeduction: _MonthlyDeduction,
            SalarySlips3Months: _SalarySlips3Months,
            SalarySlips6Months: _SalarySlips6Months,
            TrafficFineDeductionAmt: _TrafficFineDeductionAmt,
            SalaryCard: _SalaryCard,
            EmpSignature: _EmpSignature,
            MobileNumber: _MobileNumber
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HR_GeneralRequest/SaveGeneralRequest',
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
                                window.location.href = '/HRMS_Leave/Leave';
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

        if (BranchId_ == "") {
            swal("Warning", "Please Enter Branch Name !", "warning");
            return false;
        }
        //if (EmployeeId_ == "") {
        //    swal("Warning", "Please Enter Employee Name !", "warning");
        //    return false;
        //}
        //if (LeaveTypeId_ == "") {
        //    swal("Warning", "Please Enter Leave Type !", "warning");
        //    return false;
        //}
        //if (FromDate_ == "") {
        //    swal("Warning", "Please Enter From Date !", "warning");
        //    return false;
        //}
        //if (ToDate_ == "") {
        //    swal("Warning", "Please Enter To Date !", "warning");
        //    return false;
        //}
        //if (BalanceLeave_ == "") {
        //    swal("Warning", "Please Enter Balance Leave !", "warning");
        //    return false;
        //}
    }
});





function DeleteLeave(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_Leave/DeleteLeave',
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