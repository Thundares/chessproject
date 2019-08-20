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
                while(!game.Finished)
                {
                    Console.Clear();
                    Screen.printBoard(game.board);
                    
                    Console.Write("Put the origin: ");
                    Position origin = Screen.readCommand().ToPosition();
                    
                    Console.Write("Put the destiny: ");
                    Position destiny = Screen.readCommand().ToPosition();

                    game.move(origin, destiny);
                }
            }
            catch(BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
