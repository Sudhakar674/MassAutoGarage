

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

$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var _VoucherNo = $("#VoucherNo").val();
    var _FullName = $("#FullName").val();
    var _Date = $("#Date").val();
    var _ExpectedSalary = $("#ExpectedSalary").val();
    var _SalaryOffered = $("#SalaryOffered").val();

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

    var _Idincrept = $("#Idincrept").val();

    if (_FullName != "" && _Date != "" && _ExpectedSalary != "" && _SalaryOffered != "") {

        var GeneralRequestDetails = {
            VoucherNo: _VoucherNo,
            FullName: _FullName,
            Date: _Date,
            ExpectedSalary: _ExpectedSalary,
            SalaryOffered: _SalaryOffered,
            AdditionNew: _AdditionNew,
            Budgeted: _Budgeted,
            Replacement: _Replacement,
            Idincrept: _Idincrept
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HR_RecruitmentRequisition/SaveRecruitmentRequisition',
                data: JSON.stringify(GeneralRequestDetails),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
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
                                window.location.href = '/HR_RecruitmentRequisition/RecruitmentRequisition';
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
        if (_FullName == "") {
            swal("Warning", "Please Enter Full Name !", "warning");
            return false;
        }
        if (_Date == "") {
            swal("Warning", "Please Enter Date!", "warning");
            return false;
        }
        if (_ExpectedSalary == "") {
            swal("Warning", "Please Enter Expected Salary !", "warning");
            return false;
        }
        if (_SalaryOffered == "") {
            swal("Warning", "Please Enter Salary Offered !", "warning");
            return false;
        }

    }
});


function DeleteRecruitmentRequisition(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_RecruitmentRequisition/DeleteRecruitmentRequisition',
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


function ViewGetRecruitmentRequisition(Id) {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HR_RecruitmentRequisition/ViewGetRecruitmentRequisition",
        data: { Id: Id },
        dataType: "json",
        success: function (data) {
            debugger;
            if (data.Result === "yes") {
                $("#txtVoucherNo").val(data.VoucherNo);
                $("#txtFullName").val(data.FullName);
                $("#txtDate").val(data.Date);
                $("#txtExpectedSalary").val(data.ExpectedSalary);
                $("#txtSalaryOffered").val(data.SalaryOffered);
        
                if (data.AdditionNew === true) {
                    $("#AdditionNew").prop("checked", true);
                }
                else {
                    $("#AdditionNew").prop("checked", false);
                }
                if (data.Budgeted === true) {
                    $("#Budgeted").prop("checked", true);
                }
                else {
                    $("#Budgeted").prop("checked", false);
                }
                if (data.Replacement === true) {
                    $("#Replacement").prop("checked", true);
                }
                else {
                    $("#Replacement").prop("checked", false);
                }
            }
            else {
                alert("Something went wrong.");
            }
        }
    });

    $("#RecruitmentRequisitionModal").modal('show');
}