
$("#btnAdd").click(function (e) {
    debugger;
    e.preventDefault();
    var _Code = $("#Code").val();
    var _CompanyID = $("#CompanyID option:selected").val();
    var _CompanyName = $("#CompanyID option:selected").text();

    var _SupplierID = $("#SupplierID option:selected").val();
    var _SupplierName = $("#SupplierID option:selected").text();

    var _InvoiceDate = $("#InvoiceDate").val();
    var _InvoiceNumber = $("#InvoiceNumber").val();
    var _ToAccountID = $("#ToAccountID option:selected").val();
    var _ToAccountName = $("#ToAccountID option:selected").text();


    var _LPONO = $("#LPONO").val();
    var _TotalAmount = $("#TotalAmount").val();
    var _PaidAmount = $("#PaidAmount").val();
    var _BalanceAmount = $("#BalanceAmount").val();


    var tableLength = $("#example tr").length;
    var tableLength = $("#tBody2 tr").length;

    if (_Code != "" && _CompanyID != "" && _SupplierID != "" && _InvoiceDate != "" && _InvoiceNumber != "") {
        $("#example").show();
        var tr = "<tr>";
        tr += "<td>" + (tableLength + 1) + "<input type='hidden' class='clsToAccountID' value=" + _ToAccountID + " /></td><td>" + _InvoiceDate + "</td><td>" + _InvoiceNumber + "</td><td>" + _ToAccountName + "</td><td>" + _LPONO + "</td><td>" + _TotalAmount + "</td><td>" + _PaidAmount + "</td><td>" + _BalanceAmount + "</td><td><a  class='btn btn-danger view-btn DeleteTr' ><i class='fa fa-trash' aria-hidden='true'></i></a></td>";
        tr += "</tr>";
        $("#tBody2").append(tr);



    }
    else {

        swal({
            title: "Warning",
            text: "All Fields are Required !",
            type: "warning",
        }).then(function (isConfirm) {
            if (isConfirm) {
                $("#txtdamQty").val("");
            } else {
                //if no clicked => do something else
            }
        });

    }


});

$("#btnSave").click(function (e) {
    debugger;
    e.preventDefault();

    var _Code = $("#Code").val();
    var _CompanyID = $("#CompanyID option:selected").val();
    var _SupplierID = $("#SupplierID option:selected").val();
    var _Id = $("#HDFID").val();
    var _CurrentCount = $("#HDFCurrentCount").val();

    var tableLength = $("#example tr").length;
    if (_Code != "" && _CompanyID != "" && _SupplierID != "" && tableLength > 1) {

        var ProductListArr = [];
        if (tableLength > 1) {

            for (var i = 0; i < tableLength - 1; i++) {

                var ProductList = {
                    ID: _Id,
                    Code: _Code,
                    CompanyID: _CompanyID,
                    SupplierID: _SupplierID,
                    CurrentCount: _CurrentCount,
                    InvoiceDate: $("#example tBody tr:eq(" + i + ")").find('td:eq(1)').html(),
                    InvoiceNumber: $("#example tBody tr:eq(" + i + ")").find('td:eq(2)').html(),
                    ToAccountID: $("#example tBody tr:eq(" + i + ")").find(".clsToAccountID").val(),
                    LPONO: $("#example tBody tr:eq(" + i + ")").find('td:eq(4)').html(),
                    TotalAmount: $("#example tBody tr:eq(" + i + ")").find('td:eq(5)').html(),
                    PaidAmount: $("#example tBody tr:eq(" + i + ")").find('td:eq(6)').html(),
                    BalanceAmount: $("#example tBody tr:eq(" + i + ")").find('td:eq(7)').html(),
                }
                ProductListArr.push(ProductList);
            }
        };

        if (confirm("Are you sure you want to continue ?")) {
            $.ajax({
                type: 'POST',
                url: '/SupplierMaster/InsertUpdateOpeningBalance',
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
                                var url = "/SupplierMaster/OpeningBalanceDetails";
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
                                var url = "/SupplierMaster/OpeningBalanceDetails";
                                window.location.href = url;
                            } else {

                            }
                        });
                    }
                    else if (data == "4") {

                        swal("Warning", "This Code is Already Exist!", "warning");
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


        if (_Code == "") {
            swal("Warning", " Please Enter Code !", "warning");
            return false;
        }

        if (_CompanyID == "") {
            swal("Warning", "Please Select Company Name !", "warning");
            return false;
        }
        if (_SupplierID == "") {
            swal("Warning", "Please Select Supplier Name !", "warning");
            return false;
        }
        if (tableLength == 1) {

            swal("Warning", "Add Supplier Details !", "warning");
            return false;
        }
    }

})


$('#SupplierID').change(function () {
    debugger;
    var suppID = $("#SupplierID option:selected").val();
    var CompID = $("#CompanyID option:selected").val();
    $.ajax({
        url: '/SupplierMaster/GetCode_ByID',
        type: "POST",
        dataType: "json",
        data: { Supp_ID: suppID, comp_ID: CompID },

        success: function (result) {
            debugger;
            if (result != "") {

                $("#Code").val(result);
            } else {


                var NewCode = $("#HDFNewCode").val();
                $("#Code").val(NewCode);
            }


        },
        error: function (err) {
            alert(err.statusText);
        }
    });

});

$(document).on("click", ".DeleteContactTr", function () {

    if (confirm("Are you sure you want to remove ?")) {

        $(this).parents("tr").remove();

    }
})

function LoadDetails(suppId) {
    debugger;

    $.ajax({
        url: '/SupplierMaster/GetCompanySupplierDetails',
        type: "GET",
        dataType: "json",
        data: { ID: suppId },
        success: function (result) {


            $.each(result, function (i, val) {

                $("#txtCode").val(val.Code);
                $("#txtCompany").val(val.CompanyName);
                $("#txtsuppName").val(val.SupplierName);

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
        url: '/SupplierMaster/GetSupplierOpeningBalanceDetails',
        type: "GET",
        dataType: "json",
        data: { ID: suppId },
        success: function (result) {

            $('#tblContact tbody').empty()
            $.each(result, function (i, val) {
                var row = "<tr>";
                row += "<td class='text-center'>" + (i + 1) + ".</td>"
                row += "<td>" + val.InvoiceDate + "</td>"
                row += "<td>" + val.InvoiceNumber + "</td>"
                row += "<td>" + val.ToAccountName + "</td>"
                row += "<td>" + val.LPONO + "</td>"
                row += "<td>" + val.TotalAmount + "</td>"
                row += "<td>" + val.PaidAmount + "</td>"
                row += "<td>" + val.BalanceAmount + "</td>"


                row += "</tr>"
                $('#tblContact tbody').append(row);

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

function ConfirmDelete(GrdId) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x)

        if (GrdId > 0) {
            $.ajax({
                url: '/SupplierMaster/DeleteOpeningBalance',
                type: "GET",
                dataType: "json",
                data: { SupplID: GrdId },
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

//--------------------------------------------------------- Validation -------------------------------------------------------------------

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
$('#InvoiceNumber').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength) {

        $('#InvoiceNumber').val("");
        swal("Warning", " Accept only 20 Character !", "warning");

    } else {

    }

});

var maxLength3 = 15;
$('#LPONO').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength3) {

        $('#LPONO').val("");
        swal("Warning", " Accept only 15 Digits !", "warning");

    } else {

    }

});


$("#LPONO").keypress(function (event) {
    return /\d/.test(String.fromCharCode(event.keyCode));
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