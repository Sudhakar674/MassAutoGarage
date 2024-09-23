
function Reset() {
    window.location.href = "/HRMS_DeductionType/DeductionType";
}


$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var DeductionType_ = $("#DeductionType").val();
    var DeductionID_ = $("#DeductionID").val();


    if (DeductionType_ != "") {

        var DeductionTypeDetails = {
            DeductionType: DeductionType_,
            DeductionID: DeductionID_
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HRMS_DeductionType/SaveDeductionType',
                data: JSON.stringify(DeductionTypeDetails),
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
                                window.location.reload();
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

        if (DeductionType_ == "") {
            swal("Warning", "Please Enter Deduction Type!", "warning");
            return false;
        }
    }
});



function DeductionTypeList() {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HRMS_DeductionType/DeductionTypeList",
        data: "{}",
        dataType: "json",
        success: function (result) {
            $.each(result, function (i, v) {
                debugger;
                var tableLength = $("#tBodyId tr").length;

                var SerialNo = tableLength + 1;
                var tr = "<tr>";
                tr += "<td>" + SerialNo + "</td>";
                tr += "<td style='Display:none' class='DeductionID_"+v.DeductionID+"'>" + v.DeductionID + "</td>";
                tr += "<td class='DeductionType_"+v.DeductionID+"'>" + v.DeductionType + "</td>";
                tr += "<td><a onclick='return EditDeductionType(" + v.DeductionID + ")' class='btn btn-sm btn-success edit-item-btn'>Edit<i class='fa fa-edit'></i></a> <a onclick='return DeleteDeductionType(" + v.DeductionID + ")' class='btn btn-sm btn-danger remove-item-btn DeleteContactTr'><i class='fa fa-trash' aria-hidden='true'></i>Delete</a></td>";
                tr += "</tr>";
                $("#tBodyId").append(tr);
            });
        }
    });
}

function EditDeductionType(Id) {
    debugger;
    var ID_ = $(".DeductionID_" + Id).text();
    var DeductionType_ =$(".DeductionType_" + Id).text();

    $("#DeductionID").val(ID_);
    $("#DeductionType").val(DeductionType_);
    $("#btnsave").val('Update');
}


function DeleteDeductionType(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_DeductionType/DeleteDeductionType',
            data: { DeductionID: Id },
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


$('#DeductionType').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});