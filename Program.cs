using System;
using board;
using Game;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);
                board.putPeca(new King(board, Color.black), new Position(0,0));
                board.putPeca(new Tower(board, Color.white), new Position(1,0));

                Screen.printBoard(board);
            }
            catch(BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
