function Solve(args) {
    var maxSum = -100000;

    var valley = [];
    var input = args[0].split(',');
    for (var i = 0; i < input.length; i++) {
        valley[i] = +input[i];
    }

    var numberOfPatterns = parseInt(args[1]);

    for (var i = 0; i < numberOfPatterns; i++) {
        var inputPattern = args[2 + i].split(',');
        var pattern = [];
        for (var n = 0; n < inputPattern.length; n++) {
            pattern[n] = +inputPattern[n];
        }

        var visitedIdx = {};
        var patSum = 0;
        var valleyIndex = 0;
        var patternIndex = 0;

        while (valleyIndex >= 0 && valleyIndex < valley.length) {
            patSum += valley[valleyIndex];
            visitedIdx[valleyIndex] = true;

            valleyIndex += pattern[patternIndex];
            if (visitedIdx[valleyIndex] == true) {
                break;
            }

            if (patternIndex < pattern.length - 1) {
                patternIndex++;
            }
            else {
                patternIndex = 0;
            }
        }
        if (patSum > maxSum) {
            maxSum = patSum;
        }
    }
    return maxSum;
}

