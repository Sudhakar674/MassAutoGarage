

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
$("#RequestedDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#RequiredDate").datepicker(options);




/*---------------------------------------------------------start Educational Requirement-------------------------------------------------*/

function AddEducationalRequirement() {
    debugger;
    if ($("#Qualification").val() == "") {
        $("#Qualification").addClass('errortext');
        $("#Qualification").focus();
        return false;
    }
    else if ($("#PassingYear").val() == "") {
        $("#PassingYear").addClass('errortext');
        $("#PassingYear").focus();
        return false;
    }
    else if ($("#Board").val() == "") {
        $("#Board").addClass('errortext');
        $("#Board").focus();
        return false;
    }
    else if ($("#Percentage").val() == "") {
        $("#Percentage").addClass('errortext');
        $("#Percentage").focus();
        return false;
    }
    else {
        AddRowEducationalRequirement($("#Qualification").val(), $("#PassingYear").val(), $("#Board").val(), $("#Percentage").val());
        $("#Qualification").val("");
        $("#PassingYear").val("");
        $("#Board").val("");
        $("#Percentage").val("");
    }
    return true;
};

function AddRowEducationalRequirement(Qualification, PassingYear, Board, Percentage) {
    debugger;
    //Get the reference of the Table's TBODY element.
    var tBody = $("#exampleEducationalRequirement > TBODY")[0];

    //Add Row.
    row = tBody.insertRow(-1);

    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(Qualification);
    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(PassingYear);
    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(Board);
    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(Percentage);

    //Add Button cell.

    //cell = $(row.insertCell(-1));
    //var btnRemove = $("<input />");
    //btnRemove.attr("type", "button");
    //btnRemove.attr("onclick", "Remove(this);");
    //btnRemove.val("Remove");
    //cell.append(btnRemove);


    //Add Button cell.
    cell = $(row.insertCell(-1));
    var btnRemove = $("<input />");
    btnRemove.attr("type", "button");
    btnRemove.attr("onclick", "Remove1(this);");
    btnRemove.val("Remove");
    cell.append(btnRemove);
};

function Remove1(button) {
    debugger;
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Do you want to delete this record ? ")) {

        //Get the reference of the Table.
        var table = $("#exampleEducationalRequirement")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};


/*---------------------------------------------------------end Educational Requirement-------------------------------------------------*/


/*---------------------------------------------------------start Preferred Qualifications-------------------------------------------------*/

function AddPreferredQualifications() {
    debugger;
    if ($("#PreferredQualification").val() == "") {
        $("#PreferredQualification").addClass('errortext');
        $("#PreferredQualification").focus();
        return false;
    }
    else if ($("#PreferredExperience").val() == "") {
        $("#PreferredExperience").addClass('errortext');
        $("#PreferredExperience").focus();
        return false;
    }
    else {
        AddRowPreferredQualifications($("#PreferredQualification").val(), $("#PreferredExperience").val());
        $("#PreferredQualification").val("");
        $("#PreferredExperience").val("");
    }
    return true;
};

function AddRowPreferredQualifications(PreferredQualification, PreferredExperience) {
    debugger;
    //Get the reference of the Table's TBODY element.
    var tBody = $("#examplePreferredQualifications > TBODY")[0];

    //Add Row.
    row = tBody.insertRow(-1);

    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(PreferredQualification);
    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(PreferredExperience);

    //Add Button cell.
    cell = $(row.insertCell(-1));
    var btnRemove = $("<input />");
    btnRemove.attr("type", "button");
    btnRemove.attr("onclick", "Remove(this);");
    btnRemove.val("Remove");
    cell.append(btnRemove);
};

function Remove(button) {
    debugger;
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Do you want to delete this record ? ")) {

        //Get the reference of the Table.
        var table = $("#examplePreferredQualifications")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};


/*---------------------------------------------------------end Preferred Qualifications-------------------------------------------------*/




$("#btnsave").click(function () {
    debugger;
    var _VoucherNo = $("#VoucherNo").val();
    var _DepartmentId = $("#DepartmentId").val();
    var _RequestedDate = $("#RequestedDate").val();
    var _RequiredDate = $("#RequiredDate").val();
    var _DesignationId = $("#DesignationId").val();

    var FullTime = $("input[name=FullTime]:checked").val();
    if (FullTime == "true") {
        var _FullTime = 1;
    }
    else {
        var _FullTime = 0;
    }

    var ProjectHire = $("input[name=ProjectHire]:checked").val();
    if (ProjectHire == "true") {
        var _ProjectHire = 1;
    }
    else {
        var _ProjectHire = 0;
    }

    var Temporary = $("input[name=Temporary]:checked").val();
    if (Temporary == "true") {
        var _Temporary = 1;
    }
    else {
        var _Temporary = 0;
    }

    var _JobDescription = $("#JobDescription").val();

    var AdditionNew = $("input[name=AdditionNew]:checked").val();
    if (AdditionNew == "true") {
        var _AdditionNew = 1;
    }
    else {
        var _AdditionNew = 0;
    }

    var Budgeted = $("input[name=Budgeted]:checked").val();
    if (Budgeted == "true") {
        var _Budgeted = 1;
    }
    else {
        var _Budgeted = 0;
    }

    var Replacement = $("input[name=Replacement]:checked").val();
    if (Replacement == "true") {
        var _Replacement = 1;
    }
    else {
        var _Replacement = 0;
    }

    var _AgeRange = $("#AgeRange").val();
    var _SalaryRange = $("#SalaryRange").val();

    var _StatusID = $("#StatusID").val();
    var _GenderID = $("#GenderID").val();


    var _PreferredQualification = $(".txtPreferredQualification").val();
    var _PreferredExperience = $(".txtPreferredExperience").val();

    var _Idincrept = $("#Idincrept").val();

    var tableLength = $("#exampleEducationalRequirement tr").length;
    /*var tableLength1 = $("#examplePreferredQualifications tr").length;*/
    var MainPowerRListArr = [];

    if (_DepartmentId != "" && _RequestedDate != "" && _RequiredDate != "" && _DesignationId != "" && _JobDescription != "" && _AgeRange != "" && _SalaryRange != "" && _StatusID != "" && _GenderID != "" && tableLength > 2 && _PreferredQualification != "" && _PreferredExperience != "") {

        if (tableLength > 2) {

            for (var i = 0; i < tableLength - 2; i++) {

                var MainPowerRList = {
                    VoucherNo: _VoucherNo,
                    DepartmentId: _DepartmentId,
                    RequestedDate: _RequestedDate,
                    RequiredDate: _RequiredDate,
                    DesignationId: _DesignationId,
                    FullTime: _FullTime,
                    ProjectHire: _ProjectHire,
                    Temporary: _Temporary,
                    JobDescription: _JobDescription,
                    AdditionNew: _AdditionNew,
                    Budgeted: _Budgeted,
                    Replacement: _Replacement,
                    AgeRange: _AgeRange,
                    SalaryRange: _SalaryRange,
                    StatusID: _StatusID,
                    GenderID: _GenderID,
                    PreferredQualification: _PreferredQualification,
                    PreferredExperience: _PreferredExperience,
                    Idincrept: _Idincrept,

                    Qualification: $("#exampleEducationalRequirement tBody tr:eq(" + i + ")").find('td:eq(0)').html(),
                    PassingYear: $("#exampleEducationalRequirement tBody tr:eq(" + i + ")").find('td:eq(1)').html(),
                    Board: $("#exampleEducationalRequirement tBody tr:eq(" + i + ")").find('td:eq(2)').html(),
                    Percentage: $("#exampleEducationalRequirement tBody tr:eq(" + i + ")").find('td:eq(3)').html(),

                    //PreferredQualification: $("#examplePreferredQualifications tBody tr:eq(" + i + ")").find('td:eq(0)').html(),
                    //PreferredExperience: $("#examplePreferredQualifications tBody tr:eq(" + i + ")").find('td:eq(1)').html(),
                };
                MainPowerRListArr.push(MainPowerRList);
            }
            $.ajax({
                type: 'POST',
                url: '/HR_MainPowerRequisition/SaveMainPowerRequisition',
                data: JSON.stringify(MainPowerRListArr),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    if (data.Result == "yes") {
                        swal({
                            title: "success",
                            text: "Record Successfully Saved.",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                window.location.reload();
                            } else {

                            }
                        });
                    }
                    else if (data == "yes1") {
                        swal({
                            title: "success",
                            text: "Record Successfully Updated.",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                /* window.location.reload();*/
                                window.location.href = '/HR_MainPowerRequisition/MainPowerRequisition';
                            } else {

                            }
                        });
                    }
                    else {
                        /*  swal("Warning", "Record not save!", "warning");*/
                        swal({
                            title: "success",
                            text: "Record Successfully Updated.",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                /* window.location.reload();*/
                                window.location.href = '/HR_MainPowerRequisition/MainPowerRequisition';
                            } else {

                            }
                        });
                    }
                },
                error: function (httpResponse) {
                    swal("Warning", "Something Went to Wrong!", "warning");
                }
            })
        }
    }
    else {
        if (_DepartmentId == "") {
            swal("Warning", "Please Enter Department !", "warning")
            return false;
        }
        else if (_RequestedDate == "") {
            swal("Warning", "Please Enter  Date Requested !", "warning")
            return false;
        }
        else if (_RequiredDate == "") {
            swal("Warning", "Please Enter Date Required !", "warning")
            return false;
        }
        else if (_DesignationId == "") {
            swal("Warning", "Please Enter Position/Title !", "warning")
            return false;
        }
        else if (_JobDescription == "") {
            swal("Warning", "Please Enter Brief Description Of Duties(Or Attach The Job Description)!", "warning")
            return false;
        }
        else if (_AgeRange == "") {
            swal("Warning", "Please Enter Age Range !", "warning")
            return false;
        }
        else if (_SalaryRange == "") {
            swal("Warning", "Please Enter Salary Range !", "warning")
            return false;
        }
        else if (_StatusID == "") {
            swal("Warning", "Please Enter Status !", "warning")
            return false;
        }
        else if (_GenderID == "") {
            swal("Warning", "Please Enter Gender !", "warning")
            return false;
        }
        else if (tableLength == 2) {
            swal("Warning", "Please At least 1 row data required in Educational Requirement", "warning");
            return false;
        }
        else if (_PreferredQualification == "") {
            swal("Warning", "Please Enter Preferred Qualification !", "warning")
            return false;
        }
        else if (_PreferredExperience == "") {
            swal("Warning", "Please Enter Experience !", "warning")
            return false;
        }

    }
})


function ViewMainPowerDetails(Id) {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HR_MainPowerRequisition/ViewMainPowerDetails",
        data: { Id: Id },
        dataType: "json",
        success: function (data) {
            debugger;
            if (data.Result == "yes") {
                $("#txtVoucherNo").val(data.VoucherNo);
                $("#txtDepartmentName").val(data.DepartmentName);
                $("#txtRequestedDate").val(data.RequestedDate);
                $("#txtRequiredDate").val(data.RequiredDate);
                $("#txtDesignation").val(data.Designation);
                $("#txtFullTime").val(data.FullTime);
                $("#txtProjectHire").val(data.ProjectHire);
                $("#txtTemporary").val(data.Temporary);
                $("#txtAdditionNew").val(data.AdditionNew);
                $("#txtBudgeted").val(data.Budgeted);
                $("#txtReplacement").val(data.Replacement);

                if (data.FullTime == true) {
                     $("#FullTime").prop("checked", true);                 
                }
                else {
                  $("#FullTime").prop("checked", false);
                }

                if (data.ProjectHire == true) {
                    $("#ProjectHire").prop("checked", true);
                }
                else {
                    $("#ProjectHire").prop("checked", false);
                }
                if (data.Temporary == true) {
                    $("#Temporary").prop("checked", true);
                }
                else {
                    $("#Temporary").prop("checked", false);
                }
                if (data.AdditionNew == true) {
                    $("#AdditionNew").prop("checked", true);
                }
                else {
                    $("#AdditionNew").prop("checked", false);
                }
                if (data.Budgeted == true) {
                    $("#Budgeted").prop("checked", true);
                }
                else {
                    $("#Budgeted").prop("checked", false);
                }
                if (data.Replacement == true) {
                    $("#Replacement").prop("checked", true);
                }
                else {
                    $("#Replacement").prop("checked", false);
                }

                $("#txtJobDescription").val(data.JobDescription);
                $("#txtAgeRange").val(data.AgeRange);
                $("#txtSalaryRange").val(data.SalaryRange);
                $("#txtStatusID").val(data.StatusID);
                $("#txtGenderID").val(data.GenderID);
                $("#txtPreferredQualification").val(data.PreferredQualification);
                $("#txtPreferredExperience").val(data.PreferredExperience);
            }
            else {
                alert("Something went wrong.");
            }
        }
    });

    ViewMainPowerEducationalRequirement(Id)
    $("#MainPowerModal").modal('show');
}

function ViewMainPowerEducationalRequirement(Id) {

    debugger;
    $.ajax({
        type: "Get",
        url: "/HR_MainPowerRequisition/ViewMainPowerEducationalRequirement",
        data: { Id: Id },
        dataType: "json",
        success: function (result) {
            $.each(result, function (i, v) {
                debugger;
                var tableLength = $(".tBodyId tr").length;
                var SerialNo = tableLength + 1;
                var tr = "<tr>";
                tr += "<td>" + v.Qualification + "</td>";
                tr += "<td>" + v.PassingYear + "</td>";
                tr += "<td>" + v.Board + "</td>";
                tr += "<td>" + v.Percentage + "</td>";
                tr += "</tr>";
                $(".tBodyId").append(tr);
            });
        }
    });
}

function RemoveTableRecords() {
    debugger;
    $(".tBodyId tr").empty();
}

function DeleteMainPowerRequisition(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_MainPowerRequisition/DeleteMainPowerRequisition',
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