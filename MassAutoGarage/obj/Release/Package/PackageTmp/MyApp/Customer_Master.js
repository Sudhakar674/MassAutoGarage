

$("#btnAddContact").click(function (e) {
    debugger;
    e.preventDefault();
    var _ContactPerson = $("#ContactPerson").val();
    var _ContactNumber = $("#ContactNumber").val();
    var _ContactEmail = $("#ContactEmail").val();
    var _Desination = $("#Desination").val();


    var tableLength = $("#tblContact tr").length;
    var tableLength = $("#tBody3 tr").length;

    if (_ContactPerson != "" && _ContactNumber != "" && _ContactEmail != "" && _Desination != "") {
        $("#example").show();
        var tr = "<tr>";
        tr += "<td>" + (tableLength + 1) + "</td><td>" + _ContactPerson + "</td><td>" + _ContactNumber + "</td><td>" + _ContactEmail + "</td><td>" + _Desination + "</td><td><a  class='btn btn-sm btn-danger remove-item-btn DeleteContactTr' ><i class='fa fa-trash' aria-hidden='true'></i> Delete</a></td>";
        tr += "</tr>";
        $("#tBody3").append(tr);

        $("#ContactPerson").val("");
        $("#ContactNumber").val("");
        $("#ContactEmail").val("");
        $("#Desination").val("");

    }
    else {

        swal({
            title: "Warning",
            text: "Rquired Quantity is not Greater Than Given Quantity. !",
            type: "warning",
        }).then(function (isConfirm) {
            if (isConfirm) {

            } else {
                //if no clicked => do something else
            }
        });

    }


});

$("#btnAdd").click(function (e) {
    debugger;
    e.preventDefault();
    var _ExpiryDate = $("#ExpiryDate").val();
    var _fattchmentfile = $("#hdfattchmentfile").val();
    var _Description = $("#Description").val();


    var tableLength = $("#example tr").length;
    var tableLength = $("#tBody2 tr").length;

    if (_ExpiryDate != "" && _Description != "") {
        $("#example").show();
        var tr = "<tr>";
        tr += "<td>" + (tableLength + 1) + "<input type='hidden' class='clsCompanyID' value=" + _fattchmentfile + " /></td><td>" + _Description + "</td><td>" + _ExpiryDate + "</td><td>" + _fattchmentfile + "</td><td><a  class='btn btn-sm btn-danger remove-item-btn DeleteTr' ><i class='fa fa-trash' aria-hidden='true'></i> Delete</a></td>";
        tr += "</tr>";
        $("#tBody2").append(tr);

        $("#ExpiryDate").val("");
        $("#AttachmentFile").val("");
        $("#Description").val("");

    }
    else {

        swal({
            title: "Warning",
            text: "Please Add atleast one Attachment. !",
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
$(document).on("click", ".DeleteContactTr", function () {

    if (confirm("Are you sure you want to remove ?")) {

        $(this).parents("tr").remove();

    }
})
$(document).on("click", ".DeleteTr", function () {

    if (confirm("Are you sure you want to remove ?")) {

        $(this).parents("tr").remove();
        calculat();
    }
})


$('#AttachmentFile').change(function () {
    debugger;
    // Checking whether FormData is available in browser
    if (window.FormData !== undefined) {

        var fileUpload = $("#AttachmentFile").get(0);
        var files = fileUpload.files;

        // Create FormData object
        var fileData = new FormData();

        // Looping over all files and add it to FormData object
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }

        // Adding one more key to FormData object
        fileData.append('username', 'Manas');

        $.ajax({
            url: '/SupplierMaster/UploadLogo',
            type: "POST",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: fileData,
            success: function (result) {
                $("#hdfattchmentfile").val(result);
                
                if (result == "File size Should Be UpTo 7 KB !") {

                    $("#AttachmentFile").val("");
                    swal("Warning", result, "warning")
                }
                else {


                }

            },
            error: function (err) {
                alert(err.statusText);
            }
        });
    } else {
        alert("FormData is not supported.");
    }
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

$("#VATCustomerID").change(function () {
    debugger;
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


$("#btnSave").click(function () {
    debugger;

    $("#divLoader").show();
    var _HDFID = $("#HDFID").val();
    var _Code = $("#Code").val();
    var _CompanyID = $("#CompanyID option:selected").val();
    var _CustomerName = $("#CustomerName").val();
    var _AccountName = $("#AccountName").val();
    var _ContactPersonName = $("#ContactPersonName").val();
    var _Email = $("#Email").val();
    var _Mobile = $("#Mobile").val();
    var _TRN = $("#TRN").val();
    var _IsActive = $("#IsActive option:selected").val();
    var _Address = $("#Address").val();
    var _CreationDate = $("#CreationDate").val();
    var _CreditDays = $("#CreditDays").val();
    var _CreditLimit = $("#CreditLimit").val();
    var _Block = $("#Block option:selected").val();
    var _TradeLicenceExpiry = $("#TradeLicenceExpiry").val();
    var _VATCustomerID = $("#VATCustomerID option:selected").val();
    var _InternationalID = $("#InternationalID option:selected").val();
    var _UAEID = $("#UAEID option:selected").val();
    var _GCCID = $("#GCCID option:selected").val();
    var _Reason = $("#Reason").val();

    var _LoyaltyPoints = $("#LoyaltyPoints").val();
    var _Group = $("#Group option:selected").val();
    var _AdvisorName = $("#AdvisorName").val();
    var _DiscountAllowedAmt = $("#DiscountAllowedAmt").val();
    var _DiscountAllowedPercentage = $("#DiscountAllowedPercentage").val();
    var _Source = $("#Source option:selected").val();
    var _Gender = $("#Gender option:selected").val();
    var _Salesman = $("#Salesman option:selected").val();
    var _Nationality = $("#Nationality option:selected").val();
    var _Individualorcompany = $("#Individualorcompany").val();



    var tableLength = $("#example tr").length;
    var tableLength2 = $("#tblContact tr").length;
    var ProductListArr = [];

    if (_Code != "" && _CompanyID != "" && _CustomerName != "" && _AccountName != "" && _Mobile != "" && _Email != "" && _TRN != "" && _Address != "" && _CreationDate != "" && tableLength2 > 1 && tableLength > 1) {

        if (tableLength > 1) {

            for (var i = 0; i < tableLength - 1; i++) {

                var ProductList = {
                    ID: _HDFID,
                    Code: _Code,
                    CompanyID: _CompanyID,
                    CustomerName: _CustomerName,
                    AccountName: _AccountName,
                    ContactPersonName: _ContactPersonName,
                    Mobile: _Mobile,
                    Address: _Address,
                    Email: _Email,
                    TRN: _TRN,
                    CreationDate: _CreationDate,
                    CreditDays: _CreditDays,
                    CreditLimit: _CreditLimit,
                    Block: _Block,
                    Reason: _Reason,
                    VATCustomerID: _VATCustomerID,
                    TradeLicenceExpiry: _TradeLicenceExpiry,
                    LoyaltyPoints: _LoyaltyPoints,
                    InternationalID: _InternationalID,
                    UAEID: _UAEID,
                    GCCID: _GCCID,

                    Group: _Group,
                    AdvisorName: _AdvisorName,
                    DiscountAllowedAmt: _DiscountAllowedAmt,
                    Source: _Source,
                    Gender: _Gender,
                    DiscountAllowedPercentage: _DiscountAllowedPercentage,
                    Salesman: _Salesman,
                    Nationality: _Nationality,
                    Individualorcompany: _Individualorcompany,
                    IsActive: _IsActive,


                    //ContactPerson: _ContactPerson,
                    //ContactNumber: _ContactNumber,
                    //ContactEmail: _ContactEmail,
                    //Desination: _Desination,

                    //MedicineID: $("#example tBody tr:eq(" + i + ")").find(".clsMedicineID").val(),
                    //MedicineTypeID: $("#example tBody tr:eq(" + i + ")").find(".clsMedicineTypeID").val(),
                    /*  PowarID: $("#example tBody tr:eq(" + i + ")").find(".clsPowarID").val(),*/
                    Type1: '1',
                    Description: $("#example tBody tr:eq(" + i + ")").find('td:eq(1)').html(),
                    ExpiryDate: $("#example tBody tr:eq(" + i + ")").find('td:eq(2)').html(),
                    AttachmentFile: $("#example tBody tr:eq(" + i + ")").find('td:eq(3)').html(),




                };
                ProductListArr.push(ProductList);
            }


            for (var i = 0; i < tableLength2 - 1; i++) {

                var ProductList = {
                    ID: _HDFID,
                    Code: _Code,
                    CompanyID: _CompanyID,
                    CustomerName: _CustomerName,
                    AccountName: _AccountName,
                    ContactPersonName: _ContactPersonName,
                    Mobile: _Mobile,
                    Address: _Address,
                    Email: _Email,
                    TRN: _TRN,
                    CreationDate: _CreationDate,
                    CreditDays: _CreditDays,
                    CreditLimit: _CreditLimit,
                    Block: _Block,
                    Reason: _Reason,
                    VATCustomerID: _VATCustomerID,
                    TradeLicenceExpiry: _TradeLicenceExpiry,
                    LoyaltyPoints: _LoyaltyPoints,
                    InternationalID: _InternationalID,
                    UAEID: _UAEID,
                    GCCID: _GCCID,

                    Group: _Group,
                    AdvisorName: _AdvisorName,
                    DiscountAllowedAmt: _DiscountAllowedAmt,
                    Source: _Source,
                    Gender: _Gender,
                    DiscountAllowedPercentage: _DiscountAllowedPercentage,
                    Salesman: _Salesman,
                    Nationality: _Nationality,
                    Individualorcompany: _Individualorcompany,
                    IsActive: _IsActive,
                    //ContactPerson: _ContactPerson,
                    //ContactNumber: _ContactNumber,
                    //ContactEmail: _ContactEmail,
                    //Desination: _Desination,

                    //MedicineID: $("#example tBody tr:eq(" + i + ")").find(".clsMedicineID").val(),
                    //MedicineTypeID: $("#example tBody tr:eq(" + i + ")").find(".clsMedicineTypeID").val(),
                    /*  PowarID: $("#example tBody tr:eq(" + i + ")").find(".clsPowarID").val(),*/


                    Type2: '2',
                    ContactPerson: $("#tblContact tBody tr:eq(" + i + ")").find('td:eq(1)').html().trim(),
                    ContactNumber: $("#tblContact tBody tr:eq(" + i + ")").find('td:eq(2)').html().trim(),
                    ContactEmail: $("#tblContact tBody tr:eq(" + i + ")").find('td:eq(3)').html().trim(),
                    Desination: $("#tblContact tBody tr:eq(" + i + ")").find('td:eq(4)').html().trim(),


                };
                ProductListArr.push(ProductList);
            }

            $.ajax({
                type: 'POST',
                url: '/CustomerMaster/InsertUpdateCustomer',
                data: JSON.stringify(ProductListArr),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    if (data == "1") {
                        $("#divLoader").hide();
                        swal({
                            title: "success",
                            text: "Record Successfully Submitted.",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                var url = "/CustomerMaster/CustomerDetails";
                                window.location.href = url;
                            } else {

                            }
                        });

                    }
                    else if (data == "Yes") {
                        swal({
                            title: "success",
                            text: "Record Successfully Updated.",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                var url = "/CustomerMaster/CustomerDetails";
                                window.location.href = url;
                            } else {

                            }
                        });
                    }
                    else {
                        swal("Warning", "Records Already Exists !", "warning");
                    }
                },

                error: function (httpResponse) {

                    swal({
                        title: "Warning",
                        text: "Something is wrong ! Please try again",
                        type: "warning",
                    }).then(function (isConfirm) {
                        if (isConfirm) {

                            return false;
                        } else {

                        }
                    });
                }
            })
        }
        else {

            swal({
                title: "Warning",
                text: "Please Fill All Fields Properly and add minimum one  material .",
                type: "warning",
            }).then(function (isConfirm) {
                if (isConfirm) {

                    e.preventDefault();
                } else {

                }
            });
            //alert("Please Fill All Fields Properly and add minimum one  material .");
            //e.preventDefault();
        }
    }
    else {

        if (_Code == "") {
            swal("Warning", "Please Fill Code !", "warning")
            $("#Code").focus();
            return false;
        }
        if (_CompanyID == "") {
            swal("Warning", "Please Select Company Name !", "warning")
            $("#CompanyID").focus();
            return false;
        }
        if (_SupplierName == "") {
            swal("Warning", "Please Enter Supplier Name !", "warning")
            $("#SupplierName").focus();
            return false;
        }
        if (_AccountName == "") {
            swal("Warning", "Please Enter Account Name !", "warning")
            $("#AccountName").focus();
            return false;
        }
        if (_Mobile == "") {
            swal("Warning", "Please Enter Mobile Number !", "warning")
            $("#Mobile").focus();
            return false;
        }
        if (_Email == "") {
            swal("Warning", "Please Enter Email Address !", "warning")
            $("#Email").focus();
            return false;
        }
        if (_TRN == "") {
            swal("Warning", "Please Enter TRN !", "warning")
            $("#TRN").focus();
            return false;
        }


        if (_Address == "") {
            swal("Warning", "Please Enter Address !", "warning")
            $("#Address").focus();
            return false;
        }
        if (_CreationDate == "") {
            swal("Warning", "Please Fill All Field in Additional Information !", "warning")
            $("#Address").focus();
            $("#panelsStayOpen-collapseThree").css("display", "inline");
            return false;
        }

        if (tableLength2 == 1) {
            swal("Warning", "Please Add Atleast One Contact Person !", "warning")

            $("#panelsStayOpen-collapseTwo").css("display", "inline");
            return false;
        }
        if (tableLength == 1) {
            swal("Warning", "Please Upload Attachment File !", "warning")

            $("#panelsStayOpen-collapseTFour").css("display", "inline");
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
                url: '/CustomerMaster/Delete',
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

// Modal Popup-----------------------------------------------------


function ViewDetails(id) {
    debugger;

    LoadContact(id);
    LoadAttachment(id);
    LoadDetails(id);
    $("#divLoader").show();

}

function LoadContact(suppId) {

    $.ajax({
        url: '/CustomerMaster/GetContactList',
        type: "GET",
        dataType: "json",
        data: { SupplierID: suppId },
        success: function (result) {

            $('#tblContact tbody').empty()
            $.each(result, function (i, val) {
                var row = "<tr>";
                row += "<td class='text-center'>" + (i + 1) + ".</td>"
                row += "<td>" + val.ContactPerson + "</td>"
                row += "<td>" + val.ContactNumber + "</td>"
                row += "<td>" + val.ContactEmail + "</td>"
                row += "<td>" + val.Desination + "</td>"

                row += "</tr>"
                $('#tblContact tbody').append(row);

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

function LoadAttachment(suppId) {
    $.ajax({
        url: '/CustomerMaster/GetAttachmentList',
        type: "GET",
        dataType: "json",
        data: { SupplierID: suppId },
        success: function (result) {

            $('#tblAttachment tbody').empty()
            $.each(result, function (i, val) {
                var row = "<tr>";
                row += "<td class='text-center'>" + (i + 1) + ".</td>"
                row += "<td>" + val.Description + "</td>"
                row += "<td>" + val.ExpiryDate + "</td>"
                row += "<td><a href='/AttachmentFile/" + val.AttachmentFile + "' id='LetterFile' target='_blank' class='btn btn-sm btn-primary edit-item-btn'> View File</a></td>"

                row += "</tr>"
                $('#tblAttachment tbody').append(row);

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
function LoadDetails(suppId) {
    $.ajax({
        url: '/CustomerMaster/GetCustomerDetails',
        type: "GET",
        dataType: "json",
        data: { SupplierID: suppId },
        success: function (result) {
            $.each(result, function (i, val) {
                debugger;
                $("#txtCode").val(val.Code);
                $("#txtCompanyName").val(val.CompanyName);
                $("#txtCustomerName").val(val.CustomerName);
                $("#txtAccountName").val(val.AccountName);
                $("#txtContactPersonName").val(val.ContactPersonName);
                $("#txtEmail").val(val.Email);
                $("#txtMobile").val(val.Mobile);
                $("#txtTRN").val(val.TRN);
                $("#txtStatus").val(val.Status);
                $("#txtAddress").val(val.Address);
                $("#txtCreationDate").val(val.CreationDate);
                $("#txtCreditDays").val(val.CreditDays);
                $("#txtCreditLimit").val(val.CreditLimit);
                $("#txtBlock").val(val.BlockName);
                $("#txtTradeLicenceExpiry").val(val.TradeLicenceExpiry);

                $("#txtVATCustomerID").val(val.VATCustomer);

                if (val.VATCustomerID == 1) {

                    $("#divInternational").css("display", "block");
                    $("#divUAE").css("display", "none");
                    $("#divGCC").css("display", "none");
                    $("#txtInternationalID").val(val.CountryName);

                } else if (val.VATCustomerID == 2) {

                    $("#divInternational").css("display", "none");
                    $("#divUAE").css("display", "block");
                    $("#divGCC").css("display", "none");
                    $("#txtUAEID").val(val.UAE_Country);

                } else if (val.VATCustomerID == 3) {

                    $("#divInternational").css("display", "none");
                    $("#divUAE").css("display", "none");
                    $("#divGCC").css("display", "block");

                    $("#txtGCCID").val(val.GCCCountry);

                }
                $("#txtReason").val(val.Reason);
                $("#txtLoyaltyPoints").val(val.LoyaltyPointName);
                $("#txtGroup").val(val.GroupName);
                $("#txtAdvisorName").val(val.AdvisorName);
                $("#txtDiscountAllowedAmt").val(val.DiscountAllowedAmt);
                $("#txtDiscountAllowedPercentage").val(val.DiscountAllowedPercentage);
                $("#txtSource").val(val.SourceName);
                $("#txtGender").val(val.Gender);
                $("#txtSalesman").val(val.SalesmanName);
                $("#txtNationality").val(val.NationalityName);
                $("#txtIndividualorcompany").val(val.Individualorcompany);
               

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
// End Modal Popup----------------------------------------------------

//--------------Audit History-----------------------------------------
function LoadCustomerAuditDetails(suppId) {
    $.ajax({
        url: '/AuditMaster/GetCustomerDetails',
        type: "GET",
        dataType: "json",
        data: { SupplierID: suppId },
        success: function (result) {

            $('#tblSupplierDetails tbody').empty()
            $.each(result, function (i, val) {
                var row = "<tr>";
                row += "<td class='text-center'>" + (i + 1) + ".</td>"
                row += "<td>" + val.Code + "</td>"
                row += "<td>" + val.CompanyName + "</td>"
                row += "<td>" + val.CustomerName + "</td>"
                row += "<td>" + val.AccountName + "</td>"
                row += "<td>" + val.Mobile + "</td>"
                row += "<td>" + val.Email + "</td>"
                row += "<td>" + val.TRN + "</td>"
                row += "<td>" + val.CreationDate + "</td>"
                row += "<td>" + val.CreditDays + "</td>"
                row += "<td>" + val.CreditLimit + "</td>"
                row += "<td>" + val.VATCustomer + "</td>"
                row += "<td>" + val.CountryName + "</td>"
                row += "<td>" + val.UAE_Country + "</td>"
                row += "<td>" + val.GCCCountry + "</td>"
                row += "<td>" + val.UserName + "</td>"
                row += "<td>" + val.Action + "</td>"
                row += "<td>" + val.Status + "</td>"
                row += "<td>" + val.ActionDate + "</td>"

                row += "</tr>"
                $('#tblSupplierDetails tbody').append(row);

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
function LoadContact_Log(suppId) {

    $.ajax({
        url: '/AuditMaster/GetContactList',
        type: "GET",
        dataType: "json",
        data: { SupplierID: suppId },
        success: function (result) {

            $('#tblContact tbody').empty()
            $.each(result, function (i, val) {
                var row = "<tr>";
                row += "<td class='text-center'>" + (i + 1) + ".</td>"
                row += "<td>" + val.ContactPerson + "</td>"
                row += "<td>" + val.ContactNumber + "</td>"
                row += "<td>" + val.ContactEmail + "</td>"
                row += "<td>" + val.Desination + "</td>"
                row += "<td>" + val.ContactAction + "</td>"
                row += "<td>" + val.ContactActionDate + "</td>"
                row += "</tr>"
                $('#tblContact tbody').append(row);

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
function Load_CustomerAttachment(suppId) {
    $.ajax({
        url: '/AuditMaster/GetAttachmentList',
        type: "GET",
        dataType: "json",
        data: { SupplierID: suppId },
        success: function (result) {

            $('#tblAttachment tbody').empty()
            $.each(result, function (i, val) {
                var row = "<tr>";
                row += "<td class='text-center'>" + (i + 1) + ".</td>"
                row += "<td>" + val.Description + "</td>"
                row += "<td>" + val.ExpiryDate + "</td>"
                row += "<td>" + val.AttachmentAction + "</td>"

                row += "<td><a href='/AttachmentFile/" + val.AttachmentFile + "' id='LetterFile' target='_blank' class='btn btn-sm btn-primary edit-item-btn'> View File</a></td>"
                row += "<td>" + val.AttachmentActionDate + "</td>"
                row += "</tr>"
                $('#tblAttachment tbody').append(row);

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