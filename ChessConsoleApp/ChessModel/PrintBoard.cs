using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public static class PrintBoard
    {
        public static void print(Board board, bool[,] possiblePositions)
        {
            for (int i = 0; i < board._rows; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board._cols; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        //Console.Write("•");
                    }
                    else
                    {
                        if ((i + j) % 2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            //PrintPiece.print(board.getPiece(i, j));
                            //Console.ForegroundColor = ConsoleColor.Black;
                            //Console.Write(" ♜ ");
                        }
                        else
                        {

                            Console.BackgroundColor = ConsoleColor.Gray;
                           // Console.ForegroundColor = ConsoleColor.Red;
                           // PrintPiece.print(board.getPiece(i, j));
                            //Console.Write(" ♜ ");
                        }
                    }
               

                    PrintPiece.print(board.getPiece(i, j));

                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }

            Console.WriteLine("   A  B  C  D  E  F  G  H");

            Console.BackgroundColor = ConsoleColor.Black;
        }
        //initially called 
        public static void print(Board board)
        {
            for (int i = 0; i < board._rows; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board._cols; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        PrintPiece.print(board.getPiece(i, j));
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        PrintPiece.print(board.getPiece(i, j));
                    }
                }
                //Console.ResetColor();
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            //Console.ResetColor();
            Console.WriteLine("   A  B  C  D  E  F  G  H");
        }
    }
}
