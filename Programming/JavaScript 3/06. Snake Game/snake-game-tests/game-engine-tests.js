﻿(function () {

    QUnit.testStart(function () {
        var context = document.getElementById("snake-canvas").getContext("2d");
        maxX = 300;
        maxY = 300;
        game = new snakeGame.SnakeEngine(context, maxX, maxY);
    });

    var game, maxX, maxY;

    module("SnakeGame.checkCollisions");
    test("There should be collision with Food, and the snake should grow", function () {
        var collidePosition = {
            x: 2,
            y: 2
        };
        var oldsnakesize = game.snake.size;
        game.snake.position.x = collidePosition.x;
        game.snake.position.y = collidePosition.y;
        game.food.position.x = collidePosition.x;
        game.food.position.y = collidePosition.y;
        game.checkCollisions();
        var newsnakesize = game.snake.size;
        equal(newsnakesize, oldsnakesize + 1);
    });

    test("The snake should passed through borders right->left", function () {
        game.snake.position.x = -1;
        game.checkCollisions();
        var actual = game.snake.position.x;
        var expected = maxX - 1;
        equal(actual, expected);
    });

    test("The snake should passed through borders top->bottom", function () {
        game.snake.position.y = maxY;
        game.checkCollisions();
        var actual = game.snake.position.y;
        var expected = 0;
        equal(actual, expected);
    });

    test("When snake eats five food objects, should increase the speed", function () {
        var iniSpeed = game.gameSpeed;
        game.snake.eatenFoods = 5;
        game.updateGameSpeed();
        var actual = game.gameSpeed;
        var expected = iniSpeed - 100;
        equal(actual, expected);
    });

    QUnit.testStart(function () { });
}());