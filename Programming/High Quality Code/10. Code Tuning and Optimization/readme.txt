Bottleneck in the program is in file: OrbitsCalculator.cs, method: EarthRotation(), line: 101.

(CPU)Calculations with decimal numbers is very slow.
Decimal calculations is about 30 times slower than double.
Changed step variable from decimal to double.
Precision is kept.
In the end removed the whole loop.
Program works much faster.