using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class Column : BoardLine
    {
        public static Column Column1 = new Column(1);
        public static Column Column2 = new Column(2);
        public static Column Column3 = new Column(3);

        public Column(int id) : base(id)
        {
        }

        public override List<Field> GetFieldsIn()
        {
            return BoardFields.Fields().Where(f => f.Column() == Id()).Select(f => f).ToList();
        }
    }
}