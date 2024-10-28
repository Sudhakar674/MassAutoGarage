

function Reset() {
    window.location.href = "/HRMS_EmployeeFamilyDetails/EmployeeFamilyDetails";
}

$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var BranchId_ = $("#BranchId").val();
    var MotherName_ = $("#MotherName").val();
    var EmployeeName_ = $("#EmployeeName").val();
    var MaritalStatusId_ = $("#MaritalStatusId").val();
    var FatherName_ = $("#FatherName").val();
    var Photo_ = $("#Photo").val();
    var ID_ = $("#ID").val();


    if ($("#ID").val() != 0) {

        if (BranchId_ != "") {
            if (confirm("Are you sure you want to continue ?")) {

                var fileUpload = $("#Photo").get(0);
                var files = fileUpload.files;

                var formData = new FormData();
                formData.append('ID', $("#ID").val());
                formData.append('BranchId', $("#BranchId").val());
                formData.append('MotherName', $("#MotherName").val());
                formData.append('EmployeeName', $("#EmployeeName").val());
                formData.append('MaritalStatusId', $("#MaritalStatusId").val());
                formData.append('FatherName', $("#FatherName").val());
                formData.append('Photo', files[0]);

                $.ajax({
                    url: '/HRMS_EmployeeFamilyDetails/SaveEmployeeFamilyDetails',
                    type: 'POST',
                    contentType: false, // Not to set any content header
                    processData: false, // Not to process data
                    data: formData,
                    success: function (data) {
                        debugger;
                        if (data.Result == "yes") {
                            swal({
                                title: "Success",
                                text: "Records Successfully Saved",
                                type: "success",
                            }).then(function (isConfirm) {
                                if (isConfirm) {
                                    window.location.reload();
                                }
                                else {
                                }
                            });
                        }
                        else if (data.Result == "yes1") {
                            swal({
                                title: "Success",
                                text: "Records Successfully Updated",
                                type: "success",
                            }).then(function (isConfirm) {
                                if (isConfirm) {
                                    window.location.href = '/HRMS_EmployeeFamilyDetails/Index';
                                }
                                else {
                                }
                            });
                        }
                        else {
                            swal("Warning", "Record not save!", "warning");
                        }
                    },
                    error: function (httpResponse) {
                        swal("Warning", "Something Went to Wrong!", "warning");
                    }
                })
            }
        }
        else {
            if (BranchId_ == "") {
                swal("Warning", "Please Enter Branch !", "warning");
                return false;
            }
        }
    }
    else {

        if (BranchId_ != "" && MotherName_ != "" && EmployeeName_ != "" && MaritalStatusId_ != "" && FatherName_ != "" && Photo_ != "") {
            if (confirm("Are you sure you want to continue ?")) {

                var fileUpload = $("#Photo").get(0);
                var files = fileUpload.files;

                var formData = new FormData();
                formData.append('ID', $("#ID").val());
                formData.append('BranchId', $("#BranchId").val());
                formData.append('MotherName', $("#MotherName").val());
                formData.append('EmployeeName', $("#EmployeeName").val());
                formData.append('MaritalStatusId', $("#MaritalStatusId").val());
                formData.append('FatherName', $("#FatherName").val());
                formData.append('Photo', files[0]);

                $.ajax({
                    url: '/HRMS_EmployeeFamilyDetails/SaveEmployeeFamilyDetails',
                    type: 'POST',
                    contentType: false, // Not to set any content header
                    processData: false, // Not to process data
                    data: formData,
                    success: function (data) {
                        debugger;
                        if (data.Result == "yes") {
                            swal({
                                title: "Success",
                                text: "Records Successfully Saved",
                                type: "success",
                            }).then(function (isConfirm) {
                                if (isConfirm) {
                                    window.location.reload();
                                }
                                else {
                                }
                            });
                        }
                        else if (data.Result == "yes1") {
                            swal({
                                title: "Success",
                                text: "Records Successfully Updated",
                                type: "success",
                            }).then(function (isConfirm) {
                                if (isConfirm) {
                                    window.location.href = '/HRMS_EmployeeFamilyDetails/Index';
                                }
                                else {
                                }
                            });
                        }
                        else {
                            swal("Warning", "Record not save!", "warning");
                        }
                    },
                    error: function (httpResponse) {
                        swal("Warning", "Something Went to Wrong!", "warning");
                    }
                })
            }
        }
        else {
            if (BranchId_ == "") {
                swal("Warning", "Please Enter Branch !", "warning");
                return false;
            }
            if (MotherName_ == "") {
                swal("Warning", "Please Enter Mother Name !", "warning");
                return false;
            }
            if (EmployeeName_ == "") {
                swal("Warning", "Please Enter Employee Name !", "warning");
                return false;
            }
            if (MaritalStatusId_ == "") {
                swal("Warning", "Please Enter Marital Status !", "warning");
                return false;
            }
            if (FatherName_ == "") {
                swal("Warning", "Please Enter Father Name !", "warning");
                return false;
            }
            if (Photo_ == "") {
                swal("Warning", "Please Enter Photo !", "warning");
                return false;
            }
        }
    }







});



function DeleteEmployeeFamilyDetails(Id) {
    /*alert(Id);*/
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_EmployeeFamilyDetails/DeleteEmployeeFamilyDetails',
            data: { ID: Id },
            dataType: 'json',
            success: function (data) {
                if (data.Result == "yes") {
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
                }
                else {
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
    else {
        return false;
    }

}

$('#EmployeeName').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});
$('#FatherName').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});
$('#MotherName').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});
