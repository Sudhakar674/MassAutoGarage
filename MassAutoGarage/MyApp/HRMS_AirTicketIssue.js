


function Reset() {
    window.location.href = "/HRMS_AirTicketIssue/AirTicketIssue";
}

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#Date").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#ArrivalDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#DepartureDate").datepicker(options);


    $("#btnsave").click(function (e) {
        debugger;
        e.preventDefault();
        var BranchId_ = $("#BranchId").val();
        var EmployeeId_ = $("#EmployeeId").val();
        var VoucherNo_ = $("#VoucherNo").val();
        var Date_ = $("#Date").val();
        var TicketCount_ = $("#TicketCount").val();
        var TicketFrom_ = $("#TicketFrom").val();
        var TicketTo_ = $("#TicketTo").val();
        var ArrivalDate_ = $("#ArrivalDate").val();
        var DepartureDate_ = $("#DepartureDate").val();
        var AirlineName_ = $("#AirlineName").val();
        var PNRNumber_ = $("#PNRNumber").val();
        var ArrivalAirport_ = $("#ArrivalAirport").val();
        var DepartureAirport_ = $("#DepartureAirport").val();
        var ID_ = $("#ID").val();


        if (BranchId_ != "" && VoucherNo_ != "" && Date_ != "" && EmployeeId_ != "" && TicketCount_ != "" && TicketFrom_ != "" && TicketTo_ != "" && ArrivalDate_ != "" && DepartureDate_ != "" && AirlineName_ != "" && PNRNumber_ != "" && ArrivalAirport_ != "" && DepartureAirport_ != "") {

            var LoanDetails = {
                BranchId: BranchId_,
                EmployeeId: EmployeeId_,
                VoucherNo: VoucherNo_,
                Date: Date_,
                TicketCount: TicketCount_,
                TicketFrom: TicketFrom_,
                TicketTo: TicketTo_,
                ArrivalDate: ArrivalDate_,
                DepartureDate: DepartureDate_,
                AirlineName: AirlineName_,
                PNRNumber: PNRNumber_,
                ArrivalAirport: ArrivalAirport_,
                DepartureAirport: DepartureAirport_,
                ID: ID_
            };

            if (confirm("Are you sure you want to continue ?")) {

                $.ajax({
                    type: 'POST',
                    url: '/HRMS_AirTicketIssue/SaveAirTicketIssue',
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
                                    window.location.href = '/HRMS_AirTicketIssue/AirTicketIssue';
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
            if (VoucherNo_ == "") {
                swal("Warning", "Please Enter Voucher No !", "warning");
                return false;
            }
            if (Date_ == "") {
                swal("Warning", "Please Enter Date !", "warning");
                return false;
            }
            if (EmployeeId_ == "") {
                swal("Warning", "Please Enter Employee Name !", "warning");
                return false;
            }
            if (TicketCount_ == "") {
                swal("Warning", "Please Enter Ticket Count !", "warning");
                return false;
            }
            if (TicketFrom_ == "") {
                swal("Warning", "Please Enter Ticket From !", "warning");
                return false;
            }
            if (TicketTo_ == "") {
                swal("Warning", "Please Enter Ticket To !", "warning");
                return false;
            }
            if (ArrivalDate_ == "") {
                swal("Warning", "Please Enter Arrival Date !", "warning");
                return false;
            }
            if (DepartureDate_ == "") {
                swal("Warning", "Please Enter Departure Date !", "warning");
                return false;
            }
            if (AirlineName_ == "") {
                swal("Warning", "Please Enter Airline Name !", "warning");
                return false;
            }
            if (PNRNumber_ == "") {
                swal("Warning", "Please Enter PNR Number !", "warning");
                return false;
            }
            if (ArrivalAirport_ == "") {
                swal("Warning", "Please Enter Arrival Airport !", "warning");
                return false;
            }
            if (DepartureAirport_ == "") {
                swal("Warning", "Please Enter Departure Airport !", "warning");
                return false;
            }
        }
    });


function DeleteAirTicketIssue(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HRMS_AirTicketIssue/DeleteAirTicketIssue',
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