var FavouritesBar = Class.create({
    init: function (folders, urls) {
        this.folders = folders;
        this.urls = urls;
    },
    render: function (selector) {
        var container = document.getElementById(selector);
        var list = document.createElement("ul");

        var urlItems = document.createDocumentFragment();
        for (var i = 0; i < this.urls.length; i++) {
            var itemUrl = this.urls[i].render();
            urlItems.appendChild(itemUrl);
        }

        var folderItems = document.createDocumentFragment();
        for (var i = 0; i < this.folders.length; i++) {
            var itemFolder = this.folders[i].render();
            folderItems.appendChild(itemFolder);
        }
        list.appendChild(urlItems);
        list.appendChild(folderItems);

        container.appendChild(list);
    }
});

var Folder = Class.create({
    init: function (title, urls) {
        this.title = title;
        this.urls = urls;
    },
    render: function () {
        var item = document.createElement("li");
        item.innerText = this.title;
        var subList = document.createElement("ul");
        for (var i = 0; i < this.urls.length; i++) {
            subList.appendChild(this.urls[i].render());
        }
        item.appendChild(subList);

        return item;
    }
});

var Url = Class.create({
    init: function (title, url) {
        this.title = title;
        this.url = url;
    },
    render: function () {
        var item = document.createElement("li");
        var anchor = document.createElement("a");
        anchor.innerText = this.title;
        anchor.title = this.title;
        anchor.target = "_blank";
        anchor.href = this.url;
        item.appendChild(anchor);

        return item;
    }
});

Folder.inherit(FavouritesBar);