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
                yield return new TestCaseData(new List<Field> { Field.Field1, Field.Field4, Field.Field7 });
                yield return new TestCaseData(new List<Field> { Field.Field2, Field.Field5, Field.Field8 });
                yield return new TestCaseData(new List<Field> { Field.Field3, Field.Field6, Field.Field9 });
            }
        }

        public static IEnumerable<TestCaseData> RowLinesTestCases
        {
            get
            {
                yield return new TestCaseData(new List<Field> { Field.Field1, Field.Field2, Field.Field3 });
                yield return new TestCaseData(new List<Field> { Field.Field4, Field.Field5, Field.Field6 });
                yield return new TestCaseData(new List<Field> { Field.Field7, Field.Field8, Field.Field9 });
            }
        }

        public static IEnumerable<TestCaseData> DiagonalLinesTestCases
        {
            get
            {
                yield return new TestCaseData(new List<Field> { Field.Field1, Field.Field5, Field.Field9 });
                yield return new TestCaseData(new List<Field> { Field.Field3, Field.Field5, Field.Field7 });
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
            _board.SetPlayerField(Player.X, Field.Field1);

            Assert.That(_board.GetValueFor(Field.Field1), Is.EqualTo(FieldValue.X));
        }

        [Test]
        public void set_field_for_player_O()
        {
            _board.SetPlayerField(Player.O, Field.Field9);

            Assert.That(_board.GetValueFor(Field.Field9), Is.EqualTo(FieldValue.O));
        }

        [Test]
        public void throw_error_when_a_player_tries_to_set_a_field_already_taken()
        {
            _board.SetPlayerField(Player.X, Field.Field9);

            Assert.Throws<FieldAlreadyTakenException>(
                () => _board.SetPlayerField(Player.O, Field.Field9));
        }

        [Test]
        public void indicate_when_any_field_is_still_empty()
        {
            var anyEmptyFields = _board.HasAnyEmptyFields();

            Assert.That(anyEmptyFields, Is.True);
        }

        [Test]
        public void indicate_when_all_fields_are_taken()
        {
            foreach (var field in BoardFields.Fields())
            {
                _board.SetPlayerField(Player.X, field);
            }

            var anyEmptyFields = _board.HasAnyEmptyFields();

            Assert.That(anyEmptyFields, Is.False);
        }      

        [TestCaseSource(nameof(ColumnLineTestCases))]
        public void indicate_when_a_column_has_been_taken_by_a_player(List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.SetPlayerField(Player.X, field);
            }
            
            Assert.That(_board.HasWinningColumn(), Is.True);
        }

        [TestCaseSource(nameof(RowLinesTestCases))]
        public void indicate_when_a_row_has_been_taken_by_a_player(List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.SetPlayerField(Player.X, field);
            }

            Assert.That(_board.HasWinningRow(), Is.True);
        }

        [TestCaseSource(nameof(DiagonalLinesTestCases))]
        public void indicate_when_a_diagonal_has_been_taken_by_a_player(List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.SetPlayerField(Player.X, field);
            }
            
            Assert.That(_board.HasWinningDiagonal(), Is.True);
        }
    }
}
