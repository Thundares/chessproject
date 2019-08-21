using board;
using System;

namespace Game
{
    class ChessGame
    {
        public Board board {get; private set;}
        private int turn;
        private Color playerTurn;

        public bool Finished { get; private set; }

        public ChessGame()
        {
            board = new Board(8,8);
            turn = 1;
            playerTurn = Color.white;
            Finished = false;
            Initialize();
        }

        public void move(Position origin, Position destiny)
        {
            Peca p = board.removePeca(origin);
            p.moreMoves();
            Peca captured = board.removePeca(destiny);
            board.putPeca(p, destiny);
        }

        public void Initialize()
        {

            board.putPeca(new King(board, Color.white), new ChessPosition('e',1).ToPosition());
            board.putPeca(new King(board, Color.black), new ChessPosition('e',8).ToPosition());

            board.putPeca(new Tower(board, Color.white), new ChessPosition('a',1).ToPosition());
            board.putPeca(new Tower(board, Color.white), new ChessPosition('h',1).ToPosition());
            board.putPeca(new Tower(board, Color.black), new ChessPosition('a',8).ToPosition());
            board.putPeca(new Tower(board, Color.black), new ChessPosition('h',8).ToPosition());

            board.putPeca(new Horse(board, Color.black), new ChessPosition('b', 8).ToPosition());
            board.putPeca(new Horse(board, Color.black), new ChessPosition('g', 8).ToPosition());
            board.putPeca(new Horse(board, Color.white), new ChessPosition('b', 1).ToPosition());
            board.putPeca(new Horse(board, Color.white), new ChessPosition('g', 1).ToPosition());

            board.putPeca(new Bishop(board, Color.black), new ChessPosition('c', 8).ToPosition());
            board.putPeca(new Bishop(board, Color.black), new ChessPosition('f', 8).ToPosition());
            board.putPeca(new Bishop(board, Color.white), new ChessPosition('c', 1).ToPosition());
            board.putPeca(new Bishop(board, Color.white), new ChessPosition('f', 1).ToPosition());

            board.putPeca(new Quenn(board, Color.black), new ChessPosition('d', 8).ToPosition());
            board.putPeca(new Quenn(board, Color.white), new ChessPosition('d', 1).ToPosition());
        }
    }
}