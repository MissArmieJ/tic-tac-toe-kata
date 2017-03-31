using TicTacToeKata.Board;

namespace TicTacToeKata.Game
{
    public class Player
    {
        private readonly FieldValue _tokenValue;

        public static Player X = new Player(FieldValue.X);
        public static Player O = new Player(FieldValue.O);

        private Player(FieldValue tokenValue)
        {
            this._tokenValue = tokenValue;
        }

        public FieldValue TokenValue()
        {
            return _tokenValue;
        }
    }
}