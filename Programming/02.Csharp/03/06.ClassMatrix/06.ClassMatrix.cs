using System;
using System.Globalization;
using System.Text;

class ClassMatrix
{
    // * Write a class Matrix, to holds a matrix of integers.
    // Overload the operators for adding, subtracting and 
    // multiplying of matrices, indexer for accessing the 
    // matrix content and ToString().

    public class Matrix
    {
        private int[,] theMatrix;
        private readonly int rows;
        private readonly int cols;

        public Matrix(int[,] theMatrix)
        {
            this.theMatrix = theMatrix;
            rows = theMatrix.GetLength(0);
            cols = theMatrix.GetLength(1);
        }

        /// <summary>
        /// new instance of Matrix with given rows and cols values
        /// </summary>
        public Matrix(int r, int c)
        {
            rows = r;
            cols = c;
            theMatrix = new int[rows, cols];
        }

        /// <summary>
        /// Sum of two matrices
        /// </summary>
        public static Matrix operator +(Matrix first, Matrix second)
        {
            Matrix resultMatrix = new Matrix(first.rows, first.cols);
            for (int i = 0; i < first.rows; i++)
            {
                for (int j = 0; j < first.cols; j++)
                {
                    resultMatrix[i, j] = first.GetValue(rows, cols) + second.GetValue(rows, cols);
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Substraction of two matrices
        /// </summary>
        public static Matrix operator -(Matrix first, Matrix second)
        {
            Matrix resultMatrix = new Matrix(first.rows, first.cols);
            for (int i = 0; i < first.rows; i++)
            {
                for (int j = 0; j < first.cols; j++)
                {
                    resultMatrix[i, j] = first.GetValue(i, j) - second.GetValue(i, j);
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Multiplication of  two matrices
        /// </summary>
        public static Matrix operator *(Matrix first, Matrix second)
        {
            if (first.rows != second.cols
                || first.cols != second.rows)
            {
                throw new Exception("Matrices are different");
            }

            Matrix resultMatrix = new Matrix(first.rows, second.cols);
            for (int i = 0; i < resultMatrix.rows; i++)
            {
                for (int j = 0; j < resultMatrix.cols; j++)
                {
                    int result = 0;
                    for (int k = 0; k < first.cols; k++)
                    {

                        result += first.GetValue(i, k) * second.GetValue(k, j);
                    }

                    resultMatrix.SetValue(i, j, result);
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// get a value from a cell
        /// </summary>
        public int GetValue(int row, int col)
        {
            if (row < 0 || row >= rows)
            {
                throw new ArgumentOutOfRangeException("row");
            }

            if (col < 0 || col >= cols)
            {
                throw new ArgumentOutOfRangeException("col");
            }

            return theMatrix[row, col];
        }

        /// <summary>
        /// Set a value in a cell
        /// </summary>
        public void SetValue(int row, int col, int value)
        {
            if (row < 0 || row >= rows)
            {
                throw new ArgumentOutOfRangeException("row");
            }

            if (col < 0 || col >= cols)
            {
                throw new ArgumentOutOfRangeException("col");
            }

            theMatrix[row, col] = value;
        }

        //indexer
        public object this[int r, int c]
        {
            get
            {
                return this.theMatrix[r, c];
            }
            set
            {
                this[r, c] = value;
            }
        }

        //overload method for ToSting()
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    str.Append(theMatrix[i, j]);
                }
                str.Append("\n");
            }

            return str.ToString();
        }
    }
}
