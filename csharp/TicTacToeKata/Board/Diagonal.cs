using System.Collections.Generic;

namespace TicTacToeKata.Board
{
    public class Diagonal : BoardLine
    {
        public static Diagonal Diagonal1 = new Diagonal(1);
        public static Diagonal Diagonal2 = new Diagonal(2);

        public Diagonal(int id) : base(id)
        {
        }

        public override List<Field> GetFieldsIn()
        {
            if (Id() == 1)
            {
                return new List<Field>
                {
                    Field.TopLeft,
                    Field.MidCentre,
                    Field.BottomRight
                };
            }
            return new List<Field>
                {
                    Field.TopRight,
                    Field.MidCentre,
                    Field.BottomLeft
                };
        }
    }
}