namespace TicTacToeKata.Board
{
    public class Field
    {
        private readonly int _row;
        private readonly int _col;

        public static Field TopLeft = new Field(1, 1);
        public static Field TopCentre = new Field(1, 2);
        public static Field TopRight = new Field(1, 3);
        public static Field MidLeft = new Field(2, 1);
        public static Field MidCentre = new Field(2, 2);
        public static Field MidRight = new Field(2, 3);
        public static Field BottomLeft = new Field(3, 1);
        public static Field BottomCentre = new Field(3, 2);
        public static Field BottomRight = new Field(3, 3);

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