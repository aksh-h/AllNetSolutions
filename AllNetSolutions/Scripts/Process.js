
$(document).ready(function () {
    var startTime = new Date().getTime(); // record start time
    // code to be timed goes here
    $.ajax({
        url: 'api/process/get',
        type: 'GET',
        success: function (data) {
            if (data.length > 0) {
                var endTime = new Date().getTime(); // record end time
                var txt = "";
                $.each(data, function (i, v) {
                    txt += '<h2> Process ' + i + '</h2>';
                    txt += '<p>' + v.status + '<p>';
                    txt += '<p>' + v.timeTaken + '<p>';
                });
                var timeTaken = endTime - startTime;

                var t = '<p> Time Taken: ' + timeTaken + 'ms</p>';
                $('#timeTaken').append(t);
                $('#result').append(txt);
            }
            console.log(data);
            console.timeEnd('myTimer');
        },
        error: function (er) {
            alert(er);
        }
    });
});