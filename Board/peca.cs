using Game;

namespace board
{
    abstract class Peca
    {
        public Position posicao { get; set; }
        public Color color { get; set; }
        public int manyMoves { get;  protected set; }
        public Board board { get; protected set; }

        public Peca(Board board, Color color)
        {
            this.posicao = null;
            this.board = board;
            this.color = color;
            this.manyMoves = 0;
        }

        public bool isItPossibleToMove()
        {
            bool [,] mat = possibleMoves();
            for(int i =0; i<board.line; i++)
            {
                for(int j = 0; j< board.col; j++)
                {
                    if(mat[i,j])
                        return true;
                }
            }
            return false;
        }
        public abstract bool[,] possibleMoves();
        public void moreMoves()
        {
            manyMoves++;
        }
        
        public void lessMoves()
        {
            manyMoves--;
        }
        public bool destinyCalculation(Position p)
        {
            return possibleMoves()[p.line, p.col];
        }
    }
}