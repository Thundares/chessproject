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
                ChessGame game = new ChessGame();

                Screen.printBoard(game.board);
            }
            catch(BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
