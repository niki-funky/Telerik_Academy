var specialConsole = (function () {
    "use strict";

    function writeLine(value, parameters) {
        var message = messageParser.apply(null, arguments);
        console.log(message);
    }

    function writeError(value, parameters) {
        var message = messageParser.apply(null, arguments);
        console.error(message);
    }

    function writeWarning(value, parameters) {
        var message = messageParser.apply(null, arguments);
        console.warn(message);
    }

    function messageParser(object, parameters) {
        var message = '';
        var argumentsLength = arguments.length;

        if (object) {
            message = object.toString();

            if (parameters) {
                for (var i = 1; i < argumentsLength; i++) {
                    var pattern = "\\{" + (i - 1) + "\\}";
                    var regex = new RegExp(pattern, "g");

                    message = message.replace(regex, arguments[i].toString());
                }
            }
        }

        return message;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };

})();