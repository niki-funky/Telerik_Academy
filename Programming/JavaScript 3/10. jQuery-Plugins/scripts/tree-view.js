/// <reference path="external/jquery-2.0.2.js" />
(function ($) {
    $.fn.treeView = function () {
        var el = $(this);
        $("li>ul").hide();

        el.on('click', 'li', function (ev) {
            $(ev.target).find('>ul').slideToggle();
            ev.stopPropagation();
        })

        return el;
    };
}(jQuery));