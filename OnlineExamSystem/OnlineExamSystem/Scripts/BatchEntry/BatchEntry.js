



$("#OrganizationId").change(function () {
    var organizationId = $(this).val();
    var params = { organizationId: organizationId };
    $.ajax({
        type: "post",
        url: "/Batch/getBatchByOrganizationId",
        contentType: "application/json; Charset=utf-8",
        data: JSON.stringify(params),
        success: function (rData) {
            if (rData != undefined && rData != "") {
                $("#CourseId").empty();
                $("#CourseId").append("<option value=''>------Select-----</option>");
                $.each(rData,
                    function (k, v) {
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


$("#SubmitBtn").click(function () {
    var course = $("#CourseId option:selected").val();
    if (course != undefined && course != "") {
        $("#CourseIdErrorMsg").text("");
        return true;
    }
    $("#CourseIdErrorMsg").text("DropDown Value Required");
    return false;
});

$("#SubmitBtn").click(function () {
    var batchNo = $("#BatchNo").val();
    if (batchNo != undefined && batchNo != 0) {
        $("#BatchNoIdErrorMsg").text("");
        return true;
    }
    $("#BatchNoIdErrorMsg").text("You Must Be Provide Batch No");
    return false;
});


$("#SubmitBtn").click(function () {
    var description = $("#Description").val();
    if (description != undefined && description != "") {
        $("#DescriptionIdErrorMsg").text("");
        return true;
    }
    $("#DescriptionIdErrorMsg").text("Description Required");
    return false;
});