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
                yield return new TestCaseData(new List<Field> { Field.TopLeft, Field.MidLeft, Field.BottomLeft });
                yield return new TestCaseData(new List<Field> { Field.TopCentre, Field.MidCentre, Field.BottomCentre });
                yield return new TestCaseData(new List<Field> { Field.TopRight, Field.MidRight, Field.BottomRight });
            }
        }

        public static IEnumerable<TestCaseData> RowLinesTestCases
        {
            get
            {
                yield return new TestCaseData(new List<Field> { Field.TopLeft, Field.TopCentre, Field.TopRight });
                yield return new TestCaseData(new List<Field> { Field.MidLeft, Field.MidCentre, Field.MidRight });
                yield return new TestCaseData(new List<Field> { Field.BottomLeft, Field.BottomCentre, Field.BottomRight });
            }
        }

        public static IEnumerable<TestCaseData> DiagonalLinesTestCases
        {
            get
            {
                yield return new TestCaseData(new List<Field> { Field.TopLeft, Field.MidCentre, Field.BottomRight });
                yield return new TestCaseData(new List<Field> { Field.TopRight, Field.MidCentre, Field.BottomLeft });
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
            _board.SetPlayerField(Player.X, Field.TopLeft);

            Assert.That(_board.GetValueFor(Field.TopLeft), Is.EqualTo(FieldValue.X));
        }

        [Test]
        public void set_field_for_player_O()
        {
            _board.SetPlayerField(Player.O, Field.BottomRight);

            Assert.That(_board.GetValueFor(Field.BottomRight), Is.EqualTo(FieldValue.O));
        }

        [Test]
        public void throw_error_when_a_player_tries_to_set_a_field_already_taken()
        {
            _board.SetPlayerField(Player.X, Field.BottomRight);

            Assert.Throws<FieldAlreadyTakenException>(
                () => _board.SetPlayerField(Player.O, Field.BottomRight));
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
