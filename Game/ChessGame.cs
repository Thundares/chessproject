using board;
using System;

namespace Game
{
    class ChessGame
    {
        public Board board {get; private set;}
        private int turn;
        private Color playerTurn;

        public ChessGame()
        {
            board = new Board(8,8);
            turn = 1;
            playerTurn = Color.white;
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

        }
    }
}