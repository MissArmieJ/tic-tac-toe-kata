using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class Row : BoardLine
    {
        public static Row Row1 = new Row(1);
        public static Row Row2 = new Row(2);
        public static Row Row3 = new Row(3);

        public Row(int id) : base(id)
        {
        }

        public override List<Field> GetFieldsIn()
        {
            return BoardFields.Fields().Where(f => f.Row() == Id()).Select(f => f).ToList();
        }
    }
}