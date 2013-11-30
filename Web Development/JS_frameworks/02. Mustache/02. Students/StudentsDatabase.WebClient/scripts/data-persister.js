/// <reference path="external/jquery.ui.datepicker.js" />
/// <reference path="external/jquery-2.0.3.js" />
/// <reference path="list-view.js" />

var url = "http://localhost:45497/api/students";
self = this;

var getStudents = function (success, error) {
    httpRequester.getJSON(url, function (data) {
        success(data);
    }, error);
}

var readData = function () {
    getStudents(function (data) {
        var studentTemplate =
            Mustache.compile(document.getElementById("student-template").innerHTML);

        var listView = controls.getListView(data);
        var listViewHtml = listView.render(studentTemplate);
        document.getElementById("content").innerHTML = listViewHtml;

        $(".student").on('click', function (ev) {
            ev.stopPropagation();
            ev.preventDefault();
            var id = this.id;
            if ($(this).parent().children().last().hasClass('hidden')) {
                $(this).parent().children().last().removeClass();
            }
            else {
                $(this).parent().children().last().addClass("hidden");
            }
            
        })

    }, function (err) {
        var errorMsg = JSON.parse(err.responseText);
        self.msgLogger.html(errorMsg.Message);
    });
    return false;
}
