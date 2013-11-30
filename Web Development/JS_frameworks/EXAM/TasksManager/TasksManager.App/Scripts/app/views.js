/// <reference path="../libs/_references.js" />


window.viewsFactory = (function () {
    var rootUrl = "Scripts/partials/";

    var templates = {};

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates[name]) {
                resolve(templates[name])
            }
            else {
                $.ajax({
                    url: rootUrl + name + ".html",
                    type: "GET",
                    success: function (templateHtml) {
                        templates[name] = templateHtml;
                        resolve(templateHtml);
                    },
                    error: function (err) {
                        reject(err)
                    }
                });
            }
        });
        return promise;
    }

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getMainMenuView() {
        return getTemplate("main-menu");
    }

    function getLogoutView() {
        return getTemplate("logout-form");
    }

    // appointments
    function createAppView() {
        return getTemplate("create-app");
    }

    function getAllAppView() {
        return getTemplate("all-app");
    }

    function getComingAppView() {
        return getTemplate("all-coming");
    }

    function getSearchByDateAppView() {
        return getTemplate("search-by-date-app");
    }

    function getAllFromTodayAppView() {
        return getTemplate("all-app");
    }

    function getAllCurrentAppView() {
        return getTemplate("all-app");
    }

    // lists
    function createListView() {
        return getTemplate("create-list");
    }

    function getAllListsView() {
        return getTemplate("all-lists");
    }

    function getListDetailsView() {
        return getTemplate("detail-lists");
    }

    return {
        // user
        getLoginView: getLoginView,
        getMainMenuView: getMainMenuView,
        getLogoutView: getLogoutView,
        // appointments
        createAppView: createAppView,
        getAllAppView: getAllAppView,
        getComingAppView: getComingAppView,
        getSearchByDateAppView: getSearchByDateAppView,
        getAllFromTodayAppView: getAllFromTodayAppView,
        getAllCurrentAppView: getAllCurrentAppView,
        // lists
        createListView: createListView,
        getAllListsView: getAllListsView,
        getListDetailsView: getListDetailsView,
    };
}());