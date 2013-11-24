//-----------------------------------------------------------------------
// <copyright file="MatrixGyration.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Matrix
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Performs gyration in a matrix.
    /// </summary>
    public class MatrixGyration
    {
        private const int AllPossibleDirections = 8;

        private int matrixSize;

        public MatrixGyration(int matrixSize)
        {
            this.MatrixSize = matrixSize;

            this.Matrix = new int[this.MatrixSize, this.MatrixSize];

            this.FillMatrix();
        }

        public int MatrixSize
        {
            get
            {
                return this.matrixSize;
            }

            set
            {
                if (value < 1 || 100 < value)
                {
                    throw new ArgumentOutOfRangeException("Size of matrix should be in the range[1...100]!");
                }

                this.matrixSize = value;
            }
        }

        private int[,] Matrix { get; set; }

        public override string ToString()
        {
            StringBuilder matrixImage = new StringBuilder();

            for (int row = 0; row < this.MatrixSize; row++)
            {
                for (int col = 0; col < this.MatrixSize; col++)
                {
                    matrixImage.AppendFormat("{0,4}", this.Matrix[row, col]);
                }

                matrixImage.Append(Environment.NewLine);
            }

            return matrixImage.ToString();
        }

        // Private methods
        private void FillMatrix()
        {
            MatrixPosition position = new MatrixPosition(0, 0);
            int currentRow = 1;
            int currentColumn = 1;
            int number = 1;

            while (true)
            {
                this.Matrix[position.Row, position.Column] = number;

                if (!this.IsCellVacant(position.Row, position.Column))
                {
                    this.FindVacantCell(position);
                    if (this.IsCellVacant(position.Row, position.Column))
                    {
                        number++;
                        this.Matrix[position.Row, position.Column] = number;
                        currentRow = 1;
                        currentColumn = 1;
                    }
                    else
                    {
                        break;
                    }
                }

                int nextRow = position.Row + currentRow;
                int nextColumn = position.Column + currentColumn;

                while (!this.IsInMatrix(nextRow) || !this.IsInMatrix(nextColumn) || this.Matrix[nextRow, nextColumn] != 0)
                {
                    this.GetDirection(ref currentRow, ref currentColumn);

                    nextRow = position.Row + currentRow;
                    nextColumn = position.Column + currentColumn;
                }

                position.Row = nextRow;
                position.Column = nextColumn;
                number++;
            }
        }

        private bool IsCellVacant(int row, int col)
        {
            int[] directionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < AllPossibleDirections; i++)
            {
                int nextRow = row + directionsRow[i];

                if (!this.IsInMatrix(nextRow))
                {
                    directionsRow[i] = 0;
                }

                int nextColumn = col + directionsCol[i];

                if (!this.IsInMatrix(nextColumn))
                {
                    directionsCol[i] = 0;
                }
            }

            return this.IsNextCellVacant(row, col, directionsRow, directionsCol);
        }

        private bool IsNextCellVacant(int row, int col, int[] directionRow, int[] directionCol)
        {
            for (int i = 0; i < AllPossibleDirections; i++)
            {
                int nextRow = row + directionRow[i];
                int nextColumn = col + directionCol[i];

                if (this.Matrix[nextRow, nextColumn] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FindVacantCell(MatrixPosition position)
        {
            for (int currRow = 0; currRow < this.MatrixSize; currRow++)
            {
                for (int currColumn = 0; currColumn < this.MatrixSize; currColumn++)
                {
                    if (this.Matrix[currRow, currColumn] == 0)
                    {
                        position.Row = currRow;
                        position.Column = currColumn;
                        return;
                    }
                }
            }
        }

        private void GetDirection(ref int dirRow, ref int dirCol)
        {
            int[] directionsRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsColumn = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int currDirection = 0;

            for (int i = 0; i < AllPossibleDirections; i++)
            {
                if (directionsRow[i] == dirRow && directionsColumn[i] == dirCol)
                {
                    currDirection = i;
                    break;
                }
            }

            if (currDirection == AllPossibleDirections - 1)
            {
                dirRow = directionsRow[0];
                dirCol = directionsColumn[0];
                return;
            }

            dirRow = directionsRow[currDirection + 1];
            dirCol = directionsColumn[currDirection + 1];
        }

        private bool IsInMatrix(int value)
        {
            if (value < 0 || value >= this.MatrixSize)
            {
                return false;
            }

            return true;
        }
    }
}
