using System.Collections.Generic;
using NUnit.Framework;

namespace TicTacToeKata.Test
{
    [TestFixture]
    public class ColumnShould
    {
        public static IEnumerable<TestCaseData> ColumnFieldsTestCases
        {
            get
            {
                yield return new TestCaseData(1, new List<Field> { Field.Field1, Field.Field4, Field.Field7 });
                yield return new TestCaseData(2, new List<Field> { Field.Field2, Field.Field5, Field.Field8 });
                yield return new TestCaseData(3, new List<Field> { Field.Field3, Field.Field6, Field.Field9 });
            }
        }

        [TestCaseSource(nameof(ColumnFieldsTestCases))]
        public void get_fields_in_column(int id, List<Field> expected)
        {
            Column column = new Column(id);
            List<Field> fields = column.GetFieldsIn();

            Assert.That(fields.Contains(expected[0]), Is.True);
            Assert.That(fields.Contains(expected[1]), Is.True);
            Assert.That(fields.Contains(expected[2]), Is.True);
        }
    }
}
