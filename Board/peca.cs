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

        public abstract bool[,] possibleMoves();
        public void moreMoves()
        {
            manyMoves++;
        }
        
    }
}