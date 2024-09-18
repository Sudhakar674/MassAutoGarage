
var maxLength = 50;
$('#GroupName').change(function () {
    debugger;
    var textlen = $(this).val().length;

    if (textlen > maxLength) {

        $('#GroupName').val("");
        swal("Warning", " Accept only 50 Character !", "warning");

    } else {

    }

});
$(function () {
    $('#GroupName').keydown(function (e) {

        if (e.shiftKey || e.ctrlKey || e.altKey) {
            e.preventDefault();
        } else {
            var key = e.keyCode;
            if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
                e.preventDefault();
            }
        }
    });
});


$("#btnSave").click(function (e) {
    debugger;
    e.preventDefault();

    var code = $("#Code").val();
    var groupname = $("#GroupName").val();
    var GroupId = $("#HDFID").val();
    var _HDFCurrentCount = $("#HDFCurrentCount").val();
    var _IsActive = $("#IsActive").val();

    if (code != "" && groupname != "") {
        var ProductListArr = [];
        var ProductList = {
            Id: GroupId,
            Code: code,
            GroupName: groupname,
            IsActive: _IsActive,
            CurrentCount:_HDFCurrentCount

        };
        //ProductListArr.push(ProductList);


        if (confirm("Are you sure you want to continue ?")) {
            $.ajax({
                type: 'POST',
                url: '/Master/SaveGroupMaster',
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
                                var url = "/Master/GroupMasterIndex";
                                window.location.href = url;
                            } else {

                            }
                        });

                    }
                    else if (data == "2") {

                        swal({
                            title: "Success",
                            text: "Records Successfully Updated",
                            type: "success",
                        }).then(function (isConfirm) {
                            if (isConfirm) {
                                var url = "/Master/GroupMasterIndex";
                                window.location.href = url;
                            } else {

                            }
                        });
                    }
                    else if (data == "4") {

                        swal("Warning", "Record Already Exist!", "warning");
                    } else {

                        swal("Warning", "Record not save!", "warning");
                    }

                },
                error: function (httpResponse) {


                    alert("Something Went to Wrong!")
                }
            })
        }
    }
    else {

        if (code == "") {
            swal("Warning", " Please Enter Code !", "warning");
            return false;
        }
        if (groupname == "") {
            swal("Warning", "Please Enter Group Name!", "warning");
            return false;
        }

    }

})

