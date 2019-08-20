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
                Console.Write(8-i + " ");
                for(int j = 0; j < board.col; j++)
                {
                    if(board.peca(i,j) == null)
                        Console.Write("- ");
                    else
                    {
                        printPeca(board.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printPeca(Peca p)
        {
            if(p.color == Color.white)
                Console.Write(p);
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p);
                Console.ForegroundColor = aux;
            }

        }
    }
}