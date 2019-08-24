

namespace board
{
    class Board
    {

        //prop
        public int line { get; set; }
        public int col { get; set; }
        private Peca[,] pecas;
        //end prop

        //constructor
        public Board(int line, int col)
        {
            this.line = line;
            this.col = col;
            pecas = new Peca[line, col];
        }
        //end constructor


        //all the rest
        public Peca peca(int line, int col)
        {
            return pecas[line, col];
        }

        public Peca peca(Position pos)
        {
            return pecas[pos.line, pos.col];
        }

        public bool isThereaPeca(Position pos)
        {
            positionValidates(pos);
            return peca(pos) != null;
        }
        public void putPeca(Peca peca, Position position)
        {
            if(isThereaPeca(position))
            {
                throw new BoardExceptions("There is already a peca in this place");
            }
            pecas[position.line, position.col] = peca;
            peca.posicao = position;
        }

        public Peca removePeca(Position pos)
        {
            if(peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.line, pos.col] = null;
            return aux;
        }

        public bool validPosition(Position pos)
        {
            if(pos.col < 0 || pos.line < 0 || pos.line >= line || pos.col >= col)
                return false;   
            return true;
        }

        public void positionValidates(Position pos)
        {
            if(!validPosition(pos))
                throw new BoardExceptions("Invalid position!");
        }
    }
}