

namespace Board
{
    class Peca
    {
        public Position posicao { get; set; }
        public Color color { get; set; }
        public int manyMoves { get;  protected set; }
        public Board board { get; protected set; }

        public Peca(Position posicao, Board board, Color color)
        {
            this.posicao = posicao;
            this.board = board;
            this.color = color;
            this.manyMoves = 0;
        }
    }
}