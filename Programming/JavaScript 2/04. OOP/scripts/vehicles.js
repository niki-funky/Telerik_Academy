var vehicles = (function () {
    'use strict';

    var SpinDirection = Object.freeze({
        clockwise: 1,
        counterClockwise: 2
    });

    Function.prototype.inherit = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
    };

    function PropulsionUnit() {
        var acceleration;
        return {
            getAcceleration: function () {
                return acceleration;
            },
            setAcceleration: function (value) {
                acceleration = value;
            }
        };
    }
    // propulsion units
    var Wheel = function (radius) {
        this.radius = radius;

        Wheel.prototype.getAcceleration = function () {
            return parseInt(2 * Math.PI * this.radius, 10);
        };
    };

    Wheel.inherit(PropulsionUnit);

    var PropellingNozzle = function (power, afterburnerSwitch) {
        this.power = power;
        this.afterburberSwitch = afterburnerSwitch;

        PropellingNozzle.prototype.getAcceleration = function () {
            var acceleration = this.burnerSwitch ? 2 * this.power : this.power;
            return acceleration;
        };
    };

    PropellingNozzle.inherit(PropulsionUnit);

    var Propeller = function (numberOfFins, spinDirection) {
        this.numberOfFins = numberOfFins;
        this.spinDirection = spinDirection;

        Propeller.prototype.getAcceleration = function () {
            if (this.spinDirection === SpinDirection.clockwise) {
                return this.numberOfFins;
            }
            else {
                return -this.numberOfFins;
            }
        };
    };

    Propeller.inherit(PropulsionUnit);

    var Vehicle = function (speed, units) {
        this.propulsionUnits = units;
        this.speed = speed;

        Vehicle.prototype.accelerate = function () {
            var numberOfPropulsionUnits = this.propulsionUnits.length;
            for (var i = 0; i < numberOfPropulsionUnits; i++) {
                this.speed += this.propulsionUnits[i].getAcceleration();
            }
        };
    };
    //different vehicles
    var LandVehicle = function (speed, wheels) {
        Vehicle.apply(this, arguments);
    };

    LandVehicle.inherit(Vehicle);

    var AirVehicle = function (speed, propellingNozzle) {
        Vehicle.apply(this, arguments);

        AirVehicle.prototype.switchAfterburners = function (switchedState) {
            var numberOfPropulsionUnits = this.propulsionUnits.length;
            for (var i = 0; i < numberOfPropulsionUnits; i++) {
                if (this.propulsionUnits[i] instanceof PropellingNozzle) {
                    this.propulsionUnits[i].switchedState = switchedState;
                }
            }
        };
    };

    AirVehicle.inherit(Vehicle);

    var WaterVehicle = function (speed, propellers) {
        Vehicle.apply(this, arguments);

        WaterVehicle.prototype.changeSpinDerection = function (spinDirection) {
            var numberOfPropulsionUnits = this.propulsionUnits.length;
            for (var i = 0; i < numberOfPropulsionUnits; i++) {
                if (this.propulsionUnits[i] instanceof Propeller) {
                    this.propulsionUnits[i].spinDirection = spinDirection;
                }
            }
        };
    };

    WaterVehicle.inherit(Vehicle);

    var AmphibiousVehicle = function (mode, speed, propellers, wheels) {
        this.mode = mode;
        if (this.mode === 'land') {
            LandVehicle.call(this, speed, wheels);
        }
        else {
            WaterVehicle.call(this, speed, propellers);
        }
    };

    AmphibiousVehicle.inherit(Vehicle);

    return {
        SpinDirection: SpinDirection,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller,
        LandVehicle: LandVehicle,
        AirVehicle: AirVehicle,
        WaterVehicle: WaterVehicle,
        AmphibiousVehicle: AmphibiousVehicle
    };
})();