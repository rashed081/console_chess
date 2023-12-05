using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel.Pieces
{
    public class King : Piece
    {
        public King(Board board, PieceColor color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] grid = new bool[_board._rows,_board._cols];
            int[] dx = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = new int[] { 0, 1, -1, 1, -1, -1, 0, 1 };
            Cell pos = new Cell(0, 0);
            for(int i=0; i<dx.Length; i++)
            {
                pos.SetValueForCell(position.rowNum + dx[i], position.colNum + dy[i]);
                if (_board.isValidPosition(pos) && canMove(pos))
                    grid[pos.rowNum, pos.colNum] = true;
            }
            return grid;
        }
    }
}
