using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public  class Cell
    {
        public int rowNum { get; set; }
        public int colNum { get; set; }
        public bool currentlyOccupied { get; set; }
        public bool leagalNextMove { get; set; }

        public Cell(int rowNum, int colNum)
        {
            this.rowNum = rowNum;
            this.colNum = colNum;
        }
        public void SetValueForCell(int row, int col)
        {
            rowNum = row;
            colNum = col;
        }
    }
}
