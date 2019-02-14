

$(document).ready(function () {
    
    Findloadparticipant();
    loadTrainer();
    LoadExam();

    $("#datepicker1").datepicker({
        Format: "dd/mm/yy",
        changeMonth: true,
        changeYear:true,
    });
    $("#datepicker2").datepicker({
        Format: "dd/mm/yy",
        changeMonth: true,
        changeYear: true,
    });
    $("#ExamDate").datetimepicker();
});
$("#BatchAssingTrainerId").click(function() {
    loadTrainer();
    ShowDataBatchTrainerAssignTable();
});
$("#BatchAssingParticipantId").click(function() {
    Findloadparticipant();
    ShowDataBatchParticipantAssignTable();
});


function Findloadparticipant() {


    $.ajax({
        type: "POST",
        url: "/Batch/AssignParticipants",
        contentType: "application/json; Charset=utf-8",
        success: function (rData) {
            if (rData != undefined && rData != "") {
                $("#AssParticipantId").empty();
                $("#AssParticipantId").append("<option value=''>---Select---</option>");
                $.each(rData, function (k, v) {
                    $("#AssParticipantId").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                });
            }
        }
    });
}

function ShowDataBatchParticipantAssignTable() {
    var participantId = $("#AssParticipantId option:selected").val();
    var participantName= $("#AssParticipantId option:selected").text();
    var params = { id: participantId };
    $.ajax({
        type: "POST",
        url: "/Batch/AssignParticipantTable",
        contentType: "application/json; Charset=utf-8",
        data:JSON.stringify(params),
        success: function (rData) {
            var istrue = false;
            if (rData != undefined && rData != "") {
                var profession = "";
                $.each(rData,
                    function(k, v) {
                        if (v.ParticipantId === Number(participantId)) {
                            istrue = true;
                            
                            alert("Item Is already Here");
                        }
                        profession=v.Profession;
                    });
                if(istrue===false) {
           
                    $('#batchParticipantTable  tbody:last-child').append(
                        '<tr>' +
                        '<td>' +
                        participantName +
                        '</td>' +
                        '<td>' +
                        profession +
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

function ShowDataBatchTrainerAssignTable() {
    var trainer = $("#TrainerId option:selected").text();
    var trainerId = $("#TrainerId option:selected").val();
    $.ajax({
        type: "POST",
        url: "/Batch/AssignTrinerTable",
        contentType: "application/json; Charset=utf-8",
        success: function (rData) {
            var istrue = false;
            if (rData != undefined && rData != "") {
                $.each(rData,
                    function(k, v) {
                        if (v.TrainerId === Number(trainerId)) {
                            istrue = true;
                            alert("Item Is already Here");
                        }
                    });
                if(istrue===false) {
                    var triner=trainer;
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

function loadTrainer() {


    $.ajax({
        type: "POST",
        url: "/Batch/AssignTrainers",
        contentType: "application/json; Charset=utf-8",
        success: function (rData) {
            if (rData != undefined && rData != "") {
                $("#TrainerId").empty();
                $("#TrainerId").append("<option value=''>---Select---</option>");
                $.each(rData, function (k, v) {
                    $("#TrainerId").append("<option value='" + v.TrainerId + "'>" + v.Name + "</option>");
                });
            }
        }
    });
}

function LoadExam() {


    $.ajax({
        type: "POST",
        url: "/Batch/ExamSDrop",
        contentType: "application/json; Charset=utf-8",
        success: function (rData) {
            if (rData != undefined && rData != "") {
                $("#ExamId").empty();
                $("#ExamId").append("<option value=''>---Select---</option>");
                $.each(rData, function (k, v) {
                    $("#ExamId").append("<option value='" + v.Id + "'>" + v.Topic + "</option>");
                });
            }
        }
    });
}

$('#ExamScheduleButton').click(function() {
    CreateScheduleExam();
});

function CreateScheduleExam() {

    var drop = $('#ExamId option:selected').val();
    var dateTime = $('#ExamDate').val();
    var examschedule = {};
    examschedule.ExamId = drop;
    examschedule.ScheduleDateTime = dateTime;

    $.ajax({
        type: "POST",
        url: "/Batch/ScheduleExam",
        contentType: "application/json; Charset=utf-8",
        data:JSON.stringify(examschedule),
        dataType:"json",
        success: function (rData) {
            if(rData == ""){
                alert("This Item Is Already Exist.")
            }
            if (rData != undefined && rData != "") {
                $('#examScheduleTable  tbody:last-child').append(
                    '<tr>' +
                    '<td>' +
                    rData.TypeExam +
                    '</td>' +
                    '<td>' +
                    rData.Topic +
                    '</td>' +
                    '<td>' +
                    rData.ExamCode +
                    '</td>' +
                    '<td>' +
                    rData.Duration.Hours+":"+ rData.Duration.Minutes+ ":" +rData.Duration.Seconds+
                    '</td>' +
                    '<td>' +
                    rData.FMarks +
                    '</td>' +
                    '<td>' +
                    dateTime +
                    '</td>' +
                    '<td>' +
                    'Edit | Delete'+
                    '</td>' +
                    '</tr>'
                );
                }
        }
    });
}