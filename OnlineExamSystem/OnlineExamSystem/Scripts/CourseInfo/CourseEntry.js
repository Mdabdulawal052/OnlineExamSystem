


//Organization Dropdown Validation 
$("#SubmitBtn").click(function () {
    var organization = $("#Organizationid option:selected").val();
    if (organization != undefined && organization != 0) {
        $("#OrganizationIdErrorMsg").text("");
        return true;
    }
    $("#OrganizationIdErrorMsg").text("DropDown Value Required");
    return false;
});

$("#SubmitBtn").click(function () {
    var name = $("#Name").val();
    if (name != undefined && name != "") {
        $("#NameIdErrorMsg").text("");
        return true;
    }
    $("#NameIdErrorMsg").text("Name Required");
    return false;
});

$("#SubmitBtn").click(function () {
    var code = $("#Code").val();
    if (code != undefined && code != "") {
        $("#CodeIdErrorMsg").text("");
        return true;
    }
    $("#CodeIdErrorMsg").text("Code Required");
    return false;
});

$("#SubmitBtn").click(function () {
    var cduration = $("#CourseDuration").val();
    if (cduration != undefined && cduration != 0) {
        $("#CourseDurationIdErrorMsg").text("");
        return true;
    }
    $("#CourseDurationIdErrorMsg").text("Course Duration Required");
    return false;
});

//$("#SubmitBtn").click(function () {
//    var credit = $("#Credit").val();
//    if (credit != undefined && credit != "") {
//        $("#CreditIdErrorMsg").text("");
//        return true;
//    }
//    $("#CreditIdErrorMsg").text("Credit Required");
//    return false;
//});





