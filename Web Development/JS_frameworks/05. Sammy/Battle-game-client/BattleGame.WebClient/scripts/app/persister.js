/// <reference path="http-requester.js" />
/// <reference path="external/class.js" />
/// <reference path="external/cryptojs-sha1.js" />
/// <reference path="external/jquery-2.0.2.intellisense.js" />

define(["class", "cryptoJS", "http-requester"], function (Class, CryptoJS, httpRequester) {
    var persisters = (function () {
        var nickname = localStorage.getItem("nickname");
        var sessionKey = localStorage.getItem("sessionKey");

        function saveUserData(userData) {
            localStorage.setItem("nickname", userData.nickname);
            localStorage.setItem("sessionKey", userData.sessionKey);
            nickname = userData.nickname;
            sessionKey = userData.sessionKey;
        }
        function clearUserData() {
            localStorage.removeItem("nickname");
            localStorage.removeItem("sessionKey");
            nickname = "";
            sessionKey = "";
        }

        var MainPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl;
                this.user = new UserPersister(this.rootUrl);
                this.game = new GamePersister(this.rootUrl);
                this.battle = new BattlePersister(this.rootUrl);
                this.messages = new MessagesPersister(this.rootUrl);
            },
            isUserLoggedIn: function (success, error) {
                //var isLoggedIn = nickname != null && sessionKey != null;
                var url = this.rootUrl + "user/scores/" + sessionKey;

                httpRequester.getJSON(url, function (data) {
                    success(data);
                }, function (data) {
                    console.log("wrong sessionkey");
                    isLoggedIn = false;
                    clearUserData();
                    error(data);
                })
            },
            nickname: function () {
                return nickname;
            }
        });

        var UserPersister = Class.create({
            init: function (rootUrl) {
                //...api/user/
                this.rootUrl = rootUrl + "user/";
            },
            login: function (user, success, error) {
                var url = this.rootUrl + "login";
                var userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };

                httpRequester.postJSON(url, userData,
                    function (data) {
                        saveUserData(data);
                        success(data);
                    }, error);
            },
            register: function (user, success, error) {
                var url = this.rootUrl + "register";
                var userData = {
                    username: user.username,
                    nickname: user.nickname,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };
                httpRequester.postJSON(url, userData,
                    function (data) {
                        saveUserData(data);
                        success(data);
                    }, error);
            },
            logout: function (success, error) {
                var url = this.rootUrl + "logout/" + sessionKey;
                httpRequester.getJSON(url, function (data) {
                    clearUserData();
                    success(data);
                }, error)
            },
            scores: function (success, error) {
                var url = this.rootUrl + "scores/" + sessionKey;
                httpRequester.getJSON(url, function (data) {
                    // console.log(data.scores);
                    success(data);
                }, error)
            }
        });
        var GamePersister = Class.create({
            init: function (url) {
                // ../api/game
                this.rootUrl = url + "game/";
            },
            create: function (game, success, error) {
                var gameData = {
                    title: game.title,
                };
                if (game.password) {
                    gameData.password = CryptoJS.SHA1(game.password).toString();
                }
                var url = this.rootUrl + "create/" + sessionKey;
                httpRequester.postJSON(url, gameData, success, error);
            },
            join: function (game, success, error) {
                var gameData = {
                    id: game.gameId,
                };
                if (game.password) {
                    gameData.password = CryptoJS.SHA1(game.password).toString();
                }
                var url = this.rootUrl + "join/" + sessionKey;
                httpRequester.postJSON(url, gameData, success, error);
            },
            start: function (gameId, success, error) {

                var url = this.rootUrl + gameId + "/start/" + sessionKey;
                httpRequester.getJSON(url, success, error);
            },
            myActive: function (success, error) {
                var url = this.rootUrl + "my-active/" + sessionKey;
                httpRequester.getJSON(url, success, error);
            },
            open: function (success, error) {
                var url = this.rootUrl + "open/" + sessionKey;
                httpRequester.getJSON(url, success, error);
            },
            field: function (gameId, success, error) {
                var url = this.rootUrl + gameId + "/field/" + sessionKey;
                httpRequester.getJSON(url, success, error);
            }
        });
        var BattlePersister = Class.create({
            init: function (url) {
                this.rootUrl = url + "battle/";
            },
            move: function (gameId, game, success, error) {
                var gameData = {
                    unitId: game.unitId,
                    position: game.position
                }
                var url = this.rootUrl + gameId + "/move/" + sessionKey;
                httpRequester.postJSON(url, gameData, success, error);
            },
            attack: function (gameId, game, success, error) {
                var gameData = {
                    unitId: game.unitId,
                    position: game.position
                }
                var url = this.rootUrl + gameId + "/attack/" + sessionKey;
                httpRequester.postJSON(url, gameData, success, error);
            },
            defend: function (gameId, game, success, error) {
                var url = this.rootUrl + gameId + "/defend/" + sessionKey;
                httpRequester.postJSON(url, game.unitId, success, error);
            }
        });
        var MessagesPersister = Class.create({
            init: function (url) {
                this.rootUrl = url + "messages/";
            },
            unread: function (success, error) {
                var url = this.rootUrl + "unread/" + sessionKey;
                httpRequester.getJSON(url, success, error);
            },
            all: function (success, error) {
                var url = this.rootUrl + "all/" + sessionKey;
                httpRequester.getJSON(url, success, error);
            }
        });
        return {
            get: function (url) {
                return new MainPersister(url);
            }
        };
    }());

    return persisters;
});