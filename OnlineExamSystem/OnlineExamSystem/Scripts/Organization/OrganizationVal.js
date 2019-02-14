

$("#SubmitBtn").click(function () {
    var name = $("#Name").val();
    if (name != undefined && name != "") {
        $("#OrganizationValidationMessage").text("");
        return true;
    }
    $("#OrganizationValidationMessage").text("Name Is Requiored");
    return false;
});

$("#SubmitBtn").click(function () {
    var name = $("#ContactNumber").val();
    if (name != undefined && name != 0) {
        $("#PhoneNumberValid").text("");
        return true;
    }
    $("#PhoneNumberValid").text("Phone Number Is Required");
    return false;
});