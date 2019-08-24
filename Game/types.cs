using board;

namespace Game
{
    class King : Peca
    {
        private ChessGame game;
        public King(Board board, Color color, ChessGame game) : base(board, color)
        {
            this.game = game;
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

            //roque direita
            test.definePosition(posicao.line, posicao.col + 2);
            if(board.validPosition(test) && 
            canMove(test) && 
            manyMoves == 0 &&
            game.check == false &&
            game.board.peca(posicao.line, posicao.col + 3).manyMoves == 0 &&
            game.board.peca(posicao.line, posicao.col + 2) == null &&
            game.board.peca(posicao.line, posicao.col + 1) == null)
                mat[test.line, test.col] = true;

            //roque esquerda
            test.definePosition(posicao.line, posicao.col - 2);
            if(board.validPosition(test) && 
            canMove(test) && 
            manyMoves == 0 &&
            game.check == false &&
            game.board.peca(posicao.line, posicao.col - 4).manyMoves == 0 &&
            game.board.peca(posicao.line, posicao.col - 3) == null &&
            game.board.peca(posicao.line, posicao.col - 2) == null &&
            game.board.peca(posicao.line, posicao.col - 1) == null)
                mat[test.line, test.col] = true;

            return mat;
        }
        

        public override string ToString()
        {
            return "K";
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
                test.col--;
            }
            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
    class Bishop : Peca
    {
        public Bishop(Board board, Color color) : base(board, color)
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

            //diagonal esquerda cima     
            test.definePosition(posicao.line - 1, posicao.col - 1);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.line--;
                test.col--;
            }
            //diagonal direita cima
            test.definePosition(posicao.line - 1, posicao.col + 1);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.col++;
                test.line--;
            }
            //diagonal esquerda baixo
            test.definePosition(posicao.line + 1, posicao.col - 1);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.line++;
                test.col--;
            }
            //diagonal direita baixo
            test.definePosition(posicao.line + 1, posicao.col + 1);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.line++;
                test.col++;
            }
            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
    class Queen : Peca
    {
        public Queen(Board board, Color color) : base(board, color)
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
                test.col--;
            }
            //diagonal esquerda cima     
            test.definePosition(posicao.line - 1, posicao.col - 1);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.line--;
                test.col--;
            }
            //diagonal direita cima
            test.definePosition(posicao.line - 1, posicao.col + 1);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.col++;
                test.line--;
            }
            //diagonal esquerda baixo
            test.definePosition(posicao.line + 1, posicao.col - 1);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.line++;
                test.col--;
            }
            //diagonal direita baixo
            test.definePosition(posicao.line + 1, posicao.col + 1);
            while(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
                if(board.peca(test) != null && board.peca(test).color != color)
                {
                    break;
                }
                test.line++;
                test.col++;
            }
            return mat;
        }

        public override string ToString()
        {
            return "Q";
        }
    }

    class Horse : Peca
    {
        public Horse(Board board, Color color) : base(board, color)
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

            //acima direita     
            test.definePosition(posicao.line - 2, posicao.col + 1);
            if(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
            }

            //cima esquerda
            test.definePosition(posicao.line - 2, posicao.col - 1);
            if(board.validPosition(test) && canMove(test))
                mat[test.line, test.col] = true;
            
            //direita cima
            test.definePosition(posicao.line - 1, posicao.col + 2);
            if(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
            }
            //direita baixo
            test.definePosition(posicao.line + 1, posicao.col + 2);
            if(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
            }
            //baixo direita
            test.definePosition(posicao.line + 2, posicao.col + 1);
            if(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
            }
            //baixo esquerda
            test.definePosition(posicao.line + 2, posicao.col - 1);
            if(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
            }
            //esquerda baixo
            test.definePosition(posicao.line + 1, posicao.col - 2);
            if(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
            }
            //esquerda cima
            test.definePosition(posicao.line - 1, posicao.col - 2);
            if(board.validPosition(test) && canMove(test))
            {
                mat[test.line, test.col] = true;
            }
            return mat;
        }

        public override string ToString()
        {
            return "H";
        }
    }

     class Pawn : Peca
    {
        private ChessGame game;
        public Pawn(Board board, Color color, ChessGame game) : base(board, color)
        {
            this.game = game;
        }

        private bool isFree(Position pos)
        {
            Peca p = board.peca(pos);
            return board.peca(pos) == null;
        }

        private bool isThereEnemy(Position pos)
        {
            Peca p = board.peca(pos);
            return p != null && p.color != this.color;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.line, board.col];
            Position test = new Position(0,0);

            if(this.color == Color.white){
                //acima
                test.definePosition(posicao.line - 1, posicao.col);
                if(board.validPosition(test) && isFree(test))
                    mat[test.line, test.col] = true;

                //NE
                test.definePosition(posicao.line - 1, posicao.col + 1);
                if(board.validPosition(test) && isThereEnemy(test))
                    mat[test.line, test.col] = true;

                //NO
                test.definePosition(posicao.line - 1, posicao.col - 1);
                if(board.validPosition(test) && isThereEnemy(test))
                    mat[test.line, test.col] = true;

                //Cima duplo
                test.definePosition(posicao.line - 2, posicao.col);
                if(board.validPosition(test) && isFree(test) && this.manyMoves == 0)
                    mat[test.line, test.col] = true;

                //EnPassant
                if(posicao.line == 3)
                {
                    Position left = new Position(posicao.line, posicao.col - 1);
                    Position right = new Position(posicao.line, posicao.col + 1);
                    if(board.validPosition(left) && isThereEnemy(left) && board.peca(left) == game.EnPassantPossible)
                        mat[left.line-1, left.col] = true;
                    else if(board.validPosition(right) && isThereEnemy(right) && board.peca(right) == game.EnPassantPossible)
                        mat[right.line-1, right.col] = true;
                }
            }
            else{
                //Se
                test.definePosition(posicao.line + 1, posicao.col + 1);
                if(board.validPosition(test) && isThereEnemy(test))
                    mat[test.line, test.col] = true;

                //s
                test.definePosition(posicao.line + 1, posicao.col);
                if(board.validPosition(test) && isFree(test))
                    mat[test.line, test.col] = true;
                //so
                test.definePosition(posicao.line + 1, posicao.col - 1);
                if(board.validPosition(test) && isThereEnemy(test))
                    mat[test.line, test.col] = true;

                //Baixo duplo
                test.definePosition(posicao.line + 2, posicao.col);
                if(board.validPosition(test) && isFree(test) && this.manyMoves == 0)
                    mat[test.line, test.col] = true;

                //EnPassant
                if(posicao.line == 4)
                {
                    Position left = new Position(posicao.line, posicao.col - 1);
                    Position right = new Position(posicao.line, posicao.col + 1);
                    if(board.validPosition(left) && isThereEnemy(left) && board.peca(left) == game.EnPassantPossible)
                        mat[left.line+1, left.col] = true;
                    else if(board.validPosition(right) && isThereEnemy(right) && board.peca(right) == game.EnPassantPossible)
                        mat[right.line+1, right.col] = true;
                }
            }

            return mat;
        }
        
        public override string ToString()
        {
            return "P";
        }
    }
}