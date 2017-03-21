namespace TicTacToeKata
{
    public class Field
    {
        private readonly int _row;
        private readonly int _col;

        public static Field Field1 = new Field(1, 1);
        public static Field Field2 = new Field(1, 2);
        public static Field Field3 = new Field(1, 3);
        public static Field Field4 = new Field(2, 1);
        public static Field Field5 = new Field(2, 2);
        public static Field Field6 = new Field(2, 3);
        public static Field Field7 = new Field(3, 1);
        public static Field Field8 = new Field(3, 2);
        public static Field Field9 = new Field(3, 3);

        private Field(int row, int col)
        {
            _row = row;
            _col = col;
        }

        public int Column()
        {
            return _col;
        }

        public int Row()
        {
            return _row;
        }
    }
}