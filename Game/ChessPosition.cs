using board;

namespace Game
{
    class ChessPosition
    {
        public char col { get; set; }
        public int line { get; set; }

        public ChessPosition(char col, int line)
        {
            this.col = col;
            this.line = line;
        }

        public Position ToPosition()
        {
            return new Position(8-this.line, col - 'a');
        } 

        public override string ToString()
        {
            return "" + col + line;
        }
    }
}