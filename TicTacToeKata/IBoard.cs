namespace TicTacToeKata
{
    public interface IBoard
    {
        FieldValue GetValueFor(Field field);
        void SetPlayerField(Player player, Field field);
        bool HasAnyEmptyFields();
        bool HasWinningColumn();
        bool HasWinningRow();
        bool HasWinningDiagonal();
    }
}