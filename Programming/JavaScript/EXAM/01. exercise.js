function Solve(args) {

    var i, k, l;
    var N = parseInt(args[0]);
    var arr = [];
    for (i = 0; i < N; i++) {
        arr[i] = +args[i + 1];
    }

    currentSum = arr[0];
    maxSum = arr[0];

    for (k = 1; k < arr.length; k++) {
        if (arr[k] + currentSum > arr[k]) {
            currentSum = currentSum + arr[k];
        }
        else {
            currentSum = arr[k];
        }
        if (currentSum > maxSum) {
            maxSum = currentSum;
        }
    }

    return maxSum;
}

