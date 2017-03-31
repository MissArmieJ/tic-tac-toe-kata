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
                yield return new TestCaseData(new List<Field> { Field.TopLeft, Field.MidCentre, Field.MidLeft, Field.BottomRight, Field.BottomLeft });
                yield return new TestCaseData(new List<Field> { Field.TopCentre, Field.TopLeft, Field.MidCentre, Field.MidLeft, Field.BottomCentre });
                yield return new TestCaseData(new List<Field> { Field.TopRight, Field.TopLeft, Field.MidRight, Field.MidCentre, Field.BottomRight });
            }
        }

        public static IEnumerable<TestCaseData> RowLinesTestCases
        {
            get
            {
                yield return new TestCaseData(new List<Field> { Field.TopLeft, Field.MidLeft, Field.TopCentre, Field.MidCentre, Field.TopRight });
                yield return new TestCaseData(new List<Field> { Field.MidLeft, Field.TopCentre, Field.MidCentre, Field.TopRight, Field.MidRight });
                yield return new TestCaseData(new List<Field> { Field.BottomLeft, Field.TopRight, Field.BottomCentre, Field.TopLeft, Field.BottomRight });
            }
        }

        public static IEnumerable<TestCaseData> DiagonalLinesTestCases
        {
            get
            {
                yield return new TestCaseData(new List<Field> { Field.TopLeft, Field.TopRight, Field.MidCentre, Field.MidRight, Field.BottomRight });
                yield return new TestCaseData(new List<Field> { Field.TopRight, Field.TopCentre, Field.MidCentre, Field.TopLeft, Field.BottomLeft });
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
        public void play_field_for_first_player_X()
        {
            _board.Play(Field.TopLeft);

            Assert.That(_board.GetValueFor(Field.TopLeft), Is.EqualTo(FieldValue.X));
        }

        [Test]
        public void play_field_for_second_player_O()
        {
            _board.Play(Field.TopLeft);
            _board.Play(Field.MidCentre);

            Assert.That(_board.GetValueFor(Field.MidCentre), Is.EqualTo(FieldValue.O));
        }

        //        [Test]
        //        public void set_field_for_player_X()
        //        {
        //            _board.SetPlayerField(Player.X, Field.TopLeft);
        //
        //            Assert.That(_board.GetValueFor(Field.TopLeft), Is.EqualTo(FieldValue.X));
        //        }
        //
        //        [Test]
        //        public void set_field_for_player_O()
        //        {
        //            _board.SetPlayerField(Player.O, Field.BottomRight);
        //
        //            Assert.That(_board.GetValueFor(Field.BottomRight), Is.EqualTo(FieldValue.O));
        //        }

        [Test]
        public void throw_error_when_a_player_tries_to_set_a_field_already_taken()
        {
            _board.Play(Field.TopLeft);

            Assert.Throws<FieldAlreadyTakenException>(
                () => _board.Play(Field.TopLeft));
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
                _board.Play(field);
            }

            var anyEmptyFields = _board.HasAnyEmptyFields();

            Assert.That(anyEmptyFields, Is.False);
        }

        [TestCaseSource(nameof(ColumnLineTestCases))]
        public void indicate_when_a_column_has_been_taken_by_a_player(List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.Play(field);
            }

            Assert.That(_board.HasWinningLine(), Is.True);
        }

        [TestCaseSource(nameof(RowLinesTestCases))]
        public void indicate_when_a_row_has_been_taken_by_a_player(List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.Play(field);
            }

            Assert.That(_board.HasWinningLine(), Is.True);
        }

        [TestCaseSource(nameof(DiagonalLinesTestCases))]
        public void indicate_when_a_diagonal_has_been_taken_by_a_player(List<Field> fields)
        {
            foreach (var field in fields)
            {
                _board.Play(field);
            }

            Assert.That(_board.HasWinningLine(), Is.True);
        }
    }
}
