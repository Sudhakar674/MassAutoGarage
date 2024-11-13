


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
    /*dateFormat: "yy/mm/dd",*/
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#FromDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    /*dateFormat: "yy/mm/dd",*/
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#ToDate").datepicker(options);


function cal() {
    debugger;

    var StartDate = $("#FromDate").val();
    var EndDate = $("#ToDate").val();
    var _Amount = $("#Amount").val();
    var TAmount = parseFloat(0);
    if (StartDate != "" && EndDate != "" && _Amount != "") {

        $.ajax({
            type: "Get",
            url: "/HRMS_EmployeeDeduction/GetDeductionList",
            data: { StDate: StartDate, EdDate: EndDate, Amount: _Amount }
            ,
            dataType: "json",
            success: function (result) {
                $.each(result, function (i, v) {
                    var tableLength = $("#tBodyId tr").length;
                    debugger;
                    TAmount = parseFloat($("#TotalAmount").val());
                    var getAmt = parseFloat(v.Amount);
                    TAmount = parseFloat(TAmount + getAmt);
                    $("#TotalAmount").val(TAmount);
                    var tr = "<tr>";
                    tr += "<td>" + "<input type='text' class='clsCalculatedDate form-control' value=" + v.CalculatedDate + " Format='MMMM,yyyy' /><td><input type='text' class='clsAmount form-control' value=" + v.Amount + " /> </td><td><a class='btn btn-sm btn-danger remove-item-btn DeleteTr'>Remove</a></td>";
                    tr += "</tr>";
                    $("#tBodyId").append(tr);
                });
            }
        });

    }

};


$(document).on("click", ".DeleteTr", function () {
    if (confirm("Are you sure you want to remove ?")) {
        $(this).parents("tr").remove();
        calculat();
    }
})



$("#btnsave").click(function () {
    debugger;
    var _BranchId = $("#BranchId").val();
    var _EmployeeId = $("#EmployeeId").val();
    var _Amount = $("#Amount").val();
    var _FromDate = $("#FromDate").val();
    var _ToDate = $("#ToDate").val();
    var _DeductionTypeId = $("#DeductionTypeId").val();
    var _Remarks = $("#Remarks").val();
    var _TotalAmount = $("#TotalAmount").val();

    var tableLength = $("#example tr").length;
    var ProductListArr = [];

    if (_BranchId != "" && _EmployeeId != "" && _Amount != "" && _FromDate != "" && _ToDate != "" && _DeductionTypeId != "" && _Remarks != "" && _TotalAmount != "" && tableLength > 1) {

        if (tableLength > 1) {

            for (var i = 0; i < tableLength - 1; i++) {

                var ProductList = {
                    BranchId: _BranchId,
                    EmployeeId: _EmployeeId,
                    Amount: _Amount,
                    FromDate: _FromDate,
                    ToDate: _ToDate,
                    DeductionTypeId: _DeductionTypeId,
                    Remarks: _Remarks,
                    TotalAmount: _TotalAmount,

                    MonthYear: $("#example tBody tr:eq(" + i + ")").find(".clsCalculatedDate").val(),
                    Amount1: $("#example tBody tr:eq(" + i + ")").find(".clsAmount").val(),

                    //MonthYear: $("#example tBody tr:eq(" + i + ")").find('td:eq(0)').html(),
                    //Amount1: $("#example tBody tr:eq(" + i + ")").find('td:eq(1)').html(),                  
                };
                ProductListArr.push(ProductList);
            }
            $.ajax({
                type: 'POST',
                url: '/HRMS_EmployeeDeduction/SaveDeduction',
                data: JSON.stringify(ProductListArr),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    if (data.Result == "yes") {
                        swal({
                            title: "success",
                            text: "Record Successfully Saved.",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                window.location.reload();
                            } else {

                            }
                        });
                    }
                    else if (data == "yes1") {
                        swal({
                            title: "success",
                            text: "Record Successfully Updated.",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                window.location.reload();
                            } else {

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

        if (_BranchId == "") {
            swal("Warning", "Please Enter Branch !", "warning")
            return false;
        }
        if (_EmployeeId == "") {
            swal("Warning", "Please Enter Employee Name !", "warning")
            return false;
        }
        if (_Amount == "") {
            swal("Warning", "Please Enter Amount !", "warning")
            return false;
        }
        if (_FromDate == "") {
            swal("Warning", "Please Enter From Date !", "warning")
            return false;
        }
        if (_ToDate == "") {
            swal("Warning", "Please Enter To Date !", "warning")
            return false;
        }
        if (_DeductionTypeId == "") {
            swal("Warning", "Please Enter Deduction Type !", "warning")
            return false;
        }
        if (_Remarks == "") {
            swal("Warning", "Please Enter Remarks !", "warning")
            return false;
        }

        //if (tableLength == 1) {
        //    swal("Warning", "Please At least 1 row data required in employee attendance.", "warning");
        //    return false;
        //}
    }
})