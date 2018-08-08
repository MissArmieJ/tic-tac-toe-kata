using System.Collections.Generic;

namespace TicTacToeKata.Board
{
    public static class BoardFields
    {
        public static List<Field> Fields()
        {
            return new List<Field>()
            {
                Field.TopLeft,
                Field.TopCentre,
                Field.TopRight,
                Field.MidLeft,
                Field.MidCentre,
                Field.MidRight,
                Field.BottomLeft,
                Field.BottomCentre,
                Field.BottomRight
            };
        }

    }
}