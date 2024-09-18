$("#VATSupplierID").change(function () {
    debugger;
    var VATSPID = $("#VATSupplierID").val();
    if (VATSPID != "0") {

        if (VATSPID == "1") {

            $("#divInternational").css("display", "block");
            $("#divUAE").css("display", "none");
            $("#divGCC").css("display", "none");
        }
        if (VATSPID == "2") {

            $("#divInternational").css("display", "none");
            $("#divUAE").css("display", "block");
            $("#divGCC").css("display", "none");
        }
        if (VATSPID == "3") {

            $("#divInternational").css("display", "none");
            $("#divUAE").css("display", "none");
            $("#divGCC").css("display", "block");
        }
    }
})









$('#LandlineNumber').keyup(function () {
    this.value = this.value.replace(/[^0-9\.]/g, '');
});
$('#TRN').keyup(function () {
    this.value = this.value.replace(/[^0-9\.]/g, '');
});
$('#Mobile').change(function () {
    debugger;
    var isValid = false;
    var regex = /^[0-9-+()]*$/;
    isValid = regex.test($("#Mobile").val());
    if (isValid == true) {

    } else {
        $('#Mobile').val('');
        swal("Warning", "Please Enter valid Mobile Number", "warning");
    }
    return isValid;

});

$("#Email").change(function () {
    var inputvalues = $(this).val();
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(inputvalues)) {
        $("#Email").val('');
        swal("Warning", "Invalid Email Id, Please Enter Valid Email ID !", "warning");
        return regex.test(inputvalues);
    }
});
$("#ContactEmail").change(function () {
    var inputvalues = $(this).val();
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(inputvalues)) {
        $("#ContactEmail").val('');
        swal("Warning", "Invalid Email Id, Please Enter Valid Email ID !", "warning");
        return regex.test(inputvalues);
    }
});

$('#ContactNumber').change(function () {
    debugger;
    var isValid = false;
    var regex = /^[0-9-+()]*$/;
    isValid = regex.test($("#ContactNumber").val());
    if (isValid == true) {

    } else {
        $('#ContactNumber').val('');
        swal("Warning", "Please Enter valid Mobile Number", "warning");
    }
    return isValid;

});



var maxLength = 50;
$('#SupplierName').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength) {

        $('#SupplierName').val("");
        swal("Warning", " Accept only 50 Character !", "warning");

    } else {

    }

});
$('#SupplierName').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});

var maxLength2 = 50;
$('#AccountName').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength2) {

        $('#AccountName').val("");
        swal("Warning", " Accept only 50 Character !", "warning");

    } else {

    }

});
$('#AccountName').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});

function isStartDate() {
    debugger;
    var txt = document.getElementById("CreationDate").value;
    var regEx = /^\d{2}\/\d{2}\/\d{4}$/;

    if (!regEx.test(txt)) {

        $("#CreationDate").val("");
        swal("Warning", "Please enter date format mm/dd/yyyy !", "warning");


    } else {



    }

}
function isExpiryDate() {
    debugger;
    var txt = document.getElementById("ExpiryDate").value;
    var regEx = /^\d{2}\/\d{2}\/\d{4}$/;

    if (!regEx.test(txt)) {

        $("#ExpiryDate").val("");
        swal("Warning", "Please enter date format mm/dd/yyyy !", "warning");


    } else {



    }

}



//$('#CreditDays').keyup(function (event) {
//    return /\d/.test(String.fromCharCode(event.keyCode));
//});

$("#CreditDays").keypress(function (event) {
    return /\d/.test(String.fromCharCode(event.keyCode));
});

var maxLength3 = 3;
$('#CreditDays').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength3) {

        $('#CreditDays').val("");
        swal("Warning", " Accept only 3 Digits !", "warning");

    } else {

    }

});

//$("#CreditLimit").keypress(function (event) {
//    return /\d/.test(String.fromCharCode(event.keyCode));
//});

$("#CreditLimit").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength4 = 15;
$('#CreditLimit').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength4) {

        $('#CreditLimit').val("");
        swal("Warning", " Accept only 15 Digits !", "warning");

    } else {

    }

});

function TradlicenseDate() {
    debugger;
    var txt = document.getElementById("TradeLicenceExpiry").value;
    var regEx = /^\d{2}\/\d{2}\/\d{4}$/;

    if (!regEx.test(txt)) {

        $("#TradeLicenceExpiry").val("");
        swal("Warning", "Please enter date format mm/dd/yyyy !", "warning");


    } else {



    }

}



var maxLength5 = 50;
$('#ContactPerson').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength5) {

        $('#ContactPerson').val("");
        swal("Warning", " Accept only 50 Digits !", "warning");

    } else {

    }

});
$('#ContactPerson').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});


var maxLength6 = 50;
$('#Desination').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength6) {

        $('#Desination').val("");
        swal("Warning", " Accept only 50 Digits !", "warning");

    } else {

    }

});
$('#Desination').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});
