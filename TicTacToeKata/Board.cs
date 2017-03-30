using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata
{
    public class Board : IBoard
    {
        private Dictionary<Field, FieldValue> _fieldValues;

        public Board()
        {
            ClearBoard();
        }

        private void ClearBoard()
        {
            _fieldValues = new Dictionary<Field, FieldValue>()
            {
                {Field.TopLeft, FieldValue.Empty},
                {Field.TopCentre, FieldValue.Empty},
                {Field.TopRight, FieldValue.Empty},
                {Field.MidLeft, FieldValue.Empty},
                {Field.MidCentre, FieldValue.Empty},
                {Field.MidRight, FieldValue.Empty},
                {Field.BottomLeft, FieldValue.Empty},
                {Field.BottomCentre, FieldValue.Empty},
                {Field.BottomRight, FieldValue.Empty},
            };
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
            return BoardLayout.Columns()
                .Select(column => column.GetFieldsIn())
                .Any(IsWinningLine);
        }

        public bool HasWinningRow()
        {
            return BoardLayout.Rows()
                .Select(row => row.GetFieldsIn())
                .Any(IsWinningLine);
        }

        public bool HasWinningDiagonal()
        {
            return BoardLayout.Diagonals()
                .Select(diagonal => diagonal.GetFieldsIn())
                .Any(IsWinningLine);
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