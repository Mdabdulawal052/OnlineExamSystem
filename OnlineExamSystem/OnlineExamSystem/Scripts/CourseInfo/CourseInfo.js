

//$("#basicInfoFor").click(function() {
//    var url = "/Course/BasicInfo";
//    $.post(url,
//        function(rData) {
//            if (rData != undefined && rData != "") {
//                $("#basicdiv").html(rData);
//            }
//        });

//});

$("#AssignTrainer").click(function () {
    var url = "/Course/AssignTrainer";
    $.post(url,
        function (rData) {
            if (rData != undefined && rData != "") {
                $("#Trainerdiv").html(rData);
            }
        });

});

$("#createExam").click(function () {
    var url = "/Course/CreateExam";
    $.post(url,
        function (rData) {
            if (rData != undefined && rData != "") {
                $("#Creatediv").html(rData);
            }
        });

});