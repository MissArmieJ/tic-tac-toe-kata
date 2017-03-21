using System.Collections.Generic;

namespace TicTacToeKata
{
    public static class BoardFields
    {
        public static List<Field> Fields()
        {
            return new List<Field>()
            {
                Field.Field1,
                Field.Field2,
                Field.Field3,
                Field.Field4,
                Field.Field5,
                Field.Field6,
                Field.Field7,
                Field.Field8,
                Field.Field9
            };
        }

    }
}