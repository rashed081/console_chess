using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessModel
{
    public static class PrintGame
    {
        public static void print(Game game)
        {
            PrintBoard.print(game.Board);
            Console.WriteLine();

            PrintPiece.PrintCapturedPieces(game);
            Console.WriteLine();

            Console.WriteLine($"Turn: {game.Turn}");

            if (!game.GameOver)
            {
                Console.WriteLine($"Player: {game.CurrentPlayer}");
                if (game.Xeque)
                    Console.WriteLine("!!!!!!!!Ceque!!!!!!!!");

            }
            else
            {
                Console.WriteLine("CEQUEMATE");
                Console.WriteLine($"Winner: {game.CurrentPlayer}");
            }

        }
        public static ChessPosition ReadChessPosition(string dataPlayer)
        {
            char column = dataPlayer[0];
            int line = int.Parse(dataPlayer[1] + "");

            return new ChessPosition(column, line);
        }
    }
}
