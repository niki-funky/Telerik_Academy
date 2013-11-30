/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
    var data = null;

    function getLoginViewModel(successCallback) {
        var viewModel = {
            login: function () {
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        //debugger;
					        successCallback();
					    }
					}, function (err) {
					    debugger;
					    return err;
					});
            },
            register: function () {
                debugger
                data.users.register(this.get("username"), this.get("email"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        debugger;
					        successCallback();
					    }
					}, function (err) {
					    return err;
					});
            }
        };
        return kendo.observable(viewModel);
    };

    function getLogoutModel(successCallback) {
        var viewModel = {
            logout: function () {
                data.users.logout()
                .then(function () {
                    // debugger;
                    if (successCallback) {
                        successCallback();
                    }
                }, function () {
                    // debugger;
                    if (successCallback) {
                        successCallback();
                    }
                });
            },
            username: username
        }

        return kendo.observable(viewModel);
    }

    // appointments
    function getAllAppModel() {
        return data.appointments.getAll()
            .then(function (apps) {
                //debugger;
                var viewModel = {
                    appointments: apps
                }

                return kendo.observable(viewModel);
            });
    }

    function createAppModel(successCallback) {
        var viewModel = {
            create: function () {
                //debugger
                data.appointments.create(this.get("subject"), this.get("description"),
                    this.get("appointmentDate"), this.get("duration"))
                   .then(function () {
                       //debugger;
                       if (successCallback) {
                           //debugger;
                           successCallback();
                       }
                   }, function (err) {
                       return err;
                   });
            }
        };
        return kendo.observable(viewModel);
    };

    function getComingAppModel() {
        return data.appointments.getUpcomming()
            .then(function (apps) {
                //debugger;
                //var dataSource = new kendo.data.DataSource({
                //    data: apps,
                //    schema: {
                //        //data: "items",//<-- this is the field from the response which contains the actual data
                //        //total: function (data) {
                //        //    return data.items.length || 0;
                //        //}

                //    }
                //});

                //var sorting = [{ field: 'appointmentDate', dir: 'desc' }];

                //dataSource.sort(sorting);

                var viewModel = {
                    appointments: apps
                }

                return kendo.observable(viewModel);
            });
    }

    function getSearchByDateModel() {
        var viewModel = {
            searchedDate: "",
            appointments: [],
            searchByDate: function () {
                //debugger;
                var searchedDateData = this.get("searchedDate");
                searchedDateData = kendo.toString(searchedDateData, "dd-MM-yyyy");

                var transition = this;
                data.appointments.getByDate(searchedDateData)
                    .then(function (data) {

                        transition.set("appointments", data);
                    });
            }
        };

        // debugger;
        return kendo.observable(viewModel);
    }

    function getTodayAppModel() {
        return data.appointments.getByToday()
            .then(function (apps) {

                var viewModel = {
                    appointments: apps
                }

                return kendo.observable(viewModel);
            });
    }

    function getCurrentAppModel() {
        return data.appointments.getAllCurrent()
            .then(function (apps) {

                var viewModel = {
                    appointments: apps
                }

                return kendo.observable(viewModel);
            });
    }

    // lists
    function createListModel(successCallback) {
        var viewModel = {
            create: function () {
                debugger
                data.lists.create(this.get("title"))
                   .then(function () {
                       //debugger;
                       if (successCallback) {
                           debugger;
                           successCallback();
                       }
                   }, function (err) {
                       return err;
                   });
            }
        };
        return kendo.observable(viewModel);
    };

    function getAllListsModel(functionCallback) {
        return data.lists.getAll()
            .then(function (lists) {
                //debugger;
                var viewModel = {
                    lists: lists,
                    showDetails: function (ev) {
                        var id = $(ev.target).attr("list-id");
                        functionCallback(id);
                    }
                }

                return kendo.observable(viewModel);
            });
    }

    function getListByIdModel(id) {
        return data.lists.getById(id)
            .then(function (lists) {

                //debugger;
                var viewModel = {
                    lists: lists
                }

                return kendo.observable(viewModel);
            });
    }

    return {
        getLoginVM: getLoginViewModel,
        getLogoutModel: getLogoutModel,
        // appointments
        getAllAppModel: getAllAppModel,
        createAppModel: createAppModel,
        getComingAppModel: getComingAppModel,
        getSearchByDateModel: getSearchByDateModel,
        getTodayAppModel: getTodayAppModel,
        getCurrentAppModel: getCurrentAppModel,
        // lists
        createListModel: createListModel,
        getAllListsModel: getAllListsModel,
        getListByIdModel: getListByIdModel,

        setPersister: function (persister) {
            data = persister
        }
    };
}());