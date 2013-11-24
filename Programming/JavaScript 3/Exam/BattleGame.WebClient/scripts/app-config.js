/// <reference path="libs/require.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="libs/sammy.js" />
/// <reference path="libs/http-requester.js" />
/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="app/ui.js" />

(function () {
    require.config({
        paths: {
            jquery: "libs/jquery-2.0.3",
            mustache: "libs/mustache",
            sammy: "libs/sammy",
            "http-requester": "libs/http-requester",
            eventsHandler: "app/event-handler",
            uiBuild: "app/ui",
            controllers: "app/controller",
            persister: "app/persister",
            cryptoJS: "libs/cryptojs-sha1",
            "class": "libs/class",
            underscore: "libs/underscore"
        }
    })

    require(["jquery", "sammy", "mustache", "http-requester", "controllers"],
					function ($, sammy, mustache, request, controllers) {
					    var app = sammy("#main-content", function () {

					        var controller = controllers.get();
					        // home
					        this.get("#/", function () {
					            controller.loadUI("#main-content");
					        });

					        // join game
					        this.get("#/join", function () {
					            controller.loadOpenGames("#main-content");
					        });

					        // my games game
					        this.get("#/games", function () {
					            //// needed refresh !!!
					            //location.reload();
					            controller.loadActiveGames("#main-content");
					        });

					        // battlefield
					        this.get("#/battle", function () {
					            var gameIdValue = $('#btn-battle').data("gameid");
					            controller.loadBattlefield("#main-content", gameIdValue);
					        });

					        // battlefield
					        this.get("#/battle/:id", function () {
					            controller.loadBattlefield("#main-content", this.params["id"]);
					        });
					    });

					    app.run("#/");

					    $("header").on("click", "nav ul li", function () {
					        $(this).siblings().removeClass("selected");
					        $(this).addClass("selected");
					    });
					});
}());