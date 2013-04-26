function Solve(args) {

    var i, k, l, m;
    var currIndex;
    var sum = 0;
    var counter = 0;
    var word = "out";

    var rowsColumns = args[0].split(' ');
    var rows = +rowsColumns[0];
    var cols = +rowsColumns[1];

    var rowsColumns2 = args[1].split(' ');
    var row = +rowsColumns2[0];
    var col = +rowsColumns2[1];

    //aray
    var arr = new Array(rows);
    for (i = 0; i < rows; i++) {
        var input = args[i + 2].split('');
        arr[i] = new Array(cols);
        for (k = 0; k < input.length; k++) {

            arr[i][k] = input[k];
        }
    }

    //bool array
    var used = new Array(rows);
    for (i = 0; i < rows; i++) {
        used[i] = new Array(cols);
        for (k = 0; k < input.length; k++) {

            used[i][k] = false;;
        }
    }

    currIndex = arr[row][col];
    currUsed = used[row][col];

    while (true) {

        if (row >= 0 && row < rows
            && col >= 0 && col < cols) {
            if (used[row][col] === true) {
                word = "lost";
                break;
            }
            currIndex = arr[row][col];
            used[row][col] = true;
            sum += (row * cols) + (col + 1);
            counter++;
        }
        else {
            break;
        }
        if (currIndex === "l") {
            col = col - 1;
        }
        if (currIndex === "r") {
            col = col + 1;
        }
        if (currIndex === "u") {
            row = row - 1;
        }
        if (currIndex === "d") {
            row = row + 1;
        }
    }
    if (word === "lost") {
        return (word + ' ' + counter);
    }
    else {
        return (word + ' ' + sum);
    }
}

