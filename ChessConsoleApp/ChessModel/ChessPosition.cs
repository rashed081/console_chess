using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public class ChessPosition
    {
        public char col { get; set; }
        public int row { get; set; }

        public ChessPosition(char _col, int _row)
        {
            col = _col;
            row = _row;
        }
        public Cell ToBoardPosition()
        {
            return new Cell(8 - row, col - 'a');
        }

        //public override string ToString()
        //{
        //    return $"{Column}{Line}";
        //}
    }
}
