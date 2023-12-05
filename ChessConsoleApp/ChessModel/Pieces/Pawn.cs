using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Board board, PieceColor color) : base(board, color)
        {
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matriz = new bool[_board._rows, _board._cols];

            Cell pos = new(0, 0);

            if (_color == PieceColor.Blue)
            {
                pos.SetValueForCell(position.rowNum - 1, position.colNum);
                if (_board.isValidPosition(pos) && Free(pos))
                {
                    matriz[pos.rowNum, pos.colNum] = true;
                }

                pos.SetValueForCell(position.rowNum - 2, position.colNum);
                Cell position2 = new(position.rowNum - 1, position.colNum);
                if (_board.isValidPosition(position2) && Free(position2) &&
                    _board.isValidPosition(pos) && Free(pos) &&
                    moves == 0)
                {
                    matriz[pos.rowNum, pos.colNum] = true;
                }

                pos.SetValueForCell(position.rowNum - 1, position.colNum - 1);
                if (_board.isValidPosition(pos) && ThereIsEnemy(pos))
                {
                    matriz[pos.rowNum, pos.colNum] = true;
                }

                pos.SetValueForCell(position.rowNum - 1, position.colNum + 1);
                if (_board.isValidPosition(pos) && ThereIsEnemy(pos))
                {
                    matriz[pos.rowNum, pos.colNum] = true;
                }
            }
            else
            {
                pos.SetValueForCell(position.rowNum + 1, position.colNum);
                if (_board.isValidPosition(pos) && Free(pos))
                {
                    matriz[pos.rowNum, pos.colNum] = true;
                }

                pos.SetValueForCell(position.rowNum + 2, position.colNum);
                Cell position2 = new Cell(position.rowNum + 1, position.colNum);
                if (_board.isValidPosition(position2) && Free(position2) &&
                    _board.isValidPosition(pos) && Free(pos) &&
                    moves == 0)
                {
                    matriz[pos.rowNum, pos.colNum] = true;
                }

                pos.SetValueForCell(position.rowNum + 1, position.colNum - 1);
                if (_board.isValidPosition(pos) && ThereIsEnemy(pos))
                {
                    matriz[pos.rowNum, pos.colNum] = true;
                }

                pos.SetValueForCell(position.rowNum + 1, position.colNum + 1);
                if (_board.isValidPosition(pos) && ThereIsEnemy(pos))
                {
                    matriz[pos.rowNum, pos.colNum] = true;
                }
            }

            return matriz;
        }

    }
}
