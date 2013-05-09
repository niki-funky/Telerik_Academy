(function () {
    'use strict';

    var frameWidth = 960;
    var container = document.getElementById("container");
    container.style.left = '0px';

    var previousElement = document.getElementById("previous");
    previousElement.addEventListener("click", onClickSlidePrevious, false);

    var nextElement = document.getElementById("next");
    nextElement.addEventListener("click", onClickSlideNext, false);

    function onClickSlidePrevious() {
        if (container.style.left === "0px") {
            container.style.left = "-8640" + 'px';
        }
        else {
            container.style.left = parseInt(container.style.left,10) + frameWidth + 'px';
        }
    }

    function onClickSlideNext() {
        if (container.style.left === "-8640px") {
            container.style.left = "0" + 'px';
        }
        else {
            container.style.left = parseInt(container.style.left,10) - frameWidth + 'px';
        }
    }
})();