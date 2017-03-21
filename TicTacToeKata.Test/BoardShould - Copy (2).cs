using System.Collections.Generic;
using NUnit.Framework;

namespace TicTacToeKata.Test
{
    [TestFixture]
    public class BoardShould
    {
        private IBoard _board;

        [SetUp]
        public void Setup()
        {
            _board = new Board();
        }

        [Test]
        public void initialise_all_fields_with_empty_values()
        {
            foreach (var field in _board.Layout().Fields())
            {
                Assert.That(_board.GetValueFor(field), Is.EqualTo(FieldValue.Empty));
            }
        }

        [Test]
        public void set_field_for_player_X()
        {
            _board.SetFieldFor(Player.X, Field.Field1);

            Assert.That(_board.GetValueFor(Field.Field1), Is.EqualTo(FieldValue.X));
        }

        [Test]
        public void set_field_for_player_O()
        {
            _board.SetFieldFor(Player.O, Field.Field9);

            Assert.That(_board.GetValueFor(Field.Field9), Is.EqualTo(FieldValue.O));
        }

        [Test]
        public void indicate_when_any_field_is_still_empty()
        {
            var anyEmptyFields = _board.AnyEmptyFields();

            Assert.That(anyEmptyFields, Is.True);
        }

        [Test]
        public void indicate_when_all_fields_are_taken()
        {
            foreach (var field in _board.Layout().Fields())
            {
                _board.SetFieldFor(Player.X, field);
            }

            var anyEmptyFields = _board.AnyEmptyFields();

            Assert.That(anyEmptyFields, Is.False);
        }      

        [Test]
        public void indicate_when_no_column_has_been_taken_by_a_player()
        {
            var winningColumn = _board.WinningColumn();

            Assert.That(winningColumn, Is.EqualTo(0));
        }

        [TestCaseSource(nameof(BoardLayoutShould.ColumnFieldsTestCases))]
        public void indicate_when_a_column_has_been_taken_by_a_player(int columnId, List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.SetFieldFor(Player.X, field);
            }
            
            var winningColumn = _board.WinningColumn();

            Assert.That(winningColumn, Is.EqualTo(columnId));
        }

        [TestCaseSource(nameof(BoardLayoutShould.RowFieldsTestCases))]
        public void indicate_when_a_row_has_been_taken_by_a_player(int rowId, List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.SetFieldFor(Player.X, field);
            }

            var winningRow = _board.WinningRow();

            Assert.That(winningRow, Is.EqualTo(rowId));
        }

        [TestCaseSource(nameof(BoardLayoutShould.DiagonalFieldsTestCases))]
        public void indicate_when_a_diagonal_has_been_taken_by_a_player(int diagonalId, List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.SetFieldFor(Player.X, field);
            }

            var winningDiagonal = _board.WinningDiagonal();

            Assert.That(winningDiagonal, Is.EqualTo(diagonalId));
        }
    }
}
