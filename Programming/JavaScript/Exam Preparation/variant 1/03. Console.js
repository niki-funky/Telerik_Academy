function Solve(args) {
    var words = [];
    var usedWords = 0;
    var resultText = [];
    var numberOfLines = parseInt(args[0]);
    var numberOfLetters = parseInt(args[1]);

    for (var i = 0; i < numberOfLines; i++) {
        var inputWords = args[2 + i].split(' ');

        words.push.apply(words, inputWords);
    }
    //remove empty spaces
    words = words.filter(function (val) {
        return !(val === "" || typeof val == "undefined" || val === null);
    });

    while (usedWords < words.length) {
        var lineLetters = 0;
        var lineWords = 0;
        var lineFirstWordIdx = usedWords;

        lineWords++;
        usedWords++;
        lineLetters += words[lineFirstWordIdx].length;

        for (var wordToUseIdx = lineFirstWordIdx + 1; wordToUseIdx < words.length; wordToUseIdx++) {
            var potentialLinelength = words[wordToUseIdx].length + lineLetters + lineWords;
            if (potentialLinelength < numberOfLetters) {
                lineWords++;
                usedWords++;
                lineLetters += words[wordToUseIdx].length;
            }
            else {
                break;
            }
        }
        var wordSeparations = lineWords - 1;

        if (wordSeparations != 0) {
            var excessSpaces = numberOfLetters - lineLetters;
            var minSpacesPerSeparation = Math.floor(excessSpaces / wordSeparations);
            var lineLastWordInd = lineFirstWordIdx + lineWords - 1;
            var lastAdditionallySpacedWordInd = lineFirstWordIdx + (Math.floor(excessSpaces % wordSeparations));
            var minSpacing = (new Array(minSpacesPerSeparation)).join(" ");

            resultText = resultText + words[lineFirstWordIdx];

            for (var i = lineFirstWordIdx + 1; i <= lineLastWordInd; i++) {
                if (i <= lastAdditionallySpacedWordInd) {
                    resultText = resultText + ' ';
                }

                resultText = resultText + minSpacing;
                resultText = resultText + words[i];
            }

            resultText = resultText + "\n";
        }
        else {
            resultText = resultText + "\n" + words[lineFirstWordIdx];
        }
    }
    return resultText;
}

