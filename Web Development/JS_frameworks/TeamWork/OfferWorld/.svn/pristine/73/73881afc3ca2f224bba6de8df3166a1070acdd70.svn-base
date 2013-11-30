/// <reference path="_references.js" />


var httpRequester = (function () {
    function getJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function putJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "PUT",
                contentType: "application/json",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    // google token
    function postToken() {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: "https://accounts.google.com/o/oauth2/token",
                //dataType: "json",
                type: "POST",
                contentType: "application/x-www-form-urlencoded",
                dataType: "json",
                data: {
                    'client_id': "55889408904.apps.googleusercontent.com",
                    'client_secret': "P1BhzBjfutSrhHaPe1di38tj",
                    'refresh_token': "1/L6VVMsJZhwIQ1dZ_Gr34L8ss9Z0kuexCCWM6lJn5Xk4",
                    'grant_type': "refresh_token"
                },
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postFileData(url, data, success, error) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                data: data,
                cache: false,
                contentType: false,
                processData: false,
                type: 'POST',
                success: success,
                error: error
            });
        })
        return promise;
    }

    function deleteSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "DELETE",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        putJSON: putJSON,
        postToken: postToken,
        //deleteJSON: deleteJSON
    }
}());