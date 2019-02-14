
$(document).ready(function () {
    $("#ShowOption").hide();
    var value = 1;
    $("#Sl").val(value);
    var Qorder = $('#QuestionOrder').val();
    if (Qorder == 0) {
        $('#QuestionOrder').val(Qorder + 1);
    }
});

$("#OptionTypeId").change(function () {
    $("#ShowOption").show();
})



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
    var courseId = $(this).val();
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
});

//Question Main Table data
var count = 0;
$('#SubmitButton').click(function () {
    
   
     var sdata=$("form").serialize();
    var wQuestion = $('#WriteQuestion').val();
    var oTyped = $('#OptionTypeId').val();
    var qOrder = $('#QuestionOrder').val();

   

    $.ajax({
        type: "POST",
        url: "/Question/Create",
        data: sdata,
        success: function (sData) {
            if (sData != undefined && sData != "") { }
            var variable = $("#QuestionOrder").val();
            $("#QuestionOrder").val(parseInt(variable) + 1);
        }
    });

    var questionCreate = {};
    questionCreate.OptionTypeId = parseInt(oTyped);
    questionCreate.WriteQuestion = wQuestion;
    questionCreate.QuestionOrder = parseInt(qOrder);
    //  sl num is getting 0 so this 
    var sl = $("#Sl").val();
    var newsl = parseInt(sl) + 1;
    $("#Sl").val(newsl);

    $.ajax({
        type: "POST",
        url: "/Question/GetDataForQuestion",
        contentType: "application/json;Charset=utf-8",
        data: JSON.stringify(questionCreate),
        dataType: "json",
        success: function (eData) {
            
            $('#QuestionOrder').val(parseInt(qOrder));
            if (eData != undefined && eData != "") {
               
                $('#CreateQuestoionTable  tbody:last-child').append(
                    '<tr>' +
                    '<td>' +
                    eData.Order +
                    '</td>' +
                     '<td>' +
                    eData.QuestionName +
                    '</td>' +
                    '<td>' +
                    eData.OptionType +
                    '</td>' +
                    '<td>' +
                        y +
                    '</td>' +
                    '<td>' +
                    'Edit | Delete' +
                    '</td>' +
                    '</tr>'
                );

            };
        }
    });
    
    $("#QuestionCreateBody tr").remove();
     $("#WriteQuestion").val("");
    $("#Marks").val(0);
    var t, y=0;
    t = count;
    count = y;
    y = t;
    var value = 1;
    $("#Sl").val(value);
     $("#Option").val("");
});

//$("#ExamId").change(function () {
//    var examId = $(this).val();
//    var parmsExamId = { examId: examId };
//    $.ajax({
//        type: "POST",
//        url: "/Question/GetQuestionByExamId",
//        contentType: "application/json;Charset=utf-8",
//        data: JSON.stringify(parmsExamId),
//        success: function (eData) {
//            if (eData != undefined && eData != "") {

//                if (istrue === false) {

//                    $('#CreateQuestoionTable  tbody:last-child').append(
//                        '<tr>' +
//                        '<td>' +
//                        participantName +
//                        '</td>' +
//                        '<td>' +
//                        profession +
//                        '</td>' +
//                        '<td>' +
//                        participantName +
//                        '</td>' +
//                        '<td>' +
//                        profession +
//                        '</td>' +
//                        '<td>' +
//                        'Edit | Delete' +
//                        '</td>' +
//                        '</tr>'
//                    );
//                }
//            };
//        }
//    });
//});




$("#basicQuestionSubmitbtn").click(function () {
    ShowDataForQuestion();
    var sl = $("#Sl").val();

    var newsl = parseInt(sl) + 1;
    $("#Sl").val(newsl);
});


function ShowDataForQuestion() {
    count = count + 1;
    var selectedItem = getQuesSelectedItem();
    var index = $("#QuestionCreateBody").children("tr").length;
    var sl = index;
    var IndexId = "<td style='display:none'><input type='hidden' id='Index" + index + "'name=QOptions.Index' Value='" + index + "' /> </td>";
    var SlId = "<td id='Sl" + index + "'>" + (++sl) + "</td>";
    var OptionId = "<td> <input type='hidden' id='OptionId" + index + "'name='QOptions[" + index + "].Option' value='" + selectedItem.Option + "'/>" + selectedItem.Option + "</td>";
    var CheckId = "<td> <input type='hidden' id='CheckId" + index + "'name='QOptions[" + index + "].checkbox' value='" + selectedItem.checkbox + "'/>" + selectedItem.checkbox + "</td>";
    var slNo = "<td> <input type='hidden' id='slNoId" + index + "'name='QOptions[" + index + "].Sl' value= '"+ selectedItem.Sl + "'/>" + selectedItem.Sl + "</td>";
    var newRow = "<tr>" + IndexId + SlId + CheckId + slNo + OptionId + "</tr>";
    $("#QuestionCreateBody").append(newRow);
    $("#OptionId").val("");
    $("#CheckId").val("");

}

function getQuesSelectedItem() {
    var slnew = $("#Sl").val();
    var sl = parseInt(slnew);
    var option = $("#Option").val();
    var checkbox = false;
    var result = $('input[name="checkbox"]:checked');
    if (result.length > 0) {
        checkbox = true;
    }
    var item = {
        "Sl": sl,
        "Option": option,
        "checkbox": checkbox
    }
    return item;
}

$("#ExamId").change(function () {
    var eId = $(this).val();
    var parmsExam = { examId: eId };
    $.ajax({
        type: "POST",
        url: "/Question/GetQuesOrderByExamId",
        contentType: "application/json;Charset=utf-8",
        data: JSON.stringify(parmsExam),
        success: function (cData) {
            if (cData != undefined && cData != "") {

                $('#QuestionOrder').val(cData);
            }
        }
    });
});
