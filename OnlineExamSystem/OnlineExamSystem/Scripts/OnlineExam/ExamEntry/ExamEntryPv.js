//Course Dropdown




//Organization Dropdown Validation 
$("#SubmitBtn").click(function () {
    var organization = $("#OrganizationId option:selected").val();
    if (organization != undefined && organization != "") {
        $("#OrganizationIdErrorMsg").text("");
        return true;
    }
    $("#OrganizationIdErrorMsg").text("DropDown Value Required");
    return false;
});

//Organization Dropdown Validation 
$("#SubmitBtn").click(function () {
    var organization = $("#OrganizationId option:selected").val();
    if (organization != undefined && organization != "") {
        $("#OrganizationIdErrorMsg").text("");
        return true;
    }
    $("#OrganizationIdErrorMsg").text("DropDown Value Required");
    return false;
});

//Code Validation

$("#SubmitBtn").click(function () {
    var code = $("#Code").val();
    if (code != undefined && code != 0) {
        $("#CodeErrorMsg").text("");
        return true;
    }
    $("#CodeErrorMsg").text("You Must Be Provide Code");
    return false;
});

//Topic Validation
$("#SubmitBtn").click(function () {
    var topic = $("#Topic").val();
    if (topic != undefined && topic != 0) {
        $("#TopicErrorMsg").text("");
        return true;
    }
    $("#TopicErrorMsg").text("Please Write Your Topic");
    return false;
});

//FullMarks Validation
$("#SubmitBtn").click(function () {
    var fmarks = $("#FMarks").val();
    if (fmarks != undefined && fmarks != 0) {
        $("#FMarksErrorMsg").text("");
        return true;
    }
    $("#FMarksErrorMsg").text("Required");
    return false;
});

//Duration Validation
$("#SubmitBtn").click(function () {
    var duration = $("#Duration").val();
    if (duration != undefined && duration != 0) {
        $("#DurationErrorMsg").text("");
        return true;
    }
    $("#DurationErrorMsg").text("Required");
    return false;
});