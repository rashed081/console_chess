using ChessModel.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public static class PrintPiece
    {
        public static void print(Piece piece)
        {
            if (piece is null)
            {
                Console.Write("   ");
            }
            else
            {
                switch (piece)
                {
                    case King k when k._color == PieceColor.Blue:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" ♚ ");
                        break;
                    case Queen q when q._color == PieceColor.Blue:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" ♛ ");
                        break;
                    case Rook r when r._color == PieceColor.Blue:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" ♜ ");
                        break;
                    case Bishop b when b._color == PieceColor.Blue:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" ♝ ");
                        break;
                    case Knight n when n._color == PieceColor.Blue:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" ♞ ");
                        break;
                    case Pawn p when p._color == PieceColor.Blue:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(" ♟ ");
                        break;
                    case King k when k._color == PieceColor.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" ♚ ");
                        break;
                    case Queen q when q._color == PieceColor.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" ♛ ");
                        break;
                    case Rook r when r._color == PieceColor.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" ♜ ");
                        break;
                    case Bishop b when b._color == PieceColor.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" ♝ ");
                        break;
                    case Knight n when n._color == PieceColor.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" ♞ ");
                        break;
                    case Pawn p when p._color == PieceColor.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" ♟ ");
                        break;
                }
            }
            Console.ResetColor();
        }

        public static void PrintCapturedPieces(Game game)
        {
            Console.WriteLine("Killed: ");
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("Blue: ");
            PrintSet(game.AllPiecesCapturedPerColor(PieceColor.Blue));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Red: ");
            PrintSet(game.AllPiecesCapturedPerColor(PieceColor.Red));

            Console.ForegroundColor = defaultColor;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            set.ToList().ForEach(x => Console.Write(x + " "));
            Console.Write("]");
        }
    }
}
