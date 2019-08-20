using board;

namespace Game
{
    class King : Peca
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Peca p = board.peca(pos);
            return p == null || p.color != this.color;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.line, board.col];
            Position test = new Position(0,0);

            //acima
            test.definePosition(posicao.line - 1, posicao.col);
            if(board.validPosition(test) && canMove(test))
                mat[test.line, test.col] = true;

            //NE
            test.definePosition(posicao.line - 1, posicao.col + 1);
            if(board.validPosition(test) && canMove(test))
                mat[test.line, test.col] = true;

            //E
            test.definePosition(posicao.line, posicao.col + 1);
            if(board.validPosition(test) && canMove(test))
                mat[test.line, test.col] = true;

            //Se
            test.definePosition(posicao.line + 1, posicao.col + 1);
            if(board.validPosition(test) && canMove(test))
                mat[test.line, test.col] = true;

            //s
            test.definePosition(posicao.line + 1, posicao.col);
            if(board.validPosition(test) && canMove(test))
                mat[test.line, test.col] = true;
            //so
            test.definePosition(posicao.line + 1, posicao.col - 1);
            if(board.validPosition(test) && canMove(test))
                mat[test.line, test.col] = true;
            //o
            test.definePosition(posicao.line, posicao.col - 1);
            if(board.validPosition(test) && canMove(test))
                mat[test.line, test.col] = true;

            //NO
            test.definePosition(posicao.line - 1, posicao.col - 1);
            if(board.validPosition(test) && canMove(test))
                mat[test.line, test.col] = true;

            return mat;
        }
    }
        class Tower : Peca
    {
        public Tower(Board board, Color color) : base(board, color)
        {
        }

        private bool canMove(Position pos)
        {
            Peca p = board.peca(pos);
            return p == null || p.color != this.color;
        }
         public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.line, board.col];
            Position test = new Position(0,0);

            //acima       
            test.definePosition(posicao.line - 1, posicao.col);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.line--;
            }
            //E
            test.definePosition(posicao.line, posicao.col + 1);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.col++;
            }
            //s
            test.definePosition(posicao.line + 1, posicao.col);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.line++;
            }
            //o
            test.definePosition(posicao.line, posicao.col - 1);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.line++;
            }
            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}