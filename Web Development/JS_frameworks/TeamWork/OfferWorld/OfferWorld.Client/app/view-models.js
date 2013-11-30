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

    function getLogoutViewModel(successCallback) {
        var viewModel = {
            logout: function () {
                data.users.logout()
                .then(function () {
                    debugger;
                    if (successCallback) {
                        successCallback();
                    }
                }, function () {
                    debugger;
                    if (successCallback) {
                        successCallback();
                    }
                });
            },
            username: localStorage.getItem("username")
        }

        return kendo.observable(viewModel);
    };

    function getItemsViewModel(successCallback) {
        //debugger;
        return data.items.getAll()
			.then(function (data) {
			    //debugger

			    var viewModel = {
			        items: data,
			        showDetails: function (ev) {
			            debugger;
			            var id = $(ev.target).attr("item-id");
			            successCallback(id);
			        }
			    };

			    return kendo.observable(viewModel);
			}, function (err) {
			    return err;
			});
    };

    function getItemDetailViewModel(id, callbackFunction) {
        //debugger;
        var vm = data.items.getById(id)
            .then(function (itemDetails) {
                 debugger;
                var usr = data.comments.getById(id)
                    .then(function (commentDetails) {
                         debugger;
                        var viewModel = {
                            item: [itemDetails],
                            comments: commentDetails,
                            postedCommentText: "",
                            postComment: function (ev) {
                                 debugger;
                                var commentText = this.get("postedCommentText");
                                var id = $(ev.target).attr("item-id");
                                var transition = this;
                                data.comments.postComment(commentText, id).then(function () {
                                     debugger;
                                    //callbackFunction();
                                },
                                function () {
                                    // debugger;
                                    data.comments.getById(id)
                                        .then(function (data) {
                                            transition.set("comments", data);
                                        });
                                    //transition.set("comments", []);
                                    //callbackFunction();
                                });
                            }
                        }

                        return kendo.observable(viewModel);
                    });

                return usr;
            });

        return vm;
    }

    return {
        getLoginVM: getLoginViewModel,
        getLogoutVM: getLogoutViewModel,
        getItemsVM: getItemsViewModel,
        getItemDetailVM: getItemDetailViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());