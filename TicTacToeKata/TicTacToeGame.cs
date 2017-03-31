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

        public bool IsOver()
        {
            return _board.HasWinningLine() || !_board.HasAnyEmptyFields();
        }

        public List<Player> Players()
        {
            return new List<Player>()
            {
                Player.X,
                Player.O
            };
        }

        public void Play()
        {
            
        }
    }
}