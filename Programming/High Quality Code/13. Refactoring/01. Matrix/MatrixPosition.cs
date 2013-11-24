//-----------------------------------------------------------------------
// <copyright file="MatrixPosition.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Matrix
{
    using System;
    using System.Linq;

    /// <summary>
    /// Represents position in a matrix.
    /// </summary>
    public class MatrixPosition
    {
        public MatrixPosition(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public void Update(int directionX, int directionY)
        {
            this.Row += directionX;
            this.Column += directionY;
        }
    }
}
