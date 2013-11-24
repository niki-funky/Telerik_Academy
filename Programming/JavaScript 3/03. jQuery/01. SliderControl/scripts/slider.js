/// <reference path="jquery-1.10.1-vsdoc.js" />
var Slider = {
    init: function (time) {
        _self = this;
        this.enlarged = 0;
        this.slides = [];
        this.time = time;
        this.slider = $('#slider');
    },
    addSlide: function (code) {
        this.slides.push(code);
    },
    previous: function () {
        clearInterval(auto);
        auto = setInterval(_self.timer, _self.time);
        if (counter > 0) {
            current.hide();
            current = current.prev().show();
            counter -= 1;
        } else {
            counter = _self.slides.length - 1;
            current.hide();
            current = $('#wrapper').children().last();
            current.show();
        }
    },
    next: function () {
        clearInterval(auto);
        auto = setInterval(_self.timer, _self.time);
        if (counter < _self.slides.length - 1) {
            current = current.next().show();
            current.prev().hide();
            counter += 1;
        } else {
            counter = 0;
            $('#wrapper').children().last().hide();
            current = $('#wrapper').children().first();
            current.show();
        }

    },
    timer: function () {
        _self.next();
    },
    initButtons: function () {
        var prevButton = $("<button></button>");
        prevButton.attr('id', 'btn-prev');
        prevButton.on('click', this.previous);
        this.slider.prepend(prevButton);
        var nextButton = $("<button></button>");
        nextButton.attr('id', 'btn-next');
        nextButton.on('click', this.next);
        this.slider.append(nextButton);
    },
    render: function () {
        var wrapper = $('#wrapper');
        for (var i = 0; i < this.slides.length; i++) {
            var slide = $('<div id="slide' + i + '"></div>');
            slide.append($(this.slides[i])).hide();
            wrapper.append(slide);
        }
        wrapper.children().first().show();
        current = wrapper.children().first();
        counter = 0;

        this.initButtons();

        auto = setInterval(this.timer, this.time);
    }
}