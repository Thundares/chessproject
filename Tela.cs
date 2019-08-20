using board;
using System;

namespace console
{
    class Screen
    {
        public static void printBoard(Board board)
        {
            for(int i = 0; i < board.line; i++)
            {
                for(int j = 0; j < board.col; j++)
                {
                    if(board.peca(i,j) == null)
                        Console.Write("- ");
                    else
                        Console.Write(board.peca(i,j) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}