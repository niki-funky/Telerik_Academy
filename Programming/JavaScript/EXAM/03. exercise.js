function Solve(args) {

    var i, k, l;
    var arr = {};
    var line = "";
    var words = [];
    var funcName = "";



    for (i = 0; i < args.length; i++) {

        line = args[i].replace(/\s{2,}/g, ' ');
        var re = new RegExp(/\[([^()]+)\]/g);
        var brackets = re.exec(line);
        var bracks = brackets[0].replace(/\s/g, '');
        line = line.replace(new RegExp(/\[([^()]+)\]/g), bracks);
        //line = line.replace(/\s{2,}/g, ' ');
        words = line.split(' ');
        //funcName = line.exec(new RegExp(/\b.*\b/, 'g');

        for (k = 0; k < args[i].length; k++) {
            if (line[k] = 'd') {

            }
        }
    }



    return 0;
}