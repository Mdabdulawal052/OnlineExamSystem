

$(document).ready(function() {
    loadparticipant();
    
    //ShowDataForTrainerAssignNew();
});

$("#AssingTrainerId").click(function() {
    loadparticipant();
    ShowDataForTrainerAssignNew();
});
function loadparticipant() {
    

    $.ajax({
        type: "POST",
        url: "/Course/AssignTrainers",
        contentType: "application/json; Charset=utf-8",
        success: function (rData) {
            if (rData != undefined && rData != "") {
                $("#Id").empty();
                $("#Id").append("<option value=''>---Select---</option>");
                $.each(rData, function (k, v) {
                    $("#Id").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                });
            }
        }
    });
}
function ShowDataForTrainerAssignNew() {
    var organization = $("#Id option:selected").text();
    $.ajax({
        type: "POST",
        url: "/Course/AssignTrinerTable",
        contentType: "application/json; Charset=utf-8",
        success: function (rData) {
            var istrue = false;
            if (rData != undefined && rData != "") {
                $.each(rData,
                    function(k, v) {
                        if (v.TrinerName === organization) {
                            istrue = true;
                            alert("Item Is already Here");
                        }
                    });
               if(istrue===false) {
                   var triner=organization;
                   var lead = "No";
                  var result= $('input[name="Lead"]:checked');
                       if (result.length>0) {
                           lead = "Yes";
                       } 
                   //var lead = $('#Lead').val();
                   $('#tainertb  tbody:last-child').append(
                       '<tr>' +
                       '<td>' +
                       triner +
                       '</td>' +
                       '<td>' +
                       lead +
                       '</td>' +
                       '<td>' +
                       'Edit | Delete'+
                       '</td>' +
                       '</tr>'
                   );
               }
               
            }
        }
    });
}

//BootStrap Pop-Up Modal
$('#btnTrainerCreate').click(function() {
    
    var ndt = '';
    $.ajax({
        type: 'Get',
        url: "/Course/TrainerCreateByAjax",
        //data: { empId: eId },
        success: function(response) {
            //$('#loderdivnew').hide();
            $('#partialTrainerAdd').html(response);
            $('#TrainerEntryModal').modal("show");
        }
    });
});
//Modal Organization Id Change And get Course Id
//COurse List by OrganizationId
$("#OrganizationId").change(function () {
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
//Organizationidne
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


// Batch Dropdown
$("#CourseId").change(function () {
    var courseId = $(this).val();
    var parmsBatch = { courseId: courseId };
    $.ajax({
        type: "POST",
        url: "/Trainer/GetBatchByCourseId",
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



$("#SubmitBtn").click(function () {
    ShowDataForCreateExam();
    //ShowDataForTrainer();
});
function ShowDataForCreateExam() {
    var course = $("#CourseId option:selected").val();
    var examType = $("#Examtype option:selected").text();
    var code = $("#ExamCode").val().toString();
    var topic = $("#Topic").val();
    var fmarks = $("#FMarks").val();
    var duration = $("#Duration").val().toString();
    $.ajax({
        type: "POST",
        url: "/Course/CreateExamTable",
        contentType: "application/json; Charset=utf-8",
        success: function (rData) {
            var istrue = false;
            if (rData != undefined && rData != "") {
                
                $.each(rData,
                    function(k, v) {
                        if (v.CourseId=== Number(course) && v.ExamCode===Number(code)) {
                            istrue = true;
                            alert("Item Is already Here");
                        }
                    });
                if(istrue===false) {
                    
                    $('#ExamTable  tbody:last-child').append(
                        '<tr>' +
                        '<td>' +
                        examType +
                        '</td>' +
                        '<td>' +
                        topic +
                        '</td>' +
                        '<td>' +
                        code +
                        '</td>' +
                        '<td>' +
                        fmarks +
                        '</td>' +
                        '<td>' +
                        duration +
                        '</td>' +
                        '<td>' +
                        'Edit | Delete'+
                        '</td>' +
                        '</tr>'
                    );
                }
               
            }
        }
    });
}



function ShowDataForTrainer() {
    var selectedItem = getSelectedItem();
    var index = $("#TbodyId").children("tr").length;
    var sl = index;
    var IndexId = "<td style='display:none'><input type='hidden' id='Index" + index + "'name=ExamtListItems.Index' Value='" + index + "' /> </td>";
    var SlId = "<td id='Sl" + index + "'>" + (++sl) + "</td>";
    var CodeId = "<td> <input type='hidden' id='CodeId" +index +"'name='ExamtListItems[" +index +"].Code' value='" +selectedItem.Code +"'/>" +selectedItem.Code +"</td>";
    var TopicId = "<td> <input type='hidden' id='TopicId" + index + "'name='ExamtListItems[" + index + "].Topic' value='" + selectedItem.Topic + "'/>" + selectedItem.Topic + "</td>";
    var FMarksId = "<td> <input type='hidden' id='FMarksId" + index + "'name='ExamtListItems[" + index + "].FMarks' value='" + selectedItem.FMarks + "'/>" + selectedItem.FMarks + "</td>";
    var DurationId = "<td> <input type='hidden' id='DurationId" + index + "'name='ExamtListItems[" + index + "].Duration' value='" + selectedItem.Duration + "'/>" + selectedItem.Duration + "</td>";

    var newRow = "<tr>" + IndexId + SlId + CodeId + TopicId + FMarksId + DurationId + "</tr>";
    $("#TbodyId").append(newRow);
    $("#CodeId").val("");
    $("#TopicId").val("");
    $("#FMarksId").val("");
    $("#DurationId").val("");
}

function getSelectedItem() {
    var code = $("#CodeId").val();
    var topic = $("#TopicId").val();
    var fmarks = $("#FmarksId").val();
    var durationid = $("#DurationId").val();
    var item= {
        "Code": code,
        "Topic": topic,
        "FMarks": fmarks,
        "Duration": durationid

    }
    return item;
}


//function loadCreateExamS() {
    

//    $.ajax({
//        type: "POST",
//        url: "/Course/AssignCreateExam",
//        contentType: "application/json; Charset=utf-8",
//        success: function (rData) {
//            if (rData != undefined && rData != "") {
//                $("#CourseId").empty();
//                $("#CourseId").append("<option value=''>---Select---</option>");
//                $.each(rData, function (k, v) {
//                    $("#CourseId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
//                });
//            }
//        }
//    });
//}