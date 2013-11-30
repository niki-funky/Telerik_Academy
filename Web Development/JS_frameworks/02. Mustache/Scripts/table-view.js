﻿/// <reference path="jquery-2.0.3.js" />
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
        render: function (template) {
            var list = document.createElement("ul");
            for (var i = 0; i < this.itemsSource.length; i++) {
                var listItem = document.createElement("li");
                var item = this.itemsSource[i];
                listItem.innerHTML = template(item);
                list.appendChild(listItem);
            }
            return list.outerHTML;
        }
    });

    var TableView = Class.create({
        init: function (itemSource, colsCount) {
            if (!(itemSource instanceof Array)) {
                throw "The itemSource of a TreeView must be an array!";
            }
            this.itemSource = itemSource;
            this.colsCount = colsCount;
        },
        render: function (template) {
            var table = document.createElement("table");
            var row = document.createElement("tr");
            table.appendChild(row);
            var cols = 0;
            for (var i = 0; i < this.itemSource.length; i++) {
                if (cols == this.colsCount) {
                    cols = 0;
                    table.appendChild(row);
                    row = document.createElement("tr");
                }
                var cell = document.createElement("td");
                var item = this.itemSource[i];
                cell.innerHTML = template(item);
                row.appendChild(cell);
                cols++;
            }
            if (cols <= this.colsCount) {
                table.appendChild(row);
            }
            return table.outerHTML;
        }
    });

    c.getListView = function (itemsSource) {
        return new ListView(itemsSource);
    }

    c.getTableView = function (itemSource, colsCount) {
        return new TableView(itemSource, colsCount);
    }
}(controls || {}));