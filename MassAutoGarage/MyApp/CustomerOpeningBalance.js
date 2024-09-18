
function LoadopeningMaster(suppId) {
    debugger;

    $.ajax({
        url: '/CustomerMaster/GetOpeningBalanceList',
        type: "GET",
        dataType: "json",
        data: { BalanceID: suppId },
        success: function (result) {


            $.each(result, function (i, val) {

                $("#txtCompany").val(val.CompanyName);
                $("#txtJobCardDate").val(val.JobCardDate);
                $("#txtJobCardNumber").val(val.JobCardNumber);

            });


        },
        error: function (xhr, status) {
            console.log(status);
            console.log(xhr);
        },
        complete: function () {

        }
    });

}

function LoadList(suppId) {

    $.ajax({
        url: '/CustomerMaster/GetOpeningBalanceDetailsList',
        type: "GET",
        dataType: "json",
        data: { BalanceID: suppId },
        success: function (result) {

            $('#tblOpeningBalance tbody').empty()
            $.each(result, function (i, val) {
                var row = "<tr>";
                row += "<td class='text-center'>" + (i + 1) + ".</td>"
                row += "<td>" + val.ToAccountName + "</td>"
                row += "<td>" + val.InvoiceDate + "</td>"
                row += "<td>" + val.InvoiceNumber + "</td>"

                row += "<td>" + val.LPONO + "</td>"
                row += "<td>" + val.EstNo + "</td>"
                row += "<td style='text-align:right;'>" + val.TotalAmount + "</td>"
                row += "<td style='text-align:right;'>" + val.PaidAmount + "</td>"
                row += "<td style='text-align:right;'>" + val.BalanceAmount + "</td>"


                row += "</tr>"
                $('#tblOpeningBalance tbody').append(row);

            });
            $("#divLoader").hide();
            $("#staticBackdrop").modal('show');


        },
        error: function (xhr, status) {
            console.log(status);
            console.log(xhr);
        },
        complete: function () {

        }
    });
}


$("#btnSave").click(function (e) {
    debugger;
    e.preventDefault();



    var _CompanyID = $("#CompanyID option:selected").val();
    var _JobCardDate = $("#JobCardDate").val();
    var _JobCardNumber = $("#JobCardNumber").val();
    var _Id = $("#HDFID").val();
    var tableLength = $("#example tr").length;

    if (_CompanyID != "" && _JobCardDate != "" && _JobCardNumber != "" && tableLength > 1) {
        var ProductListArr = [];
        if (tableLength > 1) {
            for (var i = 0; i < tableLength - 1; i++) {
                var ProductList = {
                    ID: _Id,
                    CompanyID: _CompanyID,
                    JobCardDate: _JobCardDate,
                    JobCardNumber: _JobCardNumber,
                    ToAccountID: $("#example tBody tr:eq(" + i + ")").find(".clsToAccountID").val(),
                    InvoiceDate: $("#example tBody tr:eq(" + i + ")").find('td:eq(2)').html(),
                    InvoiceNumber: $("#example tBody tr:eq(" + i + ")").find('td:eq(3)').html(),
                    LPONO: $("#example tBody tr:eq(" + i + ")").find('td:eq(4)').html(),
                    EstNo: $("#example tBody tr:eq(" + i + ")").find('td:eq(5)').html(),
                    TotalAmount: $("#example tBody tr:eq(" + i + ")").find('td:eq(6)').html(),
                    PaidAmount: $("#example tBody tr:eq(" + i + ")").find('td:eq(7)').html(),
                    BalanceAmount: $("#example tBody tr:eq(" + i + ")").find('td:eq(8)').html(),

                };
                ProductListArr.push(ProductList);
            }
        };


        if (confirm("Are you sure you want to continue ?")) {
            $.ajax({
                type: 'POST',
                url: '/CustomerMaster/InsertUpdateCustomerOpeningBalance',
                data: JSON.stringify(ProductListArr),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    debugger;
                    if (data == "1") {
                        debugger;

                        swal({
                            title: "Success",
                            text: "Records Successfully Saved",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                var url = "/CustomerMaster/CustomerOpeningBalance";
                                window.location.href = url;
                            } else {

                            }
                        });

                    }
                    else if (data == "2") {

                        swal({
                            title: "Success",
                            text: "Records Successfully Updated",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                var url = "/CustomerMaster/CustomerOpeningBalance";
                                window.location.href = url;
                            } else {

                            }
                        });
                    }
                    else if (data == "4") {

                        swal("Warning", "This Record Already Exist!", "warning");
                    } else {

                        swal("Warning", "Record not save!", "warning");
                    }

                },
                error: function (httpResponse) {
                    swal("Warning", "Something Went to Wrong !", "warning");

                }
            })
        }
    }
    else {


        if (_CompanyID == "") {
            swal("Warning", " Please Select Company Name !", "warning");
            return false;
        }

        if (_JobCardDate == "") {
            swal("Warning", "Please Enter Job Date !", "warning");
            return false;
        }
        if (_JobCardNumber == "") {
            swal("Warning", "Please Enter Job Number !", "warning");
            return false;
        }
        if (tableLength == 1) {
            swal("Warning", "Please Add Atleast One Record in Table !", "warning");
            return false;
        }

    }

})

$("#btnAdd").click(function (e) {
    debugger;
    e.preventDefault();

    var _InvoiceDate = $("#InvoiceDate").val();
    var _InvoiceNumber = $("#InvoiceNumber").val();
    var _ToAccountID = $("#ToAccountID option:selected").val();
    var _ToAccountName = $("#ToAccountID option:selected").text();


    var _LPONO = $("#LPONO").val();
    var _EstNo = $("#EstNo").val();

    var _TotalAmount = $("#TotalAmount").val();
    var _PaidAmount = $("#PaidAmount").val();
    var _BalanceAmount = $("#BalanceAmount").val();


    var tableLength = $("#example tr").length;
    var tableLength = $("#tBody2 tr").length;

    if (_InvoiceDate != "" && _InvoiceNumber != "" && _ToAccountID != "" && _ToAccountName != "" && _LPONO != "" && _TotalAmount != "" && _PaidAmount != "" && _BalanceAmount != "") {
        $("#example").show();
        var tr = "<tr>";
        tr += "<td>" + (tableLength + 1) + "<input type='hidden' class='clsToAccountID' value=" + _ToAccountID + " /></td><td>" + _ToAccountName + "</td><td>" + _InvoiceDate + "</td><td>" + _InvoiceNumber + "</td><td>" + _LPONO + "</td><td>" + _EstNo + "</td><td>" + _TotalAmount + "</td><td>" + _PaidAmount + "</td><td>" + _BalanceAmount + "</td><td><a  class='btn btn-danger view-btn DeleteTr' ><i class='fa fa-trash' aria-hidden='true'></i> Delete</a></td>";
        tr += "</tr>";
        $("#tBody2").append(tr);



    }
    else {

        swal({
            title: "Warning",
            text: "All Fields are Required. !",
            type: "warning",
        }).then(function (isConfirm) {
            if (isConfirm) {

            } else {
                //if no clicked => do something else
            }
        });

    }


});


$(document).on("click", ".DeleteTr", function () {

    if (confirm("Are you sure you want to remove ?")) {

        $(this).parents("tr").remove();
        calculat();
    }
})


$("#PaidAmount,#TotalAmount").change(function () {
    debugger;
    var TAmt = parseFloat($("#TotalAmount").val());
    var pAmt = parseFloat($("#PaidAmount").val());
    if (TAmt > 0) {

        if (pAmt > 0) {

            var balAmt = (TAmt - pAmt);
            $("#BalanceAmount").val(balAmt.toFixed(2));
        } else {

            $("#BalanceAmount").val(TAmt.toFixed(2));
        }


    }

});

function ConfirmDelete(GrdId) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x)

        if (GrdId > 0) {
            $.ajax({
                url: '/CustomerMaster/DeleteOpeningBalace',
                type: "GET",
                dataType: "json",
                data: { BalanceID: GrdId },
                success: function (result) {
                    if (result == "3") {

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

                    } else {

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
        else
            return false;
}

//------------------------------------------------------------ Validation-----------------------------------------------------------

function Validate(e) {
    var keyCode = e.keyCode || e.which;
   
    var pattern = /^[a-z\d\-_\s]+$/i;

    //Validating the textBox value against our regex pattern.
    var isValid = pattern.test(String.fromCharCode(keyCode));
    if (!isValid) {
     
        swal("Warning", "Invalid Attempt, only alphanumeric, underscore are allowed.", "warning");
    }

    return isValid;
}

var maxLength = 20;
$('#JobCardNumber').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength) {

        $('#JobCardNumber').val("");
        swal("Warning", " Accept only 20 Character !", "warning");

    } else {

    }

});

var maxLength1 = 20;
$('#InvoiceNumber').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength1) {

        $('#InvoiceNumber').val("");
        swal("Warning", " Accept only 20 Character !", "warning");

    } else {

    }

});

$("#LPONO").keypress(function (event) {
    return /\d/.test(String.fromCharCode(event.keyCode));
});
var maxLength2 = 20;
$('#LPONO').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength2) {

        $('#LPONO').val("");
        swal("Warning", " Accept only 20 Character !", "warning");

    } else {

    }

});

$("#EstNo").keypress(function (event) {
    return /\d/.test(String.fromCharCode(event.keyCode));
});
var maxLength3 = 20;
$('#EstNo').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength3) {

        $('#EstNo').val("");
        swal("Warning", " Accept only 20 Character !", "warning");

    } else {

    }

});

$("#TotalAmount").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});
$("#PaidAmount").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength4 = 20;
$('#TotalAmount').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength4) {

        $('#TotalAmount').val("");
        swal("Warning", " Accept only 20 Digits !", "warning");

    } else {

    }

});
var maxLength5 = 20;
$('#PaidAmount').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength5) {

        $('#PaidAmount').val("");
        swal("Warning", " Accept only 20 Digits !", "warning");

    } else {

    }

});