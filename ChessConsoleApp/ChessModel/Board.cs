using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessModel.Pieces;

namespace ChessModel
{
    
    public class Board
    {
        public int _rows { get; set; }
        public int _cols { get; set; }

        Piece[,] piecesInBoard;
        public Board(int row, int col )
        {
            _rows = row;
            _cols = col;
            piecesInBoard = new Piece[_rows, _cols];
        }

        public Piece getPiece(int row, int col)
        {
            return piecesInBoard[row, col];
        }
        public Piece getPiece(Cell position)
        {
            return piecesInBoard[position.rowNum, position.colNum];
        }
        
        public void insertPiece(Piece piece, Cell position)
        {
            if(existInPosition(position))
                Console.WriteLine("Occupied Position");
            piecesInBoard[position.rowNum, position.colNum] = piece;
            piece.position = position;
        }
        public Piece removePiece(Cell position)
        {
            if (existInPosition(position) == null)
                return null;
            Piece piece = getPiece(position);
            piecesInBoard[position.rowNum, position.colNum] = null;
            return piece;
        }

        public bool existInPosition(Cell position)
        {
            return isValidPosition(position) && getPiece(position) != null;
        }
        public bool isValidPosition(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }
        public bool isValidPosition(Cell position)
        {
            return position.rowNum >= 0 && position.rowNum < 8 && position.colNum >= 0 && position.colNum < 8;
        }




        //PieceSet BlackPieces = new PieceSet(PieceColor.Black);
        //PieceSet WhitePieces = new PieceSet(PieceColor.White);

        //public void resetBoard()
        //{
        //    for(int row=0; row<8; row++)
        //    {
        //        for(int col =0; col<8; col++)
        //        {
        //            if(row == 1)
        //            {
        //                Grid[row,col] = BlackPieces.
        //            }

        //        }
        //    }
        //}








        //Knight knight = new Knight();
       
        //public void MakeNextLeagalMove(Cell currentLocation, string piece)
        //{
        //    for (int i = 0; i < 8; i++)
        //    {
        //        for (int j = 0; j < 8; j++)
        //        {
        //            Grid[i, j].currentlyOccupied = false;
        //            Grid[i, j].leagalNextMove = false;
        //        }
        //    }
        //    switch (piece)
        //    {
        //        case "knight":
        //            knight.nextValidMoves(currentLocation, Grid);
        //            break;
        //        case "king":
        //            if(isSafe (currentLocation.rowNum + 1, currentLocation.colNum + 0))
        //                Grid[currentLocation.rowNum + 1, currentLocation.colNum + 0].leagalNextMove = true;
        //            if (isSafe(currentLocation.rowNum - 1, currentLocation.colNum + 0))
        //                Grid[currentLocation.rowNum - 1, currentLocation.colNum + 0].leagalNextMove = true;
        //            if (isSafe(currentLocation.rowNum + 1, currentLocation.colNum + 1))
        //                Grid[currentLocation.rowNum + 1, currentLocation.colNum + 1].leagalNextMove = true;
        //            if (isSafe(currentLocation.rowNum - 1, currentLocation.colNum + 1))
        //                Grid[currentLocation.rowNum - 1, currentLocation.colNum + 1].leagalNextMove = true;
        //            if (isSafe(currentLocation.rowNum + 0, currentLocation.colNum + 1))
        //                Grid[currentLocation.rowNum + 0, currentLocation.colNum + 1].leagalNextMove = true;
        //            if (isSafe(currentLocation.rowNum + 0, currentLocation.colNum -1))
        //                Grid[currentLocation.rowNum + 0, currentLocation.colNum - 1].leagalNextMove = true;
        //            if (isSafe(currentLocation.rowNum + 1, currentLocation.colNum -1))
        //                Grid[currentLocation.rowNum + 1, currentLocation.colNum - 1].leagalNextMove = true;
        //            if (isSafe(currentLocation.rowNum - 1, currentLocation.colNum -1))
        //                Grid[currentLocation.rowNum - 1, currentLocation.colNum - 1 ].leagalNextMove = true;
        //            break;
        //        case "queen":
        //            for (int i = 1; i <= 7; i++)
        //            {
        //                if (isSafe(currentLocation.rowNum + i, currentLocation.colNum + 0))
        //                    Grid[currentLocation.rowNum + i, currentLocation.colNum + 0].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum + 0, currentLocation.colNum + i))
        //                    Grid[currentLocation.rowNum + 0, currentLocation.colNum + i].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum - i, currentLocation.colNum + 0))
        //                    Grid[currentLocation.rowNum - i, currentLocation.colNum + 0].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum + 0, currentLocation.colNum - i))
        //                    Grid[currentLocation.rowNum + 0, currentLocation.colNum - i].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum + i, currentLocation.colNum + i))
        //                    Grid[currentLocation.rowNum + i, currentLocation.colNum + i].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum - i, currentLocation.colNum + i))
        //                    Grid[currentLocation.rowNum - i, currentLocation.colNum + i].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum + i, currentLocation.colNum - i))
        //                    Grid[currentLocation.rowNum + i, currentLocation.colNum - i].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum - i, currentLocation.colNum - i))
        //                    Grid[currentLocation.rowNum - i, currentLocation.colNum - i].leagalNextMove = true;
        //            }
        //            break;
        //        case "rook":
        //            for (int i = 1; i <= 7; i++)
        //            {
        //                if (isSafe(currentLocation.rowNum + i, currentLocation.colNum + 0))
        //                    Grid[currentLocation.rowNum + i, currentLocation.colNum + 0].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum + 0, currentLocation.colNum + i))
        //                    Grid[currentLocation.rowNum + 0, currentLocation.colNum + i].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum - i, currentLocation.colNum + 0))
        //                    Grid[currentLocation.rowNum - i, currentLocation.colNum + 0].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum + 0, currentLocation.colNum - i))
        //                    Grid[currentLocation.rowNum + 0, currentLocation.colNum - i].leagalNextMove = true;
        //            }
        //            break;
        //        case "bishop":
        //            for(int i=1; i<=7; i++)
        //            {
        //                if (isSafe(currentLocation.rowNum + i, currentLocation.colNum + i))
        //                    Grid[currentLocation.rowNum + i, currentLocation.colNum + i].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum - i, currentLocation.colNum + i))
        //                    Grid[currentLocation.rowNum - i, currentLocation.colNum + i].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum + i, currentLocation.colNum - i))
        //                    Grid[currentLocation.rowNum + i, currentLocation.colNum - i].leagalNextMove = true;
        //                if (isSafe(currentLocation.rowNum - i, currentLocation.colNum - i))
        //                    Grid[currentLocation.rowNum - i, currentLocation.colNum - i].leagalNextMove = true;
        //            }
        //            break;
        //        case "pawn":
        //            if (isSafe(currentLocation.rowNum - 1, currentLocation.colNum + 0))
        //                Grid[currentLocation.rowNum - 1, currentLocation.colNum + 0].leagalNextMove = true;
        //            break;

        //    }
        //    Grid[currentLocation.rowNum, currentLocation.colNum].currentlyOccupied = true;
        //}
    }
}
