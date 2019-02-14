

$(document.body).on("click", "#basicCourseSubmitbtn", function() {
    var courseCV = {};
    var id = $("#BasicId").val();
    vm.Organizationid = $("#BasicInfoOrganizationId").val();
    vm.Name = $("#Name").val();
    vm.Code = $("#Code").val();
    vm.CourseDuration = $("#CourseDuration").val();
    vm.Credit = $("#Credit").val();
    vm.OutLine = $("#OutLine").val();

    if (id===null || id===0 || id==="") {
        $.ajax({
            url: "/Course/BasicInfo",
            data: courseCV,
            type: "POST",
            success: function(e) {
                if (e > 0) {
                    alert("Saved");
                } else {
                    alert("Failed");
                }
            }
        });
    }
});