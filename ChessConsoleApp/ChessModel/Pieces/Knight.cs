using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel.Pieces
{
    public class Knight : Piece
    {
        public Knight(Board board, PieceColor color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] grid = new bool[_board._rows, _board._cols];
            int[] dx = new int[8] { 2, 2, 1, 1, -2, -2, -1, -1 };
            int[] dy = new int[8] { 1, -1, 2, -2, 1, -1, 2, -2 };
            Cell pos = new Cell(0, 0);
            for (int i = 0; i < dx.Length; i++)
            {
                pos.SetValueForCell(position.rowNum + dx[i], position.colNum + dy[i]);
                if (_board.isValidPosition(pos) && canMove(pos))
                    grid[pos.rowNum, pos.colNum] = true;
            }
            return grid;
        }
    }
}
