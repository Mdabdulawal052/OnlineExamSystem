

$("#AssignParticipant").click(function () {
    var url = "/Batch/AssignTrainer";
    $.post(url,
        function (rData) {
            if (rData != undefined && rData != "") {
                $("#AssParticipantdiv").html(rData);
            }
        });

});

$("#AssignTrainer").click(function () {
    var url = "/Batch/ParticipantASS";
    $.post(url,
        function (rData) {
            if (rData != undefined && rData != "") {
                $("#AssTrainerdiv").html(rData);
            }
        });

});