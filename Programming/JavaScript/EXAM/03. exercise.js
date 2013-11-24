var Solve = (function () {
    'use strict';

    var vars = {};

    var commands =
        {
            sum: function (arg) {
                return arg.reduce(function (a, b) {
                    return a + b;
                })
            }

            , min: function (arg) {
                return Math.min.apply(Math, arg);
            }

            , max: function (arg) {
                return Math.max.apply(Math, arg);
            }

            , avg: function (arg) {
                return parseInt(commands.sum(arg) / arg.length, 10);
            }

            , assign: function (arg) {
                return arg;
            }
        }

    function addRange(arr, els) {
        els.forEach(function (el) {
            arr.push(el)
        })
    }

    function executeCommand(name, cmd, list) {

        var result = []

        list.forEach(function (el) {
            if (!isNaN(+el)) result.push(+el)

            else if (el in vars) addRange(result, vars[el])

            else throw new Error(el)
        })

        vars[name] = cmd !== 'assign' && [commands[cmd](result)] || result
    }

    function parseCommand(command) {

        if (!command.match(/^\s*def/))
            command = 'def __result__ ' + command

        try {
            var match = command.match(/^\s*def\s*(\S*)\s*(\S*)\s*\[\s*(.+?)\s*\]/)

            if (match[2] != "" &&
                match[2] != "sum" &&
                match[2] != "min" &&
                match[2] != "max" &&
                match[2] != "avg") {
                match[1] = match[2];
                match[2] = '';
            }
            executeCommand(match[1], match[2] || 'assign', match[3].split(/\s*,\s*/))
        }

        catch (e) {
            console.error(e.message)
        }
    }

    return function (args) {
        while (args.length) {
            parseCommand(args.shift())

            if (vars['__result__']) return vars['__result__'][0]
        }
    }
}());