using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel.Pieces
{
    public class PossiblePositions
    {
        public static Board _board { get; set; }
        public PossiblePositions(Board board)
        {
            _board = board;
        }
        public static bool[,] PossibleMoves(object piece, int[] dx, int[]dy, Cell position,PieceColor color)
        {
            bool[,] grid = new bool[_board._rows, _board._cols];
            Cell pos = new Cell(0, 0);


            //Queen possible moves
            if(piece is Queen)
            {
                for (int i = 0; i < dx.Length; i++)
                {
                    pos.SetValueForCell(position.rowNum + dx[i], position.colNum + dy[i]);
                    while (_board.isValidPosition(pos) && canMove(pos, color))
                    {
                        grid[pos.rowNum, pos.colNum] = true;
                        if (_board.getPiece(pos) != null && _board.getPiece(pos)._color != color)
                            break;
                        pos.SetValueForCell(position.rowNum + dx[i], position.colNum + dy[i]);
                    }
                }
            }

            //King possible moves
            if(piece is King)
            {
                for (int i = 0; i < dx.Length; i++)
                {
                    pos.SetValueForCell(position.rowNum + dx[i], position.colNum + dy[i]);
                    if (_board.isValidPosition(pos) && canMove(pos, color))
                        grid[pos.rowNum, pos.colNum] = true;
                };
            }

            //Bishop possible moves
            if(piece is Bishop)
            {
                for (int i = 0; i < dx.Length; i++)
                {
                    pos.SetValueForCell(position.rowNum + dx[i], position.colNum + dy[i]);
                    while (_board.isValidPosition(pos) && canMove(pos, color))
                    {
                        grid[pos.rowNum, pos.colNum] = true;
                        if (_board.getPiece(pos) != null && _board.getPiece(pos)._color != color)
                            break;
                        pos.SetValueForCell(position.rowNum + dx[i], position.colNum + dy[i]);
                    }

                }
            }

            //Knight Possible move
            if(piece is Knight)
            {
                for (int i = 0; i < dx.Length; i++)
                {
                    pos.SetValueForCell(position.rowNum + dx[i], position.colNum + dy[i]);
                    if (_board.isValidPosition(pos) && canMove(pos, color))
                        grid[pos.rowNum, pos.colNum] = true;
                }
            }

            //Rook Possible move
            if(piece is Rook)
            {
                for (int i = 0; i < dx.Length; i++)
                {
                    pos.SetValueForCell(position.rowNum + dx[i], position.colNum + dy[i]);
                    while (_board.isValidPosition(pos) && canMove(pos, color))
                    {
                        grid[pos.rowNum, pos.colNum] = true;
                        if (_board.getPiece(pos) != null && _board.getPiece(pos)._color != color)
                            break;
                        pos.SetValueForCell(position.rowNum + dx[i], position.colNum + dy[i]);
                    }

                }
            }
            return grid;
        }
        public static bool canMove(Cell position, PieceColor color)
        {
            Piece piece = _board.getPiece(position);
            return piece != null || piece._color != color;
        }
    }
}
