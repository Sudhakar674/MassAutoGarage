
var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#Date").datepicker(options);

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

function Add() {
    debugger;
    if ($("#Tasks").val() == "") {
        $("#Tasks").addClass('errortext');
        $("#Tasks").focus();
        return false;
    }
    else if ($("#Status").val() == "") {
        $("#Status").addClass('errortext');
        $("#Status").focus();
        return false;
    }
    else {
        AddRow($("#Tasks").val(), $("#Status").val());
        $("#Tasks").val("");
        $("#Status").val("");
    }
    return true;

    //AddRow($("#Tasks").val(), $("#Status").val());
    //$("#Tasks").val("");
    //$("#Status").val("");
};

function AddRow(Tasks, Status) {
    debugger;
    //Get the reference of the Table's TBODY element.
    var tBody = $("#example > TBODY")[0];

    //Add Row.
    row = tBody.insertRow(-1);

    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(Tasks);
    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(Status);

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
        var table = $("#example")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};


$("#btnsave").click(function () {
    debugger;
    var _VoucherNo = $("#VoucherNo").val();
    var _EmployeeId = $("#EmployeeId").val();
    var _Date = $("#Date").val();
    var _DesignationId = $("#DesignationId").val();
    var _BranchId = $("#BranchId").val();
    var _EmpNo = $("#EmpNo").val();
    var _ReasonForWorkHandOver = $("#ReasonForWorkHandOver").val();
    var _TakenOverBy = $("#TakenOverBy").val();
    var _WorkHandOverID = $("#WorkHandOverID").val();
    var _Idincrept = $("#Idincrept").val();

    var tableLength = $("#example tr").length;
    var WorkHandOverListArr = [];

    if (_EmployeeId != "" && _Date != "" && _DesignationId != "" && _BranchId != "" && _EmpNo != "" && _ReasonForWorkHandOver != "" && _TakenOverBy != "" && tableLength > 2) {

        if (tableLength > 2) {

            for (var i = 0; i < tableLength - 2; i++) {

                var WorkHandOverList = {
                    VoucherNo: _VoucherNo,
                    EmployeeId: _EmployeeId,
                    Date: _Date,
                    DesignationId: _DesignationId,
                    BranchId: _BranchId,
                    EmpNo: _EmpNo,
                    ReasonForWorkHandOver: _ReasonForWorkHandOver,
                    TakenOverBy: _TakenOverBy,
                    WorkHandOverID: _WorkHandOverID,
                    Idincrept: _Idincrept,

                    Tasks: $("#example tBody tr:eq(" + i + ")").find('td:eq(0)').html(),
                    Status: $("#example tBody tr:eq(" + i + ")").find('td:eq(1)').html(),
                };
                WorkHandOverListArr.push(WorkHandOverList);
            }
            $.ajax({
                type: 'POST',
                url: '/HR_WorkHandOverReport/SaveWorkHandOverReport',
                data: JSON.stringify(WorkHandOverListArr),
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
                                window.location.href = '/HR_WorkHandOverReport/WorkHandOverReport';
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
                                window.location.href = '/HR_WorkHandOverReport/WorkHandOverReport';
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
        if (_EmployeeId == "") {
            swal("Warning", "Please Enter Employee Name !", "warning")
            return false;
        }
        if (_Date == "") {
            swal("Warning", "Please Enter  Date !", "warning")
            return false;
        }
        if (_DesignationId == "") {
            swal("Warning", "Please Enter Designation !", "warning")
            return false;
        }
        if (_EmpNo == "") {
            swal("Warning", "Please Enter EmpNo !", "warning")
            return false;
        }
        if (_BranchId == "") {
            swal("Warning", "Please Enter Branch !", "warning")
            return false;
        }
        if (_ReasonForWorkHandOver == "") {
            swal("Warning", "Please Enter Reason For Work Hand Over !", "warning")
            return false;
        }
        if (_TakenOverBy == "") {
            swal("Warning", "Please Enter Taken Over By !", "warning")
            return false;
        }
        if (tableLength == 2) {
            swal("Warning", "Please At least 1 row data required.", "warning");
            return false;
        }

    }
})

function DeleteWorkHandOverReport(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_WorkHandOverReport/DeleteWorkHandOverReport',
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


function ViewWorkHandOverReport(Id) {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HR_WorkHandOverReport/ViewWorkHandOverReport",
        data: { Id: Id },
        dataType: "json",
        success: function (data) {
            debugger;
            if (data.Result == "yes") {
                $("#txtVoucherNo").val(data.VoucherNo);
                $("#txtEmployeeName").val(data.EmployeeName);
                $("#txtDate").val(data.Date);
                $("#txtDesignation").val(data.Designation);
                $("#txtEmpNo").val(data.EmpNo);
                $("#txtBranchName").val(data.BranchName);
                $("#txtReasonForWorkHandOver").val(data.ReasonForWorkHandOver);
                $("#txtTakenOverBy").val(data.TakenOverBy);
            }
            else {
                alert("Something went wrong.");
            }
        }
    });

    ViewWorkHandOverReportList(Id)
    $("#WorkHandOverReportModal").modal('show');
}

function ViewWorkHandOverReportList(Id) {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HR_WorkHandOverReport/ViewWorkHandOverReportList",
        data: { Id: Id },
        dataType: "json",
        success: function (result) {
            $.each(result, function (i, v) {
                debugger;
                var tableLength = $(".tBodyId22 tr").length;
                var SerialNo = tableLength + 1;
                var tr = "<tr>";
                tr += "<td>" + v.Tasks + "</td>";
                tr += "<td>" + v.Status + "</td>";
                tr += "</tr>";
                $(".tBodyId22").append(tr);
            });
        }
    });
    /*$("#ReimbursementModal").modal('show');*/
}

function RemoveTableRecords() {
    debugger;
    $(".tBodyId22 tr").empty();
}