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
                yield return new TestCaseData(1, new List<Field> { Field.TopLeft, Field.MidLeft, Field.BottomLeft });
                yield return new TestCaseData(2, new List<Field> { Field.TopCentre, Field.MidCentre, Field.BottomCentre });
                yield return new TestCaseData(3, new List<Field> { Field.TopRight, Field.MidRight, Field.BottomRight });
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
