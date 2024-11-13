
function Reset() {
    window.location.href = "/HRMS_Leave/Leave";
}

var options = $.extend({},
    $.datepicker.regional["es"], {
    /* dateFormat: "dd/mm/yy",*/
    dateFormat: "yy/mm/dd",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#FromDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    /* dateFormat: "dd/mm/yy",*/
    dateFormat: "yy/mm/dd",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#ToDate").datepicker(options);


/* Start Leave Count days*/

function TotalLeaveCount() {
    debugger;

    var date1 = new Date(document.getElementById("FromDate").value);
    var date2 = new Date(document.getElementById("ToDate").value);

    if (isNaN(date1.getTime()) || isNaN(date2.getTime())) {
        document.getElementById("result").textContent = "Please select both dates.";
        return;
    }

    var timeDiff = Math.abs(date2.getTime() - date1.getTime());
    var daysDiff = Math.ceil(timeDiff / (1000 * 3600 * 24));

    var TotalNoOfLeavedays = daysDiff + 1;

    $("#LeaveCount").val(TotalNoOfLeavedays);
}

/* End Leave Count days*/

$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var BranchId_ = $("#BranchId").val();
    var EmployeeId_ = $("#EmployeeId").val();
    var LeaveTypeId_ = $("#LeaveTypeId").val();
    var FromDate_ = $("#FromDate").val();
    var ToDate_ = $("#ToDate").val();
    var LeaveCount_ = $("#LeaveCount").val();
    var BalanceLeave_ = $("#BalanceLeave").val();
    var Description_ = $("#Description").val();
    var ID_ = $("#ID").val();


    if (BranchId_ != "" && EmployeeId_ != "" && LeaveTypeId_ != "" && FromDate_ != "" && ToDate_ != "" && BalanceLeave_ != "") {

        var LoanDetails = {
            BranchId: BranchId_,
            EmployeeId: EmployeeId_,
            LeaveTypeId: LeaveTypeId_,
            FromDate: FromDate_,
            ToDate: ToDate_,
            LeaveCount: LeaveCount_,
            BalanceLeave: BalanceLeave_,
            Description: Description_,
            ID: ID_
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HRMS_Leave/SaveLeave',
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
                                window.location.href = '/HRMS_Leave/Leave';
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
            swal("Warning", "Please Enter Branch Name !", "warning");
            return false;
        }
        if (EmployeeId_ == "") {
            swal("Warning", "Please Enter Employee Name !", "warning");
            return false;
        }
        if (LeaveTypeId_ == "") {
            swal("Warning", "Please Enter Leave Type !", "warning");
            return false;
        }
        if (FromDate_ == "") {
            swal("Warning", "Please Enter From Date !", "warning");
            return false;
        }
        if (ToDate_ == "") {
            swal("Warning", "Please Enter To Date !", "warning");
            return false;
        }
        if (BalanceLeave_ == "") {
            swal("Warning", "Please Enter Balance Leave !", "warning");
            return false;
        }
    }
});


function DeleteLeave(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_Leave/DeleteLeave',
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