using board;
using System.Collections.Generic;

namespace Game
{
    class ChessGame
    {
        public Board board {get; private set;}
        public int turn {get; private set;}
        public Color playerTurn {get; private set;}
        public bool Finished { get; private set; }
        private HashSet<Peca> All;
        private HashSet<Peca> Capture;
        public ChessGame()
        {
            board = new Board(8,8);
            turn = 1;
            playerTurn = Color.white;
            Finished = false;

            All = new HashSet<Peca>();
            Capture = new HashSet<Peca>();

            Initialize();
        }

        public HashSet<Peca> Captured(Color c)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capture)
            {
                if(x.color == c)
                    aux.Add(x);
            }
            return aux;
        }

        public HashSet<Peca> InGame(Color c)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in All)
            {
                if(x.color == c)
                    aux.Add(x);
            }
            aux.ExceptWith(Captured(c));
            return aux;
        }
        public void move(Position origin, Position destiny)
        {
            Peca p = board.removePeca(origin);
            p.moreMoves();
            Peca captured = board.removePeca(destiny);
            board.putPeca(p, destiny);
            if(captured != null)
                Capture.Add(captured);
        }

        public void validMove(Position pos)
        {
            if(board.peca(pos) == null)
                throw new BoardExceptions("There is no piece in this position");
            if(playerTurn != board.peca(pos).color)
                throw new BoardExceptions("This is not your piece");
            if(!board.peca(pos).isItPossibleToMove())
                throw new BoardExceptions("This piece cannot move");
        }
        public void turnmk(Position origin, Position destiny)
        {
            move(origin, destiny);
            turn++;
            if(playerTurn == Color.white)
                playerTurn = Color.black;
            else
                playerTurn = Color.white;
        }

        public void targetingValid(Position origin, Position destiny)
        {
            if(!board.peca(origin).destinyCalculation(destiny))
                throw new BoardExceptions("Impossible movement!");
        }

        public void putNew(char c, int l, Peca peca)
        {
            board.putPeca(peca, new ChessPosition(c, l).ToPosition());
            All.Add(peca);
        }
        public void Initialize()
        {

            putNew('e',1, new King(board, Color.white));
            putNew('e',8, new King(board, Color.black));

            putNew('a',1, new Tower(board, Color.white));
            putNew('h',1, new Tower(board, Color.white));
            putNew('h',8, new Tower(board, Color.black));
            putNew('a',8, new Tower(board, Color.black));

            putNew('b',8, new Horse(board, Color.black));
            putNew('g',8, new Horse(board, Color.black));
            putNew('g',1, new Horse(board, Color.white));
            putNew('b',1, new Horse(board, Color.white));
            
            putNew('c',8, new Bishop(board, Color.black));
            putNew('f',8, new Bishop(board, Color.black));
            putNew('c',1, new Bishop(board, Color.white));
            putNew('f',1, new Bishop(board, Color.white));

            putNew('d',8, new Quenn(board, Color.black));
            putNew('d',1, new Quenn(board, Color.white));
            
        }
    }
}