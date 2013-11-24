/// <reference path="jquery-1.10.1-vsdoc.js" />

(function () {
    var button = $('#before');
    $(button).click(function () {
        return $('<div class="box" />').insertBefore($('.center'));
    });
})();

(function () {
    var button = $('#after');
    $(button).click(function () {
        return $('<div class="box" />').insertAfter($('.center'));
    });
})();