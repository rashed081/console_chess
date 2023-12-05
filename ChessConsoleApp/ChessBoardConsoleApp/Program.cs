using ChessModel;
Console.OutputEncoding = System.Text.Encoding.Unicode;
try
{
    Game game = new Game();

    while (!game.GameOver)
    {
        Console.Clear();

        PrintGame.print(game);

        Console.WriteLine();

        Console.Write("Source: ");
        string dataSource = Console.ReadLine();

        Cell source = PrintGame.ReadChessPosition(dataSource).ToBoardPosition();

        game.isValidSource(source);

        bool[,] possiblePositions = game.Board.getPiece(source).PossibleMoves();

        Console.Clear();

        PrintBoard.print(game.Board, possiblePositions);

        Console.WriteLine();

        Console.Write("Target: ");

        string dataTarget = Console.ReadLine();

        Cell target = PrintGame.ReadChessPosition(dataTarget).ToBoardPosition();

        game.isValidTarget(source, target);

        game.normalMoves(source, target);
        
    }

    Console.Clear();
    PrintGame.print(game);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

//Board myBoard = new Board();

//Cell currentCell;
//setCurrentCell();

//currentCell.currentlyOccupied = true;

//Console.OutputEncoding = System.Text.Encoding.Unicode;

//Console.WriteLine("King / Queen / Knight / Bishop / Rook / Pawn");
//string pieceName = Console.ReadLine();

//myBoard.MakeNextLeagalMove(currentCell, pieceName.ToLower());

//PrintBoard p1 = new PrintBoard(myBoard);
//p1.Print();


//void setCurrentCell()
//{
//    int currRow = 0, currCol = 0;
//    try
//    {
//        Console.Write("Row: ");
//        currRow = int.Parse(Console.ReadLine());
//        Console.Write("\nCol:");
//        currCol = int.Parse(Console.ReadLine());
//    }
//    catch
//    {
//        Console.WriteLine("Invalid!\n");
//        setCurrentCell();
//    }

//    if (currRow >= 0 && currRow <= 7 && currCol >= 0 && currCol <= 7)
//        currentCell = myBoard.Grid[currRow, currCol];
//    else
//    {
//        Console.WriteLine("Invalid input!\n");
//        setCurrentCell();
//    }

//   // const int BOARD_SIZE = 8;



//    //Console.WriteLine("\n\n");
//    //for (int row = 0; row < BOARD_SIZE; row++)
//    //{
//    //    Console.Write("\t\t");
//    //    for (int col = 0; col < BOARD_SIZE; col++)
//    //    {
//    //            if ((row + col) % 2 == 0)
//    //            {
//    //                Console.BackgroundColor = ConsoleColor.DarkYellow;
//    //                Console.ForegroundColor = ConsoleColor.Black;
//    //                Console.Write(" ♜ ");
//    //            }
//    //            else
//    //            {
//    //                Console.BackgroundColor = ConsoleColor.Gray;
//    //                Console.ForegroundColor = ConsoleColor.Black;
//    //                Console.Write(" ♜ ");
//    //            }

//    //    }
//    //    Console.ResetColor();
//    //    Console.WriteLine();
//    //}
//}

