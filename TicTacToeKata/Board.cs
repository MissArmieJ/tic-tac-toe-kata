using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class Board : IBoard
    {
        private readonly Dictionary<Field, FieldValue> _fieldValues;

        public Board()
        {
            _fieldValues = new Dictionary<Field, FieldValue>()
            {
                {Field.Field1, FieldValue.Empty},
                {Field.Field2, FieldValue.Empty},
                {Field.Field3, FieldValue.Empty},
                {Field.Field4, FieldValue.Empty},
                {Field.Field5, FieldValue.Empty},
                {Field.Field6, FieldValue.Empty},
                {Field.Field7, FieldValue.Empty},
                {Field.Field8, FieldValue.Empty},
                {Field.Field9, FieldValue.Empty},
            };
        }

        public BoardLayout Layout()
        {
            return new BoardLayout();
        }

        public FieldValue GetValueFor(Field field)
        {
            return _fieldValues[field];
        }

        public void SetPlayerField(Player player, Field field)
        {
            if (IsTaken(field))
            {
                throw new FieldAlreadyTakenException();
            }
            _fieldValues[field] = player.TokenValue();
        }

        private bool IsTaken(Field field)
        {
            return _fieldValues[field] != FieldValue.Empty;
        }

        public bool HasAnyEmptyFields()
        {
            return _fieldValues.Any(f => f.Value == FieldValue.Empty);
        }

        public bool HasWinningColumn()
        {
            //Q: Is this Feature Envy?
            return Layout().Columns().Select(column => column.GetFieldsIn()).Any(IsWinningLine);
        }

        public bool HasWinningRow()
        {
            //Q: Is this still Duplication?
            return Layout().Rows().Select(row => row.GetFieldsIn()).Any(IsWinningLine);
        }

        public bool HasWinningDiagonal()
        {
            return Layout().Diagonals().Select(diagonal => diagonal.GetFieldsIn()).Any(IsWinningLine);
        }

        private bool IsWinningLine(List<Field> fields)
        {
            var fieldValues = fields.Select(f => _fieldValues[f]);
            var grouped = fieldValues
                .GroupBy(v => v)
                .Select(g => g.First())
                .ToList();

            return grouped.Count == 1 && grouped.First() != FieldValue.Empty;
        }

    }
}