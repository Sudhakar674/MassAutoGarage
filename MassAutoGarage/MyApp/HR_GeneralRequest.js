

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

    var SalaryCertificate = $("input[name=SalaryCertificate]:checked").val();
    if (SalaryCertificate == "on") {
        var _SalaryCertificate = "1";
    }
    else {
        var _SalaryCertificate = "0";
    }

    var SalaryTransferLetter = $("input[name=SalaryTransferLetter]:checked").val();
    if (SalaryTransferLetter == "on") {
        var _SalaryTransferLetter = "1";
    }
    else {
        var _SalaryTransferLetter = "0";
    }

    var NOC = $("input[name=NOC]:checked").val();
    if (NOC == "on") {
        var _NOC = "1";
    }
    else {
        var _NOC = "0";
    }

    var ExperienceCertificate = $("input[name=ExperienceCertificate]:checked").val();
    if (ExperienceCertificate == "on") {
        var _ExperienceCertificate = "1";
    }
    else {
        var _ExperienceCertificate = "0";
    }

    var _BankEstablishment = $("#BankEstablishment").val();
    var _AcctNoIBANNo = $("#AcctNoIBANNo").val();

    var OpneNewBankAcct = $("input[name=OpneNewBankAcct]:checked").val();
    if (OpneNewBankAcct == "on") {
        var _OpneNewBankAcct = "1";
    }
    else {
        var _OpneNewBankAcct = "0";
    }

    var TransferLoanToOtherBank = $("input[name=TransferLoanToOtherBank]:checked").val();
    if (TransferLoanToOtherBank == "on") {
        var _TransferLoanToOtherBank = "1";
    }
    else {
        var _TransferLoanToOtherBank = "0";
    }

    var PersonalLoan = $("input[name=PersonalLoan]:checked").val();
    if (PersonalLoan == "on") {
        var _PersonalLoan = "1";
    }
    else {
        var _PersonalLoan = "0";
    }

    var NOCToEmbassy = $("input[name=NOCToEmbassy]:checked").val();
    if (NOCToEmbassy == "on") {
        var _NOCToEmbassy = "1";
    }
    else {
        var _NOCToEmbassy = "0";
    }

    var ConfirmationLettrToBank = $("input[name=ConfirmationLettrToBank]:checked").val();
    if (ConfirmationLettrToBank == "on") {
        var _ConfirmationLettrToBank = "1";
    }
    else {
        var _ConfirmationLettrToBank = "0";
    }

    var LoanTopUp = $("input[name=LoanTopUp]:checked").val();
    if (LoanTopUp == "on") {
        var _LoanTopUp = "1";
    }
    else {
        var _LoanTopUp = "0";
    }

    var Others = $("input[name=Others]:checked").val();
    if (Others == "on") {
        var _Others = "1";
    }
    else {
        var _Others = "0";
    }

    var _CashAdvance = $("#CashAdvance").val();

    var InitialNewEmp = $("input[name=InitialNewEmp]:checked").val();
    if (InitialNewEmp == "on") {
        var _InitialNewEmp = "1";
    }
    else {
        var _InitialNewEmp = "0";
    }

    var Against = $("input[name=Against]:checked").val();
    if (Against == "on") {
        var _Against = "1";
    }
    else {
        var _Against = "0";
    }

    var _BehalfAgainst = $("#BehalfAgainst").val();
    var _Reason = $("#Reason").val();
    var _MonthlyDeduction = $("#MonthlyDeduction").val();

    var SalarySlips3Months = $("input[name=SalarySlips3Months]:checked").val();
    if (SalarySlips3Months == "on") {
        var _SalarySlips3Months = "1";
    }
    else {
        var _SalarySlips3Months = "0";
    }

    var SalarySlips6Months = $("input[name=SalarySlips6Months]:checked").val();
    if (SalarySlips6Months == "on") {
        var _SalarySlips6Months = "1";
    }
    else {
        var _SalarySlips6Months = "0";
    }

    var _TrafficFineDeductionAmt = $("#TrafficFineDeductionAmt").val();

    var SalaryCard = $("input[name=SalaryCard]:checked").val();
    if (SalaryCard == "on") {
        var _SalaryCard = "1";
    }
    else {
        var _SalaryCard = "0";
    }

    var _EmpSignature = $("#EmpSignature").val();
    var _MobileNumber = $("#MobileNumber").val();

    var _Idincrept = $("#Idincrept").val();


    if (_EmployeeId != "" && _Date != "" && _DesignationId != "" && _BranchId != "" && _DepartmentId != "" && _EmpId != "" && _BankEstablishment != "" && _AcctNoIBANNo != "" && _CashAdvance != "" && _Reason != "" && _MonthlyDeduction != "" && _TrafficFineDeductionAmt != ""  && _MobileNumber != "") {

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
          /*  EmpSignature: _EmpSignature,*/
            MobileNumber: _MobileNumber,
            Idincrept: _Idincrept
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
                                window.location.href = '/HR_GeneralRequest/GeneralRequest';
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
        if (_EmpId == "") {
            swal("Warning", "Please Enter EmpId !", "warning");
            return false;
        }
        if (_BankEstablishment == "") {
            swal("Warning", "Please Enter Bank/Establishment !", "warning");
            return false;
        }
        if (_AcctNoIBANNo == "") {
            swal("Warning", "Please Enter Acct No/IBAN No !", "warning");
            return false;
        }
        if (_CashAdvance == "") {
            swal("Warning", "Please Enter Cash Advance !", "warning");
            return false;
        }
        if (_Reason == "") {
            swal("Warning", "Please Enter Reason !", "warning");
            return false;
        }
        if (_MonthlyDeduction == "") {
            swal("Warning", "Please Enter Monthly Deduction !", "warning");
            return false;
        }
        if (_TrafficFineDeductionAmt == "") {
            swal("Warning", "Please Enter Traffic Fine Deduction Amt !", "warning");
            return false;
        }
        //if (_EmpSignature == "") {
        //    swal("Warning", "Please Enter Employee Signature !", "warning");
        //    return false;
        //}
        if (_MobileNumber == "") {
            swal("Warning", "Please Enter Mobile Number !", "warning");
            return false;
        }
    }
});


function DeleteGeneralRequest(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_GeneralRequest/DeleteGeneralRequest',
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