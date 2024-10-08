
/*    Date Picker Statrt     */

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#JoiningDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#DateOfBirth").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#PassportIssueDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#PassportExpiryDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#VisaIssueDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#ResignationTerminationDate").datepicker(options);

/*    Date Picker Statrt     */

$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var EmployeeCode_ = $("#EmployeeCode").val();
    var EmployeeName_ = $("#EmployeeName").val();
    var Designation_ = $("#Designation").val();
    var ReportingManager_ = $("#ReportingManager").val();
    var DepartmentId_ = $("#DeptID").val();
    var JoiningDate_ = $("#JoiningDate").val();
    var BranchLocationId_ = $("#BranchId").val();
    var NationalityId_ = $("#NationalityId").val();
    var DateOfBirth_ = $("#DateOfBirth").val();
    var MaritalStatusId_ = $("#MaritalStatusId").val();
    var TypeId_ = $("#TypeId").val();
    var GenderBloodGroup_ = $("#GenderBloodGroup").val();
    var PassportNo_ = $("#PassportNo").val();
    var PassportIssueDate_ = $("#PassportIssueDate").val();
    var PassportExpiryDate_ = $("#PassportExpiryDate").val();
    var HomeCountryAirport_ = $("#HomeCountryAirport").val();
    var HomeCountryContactNumber1_ = $("#HomeCountryContactNumber1").val();
    var HomeCountryContactNumber2_ = $("#HomeCountryContactNumber2").val();
    var EmergencyContactNo_ = $("#EmergencyContactNo").val();
    var Email_ = $("#Email").val();
    var AccountNo_ = $("#AccountNo").val();
    var WPSDebitCardNumber_ = $("#WPSDebitCardNumber").val();
    var WPSExpiry_ = $("#WPSExpiry").val();
    var TotalLeavePerYear_ = $("#TotalLeavePerYear").val();
    var NoOfWorkingHours_ = $("#NoOfWorkingHours").val();
    var NoOfDays_ = $("#NoOfDays").val();
    var LabourCardNo_ = $("#LabourCardNo").val();
    var LabourCardExpiry_ = $("#LabourCardExpiry").val();
    var PersonCode_ = $("#PersonCode").val();
    var UAEContactNo1_ = $("#UAEContactNo1").val();
    var UAEContactNo2_ = $("#UAEContactNo2").val();
    var UAEAddress_ = $("#UAEAddress").val();
    var BasicSalary_ = $("#BasicSalary").val();
    var Transportation_ = $("#Transportation").val();
    var Accommodation_ = $("#Accommodation").val();
    var AdditionalAllowance_ = $("#AdditionalAllowance").val();
    var Standard_ = $("#Standard").val();
    var Skill_ = $("#Skill").val();
    var AccommodationAllowance_ = $("#AccommodationAllowance").val();
    var Cola_ = $("#Cola").val();
    var Education_ = $("#Education").val();
    var CarAllowance_ = $("#CarAllowance").val();
    var Telephone_ = $("#Telephone").val();
    var Others_ = $("#Others").val();
    var TotalSalary_ = $("#TotalSalary").val();
    var EmiratesID_ = $("#EmiratesID").val();
    var EmiratesIDExpiry_ = $("#EmiratesIDExpiry").val();
    var VisaUIDNo_ = $("#VisaUIDNo").val();
    var VisaFileNo_ = $("#VisaFileNo").val();
    var VisaPlaceOfIssue_ = $("#VisaPlaceOfIssue").val();
    var VisaIssueDate_ = $("#VisaIssueDate").val();
    var VisaExpiry_ = $("#VisaExpiry").val();
    var InsuranceProvider_ = $("#InsuranceProvider").val();
    var InsuranceNumber_ = $("#InsuranceNumber").val();
    var InsuranceExpiry_ = $("#InsuranceExpiry").val();
    var StatusId = $("#StatusId").val();
    var ResignationTerminationDate_ = $("#ResignationTerminationDate").val();
    var Remarks_ = $("#Remarks").val();
    var Organization_ = $("#Organization").val();
    var TicketIssuedPerYear_ = $("#TicketIssuedPerYear").val();

    //////////////////////////////////////////////////////////////////////////
    
    if (EmployeeCode_ != "" && EmployeeName_ != "") {

            if (confirm("Are you sure you want to continue ?")) {

                var fileUpload = $("#Photo").get(0);
                var files = fileUpload.files;

                var formData = new FormData();
                formData.append('EmployeeCode', $("#EmployeeCode").val());
                formData.append('EmployeeName', $("#EmployeeName").val());
                formData.append('Designation', $("#Designation").val());
                formData.append('ReportingManager', $("#ReportingManager").val());
                formData.append('DepartmentId', $("#DeptID").val());
                formData.append('JoiningDate', $("#JoiningDate").val());
                formData.append('BranchLocationId', $("#BranchId").val());
                formData.append('NationalityId', $("#NationalityId").val());
                formData.append('DateOfBirth', $("#DateOfBirth").val());
                formData.append('MaritalStatusId', $("#MaritalStatusId").val());
                formData.append('TypeId', $("#TypeId").val());
                formData.append('GenderBloodGroup', $("#GenderBloodGroup").val());
                formData.append('PassportNo', $("#PassportNo").val());
                formData.append('PassportIssueDate', $("#PassportIssueDate").val());
                formData.append('PassportExpiryDate', $("#PassportExpiryDate").val());
                formData.append('HomeCountryAirport', $("#HomeCountryAirport").val());
                formData.append('HomeCountryContactNumber1', $("#HomeCountryContactNumber1").val());
                formData.append('HomeCountryContactNumber2', $("#HomeCountryContactNumber2").val());
                formData.append('EmergencyContactNo', $("#EmergencyContactNo").val());
                formData.append('Email', $("#Email").val());
                formData.append('AccountNo', $("#AccountNo").val());
                formData.append('WPSDebitCardNumber', $("#WPSDebitCardNumber").val());
                formData.append('WPSExpiry', $("#WPSExpiry").val());
                formData.append('TotalLeavePerYear', $("#TotalLeavePerYear").val());
                formData.append('NoOfWorkingHours', $("#NoOfWorkingHours").val());
                formData.append('NoOfDays', $("#NoOfDays").val());
                formData.append('LabourCardNo', $("#LabourCardNo").val());
                formData.append('LabourCardExpiry', $("#LabourCardExpiry").val());
                formData.append('PersonCode', $("#PersonCode").val());
                formData.append('UAEContactNo1', $("#UAEContactNo1").val());
                formData.append('UAEContactNo2', $("#UAEContactNo2").val());
                formData.append('UAEAddress', $("#UAEAddress").val());
                formData.append('BasicSalary', $("#BasicSalary").val());
                formData.append('Transportation', $("#Transportation").val());
                formData.append('Accommodation', $("#Accommodation").val());
                formData.append('Cola', $("#Cola").val());
                formData.append('Education', $("#Education").val());
                formData.append('CarAllowance', $("#CarAllowance").val());
                formData.append('Telephone', $("#Telephone").val());
                formData.append('Others', $("#Others").val());
                formData.append('TotalSalary', $("#TotalSalary").val());
                formData.append('EmiratesID', $("#EmiratesID").val());
                formData.append('EmiratesIDExpiry', $("#EmiratesIDExpiry").val());
                formData.append('VisaUIDNo', $("#VisaUIDNo").val());
                formData.append('VisaFileNo', $("#VisaFileNo").val());
                formData.append('VisaPlaceOfIssue', $("#VisaPlaceOfIssue").val());
                formData.append('VisaIssueDate', $("#VisaIssueDate").val());
                formData.append('VisaExpiry', $("#VisaExpiry").val());
                formData.append('InsuranceProvider', $("#InsuranceProvider").val());
                formData.append('InsuranceNumber', $("#InsuranceNumber").val());
                formData.append('InsuranceExpiry', $("#InsuranceExpiry").val());
                formData.append('StatusId', $("#StatusId").val());
                formData.append('ResignationTerminationDate', $("#ResignationTerminationDate").val());
                formData.append('Remarks', $("#Remarks").val());
                formData.append('Organization', $("#Organization").val());
                formData.append('TicketIssuedPerYear', $("#TicketIssuedPerYear").val());
                formData.append('Photo', files[0]);
             
                $.ajax({
                    url: '/HRMS_Employee/SaveEmployee',
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
                        //else if (data.Result == "yes1") {
                        //    swal({
                        //        title: "Success",
                        //        text: "Records Successfully Updated",
                        //        type: "success",
                        //    }).then(function (isConfirm) {
                        //        if (isConfirm) {
                        //            /* window.location.reload();*/
                        //            window.location.href = '/HRMS_EmployeeDocuments/Index';
                        //        }
                        //        else {
                        //        }
                        //    });
                        //}
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

        if (EmployeeCode_ == "") {
            swal("Warning", "Please Enter Employee Code !", "warning");
                return false;
        }
        if (EmployeeName_ == "") {
            swal("Warning", "Please Enter Employee Name !", "warning");
            return false;
        }




        }
    


});



