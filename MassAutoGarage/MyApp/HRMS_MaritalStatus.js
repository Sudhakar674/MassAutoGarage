
function Reset() {
    window.location.href = "/HRMS_MaritalStatus/MaritalStatus";
    }


$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var _MaritalStatus = $("#MaritalStatus").val();
    var _MaritalSId = $("#MaritalSId").val();
 

    if (_MaritalStatus != "") {

        var MaritalSDetails = {
            MaritalStatus: _MaritalStatus,
            MaritalSId: _MaritalSId
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HRMS_MaritalStatus/SaveMaritalStatus',
                data: JSON.stringify(MaritalSDetails),
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
                    else if (data.Result == "yes1")
                    {
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

        if (_MaritalStatus == "") {
            swal("Warning", "Please Enter Marital Status!", "warning");
            return false;
        }
    }
});



function MaritalStatusList() {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HRMS_MaritalStatus/MaritalStatusList",
        data: "{}",
        dataType: "json",
        success: function (result) {
            $.each(result, function (i, v) {

                var tableLength = $("#tBodyId tr").length;

                var SerialNo = tableLength + 1;
                var tr = "<tr>";
                tr += "<td>" + SerialNo + " <input type='hidden' id='hdfMaritalSId' class='clsMaritalSId' value='" + v.MaritalSId + "'/><input type='hidden' id='hdfclsMaritalStatus' class='clsMaritalStatus' value='" + v.MaritalStatus + "'/></td><td>" + v.MaritalStatus + "</td><td><a onclick='return EditMaritalStatus(" + SerialNo + ")' class='btn btn-sm btn-success edit-item-btn'>Edit <i class='fa fa-edit'></i></a> <a onclick='return DeleteMaritalStatus(" + v.MaritalSId + ")' class='btn btn-sm btn-danger remove-item-btn DeleteContactTr'><i class='fa fa-trash' aria-hidden='true'></i>Delete</a></td>";
                tr += "</tr>";
                $("#tBodyId").append(tr);
            });
        }
    });
}




function DeleteMaritalStatus(Id)
{
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
      
        $.ajax({
            type: 'POST',
            url: '/HRMS_MaritalStatus/DeleteMaritalStatus',
            data: { MaritalSId: Id },
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


function EditMaritalStatus(i) {
    debugger;

    var s = i - 1;
    var _ID = $("#example tBody tr:eq(" + s + ")").find(".clsMaritalSId").val();
    var _MaritalStatus = $("#example tBody tr:eq(" + s + ")").find(".clsMaritalStatus").val();

    $("#MaritalSId").val(_ID);
    $("#MaritalStatus").val(_MaritalStatus);
    $("#btnsave").val('Update');
}



$('#MaritalStatus').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});