using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel.Pieces
{
    public abstract class Piece 
    {
        public Cell position { get; set; }
        public PieceColor _color { get; set; }
        public Board _board { get; set; }
        public bool moved { get; set; }
        public bool toBeCaptured { get; set; }
        public int moves { get; set; } // total moves by a specific piece

        public Piece(Board board, PieceColor color)
        {
            _color = color;
            _board = board;
            moves = 0;
            position = null;
        }

        public bool isPossibleMoves()
        {
            bool[,] grid = PossibleMoves();
            for (int i = 0; i < _board._rows; i++)
                for (int j = 0; j < _board._cols; j++)
                    if (grid[i, j]) 
                        return true;
            return false;
        }

        public bool CanMoveForPosition(Cell position)
        {
            bool[,] matrix = PossibleMoves();
            return matrix[position.rowNum, position.colNum];
        }

        public abstract bool[,] PossibleMoves();
        public bool canMove(Cell position)
        {
            Piece piece = _board.getPiece(position);
            return piece == null || piece._color != _color;
        }
        protected bool ThereIsEnemy(Cell position)
        {
            Piece piece = _board.getPiece(position);
            return piece != null && piece._color != _color;
        }

        protected bool Free(Cell position)
        {
            return _board.getPiece(position) == null;
        }

    }
}
