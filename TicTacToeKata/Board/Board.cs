using System.Collections.Generic;
using System.Linq;
using TicTacToeKata.Exception;
using TicTacToeKata.Game;

namespace TicTacToeKata.Board
{
    public class Board : IBoard
    {
        private Dictionary<Field, FieldValue> _fieldValues;
        private Player _nextPlayer;

        public Board()
        {
            SetFirstPlayer();
            ClearBoard();
        }

        private void SetFirstPlayer()
        {
            _nextPlayer = Player.X;
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

        private bool IsTaken(Field field)
        {
            return _fieldValues[field] != FieldValue.Empty;
        }

        public bool HasAnyEmptyFields()
        {
            return _fieldValues.Any(f => f.Value == FieldValue.Empty);
        }

        public void Play(Field field)
        {
            if (IsTaken(field))
            {
                throw new FieldAlreadyTakenException("Field has already been taken.");
            }
            SetPlayersTokenOn(field);
            SwitchPlayers();
        }

        private void SetPlayersTokenOn(Field field)
        {
            _fieldValues[field] = _nextPlayer.TokenValue();
        }

        private void SwitchPlayers()
        {
            _nextPlayer = _nextPlayer == Player.X ? Player.O : Player.X;
        }

        public bool HasWinningLine()
        {
            return HasWinningColumn()
                || HasWinningRow()
                || HasWinningDiagonal();
        }

        private bool HasWinningColumn()
        {
            return BoardLayout.Columns()
                .Select(column => column.GetFieldsIn())
                .Any(IsWinningLine);
        }

        private bool HasWinningRow()
        {
            return BoardLayout.Rows()
                .Select(row => row.GetFieldsIn())
                .Any(IsWinningLine);
        }

        private bool HasWinningDiagonal()
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