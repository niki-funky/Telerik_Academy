var movingDivs = (function () {
    'use strict';

    var DIV_WIDTH = 50;
    var DIV_HEIGHT = 50;
    var SPEED = 100;
    var DIAMETER = 100;
    var CIRCULAR_PARAMETER = 200;
    var RECTANGULAR_PARAMETER = 5;
    var PATH_WIDTH = 500;
    var PATH_HEIGHT = 500;
    var MAX_WIDTH = PATH_WIDTH - DIV_WIDTH - RECTANGULAR_PARAMETER;
    var MAX_HEIGHT = PATH_HEIGHT - DIV_HEIGHT - RECTANGULAR_PARAMETER;

    var angle = 0;
    var countRectShapes = 0;
    var divsMovingInRectangularPath = [];
    var divsMovingInCircularPath = [];

    function add(shape) {
        if (shape == 'rect') {
            divsMovingInRectangularPath.push(generateDiv());
            addToPlayField(divsMovingInRectangularPath);
            countRectShapes++;
            moveInRectangularPath();
        }
        else if (shape == 'ellipse') {
            divsMovingInCircularPath.push(generateDiv());
            addToPlayField(divsMovingInCircularPath);
            moveInCircularPath();
        }
    }

    function addToPlayField(listOfDivs) {
        var playField = document.getElementById('playfield');
        for (var i = 0; i < listOfDivs.length; i++) {
            playField.appendChild(listOfDivs[i]);
        }
    }

    function generateRandomColor() {
        var chars = '0123456789ABCDEF'.split('');
        var color = '#';
        for (var i = 0; i < 6; i++) {
            color += chars[Math.round(Math.random() * 15)];
        }
        return color;
    }

    function generateDiv() {
        var newDivItem = document.createElement("div");
        newDivItem.className = 'discoDiv';
        newDivItem.style.width = DIV_WIDTH + 'px';
        newDivItem.style.height = DIV_HEIGHT + 'px';
        newDivItem.style.backgroundColor = generateRandomColor();
        newDivItem.innerHTML = '<strong>I rotate</strong>';
        newDivItem.style.textAlign = 'center';
        newDivItem.style.color = generateRandomColor();
        newDivItem.style.position = 'absolute';
        newDivItem.style.left = (500 / 2 - DIV_WIDTH) + 'px';
        newDivItem.style.top = (500 / 2 - DIV_HEIGHT) + (countRectShapes * DIV_HEIGHT) + 'px';
        newDivItem.style.borderStyle = "solid";
        newDivItem.style.borderRadius = 10 + 'px';
        newDivItem.style.borderColor = generateRandomColor();
        newDivItem.style.borderWidth = 3 + 'px';

        return newDivItem;
    }

    function moveInCircularPath() {
        var increase = Math.PI * 2 / divsMovingInCircularPath.length;

        for (var i = 0; i < divsMovingInCircularPath.length; i++) {
            var x = DIAMETER * Math.cos(angle) + CIRCULAR_PARAMETER;
            var y = DIAMETER * Math.sin(angle) + CIRCULAR_PARAMETER;
            divsMovingInCircularPath[i].style.left = x + 'px';
            divsMovingInCircularPath[i].style.top = y + 'px';
            divsMovingInCircularPath[i].style.webkitTransform =
                divsMovingInCircularPath[i].style.MozTransform =
                divsMovingInCircularPath[i].style.OTransform =
                divsMovingInCircularPath[i].style.transform =
                'rotate(' + Math.atan2(y - CIRCULAR_PARAMETER, x - CIRCULAR_PARAMETER) + 'rad' + ')';
            angle += increase;
        }
        //increases visual speed of rotation
        angle += 0.05;

        setTimeout(moveInCircularPath, SPEED);
    }

    function moveInRectangularPath() {

        for (var i = 0; i < divsMovingInRectangularPath.length; i++) {
            var x = parseInt(divsMovingInRectangularPath[i].style.left);
            var y = parseInt(divsMovingInRectangularPath[i].style.top);

            if (x < MAX_WIDTH && y == 0) {
                x += RECTANGULAR_PARAMETER;
            }
            else if (x == MAX_WIDTH && y < MAX_HEIGHT) {
                y += RECTANGULAR_PARAMETER;
            }
            else if (y == MAX_HEIGHT && x > 0) {
                x -= RECTANGULAR_PARAMETER;
            }
            else {
                y -= RECTANGULAR_PARAMETER;
            }

            divsMovingInRectangularPath[i].style.left = x + 'px';
            divsMovingInRectangularPath[i].style.top = y + 'px';
        }

        setTimeout(moveInRectangularPath, SPEED);
    }

    return {
        add: add
    };
})();