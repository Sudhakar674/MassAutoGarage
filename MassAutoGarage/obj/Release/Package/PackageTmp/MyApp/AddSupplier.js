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
                debugger;
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


$(document).on("click", ".DeleteTr", function () {

    if (confirm("Are you sure you want to remove ?")) {

        $(this).parents("tr").remove();
        calculat();
    }
})

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

$(document).on("click", ".DeleteContactTr", function () {

    if (confirm("Are you sure you want to remove ?")) {

        $(this).parents("tr").remove();

    }
})

$("#btnSave").click(function () {
    debugger;

    $("#divLoader").show();
    var _HDFID = $("#HDFID").val();
    var _Code = $("#Code").val();
    var _CompanyID = $("#CompanyID option:selected").val();
    var _SupplierName = $("#SupplierName").val();
    var _AccountName = $("#AccountName").val();
    var _LandlineNumber = $("#LandlineNumber").val();
    var _Mobile = $("#Mobile").val();
    var _Email = $("#Email").val();
    var _TRN = $("#TRN").val();
    var _IsActive = $("#IsActive option:selected").val();

    var _Address = $("#Address").val();
    var _CreationDate = $("#CreationDate").val();
    var _CreditDays = $("#CreditDays").val();
    var _CreditLimit = $("#CreditLimit").val();
    var _Block = $("#Block").val();
    var _TradeLicenceExpiry = $("#TradeLicenceExpiry").val();
    var _VATSupplierID = $("#VATSupplierID option:selected").val();


    var _InternationalID = $("#InternationalID option:selected").val();
    var _UAEID = $("#UAEID option:selected").val();
    var _GCCID = $("#GCCID option:selected").val();
    var _Reason = $("#Reason").val();
    var _CurrentCount = $("#HDFCurrentCount").val();



    var tableLength = $("#example tr").length;
    var tableLength2 = $("#tblContact tr").length;
    var ProductListArr = [];

    if (_Code != "" && _CompanyID != "" && _SupplierName != "" && _AccountName != "" && _Mobile != "" && _Email != "" && _TRN != "" && _Address != "" && _CreationDate != "" && tableLength2 > 1 && tableLength > 1) {

        if (tableLength > 1) {

            for (var i = 0; i < tableLength - 1; i++) {

                var ProductList = {
                    ID: _HDFID,
                    Code: _Code,
                    CompanyID: _CompanyID,
                    SupplierName: _SupplierName,
                    AccountName: _AccountName,
                    LandlineNumber: _LandlineNumber,
                    Mobile: _Mobile,
                    Email: _Email,
                    TRN: _TRN,
                    IsActive: _IsActive,
                    Address: _Address,
                    CreationDate: _CreationDate,
                    CreditDays: _CreditDays,
                    CreditLimit: _CreditLimit,
                    Block: _Block,
                    TradeLicenceExpiry: _TradeLicenceExpiry,
                    VATSupplierID: _VATSupplierID,
                    InternationalID: _InternationalID,
                    UAEID: _UAEID,
                    GCCID: _GCCID,
                    Reason: _Reason,
                    CurrentCount: _CurrentCount,
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
                    SupplierName: _SupplierName,
                    AccountName: _AccountName,
                    LandlineNumber: _LandlineNumber,
                    Mobile: _Mobile,
                    Email: _Email,
                    TRN: _TRN,
                    IsActive: _IsActive,
                    Address: _Address,
                    CreationDate: _CreationDate,
                    CreditDays: _CreditDays,
                    CreditLimit: _CreditLimit,
                    Block: _Block,
                    TradeLicenceExpiry: _TradeLicenceExpiry,
                    VATSupplierID: _VATSupplierID,
                    InternationalID: _InternationalID,
                    UAEID: _UAEID,
                    GCCID: _GCCID,
                    Reason: _Reason,
                    CurrentCount: _CurrentCount,
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
                url: '/SupplierMaster/InsertUpdateSupplier',
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
                                var url = "/SupplierMaster/SupplierDetails";
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
                                var url = "/SupplierMaster/SupplierDetails";
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