/// <reference path="../libs/_references.js" />

window.viewsFactory = (function () {
	var rootUrl = "partials/";

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

	function getItemsView() {
		return getTemplate("items");
	}

	function getItemDetailsView() {
	    return getTemplate("item-details");
	}

	return {
		getLoginView: getLoginView,
		getItemsView: getItemsView,
		getItemDetailsView: getItemDetailsView
	};
}());