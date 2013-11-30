/// <reference path="libs/class.js" />
/// <reference path="libs/http-requester.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="libs/require.js" />
/// <reference path="libs/rsvp.js" />


require.config({
    paths: {
        jquery: "libs/jquery-2.0.3.min",
        httpRequester: "libs/http-requester",
        rsvp: "libs/rsvp.min",
        mustache: "libs/mustache",
        "class": "libs/class",
        controller: "app/controller",
        dataPersister: "app/data-persister"
    }
});

require(["jquery", "dataPersister", "controller", "mustache"], function ($, data, controller, mustache) {
    data.url = "http://localhost:37035/";
    data.students()
    .then(function (data) {
        var studentTemplate = mustache.compile(document.getElementById("student-template").innerHTML);

        var comboBox = controller.createComboBox(data);

        var studentsViewHTML = comboBox.render(studentTemplate);

        $("#main-content").append(studentsViewHTML);

    }, function (err) {
        console.error(err);
    });
});