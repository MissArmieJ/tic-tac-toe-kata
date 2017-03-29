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
            return _board.WinningColumn() > 0
                    || _board.WinningRow() > 0
                    || _board.WinningDiagonal() > 0
                    || !_board.AnyEmptyFields();
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
            _board.SetPlayerField(Player.O, Field.Field1);
            _board.SetPlayerField(Player.O, Field.Field2);
            _board.SetPlayerField(Player.O, Field.Field3);
        }
    }
}