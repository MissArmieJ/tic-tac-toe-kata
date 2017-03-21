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
        public void have_3_columns()
        {
            List<Column> columns = _board.Columns();

            Assert.That(columns.Count, Is.EqualTo(3));
        }

        [Test]
        public void have_3_columns_with_values()
        {
            var column1 = _board.ColumnValues(1);
            var column2 = _board.ColumnValues(2);
            var column3 = _board.ColumnValues(3);

            Assert.That(column1, !Is.Null);
            Assert.That(column2, !Is.Null);
            Assert.That(column3, !Is.Null);
        }

        [Test]
        public void have_3_rows_with_values()
        {
            var row1 = _board.RowValues(1);
            var row2 = _board.RowValues(2);
            var row3 = _board.RowValues(3);

            Assert.That(row1, !Is.Null);
            Assert.That(row2, !Is.Null);
            Assert.That(row3, !Is.Null);
        }

        [Test]
        public void have_9_fields()
        {
            List<Field> fields = _board.Fields();

            Assert.That(fields.Contains(Field.Field1), Is.True);
            Assert.That(fields.Contains(Field.Field2), Is.True);
            Assert.That(fields.Contains(Field.Field3), Is.True);
            Assert.That(fields.Contains(Field.Field4), Is.True);
            Assert.That(fields.Contains(Field.Field5), Is.True);
            Assert.That(fields.Contains(Field.Field6), Is.True);
            Assert.That(fields.Contains(Field.Field7), Is.True);
            Assert.That(fields.Contains(Field.Field8), Is.True);
            Assert.That(fields.Contains(Field.Field9), Is.True);
        }

        [Test]
        public void have_all_fields_be_initialised_with_empty_values()
        {
            Assert.That(_board.GetValueFor(Field.Field1), Is.EqualTo(FieldValue.Empty));
            Assert.That(_board.GetValueFor(Field.Field2), Is.EqualTo(FieldValue.Empty));
            Assert.That(_board.GetValueFor(Field.Field3), Is.EqualTo(FieldValue.Empty));
            Assert.That(_board.GetValueFor(Field.Field4), Is.EqualTo(FieldValue.Empty));
            Assert.That(_board.GetValueFor(Field.Field5), Is.EqualTo(FieldValue.Empty));
            Assert.That(_board.GetValueFor(Field.Field6), Is.EqualTo(FieldValue.Empty));
            Assert.That(_board.GetValueFor(Field.Field7), Is.EqualTo(FieldValue.Empty));
            Assert.That(_board.GetValueFor(Field.Field8), Is.EqualTo(FieldValue.Empty));
            Assert.That(_board.GetValueFor(Field.Field9), Is.EqualTo(FieldValue.Empty));
        }

        [Test]
        public void set_field_for_player_X()
        {
            var player = Player.X;
            var field = Field.Field1;

            _board.PlayField(player, field);

            Assert.That(_board.GetValueFor(field), Is.EqualTo(FieldValue.X));
        }

        [Test]
        public void set_field_for_player_O()
        {
            var player = Player.O;
            var field = Field.Field2;

            _board.PlayField(player, field);

            Assert.That(_board.GetValueFor(field), Is.EqualTo(FieldValue.O));
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
            var player = Player.O;
            foreach (var field in _board.Fields())
            {
                _board.PlayField(player,field);
            }

            var anyEmptyFields = _board.AnyEmptyFields();

            Assert.That(anyEmptyFields, Is.False);
        }

        public static IEnumerable<TestCaseData> ColumnValuesTestCases
        {
            get
            {
                yield return new TestCaseData(1, new List<Field> {Field.Field1,Field.Field4,Field.Field7});
                yield return new TestCaseData(2, new List<Field> {Field.Field2,Field.Field5,Field.Field8});
                yield return new TestCaseData(3, new List<Field> {Field.Field3,Field.Field6,Field.Field9});
            }
        }

        [TestCaseSource(nameof(ColumnValuesTestCases))]
        public void get_values_for_column(int columnIndex, List<Field> columnFields )
        {
            _board.PlayField(Player.X, columnFields[0]);
            _board.PlayField(Player.O, columnFields[1]);
            _board.PlayField(Player.X, columnFields[2]);
            
            var column = _board.ColumnValues(columnIndex);

            Assert.That(column[0], Is.EqualTo(FieldValue.X));
            Assert.That(column[1], Is.EqualTo(FieldValue.O));
            Assert.That(column[2], Is.EqualTo(FieldValue.X));
        }

        public static IEnumerable<TestCaseData> RowValuesTestCases
        {
            get
            {
                yield return new TestCaseData(1, new List<Field> { Field.Field1, Field.Field2, Field.Field3 });
                yield return new TestCaseData(2, new List<Field> { Field.Field4, Field.Field5, Field.Field6 });
                yield return new TestCaseData(3, new List<Field> { Field.Field7, Field.Field8, Field.Field9 });
            }
        }

        [TestCaseSource(nameof(RowValuesTestCases))]
        public void get_values_for_row(int rowIndex, List<Field> rowFields)
        {
            _board.PlayField(Player.X, rowFields[0]);
            _board.PlayField(Player.O, rowFields[1]);
            _board.PlayField(Player.X, rowFields[2]);

            var row = _board.RowValues(rowIndex);

            Assert.That(row[0], Is.EqualTo(FieldValue.X));
            Assert.That(row[1], Is.EqualTo(FieldValue.O));
            Assert.That(row[2], Is.EqualTo(FieldValue.X));
        }

//        [TestCaseSource(nameof(ColumnValuesTestCases))]
//        public void indicate_when_all_fields_in_column_is_taken_by_a_player(int columnIndex, List<Field> columnFields)
//        {
//            foreach (var columnField in columnFields)
//            {
//                _board.PlayField(Player.X, columnField);
//            }
//
//            var winningColumn = _board.WinningColumn();
//
//            Assert.That(winningColumn, Is.EqualTo(columnIndex));
//        }
    }
}
