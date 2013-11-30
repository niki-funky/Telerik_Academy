/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
    var ListView = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a ListView must be an array!";
            }
            this.itemsSource = itemsSource;

        },
        render: function (studentTemplate, markTemplate) {
            var list = document.getElementById("content");
            for (var i = 0; i < this.itemsSource.length; i++) {
                var student = this.itemsSource[i];
                var studentItem = studentTemplate(student);
                
                list.innerHTML += studentItem;
            }
            return list.outerHTML;
        }
    });

    c.getListView = function (itemsSource) {
        return new ListView(itemsSource);
    }
}(controls || {}));