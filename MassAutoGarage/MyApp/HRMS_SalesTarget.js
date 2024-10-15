
function Reset() {
    window.location.href = "/HRMS_SalesTarget/SalesTarget";
}

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



function isNumberOrDecimal(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}





function Add() {
    debugger;
    if ($("#FromDate").val() == "") {
        $("#FromDate").addClass('errortext');
        $("#FromDate").focus();
        return false;
    }
    else if ($("#ToDate").val() == "") {
        $("#ToDate").addClass('errortext');
        $("#ToDate").focus();
        return false;
    }
    else if ($("#Target").val() == "") {
        $("#Target").addClass('errortext');
        $("#Target").focus();
        return false;
    }
    else {
        AddRow($("#FromDate").val(), $("#ToDate").val(), $("#Target").val());
        $("#FromDate").val("");
        $("#ToDate").val("");
        $("#Target").val("");
       
    }
    return true;


    //AddRow($("#FromDate").val(), $("#ToDate").val(), $("#Target").val());
    //$("#FromDate").val("");
    //$("#ToDate").val("");
    //$("#Target").val("");
  
};

function AddRow(FromDate, ToDate, Target) {
    debugger;
    //Get the reference of the Table's TBODY element.
    var tBody = $("#example > TBODY")[0];

    //Add Row.
    row = tBody.insertRow(-1);

    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(FromDate);
    //Add Name cell.
    var cell = $(row.insertCell(-1));
    cell.html(ToDate);
    //Add Country cell.
    cell = $(row.insertCell(-1));
    cell.html(Target);

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
    if (confirm("Do you want to delete: " + name)) {

        //Get the reference of the Table.
        var table = $("#example")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};


$("#btnsave").click(function () {
    debugger;
    var SalesId_ = $("#SalesId").val();
    var Id_ = $("#PK_Id").val();

    var tableLength = $("#example tr").length;
    var ProductListArr = [];

    //if (SalesId_ != "" &&  tableLength > 1) {
    //    if (tableLength > 1) {

    if (SalesId_ != "" && tableLength > 2) {

        if (tableLength > 2) {

            for (var i = 0; i < tableLength - 2; i++) {

                var ProductList = {
                    SalesId: SalesId_,
                    PK_Id: Id_,

                    FromDate: $("#example tBody tr:eq(" + i + ")").find('td:eq(0)').html(),
                    ToDate: $("#example tBody tr:eq(" + i + ")").find('td:eq(1)').html(),
                    Target: $("#example tBody tr:eq(" + i + ")").find('td:eq(2)').html(),
                };
                ProductListArr.push(ProductList);
            }
            $.ajax({
                type: 'POST',
                url: '/HRMS_SalesTarget/SaveSalesTarget',
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
                                window.location.reload();
                            } else {

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

        if (SalesId_ == "") {
            swal("Warning", "Please Enter Sales Name !", "warning")
            return false;
        }
        if (tableLength == 2) {
            swal("Warning", "Please At least 1 row data required.", "warning");
            return false;
        }
    }
})


