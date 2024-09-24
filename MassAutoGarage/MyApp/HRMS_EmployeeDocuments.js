
function Reset() {
    window.location.href = "/HRMS_EmployeeDocuments/EmployeeDocuments";
}

$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var FK_BranchId_ = $("#FK_BranchId").val();
    var EmployeeName_ = $("#EmployeeName").val();
    var Files_ = $("#files").val();
    var EmirateFile_ = $("#EmirateFile").val();
    var PassportFile_ = $("#PassportFile").val();
    var VisaFile_ = $("#VisaFile").val();
    var InsuranceFile_ = $("#InsuranceFile").val();
    var EmpCardFile_ = $("#EmpCardFile").val();

    if (FK_BranchId_ != "" && EmployeeName_ != "" && Files_ != "" && EmirateFile_ != "" && PassportFile_ != "" && VisaFile_ != "" && InsuranceFile_ != "" && EmpCardFile_ != "") {

        var EmployeeDocumentsDetails = {
            FK_BranchId: FK_BranchId_,
            EmployeeName: EmployeeName_,
            files: files,
            EmirateFile: EmirateFile_,
            PassportFile: PassportFile_,
            VisaFile: VisaFile_,
            InsuranceFile: InsuranceFile_,
            EmpCardFile: EmpCardFile_
        };

        if (confirm("Are you sure you want to continue ?")) {

            var fileUpload = $("#files").get(0);
            var files = fileUpload.files;

            var UploadEmirateFile = $("#EmirateFile").get(0);
            var EmirateFile = UploadEmirateFile.files;

            var UploadPassportFile = $("#PassportFile").get(0);
            var PassportFile = UploadPassportFile.files;

            var UploadVisaFile = $("#VisaFile").get(0);
            var VisaFile = UploadVisaFile.files;

            var UploadInsuranceFile = $("#InsuranceFile").get(0);
            var InsuranceFile = UploadInsuranceFile.files;

            var UploadEmpCardFile = $("#EmpCardFile").get(0);
            var EmpCardFile = UploadEmpCardFile.files;

            var formData = new FormData();
            formData.append('FK_BranchId', $("#FK_BranchId").val());
            formData.append('EmployeeName', $("#EmployeeName").val());
            formData.append('files', files[0]);
            formData.append('EmirateFile', EmirateFile[0]);
            formData.append('PassportFile', PassportFile[0]);
            formData.append('VisaFile', VisaFile[0]);
            formData.append('InsuranceFile', InsuranceFile[0]);
            formData.append('EmpCardFile', EmpCardFile[0]);

              $.ajax({
                    url:'/HRMS_EmployeeDocuments/SaveEmployeeDocuments',
                    type:'POST',
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
                                window.location.reload();
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

        if (FK_BranchId_ == "") {
            swal("Warning", "Please Enter Branch !", "warning");
            return false;
        }
        if (EmployeeName_ == "") {
            swal("Warning", "Please Enter Employee !", "warning");
            return false;
        }
        if (Files_ == "") {
            swal("Warning", "Please Photo Upload !", "warning");
            return false;
        }
        if (EmirateFile_ == "") {
            swal("Warning", "Please EmiratesID Upload  !", "warning");
            return false;
        }
        if (PassportFile_ == "") {
            swal("Warning", "Please Passport Upload  !", "warning");
            return false;
        }
        if (VisaFile_ == "") {
            swal("Warning", "Please Visa  Upload  !", "warning");
            return false;
        }
        if (InsuranceFile_ == "") {
            swal("Warning", "Please Insurance Card Upload  !", "warning");
            return false;
        }
        if (EmployeeContactCardFile_ == "") {
            swal("Warning", "Please Employee Contract Card  Upload  !", "warning");
            return false;
        }
    }
});

function EmployeeDocumentsList() {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HRMS_EmployeeDocuments/EmployeeDocumentsList",
        data: "{}",
        dataType: "json",
        success: function (result) {
            $.each(result, function (i, v) {
                debugger;
                var tableLength = $("#tBodyId tr").length;

                var SerialNo = tableLength + 1;
                var tr = "<tr>";
                tr += "<td>" + SerialNo + "</td>";
                tr += "<td style='Display:none' class='EmpDocId_" + v.EmpDocId + "'>" + v.EmpDocId + "</td>";
                tr += "<td style='Display:none' class='FK_BranchId_" + v.EmpDocId + "'>" + v.FK_BranchId + "</td>";
                tr += "<td class='BranchName_" + v.EmpDocId + "'>" + v.BranchName + "</td>";
                tr += "<td class='EmployeeName_" + v.EmpDocId + "'>" + v.EmployeeName + "</td>";
                tr += "<td>" + v.files +"</td>";


              /*  tr += "<td>" + <img src='/Images/PhotoFile/v.files'></img>+"</td>";*/
                tr += "<td class='EmirateFile_" + v.EmpDocId + "'>" + v.EmirateFile + "</td>";
                tr += "<td class='PassportFile_" + v.EmpDocId + "'>" + v.PassportFile + "</td>";
                tr += "<td class='VisaFile_" + v.EmpDocId + "'>" + v.VisaFile + "</td>";
                tr += "<td class='InsuranceFile_" + v.EmpDocId + "'>" + v.InsuranceFile + "</td>";
                tr += "<td class='EmpCardFile_" + v.EmpDocId + "'>" + v.EmpCardFile + "</td>";

                tr += "<td><a onclick='return EditEmployeeDocuments(" + v.EmpDocId + ")' class='btn btn-sm btn-success edit-item-btn'>Edit<i class='fa fa-edit'></i></a> <a onclick='return DeleteEmployeeDocuments(" + v.EmpDocId + ")' class='btn btn-sm btn-danger remove-item-btn DeleteContactTr'><i class='fa fa-trash' aria-hidden='true'></i>Delete</a></td>";
                tr += "</tr>";
                $("#tBodyId").append(tr);
            });
        }
    });
}



function DeleteEmployeeDocuments(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_EmployeeDocuments/DeleteEmployeeDocuments',
            data: { EmpDocId: Id },
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