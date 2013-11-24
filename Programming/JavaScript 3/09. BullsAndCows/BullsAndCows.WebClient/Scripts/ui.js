/// <reference path="external/jquery-2.0.2.intellisense.js" />
var ui = (function () {

    function buildLoginForm() {
        var html =
            '<div id="login-form-holder" class="modalDialog">' +
                '<div>' +
                    '<a href="#close" title="Close" class="close">X</a>' +
				    '<form>' +
				    	'<div id="login-form">' +
                        				    		'<button id="btn-login" class="button">Login</button>' +
				    		'<label for="tb-login-username">Username: </label>' +
				    		'<input type="text" id="tb-login-username"><br />' +
				    		'<label for="tb-login-password">Password: </label>' +
				    		'<input type="text" id="tb-login-password"><br />' +

				    	'</div>' +
				    	'<div id="register-form" style="display: none">' +
                        				    		'<button id="btn-register" class="button">Register</button>' +
				    		'<label for="tb-register-username">Username: </label>' +
				    		'<input type="text" id="tb-register-username"><br />' +
				    		'<label for="tb-register-nickname">Nickname: </label>' +
				    		'<input type="text" id="tb-register-nickname"><br />' +
				    		'<label for="tb-register-password">Password: </label>' +
				    		'<input type="text" id="tb-register-password"><br />' +

				    	'</div>' +
				    	'<a href="#" id="btn-show-login" class="button selected">Login</a>' +
				    	'<a href="#" id="btn-show-register" class="button">Register</a>' +
				    '</form>' +
                '</div>' +
            '</div>';
        return html;
    }

    function buildGameUI(nickname) {
        var html =
         '<span id="user-nickname">' +
				nickname +
		'</span>' +
		'<button id="btn-logout">Logout</button><br/>' +
		'<div id="create-game-holder">' +
			'Title: <input type="text" id="tb-create-title" />' +
			'Password: <input type="text" id="tb-create-pass" />' +
			'Number: <input type="text" id="tb-create-number" />' +
			'<button id="btn-create-game">Create</button>' +
		'</div>' +
		'<div id="open-games-container">' +
			'<h2>Open</h2>' +
			'<div id="open-games"></div>' +
		'</div>' +
		'<div id="active-games-container">' +
			'<h2>Active</h2>' +
			'<div id="active-games"></div>' +
		'</div>' +
        '<div id="game-wrapper">' +
            '<div id="guess-input" class="hide">' +
                'Guess number: <input type="text" id="tb-guess-number"/>' +
                '<button class="" id="btn-guess">guess</button>' +
            '</div>' +
		    '<div id="game-holder">' +
            '</div>' +
            '<div id="game-messages">' +
                '<h3>Game messages</h3>' +
                '<ul class="game-messages unread">' +
            '</div>' +
		'</div>';
        return html;
    }

    function buildOpenGamesList(games) {
        var list = '<ul class="game-list open-games">';
        for (var i = 0; i < games.length; i++) {
            var game = games[i];
            list +=
				'<li data-game-id="' + game.id + '">' +
					'<a href="#game-join-inputs" >' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creatorNickname +
					'</span>' +
				'</li>';
        }
        list += "</ul>";
        return list;
    }

    function buildActiveGamesList(games) {
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

        var list = '<ul class="game-list active-games">';
        for (var i = 0; i < gamesList.length; i++) {
            var game = gamesList[i];
            list +=
				'<li data-game-id="' + game.id + '">' +
					'<a href="#" class="' + game.status + '">' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creatorNickname +
					'</span>' +
				'</li>';
        }
        list += "</ul>";
        return list;
    }

    function buildGuessTable(guesses) {
        var tableHtml =
			'<table border="1" cellspacing="0" cellpadding="5">' +
				'<tr>' +
					'<th>Number</th>' +
					'<th>Cows</th>' +
					'<th>Bulls</th>' +
				'</tr>';
        for (var i = 0; i < guesses.length; i++) {
            var guess = guesses[i];
            tableHtml +=
				'<tr>' +
					'<td>' +
						guess.number +
					'</td>' +
					'<td>' +
						guess.cows +
					'</td>' +
					'<td>' +
						guess.bulls +
					'</td>' +
				'</tr>';
        }
        tableHtml += '</table>';
        return tableHtml;
    }

    function buildGameState(gameState) {
        var html =
        '<div id="game-state"' + 'class="' + gameState.inTurn + '" data-game-id="' + gameState.id + '">' +
        '<h2>' + gameState.title + '</h2>' +
            '<br/>' +
            '<br/>' +
            '<div id="blue-guesses" class="guess-holder">' +
                '<h3>' +
                    gameState.blue + '\'s gueesses' +
                '</h3>' +
                buildGuessTable(gameState.blueGuesses) +
            '</div>' +
            '<div id="red-guesses" class="guess-holder">' +
                '<h3>' +
                    gameState.red + '\'s gueesses' +
                '</h3>' +
                buildGuessTable(gameState.redGuesses) +
            '</div>' +
    '</div>';
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
                    '<span> // ' +
						message.type +
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
                '<label for="tb-game-number">Number: </label>' +
                '<input type="text" id="tb-game-number"/>' +
                '<label for="tb-game-pass">Password: </label>' +
                '<input type="text" id="tb-game-pass"/>' +
                '<button id="btn-join-game">join</button>' +
            '</div>' +
        '</div>';
        return html;
    }

    return {
        gameUI: buildGameUI,
        openGamesList: buildOpenGamesList,
        loginForm: buildLoginForm,
        activeGamesList: buildActiveGamesList,
        gameState: buildGameState,
        gameMessages: buildMessagesList,
        loginInGame: buildLoginInGame,
    }

}());