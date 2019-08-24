using board;
using System.Collections.Generic;
using System;

namespace Game
{
    class ChessGame
    {
        public Board board {get; private set;}
        public int turn {get; private set;}
        public Color playerTurn {get; private set;}
        public bool Finished { get; private set; }
        public bool check {get; private set;}
        private HashSet<Peca> All;
        private HashSet<Peca> Capture;

        private Color Enemy(Color c)
        {
            if(c == Color.white)
                return Color.black;
            else
                return Color.white;
        }
        private Peca King(Color c)
        {
            foreach (Peca x in InGame(c))
            {
                if(x is King)
                    return x;
            }
            return null;
        }
        public bool Check(Color c)
        {
            Peca K = King(c);
            if(K == null)
                throw new BoardExceptions("there is no king");

            foreach (Peca x in InGame(Enemy(c)))
            {
                bool[,] mat = x.possibleMoves();
                if(mat[K.posicao.line, K.posicao.col])
                    return true; 
            }
            return false;
        }

        public bool CheckMate(Color c)
        {
            if(!Check(c))
            {
                return false;
            }
            foreach (Peca x in InGame(c))
            {
                bool[,] mat = x.possibleMoves();
                for (int i = 0; i < board.line; i++)
                {
                    for (int j = 0; j < board.col; j++)
                    {
                        if(mat[i,j])
                        {
                            Position destiny = new Position(i,j);
                            Position origin = x.posicao;
                            Peca destroyed = move(x.posicao, destiny);
                            bool test = Check(c);
                            unMove(origin, destiny, destroyed);
                            if(!test)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public ChessGame()
        {
            board = new Board(8,8);
            turn = 1;
            playerTurn = Color.white;
            Finished = false;
            check = false;
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
        public Peca move(Position origin, Position destiny)
        {
            Peca p = board.removePeca(origin);
            p.moreMoves();
            Peca captured = board.removePeca(destiny);
            board.putPeca(p, destiny);
            if(captured != null)
                Capture.Add(captured);

            //roque direita
            if(p is King && destiny.col == origin.col + 2)
            {
                Position tower = new Position(origin.line, origin.col + 3);
                Position newtower = new Position(origin.line, origin.col + 1);
                move(tower, newtower);
                
            }

            //roque esquerda
            if(p is King && destiny.col == origin.col - 2)
            {
                Position tower = new Position(origin.line, 0);
                Position newtower = new Position(origin.line, 3);
                move(tower, newtower);
                
            }
            return captured;
        }

        public void unMove(Position origin, Position destiny, Peca x)
        {
            Peca p = board.removePeca(destiny);
            p.lessMoves();
            if(x != null)
            {
                board.putPeca(x, destiny);
                Capture.Remove(x);
            }
            board.putPeca(p, origin);
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
            Peca captured = move(origin, destiny);

            if(Check(playerTurn))
            {
                unMove(origin, destiny, captured);
                throw new BoardExceptions("You cannot move this piece");
            }
            if(Check(Enemy(playerTurn)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if(CheckMate(Enemy(playerTurn)))
            {
                Finished = true;
                Console.WriteLine("CheckMate! Winner is " + playerTurn);
            }

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

            putNew('e',1, new King(board, Color.white, this));
            putNew('e',8, new King(board, Color.black, this));

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

            putNew('a', 7, new Pawn(board, Color.black));
            putNew('b', 7, new Pawn(board, Color.black));
            putNew('c', 7, new Pawn(board, Color.black));
            putNew('d', 7, new Pawn(board, Color.black));
            putNew('e', 7, new Pawn(board, Color.black));
            putNew('f', 7, new Pawn(board, Color.black));
            putNew('g', 7, new Pawn(board, Color.black));
            putNew('h', 7, new Pawn(board, Color.black));

            putNew('a', 2, new Pawn(board, Color.white));
            putNew('b', 2, new Pawn(board, Color.white));
            putNew('c', 2, new Pawn(board, Color.white));
            putNew('d', 2, new Pawn(board, Color.white));
            putNew('e', 2, new Pawn(board, Color.white));
            putNew('f', 2, new Pawn(board, Color.white));
            putNew('g', 2, new Pawn(board, Color.white));
            putNew('h', 2, new Pawn(board, Color.white));
        
        }
    }
}