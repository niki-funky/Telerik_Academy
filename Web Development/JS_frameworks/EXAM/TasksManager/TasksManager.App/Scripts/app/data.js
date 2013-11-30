/// <reference path="../libs/_references.js" />

window.persisters = (function () {
    var username = localStorage.getItem("username");
    var accessToken = localStorage.getItem("accessToken");

    function saveUserData(userData) {
        //debugger;
        localStorage.setItem("username", userData.Username);
        localStorage.setItem("accessToken", userData.accessToken);
        username = userData.Username;
        accessToken = userData.accessToken;
    }
    function clearUserData() {
        localStorage.removeItem("username");
        localStorage.removeItem("accessToken");
        username = "";
        accessToken = "";
    }

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password) {
            //debugger;
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };
            return httpRequester.postJSON(this.apiUrl + "auth/token", user)
				.then(function (data) {
                    //debugger
				    //save to localStorage
				    saveUserData(data);
				});
        },
        register: function (username, email, password) {
            var user = {
                username: username,
                email: email,
                authCode: CryptoJS.SHA1(password).toString()
            };
            return httpRequester.postJSON(this.apiUrl + "users/register", user)
				.then(function (data) {
				    //save to localStorage
				    saveUserData(data);
				});
        },
        logout: function () {
            var headers = {
                "X-accessToken": accessToken
            };

            return httpRequester.putJSON(this.apiUrl + "users", headers)
            .then(function (data) {
                clearUserData();
            });
        },
        currentUser: function () {
            return username;
        }
    });

    var AppointmentsPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
	    create: function (subject, description, appointmentDate, duration) {
            
	        var headers = {
	            "X-accessToken": accessToken
	        };
	        var model = {
	            subject: subject,
	            description: description,
	            appointmentDate: appointmentDate,
	            duration: duration
	        };
	        debugger
	        return httpRequester.postJSON(this.apiUrl, model, headers);
	    },
	    getAll: function () {
            //debugger
	        var headers = {
	            "X-accessToken": accessToken
	        };

	        return httpRequester.getJSON(this.apiUrl + "all", headers);
	    },
	    getUpcomming: function () {
	        var headers = {
	            "X-accessToken": accessToken
	        };

	        //return getJSON(this.apiUrl + "GetById?id="+id, headers);
	        return httpRequester.getJSON(this.apiUrl + "comming", headers);
	    },
	    getByDate: function (appDate) {
	        var headers = {
	            "X-accessToken": accessToken,
	        };
            //debugger
	        return httpRequester.getJSON(this.apiUrl + "?date=" + appDate, headers);
	    },
	    getByToday: function (today) {
	        var headers = {
	            "X-accessToken": localStorage.getItem("accessToken")
	        };

	        return httpRequester.getJSON(this.apiUrl + "today", headers);
	    },
	    getAllCurrent: function () {
	        var headers = {
	            "X-accessToken": localStorage.getItem("accessToken")
	        };

	        return httpRequester.getJSON(this.apiUrl + "current", headers);
	    }
	});

	var ListsPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },	    
	    create: function (title) {
	        var headers = {
	            "X-accessToken": accessToken
	        };

	        var model = {
	            title: title,
	            todos: new Array(),
	        };

	        return httpRequester.postJSON(this.apiUrl, model, headers);
	    },
	    getAll: function () {
	        var headers = {
	            "X-accessToken": accessToken
	        };

	        return httpRequester.getJSON(this.apiUrl, headers);
	    },
	    getById: function (id) {
	        var headers = {
	            "X-accessToken": accessToken
	        };

	        return httpRequester.getJSON(this.apiUrl + id + "/todos", headers);
	    },
	    createTodo: function (id) {
	        var headers = {
	            "X-accessToken": accessToken
	        };

	        return httpRequester.postJSON(this.apiUrl + id + "/todos", headers);
	    }
	});

	var TodosPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },
	    change: function (id) {
	        var headers = {
	            "X-accessToken": accessToken
	        };

	        return httpRequester.putJSON(this.apiUrl + id, headers);
	    }
	})

	var DataPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
			this.users = new UsersPersister(apiUrl + "/");
			this.appointments = new AppointmentsPersister(apiUrl + "appointments/");
			this.lists = new ListsPersister(apiUrl + "lists/");
			this.todos = new TodosPersister(apiUrl + "todos/");
		}
	});


	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	}
}());