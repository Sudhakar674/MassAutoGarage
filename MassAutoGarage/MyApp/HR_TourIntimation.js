


function isNumberOrDecimal(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function isNumberKey(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode;
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
$("#StartDate").datepicker(options);

var options = $.extend({},
    $.datepicker.regional["es"], {
    dateFormat: "dd/mm/yy",
    changeMonth: true,
    changeYear: true,
    todayHighlight: true,
});
$("#ReturnDate").datepicker(options);




$("#btnsave").click(function (e) {
    debugger;
    e.preventDefault();
    var _VoucherNo = $("#VoucherNo").val();
    var _EmployeeId = $("#EmployeeId").val();
    var _DesignationId = $("#DesignationId").val();
    var _TourDestination = $("#TourDestination").val();
    var _TravelModeID = $("#TravelModeID").val();
    var _StartDate = $("#StartDate").val();
    var _ReturnDate = $("#ReturnDate").val();
    var _PurposeOfTour = $("#PurposeOfTour").val();
    var _Details = $("#Details").val();
    var _SuggestReplacement = $("#SuggestReplacement").val();
    var _Acknowledgement = $("#Acknowledgement").val();


    var VisaSingleEntry = $("input[name=VisaSingleEntry]:checked").val();
    if (VisaSingleEntry == "true") {
        var _VisaSingleEntry = 1;
    }
    else {
        var _VisaSingleEntry = 0;
    }

    var VisaMultipleEntry = $("input[name=VisaMultipleEntry]:checked").val();
    if (VisaMultipleEntry == "true") {
        var _VisaMultipleEntry = 1;
    }
    else {
        var _VisaMultipleEntry = 0;
    }

    var HotelEconomic = $("input[name=HotelEconomic]:checked").val();
    if (HotelEconomic == "true") {
        var _HotelEconomic = 1;
    }
    else {
        var _HotelEconomic = 0;
    }

    var PassportRelease = $("input[name=PassportRelease]:checked").val();
    if (PassportRelease == "true") {
        var _PassportRelease = 1;
    }
    else {
        var _PassportRelease = 0;
    }

    var TravelInsuranceYes = $("input[name=TravelInsuranceYes]:checked").val();
    if (TravelInsuranceYes == "true") {
        var _TravelInsuranceYes = 1;
    }
    else {
        var _TravelInsuranceYes = 0;
    }

    var TravelInsuranceNo = $("input[name=TravelInsuranceNo]:checked").val();
    if (TravelInsuranceNo == "true") {
        var _TravelInsuranceNo = 1;
    }
    else {
        var _TravelInsuranceNo = 0;
    }

    var _CashAdvanceAmt = $("#CashAdvanceAmt").val();
    var _Idincrept = $("#Idincrept").val();

    if (_EmployeeId != "" && _DesignationId != "" && _TourDestination != "" && _TravelModeID != "" && _StartDate != "" && _ReturnDate != "" && _PurposeOfTour != "" && _Details != "" && _SuggestReplacement != "" && _Acknowledgement != "" && _CashAdvanceAmt != "") {

        var TourIntimationDetails = {
            VoucherNo: _VoucherNo,
            EmployeeId: _EmployeeId,
            DesignationId: _DesignationId,
            TourDestination: _TourDestination,
            TravelModeID: _TravelModeID,
            StartDate: _StartDate,
            ReturnDate: _ReturnDate,
            PurposeOfTour: _PurposeOfTour,
            Details: _Details,
            SuggestReplacement: _SuggestReplacement,
            Acknowledgement: _Acknowledgement,
            VisaSingleEntry: _VisaSingleEntry,
            VisaMultipleEntry: _VisaMultipleEntry,
            HotelEconomic: _HotelEconomic,
            PassportRelease: _PassportRelease,
            TravelInsuranceYes: _TravelInsuranceYes,
            TravelInsuranceNo: _TravelInsuranceNo,
            CashAdvanceAmt: _CashAdvanceAmt,
            Idincrept: _Idincrept
        };

        if (confirm("Are you sure you want to continue ?")) {

            $.ajax({
                type: 'POST',
                url: '/HR_TourIntimation/SaveTourIntimation',
                data: JSON.stringify(TourIntimationDetails),
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
                                window.location.href = '/HR_TourIntimation/TourIntimation';
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
        if (_EmployeeId == "") {
            swal("Warning", "Please Enter Employee Name !", "warning");
            return false;
        }
        if (_DesignationId == "") {
            swal("Warning", "Please Enter Designation !", "warning");
            return false;
        }
        if (_TourDestination == "") {
            swal("Warning", "Please Enter Tour Destination !", "warning");
            return false;
        }

        if (_TravelModeID == "") {
            swal("Warning", "Please Enter Travel Mode !", "warning");
            return false;
        }
        if (_StartDate == "") {
            swal("Warning", "Please Enter Start Date !", "warning");
            return false;
        }

        if (_ReturnDate == "") {
            swal("Warning", "Please Enter Return Date !", "warning");
            return false;
        }
        if (_PurposeOfTour == "") {
            swal("Warning", "Please Enter Purpose Of Tour !", "warning");
            return false;
        }
        if (_Details == "") {
            swal("Warning", "Please Enter Details !", "warning");
            return false;

        }
        if (_SuggestReplacement == "") {
            swal("Warning", "Please Enter Suggest Replacement/Handing Over To : (During Absence) !", "warning");
            return false;
        }
        if (_Acknowledgement == "") {
            swal("Warning", "Please Enter Acknowledgement Of Taking Over !", "warning");
            return false;
        }
        if (_CashAdvanceAmt == "") {
            swal("Warning", "Please Enter Cash Advance Amount !", "warning");
            return false;
        }
    }
});


function DeleteTourIntimation(Id) {
    debugger;
    var x = confirm("Are you sure you want to delete?");
    if (x == true) {
        $.ajax({
            type: 'POST',
            url: '/HR_TourIntimation/DeleteTourIntimation',
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


function ViewTourIntimation(Id) {
    debugger;
    $.ajax({
        type: "Get",
        url: "/HR_TourIntimation/ViewTourIntimation",
        data: { Id: Id },
        dataType: "json",
        success: function (data) {
            debugger;
            if (data.Result === "yes") {
                $("#txtVoucherNo").val(data.VoucherNo);
                $("#txtEmployeeName").val(data.EmployeeName);
                $("#txtDesignation").val(data.Designation);
                $("#txtTourDestination").val(data.TourDestination);
                $("#txtTravelMode").val(data.TravelMode);
                $("#txtStartDate").val(data.StartDate);
                $("#txtReturnDate").val(data.ReturnDate);
                $("#txtPurposeOfTour").val(data.PurposeOfTour);
                $("#txtDetails").val(data.Details);
                $("#txtSuggestReplacement").val(data.SuggestReplacement);
                $("#txtAcknowledgement").val(data.Acknowledgement);

                if (data.VisaSingleEntry === true) {
                    $("#VisaSingleEntry").prop("checked", true);
                }
                else {
                    $("#VisaSingleEntry").prop("checked", false);
                }

                if (data.VisaMultipleEntry === true) {
                    $("#VisaMultipleEntry").prop("checked", true);
                }
                else {
                    $("#VisaMultipleEntry").prop("checked", false);
                }
                if (data.HotelEconomic === true) {
                    $("#HotelEconomic").prop("checked", true);
                }
                else {
                    $("#HotelEconomic").prop("checked", false);
                }
                if (data.PassportRelease === true) {
                    $("#PassportRelease").prop("checked", true);
                }
                else {
                    $("#PassportRelease").prop("checked", false);
                }
                if (data.TravelInsuranceYes === true) {
                    $("#TravelInsuranceYes").prop("checked", true);
                }
                else {
                    $("#TravelInsuranceYes").prop("checked", false);
                }

                if (data.TravelInsuranceNo === true) {
                    $("#TravelInsuranceNo").prop("checked", true);
                }
                else {
                    $("#TravelInsuranceNo").prop("checked", false);
                }

                $("#txtCashAdvanceAmt").val(data.CashAdvanceAmt);

            }
            else {
                alert("Something went wrong.");
            }
        }
    });

    $("#TourIntimationModal").modal('show');
}