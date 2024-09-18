
function PostData() {
    debugger;
    var ProductListArr = new Array();
   
    var tableLength = $("#tblLeads tr").length;
    if (tableLength > 1) {

        for (var i = 1; i < tableLength; i++) {

            var ProductList = {
                ID: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(0)').html(),
                Created_Time: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(1)').html(),
                Ad_Id: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(2)').html(),

                Ad_Name: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(3)').html(),
                AdSet_Id: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(4)').html(),
                AdSet_Name: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(5)').html(),
                Campaign_Id: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(6)').html(),
                Campaign_Name: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(7)').html(),
                Form_Id: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(8)').html(),
                Form_Name: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(9)').html(),
                Is_organic: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(10)').html(),
                Platform: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(11)').html(),
                Full_name: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(12)').html(),
                Phone_number: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(13)').html(),
                Email: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(14)').html(),
                City: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(15)').html(),
                Is_qualified: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(16)').html(),
                Is_quality: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(17)').html(),
                Is_converted: $("#tblLeads tBody tr:eq(" + i + ")").find('td:eq(18)').html(),

            };
            ProductListArr.push(ProductList);
           
        }
    }

    debugger;
    $.ajax({
        type: 'POST',
        url: '/CRM/SaveLeads',
        data: JSON.stringify(ProductListArr),
        contentType: "application/json; charset=utf-8",       
        dataType: 'json',
        success: function (data) {
            if (data == "1") {

                //swal({
                //    title: "success",
                //    text: "Record Successfully Submitted.",
                //    type: "success",
                //}).then(function (isConfirm) {
                //    if (isConfirm) {
                //        var url = "/CustomerMaster/CustomerDetails";
                //        window.location.href = url;
                //    } else {

                //    }
                //});

            }


        },

       
    });

}

function IsReadFacebook(id) {
    debugger;
    var imgiD = "#imgfacebook" + id;
   
    if (id > 0) {

        $.ajax({
            url: '/CRM/UpdateIsRead',
            type: "GET",
            dataType: "json",
            data: { fbID: id },
            success: function (result) {
                if (result == "1") {
                    debugger;
                    $(imgiD).hide()
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
}

function IsReadInstagram(id) {

    debugger;
    var imgiD = "#imgfacebook" + id;

    if (id > 0) {


        $.ajax({
            url: '/CRM/UpdateIsRead',
            type: "GET",
            dataType: "json",
            data: { fbID: id },
            success: function (result) {

                if (result == "1") {
                    debugger;
                    $(imgiD).hide()
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
}