/// <reference path="persister.js" />
/// <reference path="external/jquery-2.0.2.intellisense.js" />
/// <reference path="external/class.js" />
/// <reference path="ui.js" />


// tripple '{' in mustache avoid escaping
define(["class", "persister", "uiBuild", "mustache", "underscore"],
       function (Class, persisters, ui, mustache, underscore) {
           var controllers = (function () {
               var rootUrl = "http://battlegame-2.apphb.com/api/";

               var Controller = Class.create({
                   init: function () {
                       this.persister = persisters.get(rootUrl);
                       this.scheduleTimer = setTimeout(console.log("timer initialized"), 3000);
                       this._scheduledDataUpdates = new Array();
                       this.dataFromClicks = new Array();
                       this.msgLogger = $('#error-messages');
                       self = this;
                   },

                   loadUI: function (selector) {
                       self.persister.isUserLoggedIn(function (data) {
                           // stop auto updates
                           self.stopDataUpdates();

                           self.loadLoggedUser(selector);
                       }, function (data) {
                           // stop auto updates
                           self.stopDataUpdates();

                           self.loadLoginFormUI(selector);
                       });

                       self.attachUIEventHandlers(selector);
                   },

                   loadLoginFormUI: function (selector) {
                       var loginPage = ui.buildLoginPage();
                       var loginForm = ui.buildLoginForm();
                       $(selector).html(loginPage + loginForm);
                       self.stopDataUpdates();
                   },

                   loadLoggedUser: function (selector) {
                       $('<div id="temp"></div>').load('htmlTemplates/loggedUser.html',
                           function (template) {
                               var obj = {
                                   nickname: self.persister.nickname()
                               }
                               var loggedUserHtml =
                                   mustache.render(template, obj);
                               $(selector).html(loggedUserHtml);
                           });

                       //self.scheduleDataUpdates(selector);
                   },

                   loginUser: function (selector, user) {
                       self.persister.user.login(user, function () {
                           self.loadLoggedUser(selector);
                       }, function () {
                           var errorMsg = JSON.parse(err.responseText);
                           self.msgLogger.html(errorMsg.Message);
                           alert("Wrong username and/or password!");
                           $("form").trigger('reset');
                       });
                   },

                   registerUser: function (selector, data) {
                       self.persister.user.register(data, function () {
                           self.loadLoggedUser(selector);
                           //self.loadGameUI(selector);
                       }, function (err) {
                           var errorMsg = JSON.parse(err.responseText);
                           self.msgLogger.html(errorMsg.Message);
                       });
                       return false;
                   },

                   // open games
                   loadOpenGames: function (selector) {
                       self.persister.isUserLoggedIn(
                              function () {
                                  var openGamesHtml = ui.buildOpenGames();
                                  $(selector).html(openGamesHtml);
                                  // stop auto updates
                                  self.stopDataUpdates();

                                  self.updateOpenGameList();
                                  // start auto updates 
                                  //self.scheduleOpenGamesUpdates(selector);
                              }, function () {
                                  $('#main-content').html('No user is logged.')
                              });
                   },

                   updateOpenGameList: function () {
                       $('<div id="temp"></div>')
                           .load('htmlTemplates/openGamesList.html',
                            function (data) {
                                self.persister.game.open(
                                    function (games) {
                                        var view = {
                                            games: games
                                        }
                                        var openGamesListHtml =
                                        mustache.render(data, view);
                                        $('#open-games').html(openGamesListHtml);

                                        self.scheduleTimer = setTimeout(function () {
                                            self.updateOpenGameList();
                                        }, 3000);
                                    }, function (err) {
                                        var errorMsg = JSON.parse(err.responseText);
                                        self.msgLogger.html(errorMsg.Message);
                                    });
                            });
                       //self.scheduleTimer = setTimeout(function () {
                       //    self.updateOpenGameList();
                       //}, 3000);
                   },

                   // active games
                   loadActiveGames: function (selector) {
                       self.persister.isUserLoggedIn(
                           function () {
                               var activeGamesHtml = ui.buildActiveGames();
                               $(selector).html(activeGamesHtml);

                               // stop auto updates
                               self.stopDataUpdates();

                               self.updateActiveGameList();                               

                           }, function () {
                               $('#main-content').html('No user is logged.')
                           });
                   },

                   updateActiveGameList: function () {
                       $('<div id="temp"></div>')
                           .load('htmlTemplates/activeGamesList.html',
                            function (template) {
                                self.persister.game.myActive(
                                    function (games) {
                                        // sort games by status
                                        var gamesList = Array.prototype.slice.call(games, 0);
                                        gamesList.sort(function (g1, g2) {
                                            if (g1.status == g2.status) {
                                                return g1.title > g2.title;
                                            }
                                            else {
                                                if (g1.status == "in-progress") {
                                                    return -1;
                                                }
                                            }
                                            return 1;
                                        });
                                        var view = {
                                            games: games
                                        }
                                        // render mustache template
                                        var openGamesListHtml =
                                            mustache.render(template, view);
                                        $('#active-games').html(openGamesListHtml);
                                        // add gameId in the href
                                        $.each($('a.in-progress'), function (index, game) {
                                            var gameID = $(game).parent().data('game-id');
                                            $(game).attr('href', '#/battle/' + gameID)
                                        });

                                        self.scheduleTimer = setTimeout(function () {
                                            self.updateActiveGameList();
                                        }, 3000);
                                    }, function (err) {
                                        var errorMsg = JSON.parse(err.responseText);
                                        self.msgLogger.html(errorMsg.Message);
                                    });
                            });
                   },

                   // battlefield
                   loadBattlefield: function (selector, gameId) {
                       self.persister.isUserLoggedIn(
                           function (scores) {
                               // stop auto updates
                               self.stopDataUpdates();

                               if (gameId) {
                                   var battlefieldHtml = ui.buildBattlefield();
                                   $(selector).html(battlefieldHtml);

                                   self.updateBattlefield(selector, gameId, scores);
                                   //self.reloadField(selector);

                                   self.getAllMessages();

                                   // start auto updates 
                                   //self.scheduleBattlefieldUpdates(selector);
                               } else {
                                   $('#main-content').html('No active game is selected.')
                               }

                           }, function () {
                               $('#main-content').html('No user is logged.')
                           });
                   },

                   updateBattlefield: function (selector, gameId, scores) {
                       if (gameId) {
                           $('<div id="temp"></div>')
                               .load('htmlTemplates/battlefield.html',
                                function (template) {
                                    // TODO: split scores update from table update
                                    self.persister.game.field(gameId, function (state) {
                                        var battlefieldHtml =
                                            mustache.render(template, state);
                                        $(selector + " #game-holder").html(battlefieldHtml);

                                        self.parseFieldData(state);
                                        // get scores
                                        var blueScores = _.find(scores, function (obj) {
                                            return obj.nickname == state.blue.nickname;
                                        })
                                        var redScores = _.find(scores, function (obj) {
                                            return obj.nickname == state.red.nickname;
                                        })
                                        $('#bluePlayer').html(blueScores.score);
                                        $('#redPlayer').html(redScores.score);
                                        // check if in turn (disables moves)
                                        self.checkIfInTurn(state);

                                        self.scheduleTimer = setTimeout(function () {
                                            self.updateBattlefield(selector, gameId, scores);
                                        }, 3000);
                                    }, function (err) {
                                        var errorMsg = JSON.parse(err.responseText);
                                        self.msgLogger.html(errorMsg.Message);
                                    });
                                });
                       }
                   },

                   checkIfInTurn: function (state) {
                       var currentPlayer = self.persister.nickname();
                       var playerInTurn = state.blue.nickname == currentPlayer ? 'blue' : 'red';

                       if (playerInTurn != state.inTurn) {
                           //$('#guess-input').addClass('hide');
                           self.dettachUIEventHandlers();
                           $('td > span').addClass("notInTurn");
                           console.log($('td > span'));
                       }
                       else {
                           $('td > span').removeClass('notInTurn');
                       }
                   },

                   parseFieldData: function (state) {
                       var battleField = document.getElementById('field');
                       var red = state.red.units;
                       var blue = state.blue.units;
                       var unit, type, position, posX, posY;
                       for (var i = 0; i < red.length; i++) {
                           unit = red[i];
                           type = '';
                           if (unit.type === 'warrior') {
                               type = 'W';
                           }
                           else {
                               type = 'R';
                           }
                           position = unit.position;
                           posX = position.x;
                           posY = position.y;
                           battleField.rows[posY].cells[posX].innerHTML =
                               '<span id="' + unit.id +
                               '" hitPoints="' + unit.hitPoints +
                               '" player="red"' +
                               '">' + type +
                               '</span>';
                           battleField.rows[posY].cells[posX].style.backgroundColor = "#ff3a3a";
                       }
                       for (var i = 0; i < blue.length; i++) {
                           unit = blue[i];
                           type = '';
                           if (unit.type === 'warrior') {
                               type = 'W';
                           }
                           else {
                               type = 'R';
                           }
                           position = unit.position;
                           posX = position.x;
                           posY = position.y;
                           battleField.rows[posY].cells[posX].innerHTML =
                               '<span id="' + unit.id +
                               '" hitPoints="' + unit.hitPoints +
                               '" player="blue"' +
                               '">' + type +
                               '</span>';
                           battleField.rows[posY].cells[posX].style.backgroundColor = "#00d9ff";
                       }

                   },

                   reloadField: function (selector) {
                       var gameIdVal = $('#btn-battle').data("gameid");
                       if (gameIdVal) {
                           // TODO: split scores update from table update
                           self.persister.isUserLoggedIn(function (scores) {
                               self.updateBattlefield(selector, gameIdVal, scores);

                               //self.scheduleTimer = setTimeout(function () {
                               //    self.updateBattlefield(selector, gameIdVal, scores);
                               //}, 3000);
                           }, function () {
                               $('#main-content').html('No user is logged.')
                           });
                       };
                   },

                   // start full game
                   startGame: function (selector, gameId) {
                       self.persister.game.start(gameId, function () {
                           //self.loadBattlefield(selector, gameId);
                           window.location = "#/battle";
                           return false;
                       }, function (err) {
                           var errorMsg = JSON.parse(err.responseText);
                           self.msgLogger.html(errorMsg.Message);
                       });
                   },

                   // battle moves
                   calcMoveOrAttack: function (selector) {
                       var unitSpeed;
                       var unitRange;
                       if (self.dataFromClicks[0].player != undefined &&
                           self.dataFromClicks[1].player != undefined) {
                           var range = Math.abs(self.dataFromClicks[0].x - self.dataFromClicks[1].x) +
                                       Math.abs(self.dataFromClicks[0].y - self.dataFromClicks[1].y);
                           if (self.dataFromClicks[0].type == "W") {
                               unitRange = 1;
                           }
                           else {
                               unitRange = 3;
                           }
                           var calcRange = unitRange >= range;
                           if (calcRange) {
                               var data1 = {
                                   id: $('#game-state').data("game-id"),
                                   unitId: self.dataFromClicks[0].id,
                                   x: self.dataFromClicks[1].x,
                                   y: self.dataFromClicks[1].y
                               }
                               self.attackPlayer(selector, data1)
                           }

                       }
                       else {
                           var speed = Math.abs(self.dataFromClicks[0].x - self.dataFromClicks[1].x) +
                                       Math.abs(self.dataFromClicks[0].y - self.dataFromClicks[1].y);
                           if (self.dataFromClicks[0].type == "W") {
                               unitSpeed = 2;
                           }
                           else {
                               unitSpeed = 1;
                           }
                           var calcSpeed = unitSpeed >= speed
                           if (calcSpeed) {
                               var data2 = {
                                   id: $('#game-state').data("game-id"),
                                   unitId: self.dataFromClicks[0].id,
                                   x: self.dataFromClicks[1].x,
                                   y: self.dataFromClicks[1].y
                               }
                               self.movePlayer(selector, data2)
                           }
                       }

                   },

                   movePlayer: function (selector, data) {
                       var position = {
                           x: data.x,
                           y: data.y,
                       };
                       var playerData = {
                           unitId: data.unitId,
                           position: position
                       }
                       self.makeDefend(selector, data);
                       self.persister.battle.move(data.id, playerData, function (data) {
                           //self.reloadField(selector);
                       }, function (err) {
                           var errorMsg = JSON.parse(err.responseText);
                           self.msgLogger.html(errorMsg.Message);
                       });
                   },

                   attackPlayer: function (selector, data) {
                       var position = {
                           x: data.x,
                           y: data.y,
                       };
                       var playerData = {
                           unitId: data.unitId,
                           position: position
                       }

                       self.persister.battle.attack(data.id, playerData, function (data) {
                           //self.reloadField(selector);
                       }, function (err) {
                           var errorMsg = JSON.parse(err.responseText);
                           self.msgLogger.html(errorMsg.Message);
                       });
                   },

                   makeDefend: function (selector, data) {
                       var playerData = {
                           unitId: data.unitId,
                       }

                       self.persister.battle.defend(data.id, playerData, function (data) {
                           //self.reloadField(selector);
                       }, function (err) {
                           var errorMsg = JSON.parse(err.responseText);
                           self.msgLogger.html(errorMsg.Message);
                       });
                   },

                   // messages
                   getAllMessages: function (selector) {
                       self.persister.messages.all(function (data) {
                           var list = ui.gameMessages(data);
                           $("#game-messages").html(list);
                       }, function (err) {
                           var errorMsg = JSON.parse(err.responseText);
                           self.msgLogger.html(errorMsg.Message);
                       });
                   },

                   getUnreadMessages: function (selector) {
                       self.persister.messages.unread(function (data) {
                           var list = ui.gameMessages(data);
                           $(selector + " #game-messages").append(list);
                       }, function (err) {
                           var errorMsg = JSON.parse(err.responseText);
                           self.msgLogger.html(errorMsg.Message);
                       });
                   },

                   // TODO: clear error list 
                   attachUIEventHandlers: function (selector) {
                       var wrapper = $(selector);
                       var self = this;

                       wrapper.on('click', "#start-game", function (ev) {
                           ev.stopPropagation();
                           ev.preventDefault();
                           $("#login-form-holder").removeClass('hidden');
                           window.location.href = "#login-form-holder";
                           return false;
                       });
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

                           self.loginUser(selector, user);
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
                           return false;
                       });
                       wrapper.on("click", ".close", function (ev) {
                           ev.stopPropagation();
                           ev.preventDefault();
                           $("#login-form-holder").addClass('hidden');
                           $("#game-join-inputs").addClass('hidden');
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
                           //self.stopDataUpdates();

                           var html = ui.loginInGame()
                           $(this).after(html);
                       });
                       wrapper.on("click", "#btn-join-game", function () {
                           self.stopDataUpdates();

                           var game = {
                               gameId: $(this).parents("li").first().data("game-id")
                           };

                           var password = $("#tb-game-pass").val();

                           if (password) {
                               game.password = password;
                           }
                           self.persister.game.join(game, function () {
                               //self.loadGameUI(selector);
                           }, function (err) {
                               var errorMsg = JSON.parse(err.responseText);
                               self.msgLogger.html(errorMsg.Message);
                           });

                           // Clear values in the inputs
                           $("#tb-game-pass").val("");

                           window.location = "#/games";
                           return false;
                       });
                       wrapper.on("click", "#btn-create-game", function () {
                           var gameTitle = $("#tb-create-title").val();
                           var gameTitleEscaped = $("<div />").html(gameTitle).text();

                           var game = {
                               title: gameTitleEscaped,
                               //number: $("#tb-create-number").val(),
                           }
                           var password = $("#tb-create-pass").val();
                           if (password) {
                               game.password = password;
                           }
                           self.persister.game.create(game, function () {
                               //self.loadGameUI(selector);
                               $("form").trigger('reset');
                           }, function (err) {
                               var errorMsg = JSON.parse(err.responseText);
                               self.msgLogger.html(errorMsg.Message);
                           });
                       });
                       wrapper.on("click", ".in-progress", function (ev) {

                           ev.stopPropagation();
                           ev.preventDefault();
                           self.stopDataUpdates();

                           var gameId = $(this).parent().data("game-id");
                           $('#btn-battle').data('gameid', gameId);
                           //console.log(gameId);
                           console.log($('#btn-battle').data('gameid'));
                           //return false;
                       });
                       wrapper.on("click", ".full", function () {
                           //alert("OLE!");
                           var gameID = $(this).parent().data("game-id");
                           self.startGame(selector, gameID);
                       });
                       wrapper.on("click", "td", function () {
                           //var currentCell = $(this).
                           //console.log($(this).html()); // id
                           //console.log($(this).index()); // column
                           //console.log($(this).parent().index()); // row
                           var data = {
                               id: parseInt($(this).find('span').attr("id")),
                               x: $(this).index(),
                               y: $(this).parent().index(),
                               player: $(this).find('span').attr("player"),
                               points: parseInt($(this).find('span').attr("hitpoints")),
                               type: $(this).find('span').html(),
                           }

                           if (self.dataFromClicks.length == 2) {
                               self.dataFromClicks = new Array();
                               self.dataFromClicks.push(data);
                           }
                           else {
                               self.dataFromClicks.push(data);
                           }

                           self.calcMoveOrAttack(selector);
                       });
                   },

                   dettachUIEventHandlers: function () {

                       $('td').unbind('click');
                   },

                   stopDataUpdates: function () {
                       clearTimeout(self.scheduleTimer);
                   },

               });
               return {
                   get: function () {
                       return new Controller();
                   }
               }
           }());

           return controllers;
       });
