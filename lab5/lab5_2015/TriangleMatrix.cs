using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    class TriangleMatrix: Matrix
    {
        public double[][] TriMatrix;

        public TriangleMatrix(int _size, double[,] _tab): base(_size, _size, null)
        {
            if (_tab == null)
            {

            }
            else if (_tab.GetLength(0) != _tab.GetLength(1))
            {
                base.Rows = -1;
                base.Columns = -1;
            }
            else
            {
                base.Rows = _size;
                base.Columns = _size;
                TriMatrix = new double[_size][];        // tablica tablic o wymiarze _size
                for (int i = 0; i < _size; ++i)
                {
                    TriMatrix[i] = new double[i+1];
                    for (int j = 0; j < _size; ++j)
                    {
                        if (i >= j)
                        {
                            TriMatrix[i][j] = _tab[i, j];
                        }
                    }
                } //for
            }
        }

        override public double GetValue(int _row, int _col)
        {
            if (_row < 0 || _row >= base.Rows || _col < 0 || _col >= base.Columns)
            {
                return double.MinValue;
            }
            else
            {
                if (_col > _row)
                {
                    return 0;
                }
                else
                {
                    return TriMatrix[_row][_col];
                }
            }
        }
        override public void SetValue(int _row, int _col, double _val)
        {
            if (_row < 0 || _row >= base.Rows || _col < 0 || _col >= base.Columns)
            {
                return;
            }
            else
            {
                if (_col > _row)
                {
                    return;
                }
                else
                {
                    TriMatrix[_row][_col] = _val;
                }
            }
        }
    }
}
