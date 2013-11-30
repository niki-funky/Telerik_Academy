namespace Labyrinth
{
    using System;
    using System.Linq;

    public class CellInLabyrinth
    {
        public int Row { get; private set; }

        public int Column { get; private set; }

        public string WaveValue { get; private set; }

        public CellInLabyrinth(int row, int column, string value)
        {
            this.Row = row;
            this.Column = column;
            this.WaveValue = value;
        }
    }
}
