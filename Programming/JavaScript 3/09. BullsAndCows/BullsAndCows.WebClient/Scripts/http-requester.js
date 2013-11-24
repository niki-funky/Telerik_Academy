/// <reference path="external/jquery-2.0.2.intellisense.js" />
var httpRequester = (function () {
    function getJSON(url, success, error) {
        $.ajax({
            url: url,
            type: "GET",
            timeout: 5000,
            contentType: "application/json",
            success: success,
            error: error
        });
    }
    function postJSON(url, data, success, error) {
        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json",
            timeout: 5000,
            data: JSON.stringify(data),
            success: success,
            error: error
        });
    }
    return {
        getJSON: getJSON,
        postJSON: postJSON
    };
}());


//URL: http://localhost:40643/api/user/register

//Headers:

//User-Agent: Fiddler
//Host: localhost:40643
//Content-Type: application/json

//Body:

//{
//"username": "user1",
//"nickname": "nick1",
//"authCode": "11daa37d0679ca88db6464eac60da96345513a6d"
//}