var Image = {
    init: function (title, thumb_url, image_url) {
        this.title = title;
        this.thumb_url = thumb_url;
        this.image_url = image_url;
    },
    render: function () {
        var image = document.createElement("a");
        image.href = '#';
        image.title = this.title;
        image.innerHTML = "<img src='" + this.thumb_url + "' src2='" + this.image_url + "'/>";;

        return image;
    }
};

var ImageSlider = {
    init: function (images, buttons) {
        this.images = images;
        this.buttons = buttons;
        this.imageSlider = document.getElementById('container');
    },
    initEvents: function (slider) {
        slider.style.left = '0px';
        slider.addEventListener("click", this.onClickImage, false);

        if (this.imageSlider.addEventListener) {
            // IE9, Chrome, Safari, Opera
            slider.addEventListener("mousewheel", this.onMouseWheel, false);
            // Firefox
            slider.addEventListener("DOMMouseScroll", this.onMouseWheel, false);
        }
        else {
            // IE 6/7/8
            slider.attachEvent("onmousewheel", this.onMouseWheel);
        }

        var previousItem = document.getElementById("previous");
        previousItem.addEventListener("click", this.onClickSlidePrevious, false);

        var nextItem = document.getElementById("next");
        nextItem.addEventListener("click", this.onClickSlideNext, false);
    },
    onClickImage: function (ev) {
        var ev = window.event || ev; // old IE support
        ev.stopPropagation();
        ev.preventDefault();

        var clickedItem = ev.target;
        if (!(clickedItem instanceof HTMLImageElement)) {
            return;
        }
        var enlarged = document.getElementById('enlargedImage');
        enlarged.innerHTML = "";

        var enlargedImage = document.createElement('img');
        enlargedImage.id = "enlarged";
        enlargedImage.src = clickedItem.getAttribute("src2");
        enlargedImage.title = clickedItem.title;

        enlarged.appendChild(enlargedImage);
    },
    onClickSlidePrevious: function () {
        var slider = document.getElementById("container");
        if (slider.style.left !== "0px") {
            slider.style.left =
                parseInt(slider.style.left, 10) + 150 + 'px';
        }
    },
    onClickSlideNext: function () {
        var slider = document.getElementById("container");
        var coutnAll = slider.childElementCount;
        var countVisible = Math.floor(960 / 150);
        if (slider.style.left !==
                (countVisible - coutnAll) * 150 + 'px') {
            slider.style.left =
                parseInt(slider.style.left, 10) - 150 + 'px';
        }
    },
    onMouseWheel: function (ev) {
        var slider = document.getElementById("container");
        var coutnAll = slider.childElementCount;
        var countVisible = Math.floor(960 / 150);
        var currentPosition = parseInt(slider.style.left, 10);
        // cross-browser wheel delta
        var ev = window.event || ev; // old IE support
        ev.preventDefault();
        var delta = Math.max(-1, Math.min(1, (ev.wheelDelta || -ev.detail)));
        if (delta === -1 && currentPosition <=
                (countVisible - coutnAll) * 150) {
            slider.style.left =
                (countVisible - coutnAll) * 150 + 'px';
        }
        else if (delta === 1 && currentPosition === 0) {
            slider.style.left =
                slider.style.left = "0px";
        }
        else {
            slider.style.left =
                parseInt(slider.style.left, 10) + (delta * 150) + 'px';;
        }
    },
    render: function () {
        this.initEvents(this.imageSlider);
        for (var i = 0, len = this.images.length; i < len; i += 1) {
            var image = this.images[i].render();
            this.imageSlider.appendChild(image);
        }

        return this.imageSlider;
    }
};