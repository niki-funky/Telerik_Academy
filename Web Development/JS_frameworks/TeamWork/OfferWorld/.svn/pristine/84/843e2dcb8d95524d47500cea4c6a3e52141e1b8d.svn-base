function LoginController($scope, $location, AuthenticationService) {
    $scope.user = {
        username: "",
        password: ""
    };

    $scope.password = CryptoJS.SHA1($scope.password).toString();
    $scope.login = function (username, password) {
        AuthenticationService.login(username, password)
            .success(function (result) {
                $location.path("/tasks");
            })
            .error(function () {
                $location.path("/user/login");
            });
    };
}

function LogoutController($scope, $http, $location, AuthenticationService, SessionService) {
    
    $scope.logout = function () {
        AuthenticationService.logout()
            .success(function (result) {
                SessionService.unset("SessionKey");
                $location.path("/user/login");
            })
            .error(function () {
                //$location.path("/user/login");
            });
    };
}

function RegisterController($scope, $location, AuthenticationService) {
    $scope.user = {
        username: "",
        email: "",
        password: ""
    };

    $scope.register = function (username, email, password) {
        AuthenticationService.register(username, email, password)
            .success(function (result) {
                $location.path("/tasks");
            }).error(function () {
                $location.path("/user/register");
            });
    };
}

function CategoriesController($scope, $location, $http, SessionService) {
    $scope.category = {
        title: "",
        SessionKey: SessionService.get("SessionKey")
    };

    $scope.create = function () {
        $http.post("http://localhost:37755/api/categories/create", $scope.category)
            .success(function () {
                $location.path("/tasks");
            });
    };
    
    $scope.delete = function () {
        $http.post("http://localhost:37755/api/categories/delete", $scope.category)
            .success(function () {
                $location.path("/tasks");
            });
    };
}

function HomeController($scope, $http, $location) {
    $scope.redirectToLogin = function () {
        $location.path("/user/login");
    };

    $scope.redirectToRegister = function () {
        $location.path("/user/register");
    };
}

function TasksController($scope, $http, $location, AuthenticationService) {
    if (AuthenticationService.isUserLoggedIn()) {
        $location.path("/tasks");
    } else {
        $location.path("/home");
    }
}