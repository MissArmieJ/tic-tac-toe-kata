namespace TicTacToeKata
{
    public class GameResult
    {
        private readonly IBoard _board;

        public GameResult(IBoard board)
        {
            this._board = board;
        }

//        public bool IsOver()
//        {
//            return !_board.AnyEmptyFields();
//        }
    }
}