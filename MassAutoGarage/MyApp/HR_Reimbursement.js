
var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#DateOfBill").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#FromDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#ToDate").datepicker(options);

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
    if ($("#DateOfBill").val() == "") {
        $("#DateOfBill").addClass('errortext');
        $("#DateOfBill").focus();
        return false;
    }
    else if ($("#Description").val() == "") {
        $("#Description").addClass('errortext');
        $("#Description").focus();
        return false;
    }
    else if ($("#Amount").val() == "") {
        $("#Amount").addClass('errortext');
        $("#Amount").focus();
        return false;
    }
    else {
        AddRow($("#DateOfBill").val(), $("#Description").val(), $("#Amount").val());
        $("#DateOfBill").val("");
        $("#Description").val("");
        $("#Amount").val("");

    }
    return true;

    //AddRow($("#DateOfBill").val(), $("#Description").val(), $("#Amount").val());
    //$("#DateOfBill").val("");
    //$("#Description").val("");
    //$("#Amount").val("");

};

function AddRow(DateOfBill, Description, Amount) {
    debugger;
    //Get the reference of the Table's TBODY element.
    var tBody = $("#example > TBODY")[0];

    //Add Row.
    row = tBody.insertRow(-1);

    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(DateOfBill);
    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(Description);
    //Add Country cell.
    cell = $(row.insertCell(-1));
    cell.html(Amount);

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
    var _Name = $("#Name").val();
    var _FromDate = $("#FromDate").val();
    var _ToDate = $("#ToDate").val();
    var _BranchId = $("#BranchId").val();
    var _Idencrept = $("#Idencrept").val();

    var tableLength = $("#example tr").length;
    var ProductListArr = [];

    if (_Name != "" && _FromDate != "" && _ToDate != "" && _BranchId != "" && tableLength > 2) {

        if (tableLength > 2) {

            for (var i = 0; i < tableLength - 2; i++) {

                var ProductList = {
                    VoucherNo: _VoucherNo,
                    Name: _Name,
                    FromDate: _FromDate,
                    ToDate: _ToDate,
                    BranchId: _BranchId,
                    Idencrept: _Idencrept,

                    DateOfBill: $("#example tBody tr:eq(" + i + ")").find('td:eq(0)').html(),
                    Description: $("#example tBody tr:eq(" + i + ")").find('td:eq(1)').html(),
                    Amount: $("#example tBody tr:eq(" + i + ")").find('td:eq(2)').html(),
                };
                ProductListArr.push(ProductList);
            }
            $.ajax({
                type: 'POST',
                url: '/HR_Reimbursement/SaveReimbursement',
                data: JSON.stringify(ProductListArr),
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
                                window.location.href = '/HR_Reimbursement/Reimbursement';
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
                                window.location.href = '/HR_Reimbursement/Reimbursement';
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
        if (_Name == "") {
            swal("Warning", "Please Enter Name !", "warning")
            return false;
        }
        if (_FromDate == "") {
            swal("Warning", "Please Enter From Date !", "warning")
            return false;
        }
        if (_ToDate == "") {
            swal("Warning", "Please Enter To Date !", "warning")
            return false;
        }
        if (_BranchId == "") {
            swal("Warning", "Please Enter Branch !", "warning")
            return false;
        }       
        if (tableLength == 2) {
            swal("Warning", "Please At least 1 row data required.", "warning");
            return false;
        }
    }
})

function DeleteReimbursement(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_Reimbursement/DeleteReimbursement',
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


function ViewReimbursementDetails(Id) {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HR_Reimbursement/ViewReimbursementDetails",
        data: { Id: Id },
        dataType: "json",
        success: function (data) {
            debugger;
            if (data.Result == "yes") {
                $("#txtVoucherNo").val(data.VoucherNo);
                $("#txtName").val(data.Name);
                $("#txtFromDate").val(data.FromDate);
                $("#txtToDate").val(data.ToDate);
                $("#txtBranchName").val(data.BranchName);
            }
            else {
                alert("Something went wrong.");
            }       
        }
    });

    ViewReimbursementDetailsList(Id)
    $("#ReimbursementModal").modal('show');
}

function ViewReimbursementDetailsList(Id) {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HR_Reimbursement/ViewReimbursementDetailsList",
        data: { Id: Id },
        dataType: "json",
        success: function (result) {
            $.each(result, function (i, v) {
                debugger;
                var tableLength = $(".tBodyId22 tr").length;
                var SerialNo = tableLength + 1;
                var tr = "<tr>";
                tr += "<td>" + v.DateOfBill + "</td>";
                tr += "<td>" + v.Description + "</td>";
                tr += "<td>" + v.Amount + "</td>";
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