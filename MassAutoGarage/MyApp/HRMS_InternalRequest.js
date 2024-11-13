
function Reset() {
    window.location.href = "/HRMS_InternalRequest/InternalRequest";
}

    $("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var CompanyId_ = $("#CompanyId").val();
    var VoucherNo_ = $("#VoucherNo").val();
    var EmployeeId_ = $("#EmployeeId").val();
    var DepartmentId_ = $("#DepartmentId").val();
    var RequestFor_ = $("#RequestFor").val();
    var Purpose_ = $("#Purpose").val();
    var Remarks_ = $("#Remarks").val();
    var ID_ = $("#ID").val();

    if (CompanyId_ != "" && VoucherNo_ != "" && EmployeeId_ != "" && DepartmentId_ != "" && RequestFor_ != "" && Purpose_ != "") {

        var LoanDetails = {
            CompanyId: CompanyId_,
            VoucherNo: VoucherNo_,
            EmployeeId: EmployeeId_,
            DepartmentId: DepartmentId_,
            RequestFor: RequestFor_,
            Purpose: Purpose_,
            Remarks: Remarks_,
            ID: ID_
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HRMS_InternalRequest/SaveInternalRequest',
                data: JSON.stringify(LoanDetails),
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
                                window.location.href = '/HRMS_InternalRequest/InternalRequest';
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

        if (CompanyId_ == "") {
            swal("Warning", "Please Enter Company Name !", "warning");
            return false;
        }
        if (VoucherNo_ == "") {
            swal("Warning", "Please Enter Voucher No !", "warning");
            return false;
        }
        if (EmployeeId_ == "") {
            swal("Warning", "Please Enter Employee Name !", "warning");
            return false;
        }
        if (DepartmentId_ == "") {
            swal("Warning", "Please Enter Department Name !", "warning");
            return false;
        }
        if (RequestFor_ == "") {
            swal("Warning", "Please Enter Request For !", "warning");
            return false;
        }
        if (Purpose_ == 0) {
            swal("Warning", "Please Enter Purpose !", "warning");
            return false;
        }
    }
});


function DeleteInternalRequest(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_InternalRequest/DeleteInternalRequest',
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