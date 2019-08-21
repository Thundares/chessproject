using board;
using System;
using Game;

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
                    printPeca(board.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] mat)
        {
            ConsoleColor original = Console.BackgroundColor;
            ConsoleColor changed = ConsoleColor.DarkGray;
            for(int i = 0; i < board.line; i++)
            {
                Console.Write(8-i + " ");
                for(int j = 0; j < board.col; j++)
                {
                    if(mat[i,j])
                    {
                        Console.BackgroundColor = changed;
                    }
                    else
                        Console.BackgroundColor = original;
                    printPeca(board.peca(i, j));
                    Console.BackgroundColor = original;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = original;
        }
        public static ChessPosition readCommand()
        {
            string s = Console.ReadLine();
            char line = s[0];
            int col = int.Parse(s[1] + "");
            return new ChessPosition(line, col);
        }
        public static void printPeca(Peca p)
        {
            if(p == null)
                Console.Write("- ");
            else if(p.color == Color.white)
                Console.Write(p + " ");
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p + " ");
                Console.ForegroundColor = aux;
            }

        }
    }
}