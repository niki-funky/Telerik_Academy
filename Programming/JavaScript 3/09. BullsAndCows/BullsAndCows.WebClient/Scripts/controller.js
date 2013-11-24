/// <reference path="persister.js" />
/// <reference path="external/jquery-2.0.2.intellisense.js" />
/// <reference path="external/class.js" />
/// <reference path="ui.js" />

var controllers = (function () {
    var rootUrl = "http://localhost:40643/api/";

    var Controller = Class.create({
        init: function () {
            this.persister = persisters.get(rootUrl);
            this._scheduledDataUpdates = new Array();
            this.msgLogger = $('#error-messages');
            self = this;
        },

        loadUI: function (selector) {
            if (self.persister.isUserLoggedIn()) {
                self.loadGameUI(selector);
                self.scheduleDataUpdates(selector);
            }
            else {
                this.loadLoginFormUI(selector);
            }
            this.attachUIEventHandlers(selector);
        },

        loadLoginFormUI: function (selector) {
            var loginFormHtml = ui.loginForm()
            $(selector).html(loginFormHtml);
            self.stopDataUpdates();
        },

        loadGameUI: function (selector) {
            $('#start-game').hide();
            var list = ui.gameUI(this.persister.nickname());
            $(selector).html(list);

            this.persister.game.open(function (games) {
                var list = ui.openGamesList(games);
                $(selector + " #open-games").html(list);
            }, function (err) {
                var errorMsg = JSON.parse(err.responseText);
                self.msgLogger.html(errorMsg.Message);
            });

            this.persister.game.myActive(function (games) {
                var list = ui.activeGamesList(games);
                $(selector + " #active-games").html(list);
            }, function (err) {
                var errorMsg = JSON.parse(err.responseText);
                self.msgLogger.html(errorMsg.Message);
            });

            self.getAllMessages();
        },

        loadGame: function (selector, gameId) {
            this.persister.game.state(gameId, function (state) {
                var gameHtml = ui.gameState(state);
                self.checkIfInTurn(state);
                $(selector + " #game-holder").html(gameHtml);
            }, function (err) {
                var errorMsg = JSON.parse(err.responseText);
                self.msgLogger.html(errorMsg.Message);
            });
        },

        checkIfInTurn: function (state) {
            var currentPlayer = self.persister.nickname();
            var playerInTurn = state.blue == currentPlayer ? 'blue' : 'red';

            if (playerInTurn != state.inTurn) {
                $('#guess-input').addClass('hide');
            }
            else {
                $('#guess-input').removeClass('hide');
            }
        },

        checkIfExists: function (state) {
            var carrentGameId = $('#game-state').data("game-id");
            if (carrentGameId == undefined) {
                return false;
            }
            return true;
        },

        registerUser: function (selector, data) {
            self.persister.user.register(data, function () {
                self.loadGameUI(selector);
            }, function (err) {
                var errorMsg = JSON.parse(err.responseText);
                self.msgLogger.html(errorMsg.Message);
            });
            return false;
        },

        startGame: function (selector, gameId) {
            this.persister.game.start(gameId, function () {
                self.loadGame(selector, gameId);
            }, function (err) {
                var errorMsg = JSON.parse(err.responseText);
                self.msgLogger.html(errorMsg.Message);
            });
        },

        makeGuess: function (selector, game) {
            self.persister.guess.make(game, function (data) {
                self.msgLogger.html('Please wait your turn.');
            }, function (err) {
                var errorMsg = JSON.parse(err.responseText);
                self.msgLogger.html(errorMsg.Message);
            });
        },

        getAllMessages: function (selector) {
            self.persister.messages.all(function (data) {
                var list = ui.gameMessages(data);
                $("#game-messages").html(list);
            }, function (err) {
                var errorMsg = JSON.parse(err.responseText);
                self.msgLogger.html(errorMsg.Message);
            });
        },

        //getUnreadMessages: function (selector) {
        //    self.persister.messages.unread(function (data) {
        //        var list = ui.gameMessages(data);
        //        $(selector + " #game-messages").append(list);
        //    }, function (err) {
        //        var errorMsg = JSON.parse(err.responseText);
        //        self.msgLogger.html(errorMsg.Message);
        //    });
        //},

        getUnreadMessages: function (selector) {
            var printScore = function () {
                var currentPlayer = self.persister.nickname();
                self.persister.user.scores(function (data) {
                    var scoreInfo = "";
                    for (var i = 0; i < data.length; i++) {
                        var next = data[i];
                        if (next.nickname == currentPlayer) {
                            var score = next.score;
                            var nickname = next.nickname;
                            scoreInfo += "<p>nickname: " + nickname + " - " + score + " points.</p>"
                        }
                    }
                    $(selector + " #game-messages").append(scoreInfo);
                }, function (err) {
                    var errorMsg = JSON.parse(err.responseText);
                    self.msgLogger.html(errorMsg.Message);
                });
            };

            self.persister.messages.unread(function (data) {
                var list = ui.gameMessages(data);
                $(selector + " #game-messages").append(list);
                printScore();


            }, function (err) {
                var errorMsg = JSON.parse(err.responseText);
                self.msgLogger.html(errorMsg.Message);
            });
        },

        // TODO: clear error list 
        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on("click", "#btn-show-login", function () {
                wrapper.find(".button.selected").removeClass("selected");
                $(this).addClass("selected");
                wrapper.find("#login-form").show();
                wrapper.find("#register-form").hide();
                return false;
            });
            wrapper.on("click", "#btn-show-register", function () {
                wrapper.find(".button.selected").removeClass("selected");
                $(this).addClass("selected");
                wrapper.find("#register-form").show();
                wrapper.find("#login-form").hide();
                return false;
            });
            wrapper.on("click", "#btn-login", function () {
                var username = $(selector + " #tb-login-username").val();
                var usernameEscaped = $("<div />").html(username).text();

                var user = {
                    username: usernameEscaped,
                    password: $(selector + " #tb-login-password").val()
                }

                self.persister.user.login(user, function () {
                    self.loadGameUI(selector);
                }, function () {
                    wrapper.html("oh no..");
                });
                return false;
            });
            wrapper.on("click", "#btn-register", function () {
                var username = $(selector + " #tb-register-username").val();
                var usernameEscaped = $("<div />").html(username).text();
                var nick = $(selector + " #tb-register-nickname").val();
                var nicknameEscaped = $("<div />").html(nick).text();

                var data = {
                    username: usernameEscaped,
                    nickname: nicknameEscaped,
                    password: $(selector + " #tb-register-password").val()
                }

                self.registerUser(selector, data);
            });
            wrapper.on("click", "#btn-logout", function () {
                self.persister.user.logout(function () {
                    self.loadLoginFormUI(selector);
                }, function (err) {
                    var errorMsg = JSON.parse(err.responseText);
                    self.msgLogger.html(errorMsg.Message);
                });
                return false;
            });
            wrapper.on("click", "#open-games-container a", function () {
                //$("#game-join-inputs").remove();
                self.stopDataUpdates();
                //var html =
                //	'<div id="game-join-inputs">' +
                //		'Number: <input type="text" id="tb-game-number"/>' +
                //		'Password: <input type="text" id="tb-game-pass"/>' +
                //		'<button id="btn-join-game">join</button>' +
                //	'</div>';
                var html = ui.loginInGame()
                $(this).after(html);
            });
            wrapper.on("click", "#btn-join-game", function () {
                var game = {
                    number: $("#tb-game-number").val(),
                    gameId: $(this).parents("li").first().data("game-id")
                };

                var password = $("#tb-game-pass").val();

                if (password) {
                    game.password = password;
                }
                self.persister.game.join(game, function () {
                    self.loadGameUI(selector);
                }, function (err) {
                    var errorMsg = JSON.parse(err.responseText);
                    self.msgLogger.html(errorMsg.Message);
                });

                // Clear values in the inputs
                $("#tb-game-number").val("");
                $("#tb-game-pass").val("");
                self.loadUI();
                self.scheduleDataUpdates(selector);
            });
            wrapper.on("click", "#btn-create-game", function () {
                var gameTitle = $("#tb-create-title").val();
                var gameTitleEscaped = $("<div />").html(gameTitle).text();

                var game = {
                    title: gameTitleEscaped,
                    number: $("#tb-create-number").val(),
                }
                var password = $("#tb-create-pass").val();
                if (password) {
                    game.password = password;
                }
                self.persister.game.create(game, function () {
                    //self.loadGameUI(selector);
                }, function (err) {
                    var errorMsg = JSON.parse(err.responseText);
                    self.msgLogger.html(errorMsg.Message);
                });
            });
            wrapper.on("click", ".active-games .in-progress", function () {
                //alert("Play me!");
                self.loadGame(selector, $(this).parent().data("game-id"));
            });
            wrapper.on("click", ".active-games .full", function () {
                //alert("OLE!");
                var gameID = $(this).parent().data("game-id");
                self.startGame(selector, gameID);
            });
            //wrapper.on("click", "div:not(li)", function () {
            //$("#tb-guess-number").val("");
            //    self.scheduleDataUpdates(selector);
            //});
            //wrapper.on("click", "#btn-join-game", function () {
            //    $("#tb-guess-number").val("");
            //    self.scheduleDataUpdates(selector);
            //});
            wrapper.on("click", "#btn-guess", function () {
                var game = {
                    gameId: $('#game-state').data("game-id"),
                    number: $("#tb-guess-number").val(),
                }
                self.makeGuess(selector, game);
                $("#tb-guess-number").val("");
            });
        },

        scheduleDataUpdates: function (selector) {
            var self = this;

            this._scheduledDataUpdates.push(setInterval(function () {
                self.persister.game.open(function (games) {
                    var list = ui.openGamesList(games);
                    $(selector + " #open-games").html(list);
                }, function (err) {
                    var errorMsg = JSON.parse(err.responseText);
                    self.msgLogger.html(errorMsg.Message);
                });

                self.persister.game.myActive(function (games) {
                    var list = ui.activeGamesList(games);
                    $(selector + " #active-games").html(list);
                }, function (err) {
                    var errorMsg = JSON.parse(err.responseText);
                    self.msgLogger.html(errorMsg.Message);
                });

                if (self.checkIfExists()) {
                    self.persister.game.state($('#game-state').data("game-id"), function (state) {
                        var gameHtml = ui.gameState(state);
                        self.checkIfInTurn(state);
                        $(selector + " #game-holder").html(gameHtml)
                    }, function (err) {
                        var errorMsg = JSON.parse(err.responseText);
                        self.msgLogger.html(errorMsg.Message);
                    });
                };

                self.getUnreadMessages(selector);

            }, 9000));
        },

        stopDataUpdates: function () {
            for (i in this._scheduledDataUpdates) {
                var intervalId = this._scheduledDataUpdates[i];
                clearInterval(intervalId);
            }
        },

        stopGame: function () {
            this.stopDataUpdates();

            this._scheduledDataUpdates = new Array();
        }

    });
    return {
        get: function () {
            return new Controller();
        }
    }
}());

$(function () {
    var controller = controllers.get();
    controller.loadUI("#content");
});