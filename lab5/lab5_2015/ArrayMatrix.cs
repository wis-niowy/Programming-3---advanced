using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    class ArrayMatrix: Matrix
    {
        public double[,] Matrix;

        public ArrayMatrix(int _rows, int _columns, double[,] _tab): base(_rows, _columns, _tab)
        {
            if (base.Rows == -1)
            {
                Matrix = null;
            }
            else
            {
                Matrix = _tab;
            }
        }

        override public double GetValue(int _row, int _col)
        {
            if (_row < 0 || _row >= base.Rows || _col < 0 || _col >= base.Columns)
                return double.MinValue;
            else
            return Matrix[_row, _col];
        }
        override public void SetValue(int _row, int _col, double _val)
        {
            if (_row < 0 || _row >= base.Rows || _col < 0 || _col >= base.Columns)
                return;
            else
            Matrix[_row, _col] = _val;
        }
    }
}
