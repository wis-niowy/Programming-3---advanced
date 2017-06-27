using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    abstract class Matrix
    {
        public int Rows;
        public int Columns;

        public Matrix(int _rows, int _columns, double[,] _tab)
        {
            if (_rows <= 0 || _columns <= 0 || _tab == null)
            {
                Rows = Columns = -1;
            }
            else if(_rows != _tab.GetLength(0) || _columns != _tab.GetLength(1))
            {
                Rows = Columns = -1;
            }
            else
            {
                Rows = _rows;
                Columns = _columns;
            }
        }
        abstract public double GetValue(int _row, int _col);
        abstract public void SetValue(int _row, int _col, double _val);

        public void Print()
        {
            for (int i = 0; i < this.Rows; ++i)
            {
                for (int j = 0; j < this.Columns; ++j)
                {
                    Console.Write("{0}    ", GetValue(i, j));
                }
                Console.Write("\n");
            }
        }
    }
}
