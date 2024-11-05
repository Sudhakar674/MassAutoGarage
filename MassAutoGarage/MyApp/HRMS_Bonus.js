
function Reset() {
    window.location.href = "/HRMS_Bonus/Bonus";
}

function isNumberOrDecimal(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
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
$("#BonusDate").datepicker(options);


$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var BranchId_ = $("#BranchId").val();
    var EmployeeId_ = $("#EmployeeId").val();
    var BonusAmount_ = $("#BonusAmount").val();
    var BonusDate_ = $("#BonusDate").val();
    var Remarks_ = $("#Remarks").val();
    var ID_ = $("#ID").val();


    //////////////////////////////////////////////////////////////////////////

    if (BranchId_ != "" && EmployeeId_ != "" && BonusAmount_ != "" && BonusDate_ != "") {

        if (confirm("Are you sure you want to continue ?")) {

            var formData = new FormData();
            formData.append('ID', $("#ID").val());
            formData.append('BranchId', $("#BranchId").val());
            formData.append('EmployeeId', $("#EmployeeId").val());
            formData.append('BonusAmount', $("#BonusAmount").val());
            formData.append('BonusDate', $("#BonusDate").val());
            formData.append('Remarks', $("#Remarks").val());
      
            $.ajax({
                url: '/HRMS_Bonus/SaveBonus',
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
                                window.location.href = '/HRMS_Bonus/Bonus';
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
        if (BonusAmount_ == "") {
            swal("Warning", "Please Enter Bonus Amount !", "warning");
            return false;
        }
        if (BonusDate_ == "") {
            swal("Warning", "Please Enter Bonus Date !", "warning");
            return false;
        }
    }
});



function DeleteBonus(Id) {
    /*alert(Id);*/
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_Bonus/DeleteBonus',
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