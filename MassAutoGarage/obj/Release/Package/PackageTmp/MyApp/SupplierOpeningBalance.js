
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
        tr += "<td>" + (tableLength + 1) + "<input type='hidden' class='clsCompanyID' value=" + _CompanyID + " /><input type='hidden' class='clsSupplierID' value=" + _SupplierID + " /><input type='hidden' class='clsToAccountID' value=" + _ToAccountID + " /></td><td>" + _Code + "</td><td>" + _CompanyName + "</td><td>" + _SupplierName + "</td><td>" + _InvoiceDate + "</td><td>" + _InvoiceNumber + "</td><td>" + _ToAccountName + "</td><td>" + _LPONO + "</td><td>" + _TotalAmount + "</td><td>" + _PaidAmount + "</td><td>" + _BalanceAmount + "</td><td><a  class='btn btn-danger view-btn DeleteTr' ><i class='fa fa-trash' aria-hidden='true'></i></a></td>";
        tr += "</tr>";
        $("#tBody2").append(tr);



    }
    else {

        swal({
            title: "Warning",
            text: "Rquired Quantity is not Greater Than Given Quantity. !",
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


    var _code = $("#Code").val();
    var _ColorId = $("#ColorId option:selected").val();
    var _ColorCode = $("#ColorCode").val();
    var _IsActive = $("#IsActive option:selected").val();
    var _Id = $("#HDFID").val();


    if (_code != "" && _ColorId != "") {
        var ProductListArr = [];
        var ProductList = {
            ID: _Id,
            Code: _code,
            ColorId: _ColorId,
            ColorCode: _ColorCode,
            IsActive: _IsActive

        };
        //ProductListArr.push(ProductList);
        if (confirm("Are you sure you want to continue ?")) {
            $.ajax({
                type: 'POST',
                url: '/ColorMaster/SaveColorMaster',
                data: JSON.stringify(ProductList),
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
                                var url = "/ColorMaster/ColorDetails";
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
                                var url = "/ColorMaster/ColorDetails";
                                window.location.href = url;
                            } else {

                            }
                        });
                    }
                    else if (data == "4") {

                        swal("Warning", "This Color is Already Exist!", "warning");
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


        if (_code == "") {
            swal("Warning", " Please Enter Code !", "warning");
            return false;
        }

        if (_ColorId == "") {
            swal("Warning", "Please Select Color !", "warning");
            return false;
        }


    }

})
