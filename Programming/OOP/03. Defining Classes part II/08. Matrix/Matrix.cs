using System;
using System.Linq;
using System.Text;

namespace Matrix
{
    class Matrix<T>
    {
        // fields
        private readonly int row;
        private readonly int col;

        private T[,] matrix;

        // constructor
        public Matrix(int r, int c)
        {
            this.row = r;
            this.col = c;
            this.matrix = new T[row, col];
        }

        // Indexer declaration
        public T this[int r, int c]
        {
            get
            {
                if (r >= 0 && r < this.row
                    && c >= 0 && c < this.col)
                {
                    return this.matrix[r, c];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (r >= 0 && r < this.row
                    && c >= 0 && c < this.col)
                {
                    this.matrix[r, c] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        // Sum of two matrices
        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if (first.row != second.col
                || first.col != second.row)
            {
                throw new Exception("Matrices are different");
            }

            Matrix<T> resultMatrix = new Matrix<T>(first.row, first.col);
            for (int i = 0; i < first.row; i++)
            {
                for (int j = 0; j < first.col; j++)
                {
                    resultMatrix[i, j] = (dynamic)first[i, j] + (dynamic)second[i, j];
                }
            }

            return resultMatrix;
        }

        // Substraction of two matrices
        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if (first.row != second.col
                || first.col != second.row)
            {
                throw new Exception("Matrices are different");
            }

            Matrix<T> resultMatrix = new Matrix<T>(first.row, first.col);
            for (int i = 0; i < first.row; i++)
            {
                for (int j = 0; j < first.col; j++)
                {
                    resultMatrix[i, j] = (dynamic)first[i, j] - (dynamic)second[i, j];
                }
            }

            return resultMatrix;
        }

        // Multiplication of two matrices
        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if (first.row != second.col
                || first.col != second.row)
            {
                throw new Exception("Matrices are different");
            }

            Matrix<T> resultMatrix = new Matrix<T>(first.row, second.col);
            for (int i = 0; i < resultMatrix.row; i++)
            {
                for (int j = 0; j < resultMatrix.col; j++)
                {
                    for (int k = 0; k < first.col; k++)
                    {
                        resultMatrix[i, j] += (dynamic)first[i, k] * (dynamic)second[k, j];
                    }
                }
            }

            return resultMatrix;
        }

        // true operator
        public static bool operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.row; i++)
            {
                for (int j = 0; j < matrix.col; j++)
                {
                    if (matrix[i, j].Equals(default(T)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // false operator
        public static bool operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.row; i++)
            {
                for (int j = 0; j < matrix.col; j++)
                {
                    if (matrix[i, j].Equals(default(T)))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //overload method for ToSting()
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    str.Append(" " + matrix[i, j]);
                }
                str.Append("\n");
            }

            return str.ToString();
        }
    }
}
