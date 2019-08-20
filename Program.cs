using System;
using board;
using Game;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            board.putPeca(new King(board, Color.black), new Position(0,0));

            Screen.printBoard(board);
        }
    }
}
