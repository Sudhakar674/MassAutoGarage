$('#DepartmentName').keypress(function (e) {
    debugger;
    var regex = new RegExp("^[a-zA-Z ]+$");
    var strigChar = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(strigChar)) {
        return true;
    }
    return false
});

$("#btnSave").click(function (e) {
  
    debugger;
      e.preventDefault();
    var _DepartmentName = $("#DepartmentName").val();
    var deptid = $("#DeptID").val();

    if (_DepartmentName != "") {

        /* var ProductListArr = [];*/
        var ProductList = {
            DepartmentName: _DepartmentName,
            DeptID: deptid,
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HRMS_Department/SaveDepartment',
                data: JSON.stringify(ProductList),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    debugger;
                    if (data == "1") {
                        debugger;
                        swal({
                            title: "Success",
                            text: "Records Successfully Saved",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                $("#DepartmentName").val("");
                                BindDepartment();
                            } else {

                            }
                        });

                    }
                    //else if (data == "2") {

                    //    swal({
                    //        title: "Success",
                    //        text: "Records Successfully Updated",
                    //        type: "success",
                    //    }).then(function (isConfirm) {
                    //        if (isConfirm) {
                    //            var url = "/CompanyMaster/Index";
                    //            window.location.href = url;
                    //        } else {

                    //        }
                    //    });
                    //}
                    //else if (data == "4") {
                    //    swal("Warning", "This Code is Already Exist !", "warning");
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

        if (_DepartmentName == "") {
            swal("Warning", "Please Enter Department Name!", "warning");
            return false;
        }
    }
});

function BindDepartment()
{
    $.ajax({
        type: "Get",
        url: "/HRMS_Department/GetList",
        data: "{}",
        dataType: "json",
        success: function (data) {
            $.each(data, function (i, v) {

                var tableLength = $("#tBody3 tr").length;

                var SerialNo = tableLength + 1;
                var tr = "<tr>";
                tr += "<td>" + SerialNo + " <input type='hidden' id='hdfdeptID' class='clsdeptid' value='" + v.DeptID + "'/><input type='hidden' id='hdfdeptID' class='clsDepartmentName' value='" + v.DepartmentName + "'/></td><td>" + v.DepartmentName + "</td><td><a onclick='return EditDepartment(" + SerialNo +")' class='btn btn-sm btn-success edit-item-btn'>Edit <i class='fa fa-edit'></i></a> <a onclick='return ConfirmDelete(" + v.DeptID +")' class='btn btn-sm btn-danger remove-item-btn DeleteContactTr'><i class='fa fa-trash' aria-hidden='true'></i>Delete</a></td>";
                tr += "</tr>";
                $("#tBody3").append(tr);
            });
        }
    });
}

function ConfirmDelete(DeptId) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x)

        if (DeptId > 0) {
            $.ajax({
                url: '/HRMS_Department/Delete',
                type: "GET",
                dataType: "json",
                data: { DeptId: DeptId },
                success: function (result) {
                    if (result == "1") {

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
                    } else {
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
        else
            return false;
}

function EditDepartment(i)
{
    var s = i - 1;
    debugger;


    var ID = $("#example tBody tr:eq(" + s + ")").find(".clsdeptid").val();
    var DepartmentName = $("#example tBody tr:eq(" + s + ")").find(".clsDepartmentName").val();

    //var tableLength = $("#example tr").length;

    $("#DeptID").val(ID);
    $("#DepartmentName").val(DepartmentName);

}










