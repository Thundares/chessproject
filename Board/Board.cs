

namespace board
{
    class Board
    {
        public int line { get; set; }
        public int col { get; set; }
        private Peca[,] pecas;

        public Board(int line, int col)
        {
            this.line = line;
            this.col = col;
            pecas = new Peca[line, col];
        }

        public Peca peca(int line, int col)
        {
            return pecas[line, col];
        }

        public void putPeca(Peca peca, Position position)
        {
            pecas[position.line, position.col] = peca;
        }
    }
}