namespace TicTacToeKata
{
    public interface IBoard
    {
        BoardLayout Layout();
        FieldValue GetValueFor(Field field);
        void SetPlayerField(Player player, Field field);
        bool AnyEmptyFields();

        int WinningColumn();
        int WinningRow();
        int WinningDiagonal();
    }
}