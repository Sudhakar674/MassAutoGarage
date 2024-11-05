
function Reset() {
    window.location.href = "/HRMS_Loan/Loan";
}
function isNumberOrDecimal(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
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
$("#LoanDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#FromDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#ToDate").datepicker(options);


$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var BranchId_ = $("#BranchId").val();
    var EmployeeId_ = $("#EmployeeId").val();
    var LoanDate_ = $("#LoanDate").val();
    var LoanAmount_ = $("#LoanAmount").val();
    var FromDate_ = $("#FromDate").val();
    var ToDate_ = $("#ToDate").val();
    var DeductionPerMonth_ = $("#DeductionPerMonth").val();
    var TotalAmount_ = $("#TotalAmount").val();
    var Remarks_ = $("#Remarks").val();
    var ID_ = $("#ID").val();
    

    if (BranchId_ != "" && EmployeeId_ != "" && LoanDate_ != "" && LoanAmount_ != "" && FromDate_ != "" && ToDate_ != "" && DeductionPerMonth_ != "" && TotalAmount_ != "") {

        var LoanDetails = {
            BranchId: BranchId_,
            EmployeeId: EmployeeId_,
            LoanDate: LoanDate_,
            LoanAmount: LoanAmount_,
            FromDate: FromDate_,
            ToDate: ToDate_,
            DeductionPerMonth: DeductionPerMonth_,
            TotalAmount: TotalAmount_,
            Remarks: Remarks_,
            ID: ID_
               
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HRMS_Loan/SaveLoan',
                data: JSON.stringify(LoanDetails),
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
                                window.location.href = '/HRMS_Loan/Loan';
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
        if (EmployeeId_ == "") {
            swal("Warning", "Please Enter Employee Name !", "warning");
            return false;
        }
        if (LoanDate_ == "") {
            swal("Warning", "Please Enter Loan Date !", "warning");
            return false;
        }
        if (LoanAmount_ == "") {
            swal("Warning", "Please Enter Loan Amount !", "warning");
            return false;
        }
        if (FromDate_ == "") {
            swal("Warning", "Please Enter From Date !", "warning");
            return false;
        }
        if (ToDate_ == "") {
            swal("Warning", "Please Enter To Date !", "warning");
            return false;
        }
        if (DeductionPerMonth_ == "") {
            swal("Warning", "Please Enter Deduction Per Month !", "warning");
            return false;
        }
        if (TotalAmount_ == "") {
            swal("Warning", "Please Enter Total Amount !", "warning");
            return false;
        }
    }
});


function DeleteLoan(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_Loan/DeleteLoan',
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
