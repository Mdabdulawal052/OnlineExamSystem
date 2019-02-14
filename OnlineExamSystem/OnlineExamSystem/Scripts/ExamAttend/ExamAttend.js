
$("#OrganizationId").change(function () {
    var organizationId = $(this).val();
    var params = { organizationId: organizationId };
    $.ajax({
        type: "POST",
        url: "/Question/GetCourseByOrganizationId",
        contentType: "application/json; Charset=utf-8",
        data: JSON.stringify(params),
        success: function (rData) {
            if (rData != undefined && rData != "") {
                $("#CourseId").empty();
                $("#CourseId").append("<option value=''>---Select---</option>");
                $.each(rData,
                    function (k, v) {
                        $("#CourseId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                    });
            }
        }
    });

});

//Batch Dropdown
$("#CourseId").change(function () {
    getParticipant();
    getExam();
});

function getExam(){
    var courseId = $("#CourseId").val();
    var parmsExam = { courseId: courseId };
    $.ajax({
        type: "POST",
        url: "/Question/GetExamByCourseId",
        contentType: "application/json;Charset=utf-8",
        data: JSON.stringify(parmsExam),
        success: function (cData) {
            if (cData != undefined && cData != "") {
                $("#ExamId").empty();
                $("#ExamId").append("<option value=''>---Select---</option>");
                $.each(cData, function (k, v) {
                    $("#ExamId").append("<option value='" + v.Id + "'>" + v.Topic + "</option>");
                });
            }
        }
    });
}
function getParticipant() {
    var courseId = $("#CourseId").val();
    var parmsBatch = { courseId: courseId };
    $.ajax({
        type: "POST",
        url: "/Participant/GetParticipantByCourseId",
        contentType: "application/json;Charset=utf-8",
        data: JSON.stringify(parmsBatch),
        success: function (bData) {
            if (bData != undefined && bData != "") {
                $("#BatchId").empty();
                $("#BatchId").append("<option value=''>---Select---</option>");
                $.each(bData, function (k, v) {
                    $("#BatchId").append("<option value='" + v.Id + "'>" + v.BatchNo + "</option>");
                });
            }
        }
    });
};