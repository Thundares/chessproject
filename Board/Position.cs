

namespace Board
{
    class Position
    {
        public int line { get; set; }
        public int col { get; set; }

        public Position(int line, int col)
        {
            this.line = line;
            this.col = col;
        }
        public override string ToString()
        {
            return this.line.ToString() + " " + this.col.ToString();
        }
    }
}