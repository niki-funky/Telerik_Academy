/// <reference path="Scripts/angular.min.js" />
/// <reference path="~/Scripts/underscore.js" />

var app = angular.module("OfferWorld", []);

app.config(function ($routeProvider) {
    $routeProvider
        .when('/home',
        {
            templateUrl: 'AdminClient/partials/home.html',
            controller: HomeController
        })
        .when('/user/login',
        {
            templateUrl: 'AdminClient/partials/login-form.html',
            controller: LoginController
        })
        .when('/tasks',
        {
            templateUrl: 'AdminClient/partials/tasks.html',
            controller: LogoutController
        })
        .when('/category/create',
        {
            templateUrl: 'AdminClient/partials/create-category.html',
            controller: CategoriesController
        })
        .when('/category/delete',
        {
            templateUrl: 'AdminClient/partials/delete-category.html',
            controller: CategoriesController
        })
        .when('/user/register',
        {
            templateUrl: 'AdminClient/partials/register-form.html',
            controller: RegisterController
        })
        .when('/tasks',
        {
            templateUrl: 'AdminClient/partials/tasks.html',
            controller: TasksController
        })
        .otherwise({ redirectTo: "/home" });;
});

app.factory("SessionService", function () {
    var get = function (key) {
        return sessionStorage.getItem(key);
    };
    var set = function (key, value) {
        return sessionStorage.setItem(key, value);
    };
    var unset = function (key) {
        return sessionStorage.removeItem(key);
    };

    return {
        get: get,
        set: set,
        unset: unset
    };
});

app.factory("AuthenticationService", function ($http, $location, SessionService) {

    var login = function (username, password) {
        var newUser = {
            Username: username,
            AuthCode: CryptoJS.SHA1(password).toString()
        };

        var result = $http.post("http://localhost:37755/api/users/login", newUser);
        result.success(function (data) {
            SessionService.set("SessionKey", data.SessionKey);
        });

        return result;
    };

    var logout = function () {
        
        var sessionKey = SessionService.get("SessionKey");
        var headers = {
            "X-sessionKey": sessionKey
        };
        
        var result = $http.put("http://localhost:37755/api/users/logout", headers);
        //result.success(function () {
        //    SessionService.set("SessionKey", "");
        //});

        return result;
    };

    var register = function (username, email, password) {
        var newUser = {
            Username: username,
            AuthCode: CryptoJS.SHA1(password).toString(),
            Email: email
        };

        var result = $http.post("http://localhost:37755/api/users/register", newUser);
        result.success(function (data) {
            SessionService.set("SessionKey", data.SessionKey);
        });

        return result;
    };

    var isUserLoggedIn = function () {
        return SessionService.get("SessionKey");
    };

    return {
        login: login,
        logout: logout,
        register: register,
        isUserLoggedIn: isUserLoggedIn
    };
});