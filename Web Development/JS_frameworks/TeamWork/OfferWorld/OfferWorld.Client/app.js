/// <reference path="libs/_references.js" />

(function () {
    var appLayout = new kendo.Layout('<div id="main-content"></div>');

    var data = persisters.get("http://localhost:37755/api/");
    vmFactory.setPersister(data);

    var router = new kendo.Router();
    router.route("/", function () {
        //debugger;
        if (data.users.currentUser()) {
            router.navigate("/all-items");
        }
        else {
            router.navigate("/login");
        }
    });

    router.route("/login", function () {
        $("#logout-div").toggle();
        if (data.users.currentUser()) {
            router.navigate("/");
        }
        else {
            viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(function () {
				        router.navigate("/");
				    });
				    var view = new kendo.View(loginViewHtml, { model: loginVm });
				    appLayout.showIn("#main-content", view);
				});
        }
    });

    router.route("/all-items", function () {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        viewsFactory.getItemsView()
            .then(function (itemListHtml) {
                vmFactory.getItemsVM(function (id) {
                    debugger;
                    router.navigate("/item-details/" + id);
                })
                .then(function (vm) {

                    var view = new kendo.View(itemListHtml);

                    appLayout.showIn("#main-content", view);
                    //debugger;

                    var dataSource = new kendo.data.DataSource({
                        data: vm,
                        pageSize: 8,
                        schema: {
                            data: "items",//<-- this is the field from the response which contains the actual data
                            total: function (data) {
                                return data.items.length|| 0;
                            }
                        }
                    });

                    $("#pager").kendoPager({
                        dataSource: dataSource
                    });

                    $("#listView").kendoListView({
                        dataSource: dataSource,
                        selectable: "multiple",
                        //dataBound: onDataBound,
                        change: onChange,
                        template: kendo.template($("#items-template").html())
                    });

                    function onDataBound() {
                        console.log("ListView data bound");
                    }

                    function onChange(ev) {
                        //debugger;
                        var data = dataSource.view()
                        var selectedId = $.map(this.select(), function (item) {
                            //debugger;
                            return data[$(item).index()].Id;
                        });

                        console.log("Selected:" + selectedId);
                        
                        router.navigate("/item-details/" + selectedId);
                    }
                });
            }, function (err) {
                console.log(err);
            });
    });

    router.route("/item-details/:id", function (id) {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        viewsFactory.getItemDetailsView()
        .then(function (itemDetailsHtml) {
            //debugger;
            vmFactory.getItemDetailVM(id, function () {
                debugger;
                router.navigate("/redirection/" + id);
            }).then(function (vm) {;
                debugger;
                var itemDetailsModel = vm;
                var view = new kendo.View(itemDetailsHtml, { model: itemDetailsModel });
                appLayout.showIn("#main-content", view);
            },
                function (err) {
                    debugger;
                });
        });
    });

    router.route("/redirection/:id", function (id) {
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }

        // debugger;
        router.navigate("/item-details/" + id);

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