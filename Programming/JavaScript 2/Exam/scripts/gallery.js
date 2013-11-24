var controls = (function () {

    function hidePrev(item) {
        var prev = item.previousElementSibling;

        while (prev) {
            var sublist = prev.querySelector("ul");
            if (sublist) {
                sublist.style.display = "none";
            }
            prev = prev.previousElementSibling;
        }
    }

    function hideNext(item) {
        var next = item.nextElementSibling;
        while (next) {
            var sublist = next.querySelector("ul");
            if (sublist) {
                sublist.style.display = "none";
            }
            next = next.nextElementSibling;
        }
    }

    function Gallery(selector) {
        var images = [];
        var albums = [];
        var galleryImage = document.querySelector(selector);

        galleryImage.addEventListener("click", function (ev) {
            if (!ev) {
                ev = window.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            var clickedItem = ev.target;
            if (!(clickedItem instanceof HTMLAnchorElement
                && clickedItem.hasAttribute('class'))) {
                return;
            }

            hidePrev(clickedItem.parentNode);
            hideNext(clickedItem.parentNode);

            var subAlbum = clickedItem.nextElementSibling;
            if (!subAlbum) {
                return;
            }
            if (subAlbum.style.display === "none") {
                subAlbum.style.display = "";
            }
            else {
                subAlbum.style.display = "none";
            }

        }, false);

        galleryImage.addEventListener("click", function (ev) {
            if (!ev) {
                ev = window.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            var clickedItem = ev.target;
            if (!(clickedItem instanceof HTMLImageElement)) {
                return;
            }

            var container = document.getElementById('enlargedImages');
            container.innerHTML = "";

            var enlargedImage = document.createElement('img');
            enlargedImage.id = "enlarged";
            enlargedImage.src = clickedItem.src;

            container.appendChild(enlargedImage);

        }, false);

        var imagesList = document.createElement("ul");

        this.addImage = function (title, path) {
            var newImage = new Image(title, path);
            images.push(newImage);
            return newImage;
        };

        this.render = function () {
            for (var i = 0, len = images.length; i < len; i += 1) {
                var domItem = images[i].render();
                imagesList.appendChild(domItem);
            }
            for (var j = 0, aLen = albums.length; j < aLen; j += 1) {
                var albumItem = albums[j].render();
                imagesList.appendChild(albumItem);
            }
            galleryImage.appendChild(imagesList);
            return this;
        };

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };

        this.serialize = function () {
            var serializedItems = [];
            for (var i = 0; i < images.length; i += 1) {
                serializedItems.push(images[i].serialize());
            }
            for (var j = 0; j < albums.length; j += 1) {
                serializedItems.push(albums[j].serialize());
            }
            return serializedItems;
        };
    }

    function Image(title, path) {

        this.render = function () {
            var itemNode = document.createElement("li");

            itemNode.innerHTML = "<a href='#' >" + title + "<img src='" + path + "'/>" + "</a>";
            return itemNode;
        };

        this.serialize = function () {
            var thisImage = {
                title: title,
                source: path
            };
            thisImage.imageBinary = getBase64Image(this);

            return thisImage;
        };
    }

    function Album(title) {
        var images = [];
        var albums = [];

        this.addImage = function (title, path) {
            var newImage = new Image(title, path);
            images.push(newImage);
            return newImage;
        };

        this.addAlbum = function (title) {
            var newAlbum = new Album(title);
            albums.push(newAlbum);
            return newAlbum;
        };

        this.render = function () {
            var itemNode = document.createElement("li");
            itemNode.innerHTML = "<a href='#' class='album'>" + title + "</a>";
            itemNode.className = "subAlbum";

            var subList = document.createElement("ul");

            if (images.length > 0) {
                subList.style.display = "none";
                for (var i = 0, len = images.length; i < len; i += 1) {
                    var subImage = images[i].render();
                    subList.appendChild(subImage);
                }
                itemNode.appendChild(subList);
            }
            // if nested albums
            if (albums.length > 0) {
                for (var j = 0, albumLen = albums.length; j < albumLen; j += 1) {
                    var nestedAlbum = albums[j].render();
                    subList.appendChild(nestedAlbum);
                }
            }

            return itemNode;
        };

        this.serialize = function () {
            var thisAlbum = {
                title: title
            };
            if (images.length > 0) {
                var serializedImages = [];
                for (var i = 0; i < images.length; i += 1) {
                    var serImage = images[i].serialize();
                    serializedImages.push(serImage);
                }
                thisAlbum.images = serializedImages;
            }

            if (albums.length > 0) {
                var serializedAlbums = [];
                for (var j = 0; j < albums.length; j += 1) {
                    var serAlbum = albums[j].serialize();
                    serializedAlbums.push(serAlbum);
                }
                thisAlbum.albums = serializedAlbums;
            }

            return thisAlbum;
        };
    }

    return {
        getImageGalerry: function (selector) {
            return new Gallery(selector);
        }
    };
})();