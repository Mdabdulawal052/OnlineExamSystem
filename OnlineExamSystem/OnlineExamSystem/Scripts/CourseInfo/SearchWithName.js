$(document).ready(function() {
    $(function() {
        $("#nameSearch").autocomplete({
            type: "Get",
            url: "/Course/AssignCreateExam"
        });
    });
});

