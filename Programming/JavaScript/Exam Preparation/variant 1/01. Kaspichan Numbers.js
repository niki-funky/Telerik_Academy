function Solve(args) {
    var number = parseInt(args);
    var digits = generateDigits();

    function generateDigits() {
        var capsLetters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
        var arr = new Array(256);
        for (i = 0; i < arr.length; i++) {
            if (i < capsLetters.length) {
                arr[i] = capsLetters[i];
            }
            else {
                arr[i] =
                    capsLetters[Math.floor(i / 26) - 1].toLocaleLowerCase()
                    + capsLetters[i % 26];
            }
        }
        return arr;
    }

    var convertedNumber = ConvertNumberToBase(number, 256, digits);

    return convertedNumber;
}

function ConvertNumberToBase(num, base, arr) {
    var resultDigits = "";
    do {
        var remainder = num % base;
        var nextDigit = arr[remainder];
        resultDigits = nextDigit + resultDigits;
        num = Math.floor(num / base);
    } while (num > 0);

    return resultDigits;
}

