namespace TicTacToeKata.Board
{
    public interface IBoard
    {
        FieldValue GetValueFor(Field field);
        bool HasAnyEmptyFields();
        void Play(Field field);
        bool HasWinningLine();
    }
}