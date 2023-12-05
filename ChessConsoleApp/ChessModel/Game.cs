using ChessModel.Pieces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public class Game
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public PieceColor CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }

        private HashSet<Piece> Pieces;

        private HashSet<Piece> CapturedPieces;

        public Piece PossibleEnPassant { get; private set; }

        public bool Xeque { get; private set; }

        public Game()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = PieceColor.Blue;
            GameOver = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PossibleEnPassant = null;
            Xeque = false;
            insertAllPieces();
        }


        //when the target cell contains enemy 
        public Piece killingMove(Cell source, Cell target)
        {
            Piece piece = Board.removePiece(source);
            piece.moves++;
            Piece capturedPiece = Board.removePiece(target);
            Board.insertPiece(piece, target);

            if (capturedPiece != null)
                CapturedPieces.Add(capturedPiece);

            return capturedPiece;
        }

        public void normalMoves(Cell source, Cell target)
        {
            Piece capturedPiece = killingMove(source, target);

            if (isCheque(CurrentPlayer))
            {
                UndoMove(source, target, capturedPiece);
                throw new Exception("Can't put in cheque position");
            }

            Piece piece = Board.getPiece(target);

            if (piece is Pawn)
            {
                if (piece._color == PieceColor.Blue && target.rowNum== 0 ||
                    piece._color == PieceColor.Red && target.rowNum == 7)
                {
                    piece = Board.removePiece(target);
                    Pieces.Remove(piece);
                    Piece queen = new Queen(Board, piece._color);
                    Board.insertPiece(queen, target);
                    Pieces.Add(queen);
                }
            }

            if (isCheque(opponent(CurrentPlayer)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (isChequeMate(opponent(CurrentPlayer)))
            {
                GameOver = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

           
            if (piece is Pawn && (target.rowNum == source.rowNum - 2 ||
                target.rowNum == source.rowNum + 2))
            {
                PossibleEnPassant = piece;
            }
            else
            {
                PossibleEnPassant = null;
            }

        }

        public void UndoMove(Cell source, Cell target, Piece captured)
        {
            Piece piece = Board.removePiece(target);
            piece.moves--;

            if (captured != null)
            {
                Board.insertPiece(captured, target);
                CapturedPieces.Remove(captured);
            }

            Board.insertPiece(piece, source);
        }

        public void isValidSource(Cell position)
        {
            if (Board.getPiece(position) is null)
                throw new Exception("No piece there.");

            if (CurrentPlayer != Board.getPiece(position)._color)
                throw new Exception("Not your piece");

            if (!Board.getPiece(position).isPossibleMoves())
                throw new Exception("No possible move available");
        }

        public void isValidTarget(Cell origin, Cell target)
        {
            if (!Board.getPiece(origin).CanMoveForPosition(target))
            {
                throw new Exception("Invalid Target");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == PieceColor.Blue)
            {
                CurrentPlayer = PieceColor.Red;
            }
            else
            {
                CurrentPlayer = PieceColor.Blue;
            }
        }

        public HashSet<Piece> AllPiecesCapturedPerColor(PieceColor color)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();
            foreach (var item in CapturedPieces)
            {
                if (item._color == color)
                {
                    pieces.Add(item);
                }
            }

            return pieces;
        }

        public HashSet<Piece> PiecesAtGame(PieceColor color)
        {
            HashSet<Piece> allPieces = new HashSet<Piece>();
            foreach (var item in Pieces)
            {
                if (item._color == color)
                {
                    allPieces.Add(item);
                }
            }

            allPieces.ExceptWith(AllPiecesCapturedPerColor(color));
            return allPieces;
        }

        public Cell ToBoardPosition(int row, char col)
        {
            return new Cell(8 - row, col - 'a');
        }
        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.insertPiece(piece, new ChessPosition(column, line).ToBoardPosition());
            Pieces.Add(piece);
        }

        private PieceColor opponent(PieceColor color)
        {
            if (color == PieceColor.Blue)
            {
                return PieceColor.Red;
            }
            else
            {
                return PieceColor.Blue;
            }
        }

        private Piece isKing(PieceColor color)
        {
            foreach (var item in PiecesAtGame(color))
            {
                if (item is King)
                    return item;
            }

            return null;
        }

        public bool isCheque(PieceColor color)
        {
            Piece king = isKing(color);

            if (king is null)
                throw new Exception($"There is no King in that color: {color}");

            foreach (var item in PiecesAtGame(opponent(color)))
            {
                bool[,] matriz = item.PossibleMoves();
                if (matriz[king.position.rowNum, king.position.colNum])
                {
                    return true;
                }
            }
            return false;
        }

        public bool isChequeMate(PieceColor color)
        {
            if (!isCheque(color))
                return false;

            foreach (var item in PiecesAtGame(color))
            {
                bool[,] matriz = item.PossibleMoves();
                for (int i = 0; i < Board._rows; i++)
                {
                    for (int j = 0; j < Board._cols; j++)
                    {
                        if (matriz[i, j])
                        {
                            Cell source = item.position;
                            Cell target = new Cell(i, j);
                            Piece caputredPiece = killingMove(source, target);
                            bool cheque = isCheque(color);
                            UndoMove(source, target, caputredPiece);

                            if (!Xeque)
                                return false;
                        }
                    }
                }
            }
            return true;
        }

        private void insertAllPieces()
        {
            PutNewPiece('a', 1, new Rook(Board, PieceColor.Blue));
            PutNewPiece('h', 1, new Rook(Board, PieceColor.Blue));
            PutNewPiece('b', 1, new Knight(Board, PieceColor.Blue));
            PutNewPiece('g', 1, new Knight(Board, PieceColor.Blue));
            PutNewPiece('c', 1, new Bishop(Board, PieceColor.Blue));
            PutNewPiece('f', 1, new Bishop(Board, PieceColor.Blue));
            PutNewPiece('d', 1, new Queen(Board, PieceColor.Blue));
            PutNewPiece('e', 1, new King(Board, PieceColor.Blue));
            PutNewPiece('a', 2, new Pawn(Board, PieceColor.Blue));
            PutNewPiece('b', 2, new Pawn(Board, PieceColor.Blue));
            PutNewPiece('c', 2, new Pawn(Board, PieceColor.Blue));
            PutNewPiece('d', 2, new Pawn(Board, PieceColor.Blue));
            PutNewPiece('e', 2, new Pawn(Board, PieceColor.Blue));
            PutNewPiece('f', 2, new Pawn(Board, PieceColor.Blue));
            PutNewPiece('g', 2, new Pawn(Board, PieceColor.Blue));
            PutNewPiece('h', 2, new Pawn(Board, PieceColor.Blue));

            PutNewPiece('a', 8, new Rook(Board, PieceColor.Red));
            PutNewPiece('h', 8, new Rook(Board, PieceColor.Red));
            PutNewPiece('b', 8, new Knight(Board, PieceColor.Red));
            PutNewPiece('g', 8, new Knight(Board, PieceColor.Red));
            PutNewPiece('c', 8, new Bishop(Board, PieceColor.Red));
            PutNewPiece('f', 8, new Bishop(Board, PieceColor.Red));
            PutNewPiece('d', 8, new Queen(Board, PieceColor.Red));
            PutNewPiece('e', 8, new King(Board, PieceColor.Red));
            PutNewPiece('a', 7, new Pawn(Board, PieceColor.Red));
            PutNewPiece('b', 7, new Pawn(Board, PieceColor.Red));
            PutNewPiece('c', 7, new Pawn(Board, PieceColor.Red));
            PutNewPiece('d', 7, new Pawn(Board, PieceColor.Red));
            PutNewPiece('e', 7, new Pawn(Board, PieceColor.Red));
            PutNewPiece('f', 7, new Pawn(Board, PieceColor.Red));
            PutNewPiece('g', 7, new Pawn(Board, PieceColor.Red));
            PutNewPiece('h', 7, new Pawn(Board, PieceColor.Red));
        }
    }
}

