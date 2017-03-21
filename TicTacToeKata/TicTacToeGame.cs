using System.Collections.Generic;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        private readonly IBoard _board;

        public TicTacToeGame(IBoard board)
        {
            this._board = board;
        }

        public GameResult Play()
        {
            return new GameResult(_board);
        }

        public List<Player> Players()
        {
            return new List<Player>()
            {
                Player.X,
                Player.O
            };
        }
    }
}