using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeKata.Test;

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


        public FieldValue GetValueFor(Field field)
        {
            return _fieldValues[field];
        }

        public void SetFieldFor(Player player, Field field)
        {
            if (_fieldValues[field] != FieldValue.Empty)
            {
                throw new FieldAlreadyTakenException();
            }
            _fieldValues[field] = player.TokenValue();
        }

        public bool AnyEmptyFields()
        {
            return _fieldValues.Any(f => f.Value == FieldValue.Empty);
        }

        public int WinningColumn()
        {
            var winningColumn = 0;
            foreach (var column in Layout().Columns())
            {
                var fields = column.GetFieldsIn();
                if (IsWinningLine(fields))
                {
                    winningColumn = column.Id();
                }
            }
            return winningColumn;
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

        public int WinningRow()
        {
            var winningRow = 0;
            foreach (var row in Layout().Rows())
            {
                var fields = row.GetFieldsIn();
                if (IsWinningLine(fields))
                {
                    winningRow = row.Id();
                }
            }
            return winningRow;
        }

        public int WinningDiagonal()
        {
            var winningDiagonal = 0;
            foreach (var diagonal in Layout().Diagonals())
            {
                var fields = diagonal.GetFieldsIn();
                if (IsWinningLine(fields))
                {
                    winningDiagonal = diagonal.Id();
                }
            }
            return winningDiagonal;
        }

        public BoardLayout Layout()
        {
            return new BoardLayout();
        }
    }
}