/// <reference path="external/jquery-2.0.2.intellisense.js" />

define(function () {
    var uiPages = (function () {

        function buildLoginForm() {
            var html =
                '<div id="login-form-holder" class="hidden modalDialog">' +
                    '<div>' +
                        '<a href="#close" title="Close" class="close">X</a>' +
                        '<form>' +
                            '<div id="login-form">' +
                                '<button id="btn-login" class="logreg">Login</button>' +
                                '<label for="tb-login-username">Username: </label>' +
                                '<input type="text" id="tb-login-username"><br />' +
                                '<label for="tb-login-password">Password: </label>' +
                                '<input type="password" id="tb-login-password"><br />' +

                            '</div>' +
                            '<div id="register-form" style="display: none">' +
                                '<button id="btn-register" class="logreg">Register</button>' +
                                '<label for="tb-register-username">Username: </label>' +
                                '<input type="text" id="tb-register-username"><br />' +
                                '<label for="tb-register-nickname">Nickname: </label>' +
                                '<input type="text" id="tb-register-nickname"><br />' +
                                '<label for="tb-register-password">Password: </label>' +
                                '<input type="password" id="tb-register-password"><br />' +

                            '</div>' +
                            '<a href="#" id="btn-show-login" class="button selected">Login</a>' +
                            '<a href="#" id="btn-show-register" class="button">Register</a>' +
                        '</form>' +
                    '</div>' +
                '</div>';
            return html;
        }

        function buildLoginPage() {
            var html =
            '<span id="start-game">Start game</span>';
            return html;
        }

        function buildOpenGames() {
            var html =
            '<div id="open-games-container">' +
                '<h2>Open games</h2>' +
                '<div id="open-games"></div>' +
            '</div>' +
            '<div id="open-games-image">' +
            '</div>'
            return html;
        }

        function buildActiveGames() {
            var html =
            '<div id="create-game-holder">' +
                '<form id="create-game-form">' +
                    '<label for="tb-create-title" id="lb-create-title">Title: </label>' +
                    '<input type="text" id="tb-create-title" />' +
                    '<label for="tb-create-pass" id="lb-create-pass">Password: </label>' +
                    '<input type="password" id="tb-create-pass" />' +
                    '<button id="btn-create-game">Create new game</button>' +
                '</form>' +
            '</div>' +
            '<div id="active-games-container">' +
                '<h2>Active</h2>' +
                '<div id="active-games"></div>' +
            '</div>' +
            '<div id="active-games-image">' +
            '</div>'
            return html;
        }

        function buildBattlefield() {
            var html =
            '<div id="game-wrapper-image1">' +
            '</div>' +
            '<div id="game-wrapper">' +
                '<div id="game-messages">' +
                    '<h3>Game messages</h3>' +
                    '<ul class="game-messages unread">' +
                '</div>' +
                '<div id="game-holder">' +
                '</div>' +
            '</div>' +
            '<div id="game-wrapper-image2">' +
            '</div>'
            return html;
        }

        function buildMessagesList(messages) {
            var messagesList = Array.prototype.slice.call(messages, 0);

            var list = "";
            for (var i = 0; i < messagesList.length; i++) {
                var message = messagesList[i];
                list +=
                    '<li message-id="' + message.gameId + '">' +
                        '<span>' +
                            message.text +
                        '</span>' +
                    '</li>';
            }
            list += "</ul>";
            return list;
        }

        function buildLoginInGame() {
            var html =
            '<div id="game-join-inputs" class="modalDialog">' +
                '<div>' +
                    '<a href="#close" title="Close" class="close">X</a>' +
                    '<label for="tb-game-pass">Password: </label>' +
                    '<input type="text" id="tb-game-pass"/>' +
                    '<button id="btn-join-game">join</button>' +
                '</div>' +
            '</div>';
            return html;
        }

        return {
            buildLoginForm: buildLoginForm,
            buildLoginPage: buildLoginPage,
            buildOpenGames: buildOpenGames,
            buildActiveGames: buildActiveGames,
            buildBattlefield: buildBattlefield,
            loginInGame: buildLoginInGame,
            gameMessages: buildMessagesList,
        }
    }());

    return uiPages;
});