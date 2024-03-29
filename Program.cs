﻿using System;
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
                    try{
                        Console.Clear();

                        Screen.printGame(game);
                        Position origin = Screen.readCommand().ToPosition();
                        game.validMove(origin);

                        bool[,] possible = game.board.peca(origin).possibleMoves();
                        Console.Clear();
                        Screen.printBoard(game.board, possible);

                        Console.Write("Put the destiny: ");
                        Position destiny = Screen.readCommand().ToPosition();
                        game.targetingValid(origin, destiny);

                        game.turnmk(origin, destiny);
                    }
                    catch (BoardExceptions e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch(BoardExceptions e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
