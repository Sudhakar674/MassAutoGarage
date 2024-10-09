
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

/*    Validation Statrt     */

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
function isNumberOrDecimal(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
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

/*    Validation end     */


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
            formData.append('AdditionalAllowance', $("#AdditionalAllowance").val());
            formData.append('Standard', $("#Standard").val());
            formData.append('Skill', $("#Skill").val());
            formData.append('AccommodationAllowance', $("#AccommodationAllowance").val());
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


function EmployeeList() {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HRMS_Employee/EmployeeList",
        data: "{}",
        dataType: "json",
        success: function (result) {
            $.each(result, function (i, v) {
                debugger;
                var tableLength = $("#tBodyId tr").length;
                var SerialNo = tableLength + 1;
                var tr = "<tr>";
                tr += "<td>" + SerialNo + "</td>";
                tr += "<td style='Display:none'  class='EmployeeId_" + v.EmployeeId + "'>" + v.EmployeeId + "</td>";
                tr += "<td class='EmployeeCode_" + v.EmployeeId + "'>" + v.EmployeeCode + "</td>";
                tr += "<td class='EmployeeName_" + v.EmployeeId + "'>" + v.EmployeeName + "</td>";
                tr += "<td class='Designation_" + v.EmployeeId + "'>" + v.Designation + "</td>";
                tr += "<td class='ReportingManager_" + v.EmployeeId + "'>" + v.ReportingManager + "</td>";
                tr += "<td style='Display:none'  class='DeptID_" + v.EmployeeId + "'>" + v.DeptID + "</td>";
                tr += "<td style='Display:none' class='DepartmentName_" + v.EmployeeId + "'>" + v.DepartmentName + "</td>";
                tr += "<td style='Display:none' class='JoiningDate_" + v.EmployeeId + "'>" + v.JoiningDate + "</td>";
                tr += "<td style='Display:none' class='BranchId_" + v.EmployeeId + "'>" + v.BranchId + "</td>";
                tr += "<td style='Display:none' class='BranchName_" + v.EmployeeId + "'>" + v.BranchName + "</td>";
                tr += "<td style='Display:none' class='NationalityId_" + v.EmployeeId + "'>" + v.NationalityId + "</td>";
                tr += "<td style='Display:none' class='Nationality_" + v.EmployeeId + "'>" + v.Nationality + "</td>";
                tr += "<td style='Display:none' class='DateOfBirth_" + v.EmployeeId + "'>" + v.DateOfBirth + "</td>";
                tr += "<td style='Display:none' class='MaritalStatusId_" + v.EmployeeId + "'>" + v.MaritalStatusId + "</td>";
                tr += "<td style='Display:none' class='MaritalStatus_" + v.EmployeeId + "'>" + v.MaritalStatus + "</td>";
                tr += "<td style='Display:none' class='GenderBloodGroup_" + v.EmployeeId + "'>" + v.GenderBloodGroup + "</td>";
                tr += "<td style='Display:none' class='PassportNo_" + v.EmployeeId + "'>" + v.PassportNo + "</td>";
                tr += "<td style='Display:none' class='PassportIssueDate_" + v.EmployeeId + "'>" + v.PassportIssueDate + "</td>";
                tr += "<td style='Display:none' class='PassportExpiryDate_" + v.EmployeeId + "'>" + v.PassportExpiryDate + "</td>";
                tr += "<td style='Display:none' class='HomeCountryAirport_" + v.EmployeeId + "'>" + v.HomeCountryAirport + "</td>";
                tr += "<td style='Display:none' class='HomeCountryContactNumber1_" + v.EmployeeId + "'>" + v.HomeCountryContactNumber1 + "</td>";
                tr += "<td style='Display:none' class='HomeCountryContactNumber2_" + v.EmployeeId + "'>" + v.HomeCountryContactNumber2 + "</td>";
                tr += "<td style='Display:none' class='EmergencyContactNo_" + v.EmployeeId + "'>" + v.EmergencyContactNo + "</td>";
                tr += "<td style='Display:none' class='Email_" + v.EmployeeId + "'>" + v.Email + "</td>";
                tr += "<td style='Display:none' class='AccountNo_" + v.EmployeeId + "'>" + v.AccountNo + "</td>";
                tr += "<td style='Display:none' class='WPSDebitCardNumber_" + v.EmployeeId + "'>" + v.WPSDebitCardNumber + "</td>";
                tr += "<td style='Display:none' class='WPSExpiry_" + v.EmployeeId + "'>" + v.WPSExpiry + "</td>";
                tr += "<td style='Display:none' class='TotalLeavePerYear_" + v.EmployeeId + "'>" + v.TotalLeavePerYear + "</td>";
                tr += "<td style='Display:none' class='NoOfWorkingHours_" + v.EmployeeId + "'>" + v.NoOfWorkingHours + "</td>";
                tr += "<td style='Display:none' class='NoOfDays_" + v.EmployeeId + "'>" + v.NoOfDays + "</td>";
                tr += "<td style='Display:none' class='LabourCardNo_" + v.EmployeeId + "'>" + v.LabourCardNo + "</td>";
                tr += "<td style='Display:none' class='LabourCardExpiry_" + v.EmployeeId + "'>" + v.LabourCardExpiry + "</td>";
                tr += "<td style='Display:none' class='PersonCode_" + v.EmployeeId + "'>" + v.PersonCode + "</td>";
                tr += "<td style='Display:none' class='UAEContactNo1_" + v.EmployeeId + "'>" + v.UAEContactNo1 + "</td>";
                tr += "<td style='Display:none' class='UAEContactNo2_" + v.EmployeeId + "'>" + v.UAEContactNo2 + "</td>";
                tr += "<td style='Display:none' class='UAEAddress_" + v.EmployeeId + "'>" + v.UAEAddress + "</td>";
                tr += "<td style='Display:none' class='BasicSalary_" + v.EmployeeId + "'>" + v.BasicSalary + "</td>";
                tr += "<td style='Display:none' class='Transportation_" + v.EmployeeId + "'>" + v.Transportation + "</td>";
                tr += "<td style='Display:none' class='Accommodation_" + v.EmployeeId + "'>" + v.Accommodation + "</td>";
                tr += "<td style='Display:none' class='AdditionalAllowance_" + v.EmployeeId + "'>" + v.AdditionalAllowance + "</td>";
                tr += "<td style='Display:none' class='Standard_" + v.EmployeeId + "'>" + v.Standard + "</td>";
                tr += "<td style='Display:none' class='Skill_" + v.EmployeeId + "'>" + v.Skill + "</td>";
                tr += "<td style='Display:none' class='AccommodationAllowance_" + v.EmployeeId + "'>" + v.AccommodationAllowance + "</td>";
                tr += "<td style='Display:none' class='Cola_" + v.EmployeeId + "'>" + v.Cola + "</td>";
                tr += "<td style='Display:none' class='Education_" + v.EmployeeId + "'>" + v.Education + "</td>";
                tr += "<td style='Display:none' class='CarAllowance_" + v.EmployeeId + "'>" + v.CarAllowance + "</td>";
                tr += "<td style='Display:none' class='Telephone_" + v.EmployeeId + "'>" + v.Telephone + "</td>";
                tr += "<td style='Display:none' class='Others_" + v.EmployeeId + "'>" + v.Others + "</td>";
                tr += "<td style='Display:none' class='TotalSalary_" + v.EmployeeId + "'>" + v.TotalSalary + "</td>";
                tr += "<td style='Display:none' class='EmiratesID_" + v.EmployeeId + "'>" + v.EmiratesID + "</td>";
                tr += "<td style='Display:none' class='EmiratesIDExpiry_" + v.EmployeeId + "'>" + v.EmiratesIDExpiry + "</td>";
                tr += "<td style='Display:none' class='VisaUIDNo_" + v.EmployeeId + "'>" + v.VisaUIDNo + "</td>";
                tr += "<td style='Display:none' class='VisaFileNo_" + v.EmployeeId + "'>" + v.VisaFileNo + "</td>";
                tr += "<td style='Display:none' class='VisaPlaceOfIssue_" + v.EmployeeId + "'>" + v.VisaPlaceOfIssue + "</td>";
                tr += "<td style='Display:none' class='VisaIssueDate_" + v.EmployeeId + "'>" + v.VisaIssueDate + "</td>";
                tr += "<td style='Display:none' class='VisaExpiry_" + v.EmployeeId + "'>" + v.VisaExpiry + "</td>";
                tr += "<td style='Display:none' class='InsuranceProvider_" + v.EmployeeId + "'>" + v.InsuranceProvider + "</td>";
                tr += "<td style='Display:none' class='InsuranceNumber_" + v.EmployeeId + "'>" + v.InsuranceNumber + "</td>";
                tr += "<td style='Display:none' class='InsuranceExpiry_" + v.EmployeeId + "'>" + v.InsuranceExpiry + "</td>";
                tr += "<td style='Display:none' class='StatusId_" + v.EmployeeId + "'>" + v.StatusId + "</td>";
                tr += "<td style='Display:none' class='Status_" + v.EmployeeId + "'>" + v.Status + "</td>";
                tr += "<td style='Display:none' class='ResignationTerminationDate_" + v.EmployeeId + "'>" + v.ResignationTerminationDate + "</td>";
                tr += "<td style='Display:none' class='Remarks_" + v.EmployeeId + "'>" + v.Remarks + "</td>";
                tr += "<td style='Display:none' class='Organization_" + v.EmployeeId + "'>" + v.Organization + "</td>";
                tr += "<td style='Display:none' class='TicketIssuedPerYear_" + v.EmployeeId + "'>" + v.TicketIssuedPerYear + "</td>";
                tr += "<td style='Display:none' class='Photo_" + v.EmployeeId + "'>" + "<img src='" + v.Photo + "'/>" + "</td>";
                /*---------------------------------------------End----------------------------------------------------*/
                /*  tr += "<td>" + "<img src='" + v.Photo + "' style='height:90px;width:90px;'/>" + "</td>";*/
                tr += "<td><a onclick='return ViewEmployeeDetails(" + v.EmployeeId + ")' class='btn btn-sm btn-primary edit-item-btn'>View<i class='fa fa-eye'></i></a> <a onclick='return EditEmployee(" + v.EmployeeId + ")' class='btn btn-sm btn-success edit-item-btn'>Edit<i class='fa fa-edit'></i></a> <a onclick='return DeleteEmployee(" + v.EmployeeId + ")' class='btn btn-sm btn-danger remove-item-btn DeleteContactTr'><i class='fa fa-trash' aria-hidden='true'></i>Delete</a></td>";
                tr += "</tr>";
                $("#tBodyId").append(tr);
            });
        }
    });
}



function ViewEmployeeDetails(Id) {
    debugger;

    var EmployeeId_ = $(".EmployeeId_" + Id).text();
    var EmployeeCode_ = $(".EmployeeCode_" + Id).text();
    var EmployeeName_ = $(".EmployeeName_" + Id).text();
    var Designation_ = $(".Designation_" + Id).text();
    var ReportingManager_ = $(".ReportingManager_" + Id).text();



    $("#EmployeeCode").text(EmployeeCode_);
    $("#EmployeeName").text(EmployeeName_);
    $("#Designation").text(Designation_);
    $("#ReportingManager").text(ReportingManager_);

    $("#staticBackdrop").modal('show');

}