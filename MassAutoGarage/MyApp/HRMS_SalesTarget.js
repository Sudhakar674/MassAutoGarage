


$("#btnSave").click(function () {
    debugger;

    var SalesId_ = $("#SalesId").val();
   
    var tableLength = $("#example tr").length;
  
    var ProductListArr = [];

    if (SalesId_ != "" && tableLength > 1) {

        if (tableLength > 1) {

            for (var i = 0; i < tableLength - 1; i++) {

                var ProductList = {
                    Code: _Code,
              
                    Type1: '1',
                    Description: $("#example tBody tr:eq(" + i + ")").find('td:eq(1)').html(),
                    ExpiryDate: $("#example tBody tr:eq(" + i + ")").find('td:eq(2)').html(),
                    AttachmentFile: $("#example tBody tr:eq(" + i + ")").find('td:eq(3)').html(),

                };
                ProductListArr.push(ProductList);
            }

            $.ajax({
                type: 'POST',
                url: '/SupplierMaster/InsertUpdateSupplier',
                data: JSON.stringify(ProductListArr),
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                success: function (data) {
                    if (data == "1") {
                        $("#divLoader").hide();
                        swal({
                            title: "success",
                            text: "Record Successfully Submitted.",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                var url = "/SupplierMaster/SupplierDetails";
                                window.location.href = url;
                            } else {

                            }
                        });

                    }
                  
                },

               
            })
        }
      
    }
   


})