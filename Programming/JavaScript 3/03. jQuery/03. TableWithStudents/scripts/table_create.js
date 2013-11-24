/// <reference path="jquery-1.10.1-vsdoc.js" />
var Student = {
    init: function (fName, lName, grade) {
        this.fName = fName;
        this.lName = lName;
        this.grade = grade;
    }
};

var createTable = function (data) {
    var numCols = 1;
    var container = $('#table');
    table = $('<table>')
    tHead = $('<thead>');
    th1 = $('<th>').html('First Name');
    th2 = $('<th>').html('Last Name');
    th3 = $('<th>').html('Grade');
    tHead.append(th1);
    tHead.append(th2);
    tHead.append(th3);
    table.append(tHead);

    $.each(data, function (i) {
        if (!(i % numCols)) {
            tRow = $('<tr>');
        }

        for (var key in data[i]) {
            if (!data[i].hasOwnProperty(key)) {
                continue;
            }
            var tCell = $('<td>').html(data[i][key]);

            tRow.append(tCell);
        }

        table.append(tRow.append(tRow));
    });

    $('body').append(table);
};