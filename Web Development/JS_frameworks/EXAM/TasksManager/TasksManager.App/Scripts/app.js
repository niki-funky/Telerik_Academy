/// <reference path="libs/_references.js" />


(function () {
    var appLayout = new kendo.Layout('<div id="main-content"></div>');

    var data = persisters.get("http://localhost:16183/api/");
    vmFactory.setPersister(data);

    var router = new kendo.Router();
    router.route("/", function () {

        if (data.users.currentUser()) {
            //debugger;
            router.navigate("/logged");
        }
        else {
            //debugger;
            $("#logout-container").hide();
            router.navigate("/login");
        }
    });

    router.route("/login", function () {
        $("#logout-div").toggle();
        if (data.users.currentUser()) {
            debugger;
            router.navigate("/logged");
        }
        else {
            viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    //debugger
				    var loginVm = vmFactory.getLoginVM(function () {
				        router.navigate("/logged");
				    });
				    var view = new kendo.View(loginViewHtml, { model: loginVm });
				    appLayout.showIn("#main-content", view);
				});
        }
    });

    router.route("/logged", function () {
        $("#logout-container").show();
        //debugger;
        viewsFactory.getMainMenuView()
        .then(function (mainMenuHtml) {
            //debugger;
            var view = new kendo.View(mainMenuHtml);
            appLayout.showIn("#main-content", view);
        })
    });

    // appointments
    router.route("/all-app", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        $("#logout-container").show();
        //debugger
        viewsFactory.getAllAppView()
            .then(function (appHtml) {
                //debugger;
                vmFactory.getAllAppModel(function () {
                })
                .then(function (vm) {;
                    //debugger;
                    var view = new kendo.View(appHtml, { model: vm });
                    appLayout.showIn("#main-content", view)
                });
            });
    });

    router.route("/create-app", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        $("#logout-container").show();
        //debugger
        viewsFactory.createAppView()
            .then(function (appHtml) {
                //debugger;
                var loginVm = vmFactory.createAppModel(function () {
                    //debugger;
                    router.navigate("/logged");
                });
                //debugger
                var view = new kendo.View(appHtml, { model: loginVm });
                appLayout.showIn("#main-content", view)
            });
    });

    router.route("/coming-app", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        $("#logout-container").show();
        //debugger
        viewsFactory.getComingAppView()
            .then(function (appHtml) {
                //debugger;
                vmFactory.getComingAppModel(function () {
                })
                .then(function (vm) {;
                    //debugger;
                    var view = new kendo.View(appHtml, { model: vm });
                    appLayout.showIn("#main-content", view)
                });
            });
    });

    router.route("/search-by-date-app", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        $("#logout-container").show();
        //debugger;
        viewsFactory.getSearchByDateAppView()
            .then(function (appHtml) {
                var vm = vmFactory.getSearchByDateModel(function () {
                    //debugger;
                });
                //debugger;
                var view = new kendo.View(appHtml, { model: vm });
                appLayout.showIn("#main-content", view);
                $("#datepicker1").kendoDatePicker();
            });
    });

    router.route("/all-from-today-app", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        $("#logout-container").show();
        //debugger
        viewsFactory.getAllFromTodayAppView()
            .then(function (appHtml) {
                //debugger;
                vmFactory.getTodayAppModel(function () {
                })
                .then(function (vm) {;
                    //debugger;
                    var view = new kendo.View(appHtml, { model: vm });
                    appLayout.showIn("#main-content", view)
                });
            });
    });

    router.route("/all-current", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        $("#logout-container").show();
        //debugger
        viewsFactory.getAllCurrentAppView()
            .then(function (appHtml) {
                //debugger;
                vmFactory.getCurrentAppModel(function () {
                })
                .then(function (vm) {;
                    //debugger;
                    var view = new kendo.View(appHtml, { model: vm });
                    appLayout.showIn("#main-content", view)
                });
            });
    });

    // lists
    router.route("/create-list", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        $("#logout-container").show();
        //debugger
        viewsFactory.createListView()
            .then(function (listsHtml) {
                //debugger;
                var loginVm = vmFactory.createListModel(function () {
                    //debugger;
                    router.navigate("/logged");
                });
                //debugger
                var view = new kendo.View(listsHtml, { model: loginVm });
                appLayout.showIn("#main-content", view)
            });
    });

    router.route("/all-lists", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        $("#logout-container").show();
        //debugger
        viewsFactory.getAllListsView()
            .then(function (listsHtml) {
                //debugger;
                vmFactory.getAllListsModel(function (idParam) {
                    router.navigate("/get-by-id-list/" + idParam);
                })
                .then(function (vm) {;
                    //debugger;
                    var view = new kendo.View(listsHtml, { model: vm });
                    appLayout.showIn("#main-content", view)
                });
            });
    });

    router.route("/get-by-id-list/:id", function (id) {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        } else {
            //debugger
            viewsFactory.getListDetailsView()
                .then(function (listHtml) {
                    //debugger
                    vmFactory.getListByIdModel(id)
                        .then(function (vm) {
                            //debugger
                            var view = new kendo.View(listHtml,
                            {
                                model: vm
                            });
                            appLayout.showIn("#main-content", view);
                        })
                })
        }
    });

    //only for registered users
    router.route("/special", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
    });

    $(function () {
        appLayout.render("#app");
        router.start();
    });
}());