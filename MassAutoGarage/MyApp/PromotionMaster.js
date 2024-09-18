

$("#PaidAmount,#TotalAmount").change(function () {
    debugger;
    var TAmt = parseFloat($("#TotalAmount").val());
    var pAmt = parseFloat($("#PaidAmount").val());
    if (TAmt > 0 && pAmt > 0) {

        var balAmt = (TAmt - pAmt);
        $("#BalanceAmount").val(balAmt.toFixed(2));

    }

});

$("#btnSave").click(function (e) {
    debugger;
    e.preventDefault();


    var _code = $("#Code").val();
    var _PromotionName = $("#PromotionName").val();
    var _PeriodFromDate = $("#PeriodFromDate").val();
    var _ToDate = $("#ToDate").val();
    var _ServiceID = $("#ServiceID option:selected").val();
    var _Discount = $("#Discount").val();
    var _DiscountAmount = $("#DiscountAmount").val();
    var _IsActive = $("#IsActive option:selected").val();
    var _ID = $("#HDFID").val();
    var _CurrentCount = $("#HDFCurrentCount").val();


    if (_code != "" && _PromotionName != "" && _PeriodFromDate != "" && _ToDate != "" && _ServiceID != "0" && _Discount != "" && _DiscountAmount != "" && _IsActive != "0") {
        var ProductListArr = [];
        var ProductList = {
            ID: _ID,
            CurrentCount: _CurrentCount,
            Code: _code,
            PromotionName: _PromotionName,
            PeriodFromDate: _PeriodFromDate,
            ToDate: _ToDate,
            ServiceID: _ServiceID,
            Discount: _Discount,
            DiscountAmount: _DiscountAmount,
            IsActive: _IsActive

        };
        //ProductListArr.push(ProductList);
        if (confirm("Are you sure you want to continue ?")) {
            $.ajax({
                type: 'POST',
                url: '/PramotionMaster/SavePromotionMaster',
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
                                var url = "/PramotionMaster/PramotionDetails";
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
                                var url = "/PramotionMaster/PramotionDetails";
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

        if (_PromotionName == "") {
            swal("Warning", "Please Enter Promotion Name !", "warning");
            return false;
        }
        if (_PeriodFromDate == "") {
            swal("Warning", "Please Enter Period From Date !", "warning");
            return false;
        }
        if (_ToDate == "") {
            swal("Warning", "Please Enter To Date !", "warning");
            return false;
        }
        if (_ServiceID == "0") {
            swal("Warning", "Please Select Service Name !", "warning");
            return false;
        }
        if (_Discount == "") {
            swal("Warning", "Please Enter Discount !", "warning");
            return false;
        }
        if (_DiscountAmount == "") {
            swal("Warning", "Please Enter Discount Amount !", "warning");
            return false;
        }
        if (_IsActive == "0") {
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
                url: '/PramotionMaster/Delete',
                type: "GET",
                dataType: "json",
                data: { promid: GrdId },
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

//------------------------ Validation Section-----------------------------------

var maxLength = 50;
$('#PromotionName').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength) {

        $('#PromotionName').val("");
        swal("Warning", " Accept only 50 Character !", "warning");

    } else {

    }

});
$('#PromotionName').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});
function isPeriodFromDate() {
    debugger;
    var txt = document.getElementById("PeriodFromDate").value;
    var regEx = /^\d{2}\/\d{2}\/\d{4}$/;

    if (!regEx.test(txt)) {

        $("#PeriodFromDate").val("");
        swal("Warning", "Please enter date format mm/dd/yyyy !", "warning");


    } else {



    }

} function isToDate() {
    debugger;
    var txt = document.getElementById("ToDate").value;
    var regEx = /^\d{2}\/\d{2}\/\d{4}$/;

    if (!regEx.test(txt)) {

        $("#ToDate").val("");
        swal("Warning", "Please enter date format mm/dd/yyyy !", "warning");


    } else {



    }

}
$("#Discount").on("keypress keyup blur", function (event) {
    //this.value = this.value.replace(/[^0-9\.]/g,'');
    $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});

$("#DiscountAmount").on("keypress keyup blur", function (event) {
    //this.value = this.value.replace(/[^0-9\.]/g,'');
    $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});

var maxLength2 = 7;
$('#Discount').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength2) {

        $('#Discount').val("");
        swal("Warning", " Accept only 7 Character !", "warning");

    } else {

    }

});

var maxLength3 = 7;
$('#DiscountAmount').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength3) {

        $('#DiscountAmount').val("");
        swal("Warning", " Accept only 7 Character !", "warning");

    } else {

    }

});