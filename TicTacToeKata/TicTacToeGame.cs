using System.Collections.Generic;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        private readonly IBoard _board;
        private readonly IConsole _console;

        public TicTacToeGame(IConsole console, IBoard board)
        {
            this._console = console;
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
            while (!IsOver())
            {
                var field = _console.GetField();
                _board.Play(field);
            }
        }
    }
}