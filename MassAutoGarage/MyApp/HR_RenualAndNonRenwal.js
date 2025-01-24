
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
$("#DateOfJoined").datepicker(options);

$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var _VoucherNo = $("#VoucherNo").val();
    var _EmployeeId = $("#EmployeeId").val();
    var _DateOfJoined = $("#DateOfJoined").val();
    var _DesignationId = $("#DesignationId").val();
    var _BranchId = $("#BranchId").val();
    var _DepartmentId = $("#DepartmentId").val();

    var Renew = $("input[name=Renew]:checked").val();
    if (Renew == "true") {
        var _Renew = 1;
    }
    else {
        var _Renew = 0;
    }

    var NotRenewing = $("input[name=NotRenewing]:checked").val();
    if (NotRenewing == "true") {
        var _NotRenewing = 1;
    }
    else {
        var _NotRenewing = 0;
    }

    var _Idincrept = $("#Idincrept").val();

    if (_EmployeeId != "" && _DateOfJoined != "" && _DesignationId != "" && _DepartmentId != "" && _BranchId != "") {

        var GeneralRequestDetails = {
            VoucherNo: _VoucherNo,
            EmployeeId: _EmployeeId,
            DateOfJoined: _DateOfJoined,
            DesignationId: _DesignationId,
            BranchId: _BranchId,
            DepartmentId: _DepartmentId,
            Renew: _Renew,
            NotRenewing: _NotRenewing,
            Idincrept: _Idincrept
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HR_RenualAndNonRenwal/SaveRenualAndNonRenwal',
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
                                window.location.href = '/HR_RenualAndNonRenwal/RenualAndNonRenwal';
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
            swal("Warning", "Please Enter Employee Name !", "warning");
            return false;
        }
        if (_DateOfJoined == "") {
            swal("Warning", "Please Enter Date Of Joined!", "warning");
            return false;
        }
        if (_DesignationId == "") {
            swal("Warning", "Please Enter Designation !", "warning");
            return false;
        }
        if (_DepartmentId == "") {
            swal("Warning", "Please Enter Department !", "warning");
            return false;
        }
        if (_BranchId == "") {
            swal("Warning", "Please Enter Branch !", "warning");
            return false;
        }
       
    }
});


function DeleteRenualAndNonRenwal(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_RenualAndNonRenwal/DeleteRenualAndNonRenwal',
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