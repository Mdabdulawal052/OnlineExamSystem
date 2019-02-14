//Course Dropdown


$("#OrganizationId").change(function () {
    var organizationId = $(this).val();
    var params = { organizationId: organizationId };
    $.ajax({
        type: "POST",
        url: "/Exam/GetCourseByOrganizationId",
        contentType: "application/json; Charset=utf-8",
        data: JSON.stringify(params),
        success: function (rData) {
            if (rData != undefined && rData != "") {
                $("#CourseId").empty();
                $("#CourseId").append("<option value=''>---Select---</option>");
                $.each(rData, function (k, v) {
                    $("#CourseId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                });
            }
        }
    });
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
    var code = $("#ExamCode").val();
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
    var duration = $("#Duration").text();
    if (duration != undefined && duration != null) {
        $("#DurationErrorMsg").text("");
        return true;
    }
    $("#DurationErrorMsg").text("Required");
    return false;
});