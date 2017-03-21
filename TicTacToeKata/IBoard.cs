namespace TicTacToeKata
{
    public interface IBoard
    {
        BoardLayout Layout();
        FieldValue GetValueFor(Field field);
        void SetFieldFor(Player player, Field field);
        bool AnyEmptyFields();

        int WinningColumn();
        int WinningRow();
        int WinningDiagonal();
    }


}