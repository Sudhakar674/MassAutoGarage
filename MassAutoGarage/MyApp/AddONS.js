$("#btnSave").click(function (e) {
    debugger;
    e.preventDefault();


    var _code = $("#Code").val();
    var _ServiceID = $("#ServiceID option:selected").val();
    var _Comission = $("#Comission").val();
    var _ComissionAmount = $("#ComissionAmount").val();
    var _Id = $("#HDFID").val();
    var _CurrentCount = $("#HDFCurrentCount").val();


    if (_code != "" && _ServiceID != "" && _Comission != "" && _ComissionAmount != "") {
        var ProductListArr = [];
        var ProductList = {
            ID: _Id,
            Code: _code,
            ServiceID: _ServiceID,
            Comission: _Comission,
            ComissionAmount: _ComissionAmount,
            CurrentCount: _CurrentCount

        };
        //ProductListArr.push(ProductList);
        if (confirm("Are you sure you want to continue ?")) {
            $.ajax({
                type: 'POST',
                url: '/AddOnsMaster/SaveAddONSMaster',
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
                                var url = "/AddOnsMaster/OnsDetails";
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
                                var url = "/AddOnsMaster/OnsDetails";
                                window.location.href = url;
                            } else {

                            }
                        });
                    }
                    else if (data == "4") {

                        swal("Warning", "This Voucher Code is Already Exist!", "warning");
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

        if (_ServiceID == "") {
            swal("Warning", "Please Select Service !", "warning");
            return false;
        }
        if (_Comission == "") {
            swal("Warning", "Please Enter Comission !", "warning");
            return false;
        }
        if (_ComissionAmount == "") {
            swal("Warning", "Please Enter Comission Amount !", "warning");
            return false;
        }
    }

})


// ---------------------------------------------- Validation --------------------------------------------------------------
$("#Comission").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength1 = 20;
$('#Comission').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength1) {

        $('#Comission').val("");
        swal("Warning", " Accept only 20 Digits !", "warning");

    } else {

    }

});

$("#ComissionAmount").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength2 = 20;
$('#ComissionAmount').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength2) {

        $('#ComissionAmount').val("");
        swal("Warning", " Accept only 20 Digits !", "warning");

    } else {

    }

});