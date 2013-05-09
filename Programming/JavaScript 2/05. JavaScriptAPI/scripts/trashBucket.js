var cleanCity = (function () {
    'use strict';

    var TRASH_CLOSED = "images/Trash_Can_Empty_128x128x32.png";
    var TRASH_OPENED = "images/Trash_Can_Full_128x128x32.png";
    var TRASH = "images/recyle_bag.png";
    var TRASH_BUCKET = "images/Trash_Can_Empty_128x128x32.png";
    var LOGO = "images/logo.png";
    var LEFT = 100;
    var TOP = 100;
    var MAX_TOP = 450;
    var MAX_LEFT = 465;

    var trashCounter = 0;
    var trashNumber = 9;
    var tick;
    var hours = 0, minutes = 0, seconds = 0;
    var scoreCounter = 0;

    function InitializeGame() {
        trashCounter = 0;
        hours = 0, minutes = 0, seconds = 0;
        tick = window.setInterval("cleanCity.simpleCounter()", 1000);
        document.body.removeChild(document.getElementById('startButton'));

        var container = document.createElement('div');
        container.id = "container";
        document.body.appendChild(container);
        container.appendChild(genrateTrashBucket());

        var playField = document.getElementById('container');
        for (var i = 0; i < trashNumber; i++) {
            var img = generateImageElement(TOP, LEFT, MAX_TOP, MAX_LEFT);
            playField.appendChild(img);
            trashCounter++;
        }

        showFinalScore();
    }

    function generateRandomNumberInRange(startOfRange, endOfRange) {
        var randomNumber = 0;
        randomNumber += Math.round(Math.random() * (endOfRange - startOfRange + 1) + startOfRange) + 'px';

        return randomNumber;
    }

    function generateImageElement(imgTop, imgLeft, maxTop, maxLeft) {
        var image = document.createElement("img");
        image.id = "image0" + trashCounter;
        image.style.position = "absolute";

        var top = generateRandomNumberInRange(imgTop, maxTop);
        image.style.top = top;

        var left = generateRandomNumberInRange(imgLeft, maxLeft);
        image.style.left = left;
        image.setAttribute("src", TRASH);
        image.setAttribute("width", 50);
        image.setAttribute("alt", "trash");
        image.setAttribute("draggable", "true");
        image.addEventListener("dragstart", drag, false);

        return image;
    }

    function genrateTrashBucket() {
        var bucket = document.createElement("img");
        bucket.id = "trashBucket";
        bucket.setAttribute("src", TRASH_BUCKET);
        bucket.setAttribute("alt", "trashBucket");
        bucket.addEventListener("drop", drop, false);
        bucket.addEventListener("dragover", allowDrop, false);

        return bucket;
    }

    function allowDrop(ev) {
        var event = ev.target;
        event.src = TRASH_OPENED;
        ev.preventDefault();
    }

    function drag(ev) {
        ev.dataTransfer.setData("dragged-id", ev.target.id);
        var dragIcon = document.createElement('img');
        dragIcon.src = LOGO;
        ev.dataTransfer.setDragImage(dragIcon, 30, 30);
    }

    function drop(ev) {
        var event = ev.target;
        ev.preventDefault();
        var data = ev.dataTransfer.getData("dragged-id");
        event.appendChild(document.getElementById(data));
        event.src = TRASH_CLOSED;

        trashCounter--;
        if (trashCounter === 0) {
            endGame();
        }
    }

    function simpleCounter() {
        var time = "";
        minutes = parseInt(seconds / 60, 10);
        seconds = (seconds % 60);
        hours = parseInt(minutes / 60, 10);
        minutes = (minutes % 60);
        if (seconds <= 9) {
            seconds = "0" + seconds;
        }
        if (minutes <= 9) {
            minutes = "0" + minutes;
        }
        if (hours <= 9) {
            hours = "0" + hours;
        }

        time = hours + ":" + minutes + ":" + seconds;
        document.getElementById('clock').innerHTML = time;
        seconds++;
        //tick = setTimeout("cleanCity.simpleCounter()", 1000);
    }

    function removeElement(id) {
        document.getElementById(id).parentNode.removeChild(document.getElementById(id));
    }

    function calculateSecondsFromScore() {
        var result;
        result = seconds + (minutes * 60) + (hours * 3600);

        return result;
    }

    function checkLocalStorageForScores() {
        scoreCounter = 0;
        for (var key in localStorage) {
            if (key.charAt(0) === "_") {
                scoreCounter++;
            }
        }
    }

    function showFinalScore() {

        var array = [];
        var nameList = document.createElement('ul');
        nameList.id = 'scores';
        nameList.innerHTML = "Top 5 scores: ";

        if (localStorage.length && localStorage.length > 0) {
            for (var saveditem in localStorage) {
                if (saveditem.charAt(0) === "_") {
                    var key = saveditem;
                    var value = localStorage[saveditem];

                    array.push({ key: key, value: value });
                }
            }

            array.sort(function (obj, obj2) {
                return obj.value - obj2.value;
            });

            checkLocalStorageForScores();

            for (var i = 0; i < scoreCounter; i++) {
                var item = document.createElement('li');
                item.innerHTML =
                    array[i].key.substring(1) +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; score: " +
                    array[i].value;
                nameList.appendChild(item);
            }
        }
        
        document.body.appendChild(nameList);
    }

    function newGame() {
        var startButton = document.createElement('button');
        startButton.id = 'startButton';
        startButton.name = 'startButton';
        startButton.innerHTML = "START NEW GAME";
        startButton.addEventListener("click", InitializeGame, false);
        document.body.appendChild(startButton);
    }

    function endGame() {
        window.clearInterval(tick);

        var score = calculateSecondsFromScore();
        var name = prompt("Please enter your nickname: ");
        // name is saved with _ in front of it, because 
        // there may be other key-value pairs in the local storage
        localStorage[name ? "_" + name : "_pesho"] = score;
        checkLocalStorageForScores();

        if (scoreCounter > 5) {
            var lowestScore = 0;
            var lowestName;
            for (var saveditem in localStorage) {
                if (saveditem.charAt(0) === "_") {
                    var key = saveditem;
                    var value = localStorage[saveditem];

                    if (parseInt(value, 10) > parseInt(lowestScore, 10)) {
                        lowestScore = value;
                        lowestName = key;
                    }
                }
            }

            localStorage.removeItem(lowestName);
        }

        removeElement('container');
        removeElement('scores');
        document.getElementById('clock').innerHTML = " ";
        newGame();
    }

    return {
        newgame: newGame,
        simpleCounter: simpleCounter
    };

})();