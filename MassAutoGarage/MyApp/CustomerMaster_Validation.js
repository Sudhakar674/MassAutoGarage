

$('#TRN').keyup(function () {
    this.value = this.value.replace(/[^0-9\.]/g, '');
});
$('#Mobile').change(function () {
    
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

$("#VATCustomerID").change(function () {
   
    var VATSPID = $("#VATCustomerID").val();
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

var maxLength1 = 50;
$('#CustomerName').change(function () {
   
    var textlen = $(this).val().length;

    if (textlen > maxLength1) {

        $('#CustomerName').val("");
        swal("Warning", " Accept only 50 Digits !", "warning");

    } else {

    }

});
$('#CustomerName').keypress(function (e) {
   
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});

var maxLength2 = 50;
$('#AccountName').change(function () {
  
    var textlen = $(this).val().length;

    if (textlen > maxLength2) {

        $('#AccountName').val("");
        swal("Warning", " Accept only 50 Digits !", "warning");

    } else {

    }

});
$('#AccountName').keypress(function (e) {
    
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});

var maxLength3 = 50;
$('#ContactPersonName').change(function () {
    
    var textlen = $(this).val().length;

    if (textlen > maxLength3) {

        $('#ContactPersonName').val("");
        swal("Warning", " Accept only 50 Digits !", "warning");

    } else {

    }

});
$('#ContactPersonName').keypress(function (e) {
   
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});

$("#CreditDays").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength4 = 10;
$('#CreditDays').change(function () {
   
    var textlen = $(this).val().length;

    if (textlen > maxLength4) {

        $('#CreditDays').val("");
        swal("Warning", " Accept only 10 Digits !", "warning");

    } else {

    }

});

$("#CreditLimit").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength5 = 10;
$('#CreditLimit').change(function () {
   
    var textlen = $(this).val().length;

    if (textlen > maxLength5) {

        $('#CreditLimit').val("");
        swal("Warning", " Accept only 10 Digits !", "warning");

    } else {

    }

});



var maxLength6 = 50;
$('#AdvisorName').change(function () {
    
    var textlen = $(this).val().length;

    if (textlen > maxLength6) {

        $('#AdvisorName').val("");
        swal("Warning", " Accept only 50 Digits !", "warning");

    } else {

    }

});
$('#AdvisorName').keypress(function (e) {
   
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});

var maxLength7 = 10;
$('#DiscountAllowedAmt').change(function () {
   
    var textlen = $(this).val().length;

    if (textlen > maxLength7) {

        $('#DiscountAllowedAmt').val("");
        swal("Warning", " Accept only 10 Digits !", "warning");

    } else {

    }

});

$("#DiscountAllowedAmt").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength8 = 10;
$('#DiscountAllowedPercentage').change(function () {
   
    var textlen = $(this).val().length;

    if (textlen > maxLength8) {

        $('#DiscountAllowedPercentage').val("");
        swal("Warning", " Accept only 10 Digits !", "warning");

    } else {

    }

});

$("#DiscountAllowedPercentage").keyup(function () {
    var $this = $(this);
    $this.val($this.val().replace(/[^\d.]/g, ''));
});

var maxLength9 = 50;
$('#Individualorcompany').change(function () {
    
    var textlen = $(this).val().length;

    if (textlen > maxLength9) {

        $('#Individualorcompany').val("");
        swal("Warning", " Accept only 50 Digits !", "warning");

    } else {

    }

});
$('#Individualorcompany').keypress(function (e) {
   
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});


var maxLength10 = 50;
$('#ContactPerson').change(function () {
   
    var textlen = $(this).val().length;

    if (textlen > maxLength10) {

        $('#ContactPerson').val("");
        swal("Warning", " Accept only 50 Digits !", "warning");

    } else {

    }

});
$('#ContactPerson').keypress(function (e) {
   
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});

var maxLength11 = 50;
$('#Desination').change(function () {
   
    var textlen = $(this).val().length;

    if (textlen > maxLength11) {

        $('#Desination').val("");
        swal("Warning", " Accept only 50 Digits !", "warning");

    } else {

    }

});
$('#Desination').keypress(function (e) {
   
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});