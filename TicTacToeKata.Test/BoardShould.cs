using System.Collections.Generic;
using NUnit.Framework;

namespace TicTacToeKata.Test
{
    [TestFixture]
    public class BoardShould
    {
        private IBoard _board;

        public static IEnumerable<TestCaseData> ColumnLineTestCases
        {
            get
            {
                yield return new TestCaseData(1, new List<Field> { Field.Field1, Field.Field4, Field.Field7 });
                yield return new TestCaseData(2, new List<Field> { Field.Field2, Field.Field5, Field.Field8 });
                yield return new TestCaseData(3, new List<Field> { Field.Field3, Field.Field6, Field.Field9 });
            }
        }

        public static IEnumerable<TestCaseData> RowLinesTestCases
        {
            get
            {
                yield return new TestCaseData(1, new List<Field> { Field.Field1, Field.Field2, Field.Field3 });
                yield return new TestCaseData(2, new List<Field> { Field.Field4, Field.Field5, Field.Field6 });
                yield return new TestCaseData(3, new List<Field> { Field.Field7, Field.Field8, Field.Field9 });
            }
        }

        public static IEnumerable<TestCaseData> DiagonalLinesTestCases
        {
            get
            {
                yield return new TestCaseData(1, new List<Field> { Field.Field1, Field.Field5, Field.Field9 });
                yield return new TestCaseData(2, new List<Field> { Field.Field3, Field.Field5, Field.Field7 });
            }
        }

        [SetUp]
        public void Setup()
        {
            _board = new Board();
        }

        [Test]
        public void initialise_all_fields_with_empty_values()
        {
            foreach (var field in BoardFields.Fields())
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
            foreach (var field in BoardFields.Fields())
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

        [TestCaseSource(nameof(ColumnLineTestCases))]
        public void indicate_when_a_column_has_been_taken_by_a_player(int columnId, List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.SetFieldFor(Player.X, field);
            }

            var winningColumn = _board.WinningColumn();

            Assert.That(winningColumn, Is.EqualTo(columnId));
        }

        [TestCaseSource(nameof(RowLinesTestCases))]
        public void indicate_when_a_row_has_been_taken_by_a_player(int rowId, List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.SetFieldFor(Player.X, field);
            }

            Assert.That(_board.WinningRow(), Is.EqualTo(rowId));
        }

        [TestCaseSource(nameof(DiagonalLinesTestCases))]
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
