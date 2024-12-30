



function onlyAlphabets(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 32))
            return true;
        else
            return false;
    }
    catch (err) {
        alert(err.Description);
    }
}

function isNumberOrDecimal(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function isNumberKey(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#Date").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#DateOfJoining").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#LeaveFromDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#LeaveToDate").datepicker(options);



//var option = document.getElementsByName('MedicalCertificate');

//if (!(option[0].checked || option[1].checked)) {
//    alert("Please Select Your Gender");
//    return false;
//}

//if (!document.getElementByID("MedicalCertificateNo").checked && !document.getElementByID("MedicalCertificateYes").checked) {
//    alert("Please specify gender");
//    return;
//}


////////////////////////////////////////////////////////////////////////////////////////////////
$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var _VoucherNo = $("#VoucherNo").val();
    var _EmployeeId = $("#EmployeeId").val();
    var _Date = $("#Date").val();
    var _DesignationId = $("#DesignationId").val();
    var _EmpNo = $("#EmpNo").val();
    var _CompanyID = $("#CompanyID").val();
    var _DepartmentId = $("#DepartmentId").val();
    var _BranchId = $("#BranchId").val();
    var _DateOfJoining = $("#DateOfJoining").val();

    var MarriageLeave = $("input[name=MarriageLeave]:checked").val();
    if (MarriageLeave == "true") {
        var _MarriageLeave = "true";
    }
    else {
        var _MarriageLeave = "false";
    }

    var AnnualLeave = $("input[name=AnnualLeave]:checked").val();
    if (AnnualLeave == "true") {
        var _AnnualLeave = "true";
    }
    else {
        var _AnnualLeave = "false";
    }

    var AuthorizedUnpaidLeave = $("input[name=AuthorizedUnpaidLeave]:checked").val();
    if (AuthorizedUnpaidLeave == "true") {
        var _AuthorizedUnpaidLeave = "true";
    }
    else {
        var _AuthorizedUnpaidLeave = "false";
    }

    var EmergencyLeave = $("input[name=EmergencyLeave]:checked").val();
    if (EmergencyLeave == "true") {
        var _EmergencyLeave = "true";
    }
    else {
        var _EmergencyLeave = "false";
    }

    var SickLeave = $("input[name=SickLeave]:checked").val();
    if (SickLeave == "true") {
        var _SickLeave = "true";
    }
    else {
        var _SickLeave = "false";
    }

    var MaternityLeave = $("input[name=MaternityLeave]:checked").val();
    if (MaternityLeave == "true") {
        var _MaternityLeave = "true";
    }
    else {
        var _MaternityLeave = "false";
    }

    var Others = $("input[name=Others]:checked").val();
    if (Others == "true") {
        var _Others = "true";
    }
    else {
        var _Others = "false";
    }
    var _PleaseSpecifyOtherLeave = $("#PleaseSpecifyOtherLeave").val();

    var LocalLeave = $("input[name=LocalLeave]:checked").val();
    if (LocalLeave == "true") {
        var _LocalLeave = "true";
    }
    else {
        var _LocalLeave = "false";
    }

    var _LeaveFromDate = $("#LeaveFromDate").val();
    var _LeaveToDate = $("#LeaveToDate").val();
    var _AirportName = $("#AirportName").val();
    var _FromAirportName = $("#FromAirportName").val();
    var _ToAirportName = $("#ToAirportName").val();
    var _ReasonforSickLeave = $("#ReasonforSickLeave").val();

    var MedicalCertificate = $("#MedicalCertificate").val();
    var _MedicalCertificateFile = $("#MedicalCertificateFile").val();

    var _HDF_MedicalCertificateFile = $("#HDF_MedicalCertificateFile").val();

    

    if (MedicalCertificate == "1" && _MedicalCertificateFile != "") {
        _MedicalCertificate = 1;
        /*_MedicalCertificate = "true";*/
    }
    else {
        /*_MedicalCertificate = "false";*/
        _MedicalCertificate = 0;
    }

    var _Email = $("#Email").val();
    var _MobileNo = $("#MobileNo").val();
    var _Idincrept = $("#Idincrept").val();


    //////////////////////////////////////////////////////////////////////////

  /*  if (_EmployeeId != "" && _Date != "" && _DesignationId != "" && _EmpNo != "" && _CompanyID != "" && _DepartmentId != "" && _BranchId != "" && _DateOfJoining != "" && _LeaveFromDate != "" && _LeaveToDate != "" && _AirportName != "" && _FromAirportName != "" && _ToAirportName != "" && _ReasonforSickLeave != "" && !document.getElementById("MedicalCertificateNo").checked && !document.getElementById("MedicalCertificateYes").checked && _Email != "" && _MobileNo != "") {*/

    if (_EmployeeId != "" && _Date != "" && _DesignationId != "" && _EmpNo != "" && _CompanyID != "" && _DepartmentId != "" && _BranchId != "" && _DateOfJoining != "" && _LeaveFromDate != "" && _LeaveToDate != "" && _AirportName != "" && _FromAirportName != "" && _ToAirportName != "" && _ReasonforSickLeave != "" && _Email != "" && _MobileNo != "") {
    /*if (_EmployeeId != "" && _Date != "" && _DesignationId != "") {*/

        if (confirm("Are you sure you want to continue ?")) {

            var fileUpload = $("#MedicalCertificateFile").get(0);
            var files = fileUpload.files;

            var formData = new FormData();
            
            formData.append('Idincrept', _Idincrept);
            formData.append('VoucherNo', _VoucherNo);
            formData.append('EmployeeId', _EmployeeId);
            formData.append('Date', _Date);
            formData.append('DesignationId', _DesignationId);
            formData.append('EmpNo', _EmpNo);
            formData.append('CompanyID', _CompanyID);
            formData.append('DepartmentId', _DepartmentId);
            formData.append('BranchId', _BranchId);
            formData.append('DateOfJoining', _DateOfJoining);
            formData.append('MarriageLeave', _MarriageLeave);
            formData.append('AnnualLeave', _AnnualLeave);
            formData.append('AuthorizedUnpaidLeave', _AuthorizedUnpaidLeave);
            formData.append('EmergencyLeave', _EmergencyLeave);
            formData.append('SickLeave', _SickLeave);
            formData.append('MaternityLeave', _MaternityLeave);
            formData.append('Others', _Others);
            formData.append('PleaseSpecifyOtherLeave', _PleaseSpecifyOtherLeave);
            formData.append('LocalLeave', _LocalLeave);
            formData.append('LeaveFromDate', _LeaveFromDate);
            formData.append('LeaveToDate', _LeaveToDate);
            formData.append('AirportName', _AirportName);
            formData.append('FromAirportName', _FromAirportName);
            formData.append('ToAirportName', _ToAirportName);
            formData.append('ReasonforSickLeave', _ReasonforSickLeave);
            formData.append('MedicalCertificate', _MedicalCertificate);
            formData.append('Email', _Email);
            formData.append('MobileNo', _MobileNo);
            formData.append('MedicalCertificateFile', files[0]);
            formData.append('HDF_MedicalCertificateFile', _HDF_MedicalCertificateFile);
            $.ajax({
                url: '/HR_LeaveRequest/SaveLeaveRequest',
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
                                /* window.location.reload();*/
                                window.location.href = '/HR_LeaveRequest/LeaveRequest';
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
        if (_EmployeeId == "") {
            swal("Warning", "Please Select Employee Name !", "warning");
            return false;
        }
        if (_Date == "") {
            swal("Warning", "Please Enter Date !", "warning");
            return false;
        }
        if (_DesignationId == "") {
            swal("Warning", "Please Select Designation !", "warning");
            return false;
        }
        if (_EmpNo == "") {
            swal("Warning", "Please Enter EmpNo !", "warning");
            return false;
        }
        if (_CompanyID == "") {
            swal("Warning", "Please Select Company !", "warning");
            return false;
        }
        if (_DepartmentId == "") {
            swal("Warning", "Please Select Department !", "warning");
            return false;
        }
        if (_BranchId == "") {
            swal("Warning", "Please Select Branch !", "warning");
            return false;
        }
        if (_DateOfJoining == "") {
            swal("Warning", "Please Enter Date Of Joining !", "warning");
            return false;
        }
        if (_LeaveFromDate == "") {
            swal("Warning", "Please Enter From Date !", "warning");
            return false;
        }
        if (_LeaveToDate == "") {
            swal("Warning", "Please Enter To Date !", "warning");
            return false;
        }
        if (_AirportName == "") {
            swal("Warning", "Please Enter Airport Name !", "warning");
            return false;
        }
        if (_FromAirportName == "") {
            swal("Warning", "Please Enter AirPort From Name !", "warning");
            return false;
        }
        if (_ToAirportName == "") {
            swal("Warning", "Please Enter AirPort To Name !", "warning");
            return false;
        }
        if (_ReasonforSickLeave == "") {
            swal("Warning", "Please Enter Reason For Sick Leave !", "warning");
            return false;
        }
        //if (!document.getElementById("MedicalCertificateNo").checked && !document.getElementById("MedicalCertificateYes").checked) {

        //    swal("Warning", "Please Choose Medical Certificate !", "warning");
        //    return false;
        //    //debugger;
        //    //if (MedicalCertificate == "on" && _MedicalCertificateFile == "") {
        //    //    swal("Warning", "Please Upload Medical Certificate !", "warning");
        //    //    return false;
        //    //}                  
        //}
        if (_Email == "") {
            swal("Warning", "Please Enter Email Id !", "warning");
            return false;
        }
        if (_MobileNo == "") {
            swal("Warning", "Please Enter Mobile Number !", "warning");
            return false;
        }
    }
});

////////////////////////////////////////////////////////////////////////////////////////////////////


function DeleteLeaveRequest(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_LeaveRequest/DeleteLeaveRequest',
            data: { Id: Id },
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




//$("#btnsave555").click(function (e) {
//    debugger;
//    e.preventDefault();
//    var _VoucherNo = $("#VoucherNo").val();
//    var _EmployeeId = $("#EmployeeId").val();
//    var _Date = $("#Date").val();
//    var _DesignationId = $("#DesignationId").val();

//    var fileUpload = $("#MedicalCertificateFile").get(0);
//    var MedicalCertificateFile = fileUpload.files[0];


//    var MarriageLeave = $("input[name=MarriageLeave]:checked").val();
//    if (MarriageLeave == "true") {
//        var _MarriageLeave = 1;
//    }
//    else {
//        var _MarriageLeave = 0;
//    }

//    if (_EmployeeId != "") {

//        var GeneralRequestDetails = {
//            VoucherNo: _VoucherNo,
//            EmployeeId: _EmployeeId,
//            Date: _Date,
//            DesignationId: _DesignationId,
//            MarriageLeave: _MarriageLeave
//            /*MedicalCertificateFile: files[0]*/
//        };

//        if (confirm("Are you sure you want to continue ?")) {

//            $.ajax({
//                type: 'POST',
//                url: '/HR_LeaveRequest/SaveLeaveRequest',
//                data: JSON.stringify(GeneralRequestDetails),
//                contentType: "application/json; charset=utf-8",
//                processData: false, // Not to process data
//                dataType: 'json',
//                success: function (data) {
//                    debugger;
//                    if (data.Result == "yes") {
//                        swal({
//                            title: "Success",
//                            text: "Records Successfully Saved",
//                            type: "success",
//                        }).then(function (isConfirm) {
//                            if (isConfirm) {
//                                window.location.reload();
//                            }
//                            else {

//                            }
//                        });
//                    }
//                    else if (data.Result == "yes1") {
//                        swal({
//                            title: "Success",
//                            text: "Records Successfully Updated",
//                            type: "success",
//                        }).then(function (isConfirm) {
//                            if (isConfirm) {
//                                window.location.href = '/HR_GeneralRequest/GeneralRequest';
//                            }
//                            else {

//                            }
//                        });
//                    }
//                    else {
//                        swal("Warning", "Record not save!", "warning");
//                    }
//                },
//                error: function (httpResponse) {
//                    swal("Warning", "Something Went to Wrong!", "warning");
//                }
//            })
//        }
//    }
//    else {
//        if (_EmployeeId == "") {
//            swal("Warning", "Please Enter Employee Name !", "warning");
//            return false;
//        }
//    }
//});