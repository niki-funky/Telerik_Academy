var domModule = (function () {
    'use strict';

    var MAX_BUFFER_SIZE = 100;
    var elementsBuffer = [];

    function addChild(element, selector) {
        var parent = document.querySelector(selector);
        parent.appendChild(element);
    }

    function removeChild(element, selector) {
        if (element) {
            var elements = document.querySelectorAll(element);
            var childElements;

            for (var i = 0; i < elements.length; i++) {
                childElements = elements[i].querySelectorAll(selector);

                for (var j = 0; j < childElements.length; j++) {
                    elements[i].removeChild(childElements[j]);
                }
            }
        }
    }

    function attachEvent(selector, eventType, eventHandler) {
        var elements = document.querySelectorAll(selector);

        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener(eventType, eventHandler, false);
        }
    }

    function addElementToBuffer(selector, element) {
        if (!elementsBuffer[selector]) {
            elementsBuffer[selector] = document.createDocumentFragment();
        }

        elementsBuffer[selector].appendChild(element);

        var numberOfElementsPerSelector = elementsBuffer[selector].childNodes.length;

        if (numberOfElementsPerSelector === MAX_BUFFER_SIZE) {
            for (var selectorItem in elementsBuffer) {
                var parentElements = document.querySelectorAll(selectorItem);
                for (var j = 0; j < parentElements.length; j++) {
                    parentElements[j].appendChild(elementsBuffer[selectorItem]);
                }
            }
            // empty the buffer
            elementsBuffer = [];
        }
    }

    function getElements(selector) {
        return document.querySelectorAll(selector);
    }

    return {
        addChild: addChild,
        removeChild: removeChild,
        attachEvent: attachEvent,
        addElementToBuffer: addElementToBuffer,
        getElements: getElements
    }
})();