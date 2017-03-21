using System.Collections.Generic;

namespace TicTacToeKata
{
    public class BoardLayout
    {
        public List<Column> Columns()
        {
            return new List<Column>()
            {
                Column.Column1,
                Column.Column2,
                Column.Column3
            };
        }

        public List<Row> Rows()
        {
            return new List<Row>()
            {
                Row.Row1,
                Row.Row2,
                Row.Row3
            };
        }

        public List<Diagonal> Diagonals()
        {
            return new List<Diagonal>()
            {
                Diagonal.Diagonal1,
                Diagonal.Diagonal2
            };
        }
    }
}