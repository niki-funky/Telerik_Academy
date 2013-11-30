/// <reference path="lib/jquery-2.0.3.js" />

define(["httpRequester"], function (httpRequester) {
    function getStudents() {
        var url = this.url + "api/students/";
        return httpRequester.getJSON(url);
    }

    return {
        students: getStudents,
        url: this.url
    }
});
