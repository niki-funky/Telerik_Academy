var numCols = 1;
var PrintAlbums = function (data) {
    tRowHeader = $('<tr>');
    var tCellHeader1 = $('<th>').html('Title');
    var tCellHeader2 = $('<th>').html('ReleaseDate');
    var tCellHeader3 = $('<th>').html('Producer');
    var tCellHeader4 = $('<th>').html('');
    $('table').append(tRowHeader.append(tCellHeader1));
    $('table').append(tRowHeader.append(tCellHeader2));
    $('table').append(tRowHeader.append(tCellHeader3));
    $('table').append(tRowHeader.append(tCellHeader4));
    $.each(data, function (i) {
        if (!(i % numCols)) tRow = $('<tr>');
        var tCell1 = $('<td>').html(data[i].Title);
        var tCell2 = $('<td>').html(data[i].ReleaseDate);
        var tCell3 = $('<td>').html(data[i].Producer);
        var button = $('<button>Delete</button>')
            .on("click", function () {
                removeAlbum(data[i].AlbumId);
            });
        var tCell4 = $('<td>').append(button);
        $('table').append(tRow.append(tCell1));
        $('table').append(tRow.append(tCell2));
        $('table').append(tRow.append(tCell3));
        $('table').append(tRow.append(tCell4));
    });
}