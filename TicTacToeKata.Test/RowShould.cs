using System.Collections.Generic;
using NUnit.Framework;

namespace TicTacToeKata.Test
{
    [TestFixture]
    public class RowShould
    {
        public static IEnumerable<TestCaseData> RowFieldsTestCases
        {
            get
            {
                yield return new TestCaseData(1, new List<Field> { Field.TopLeft, Field.TopCentre, Field.TopRight });
                yield return new TestCaseData(2, new List<Field> { Field.MidLeft, Field.MidCentre, Field.MidRight });
                yield return new TestCaseData(3, new List<Field> { Field.BottomLeft, Field.BottomCentre, Field.BottomRight });
            }
        }

        [TestCaseSource(nameof(RowFieldsTestCases))]
        public void get_fields_in_row(int id, List<Field> expected)
        {
            Row row = new Row(id);

            List<Field> fields = row.GetFieldsIn();

            Assert.That(fields.Contains(expected[0]), Is.True);
            Assert.That(fields.Contains(expected[1]), Is.True);
            Assert.That(fields.Contains(expected[2]), Is.True);
        }

    }
}
