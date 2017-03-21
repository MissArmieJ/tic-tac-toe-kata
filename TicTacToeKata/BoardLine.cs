using System.Collections.Generic;

namespace TicTacToeKata
{
    public abstract class BoardLine
    {
        private readonly int _id;

        protected BoardLine(int id)
        {
            _id = id;
        }

        public int Id()
        {
            return _id;
        }

        public abstract List<Field> GetFieldsIn();
        
    }
}