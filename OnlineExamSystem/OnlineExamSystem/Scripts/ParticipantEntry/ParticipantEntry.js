
// required/////////////


$("#SubmitButton").click(function () {
    var organizatin = $("#OrganizationId option:selected").val();
    if (organizatin != undefined && organizatin != "") {
        $("#OrganizationValidationMessage").text("");
        return true;
    }
    $("#OrganizationValidationMessage").text("Organizatin must be Provided ");
    return false;
});


$("#SubmitButton").click(function () {
    var course = $("#CourseId option:selected").val();
    if (course != undefined && course != "") {
        $("#CourseValidationMessage").text("");
        return true;
    }
    $("#CourseValidationMessage").text("Course must be Provided ");
    return false;
});

$("#SubmitButton").click(function () {
    var batch = $("#BatchId option:selected").val();
    if (batch != undefined && batch != "") {
        $("#BatchValidationMessage").text("");
        return true;
    }
    $("#BatchValidationMessage").text("Batch must be Provided ");
    return false;
});

$("#SubmitButton").click(function () {
    var name = $("#Name").val();
    if (name != undefined && name != "") {
        $("#NameValidationMessage").text(" ");
        return true;
    }
    $("#NameValidationMessage").text("Name Is Required ");
    return false;
});

$("#SubmitButton").click(function () {
    var contact = $("#ContactNo").val();
    if (contact != undefined && contact != "") {
        $("#ContactValidationMessage").text(" ");
        return true;
    }
    $("#ContactValidationMessage").text("Contact Number Is Required ");
    return false;
});

$("#SubmitButton").click(function () {
    var email = $("#Email").val();
    if (email != undefined && email != "") {
        $("#EmailValidationMessage").text(" ");
        return true;
    }
    $("#EmailValidationMessage").text("Email Is Required ");
    return false;
});

$("#SubmitButton").click(function () {
    var city = $("#City").val();
    if (city != undefined && city != "") {
        $("#CityValidationMessage").text(" ");
        return true;
    }
    $("#CityValidationMessage").text("City Is Required ");
    return false;
});

$("#SubmitButton").click(function () {
    var postcode = $("#PostCode").val();
    if (postcode != undefined && postcode != 0) {
        $("#PostCodeValidationMessage").text(" ");
        return true;
    }
    $("#PostCodeValidationMessage").text("Post Code Is Required ");
    return false;
});

$("#SubmitButton").click(function () {
    var country = $("#Country").val();
    if (country != undefined && country != "") {
        $("#CountryValidationMessage").text(" ");
        return true;
    }
    $("#CountryValidationMessage").text("Country Is Required ");
    return false;
});

$("#SubmitButton").click(function () {
    var profession = $("#Profession").val();
    if (profession != undefined && profession != "") {
        $("#ProfessionValidationMessage").text(" ");
        return true;
    }
    $("#ProfessionValidationMessage").text("Profession Is Required ");
    return false;
});
$("#SubmitButton").click(function () {
    var hacademic = $("#HAcademic").val();
    if (hacademic != undefined && hacademic != "") {
        $("#HAcademicValidationMessage").text(" ");
        return true;
    }
    $("#HAcademicValidationMessage").text("Highest Academic Is Required ");
    return false;
});



///auto Code 


$("#OrganizationId").change(function() {
    var organizationId = $(this).val();
    var params = { organizationId: organizationId };
    $.ajax({
        type: "POST",
        url: "/Participant/GetCourseByOrganizationId",
        contentType: "application/json; Charset=utf-8",
        data: JSON.stringify(params),
        success: function(rData) {
            if (rData != undefined && rData != "") {
                $("#CourseId").empty();
                $("#CourseId").append("<option value=''>---Select---</option>");
                $.each(rData,
                    function(k, v) {
                        $("#CourseId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                    });
            }
        }
    });


    var url2= "/Participant/GetAutoCode";
    var organization = $("#OrganizationId option:selected").text();
    var parmsauto = { organization: organization };
    
    $.post(url2,parmsauto,
        function(autoCode) {
            $("#RegNo").val(autoCode);
        });
   

});

// Batch Dropdown
$("#CourseId").change(function () {
    var courseId = $(this).val();
    var parmsBatch = { courseId: courseId };
    $.ajax({
        type: "POST",
        url: "/Participant/GetBatchByCourseId",
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
});