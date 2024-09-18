

$("#btnSave").click(function (e) {
    debugger;
    e.preventDefault();

    var _HDFID = $("#HDFID").val();
    var _code = $("#Code").val();
    var _SalesValue = $("#SalesValue").val();
    var _ToSalesValue = $("#ToSalesValue").val();
    var _LoyaltyPoints = $("#LoyaltyPoints").val();
    var _IsActive = $("#IsActive option:selected").val();
    var _CurrentCount = $("#HDFCurrentCount").val();



    if (_code != "" && _SalesValue != "" && _ToSalesValue != "" && _LoyaltyPoints != "" && _IsActive != "") {
        var ProductListArr = [];
        var ProductList = {
            ID: _HDFID,
            CurrentCount: _CurrentCount,
            Code: _code,
            SalesValue: _SalesValue,
            ToSalesValue: _ToSalesValue,
            LoyaltyPoints: _LoyaltyPoints,
            IsActive: _IsActive

        };
        //ProductListArr.push(ProductList);
        if (confirm("Are you sure you want to continue ?")) {
            $.ajax({
                type: 'POST',
                url: '/LoyaltyPointMaster/SaveLoyaltyPoint',
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
                                var url = "/LoyaltyPointMaster/LoyaltyDetails";
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
                                var url = "/LoyaltyPointMaster/LoyaltyDetails";
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
        if (_SalesValue == "") {
            swal("Warning", "Please Enter Sales Value !", "warning");
            return false;
        }
        if (_ToSalesValue == "") {
            swal("Warning", "Please Enter ToSales Value !", "warning");
            return false;
        } if (_LoyaltyPoints == "") {
            swal("Warning", "Please Enter Loyalty Points !", "warning");
            return false;
        }
        if (_IsActive == "") {
            swal("Warning", "Please Select Status !", "warning");
            return false;
        }


    }

})

function ConfirmDelete(GrdId) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x)

        if (GrdId > 0) {
            $.ajax({
                url: '/LoyaltyPointMaster/Delete',
                type: "GET",
                dataType: "json",
                data: { id: GrdId },
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


//----------------------------------------------Validation-------------------------------------------------------
$("#SalesValue").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength1 = 10;
$('#SalesValue').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength1) {

        $('#SalesValue').val("");
        swal("Warning", " Accept only 10 Digits !", "warning");

    } else {

    }

});

$("#ToSalesValue").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength2 = 10;
$('#ToSalesValue').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength2) {

        $('#ToSalesValue').val("");
        swal("Warning", " Accept only 10 Digits !", "warning");

    } else {

    }

});

$("#LoyaltyPoints").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength3 = 10;
$('#LoyaltyPoints').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength3) {

        $('#LoyaltyPoints').val("");
        swal("Warning", " Accept only 10 Digits !", "warning");

    } else {

    }

});