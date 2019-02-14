$("#patricButton").change(function () {
    var organizationId = $(this).val();
    var params = { organizationId: organizationId };
    $.ajax({
        type: "post",
        url: "/Course/GetCourseByOrganizationId",
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