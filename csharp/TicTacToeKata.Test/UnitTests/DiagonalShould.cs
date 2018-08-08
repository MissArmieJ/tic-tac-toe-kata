using System.Collections.Generic;
using NUnit.Framework;
using TicTacToeKata.Board;

namespace TicTacToeKata.Test.UnitTests
{
    [TestFixture]
    public class DiagonalShould
    {
        public static IEnumerable<TestCaseData> DiagonalFieldsTestCases
        {
            get
            {
                yield return new TestCaseData(1, new List<Field> { Field.TopLeft, Field.MidCentre, Field.BottomRight });
                yield return new TestCaseData(2, new List<Field> { Field.TopRight, Field.MidCentre, Field.BottomLeft });
            }
        }

        [TestCaseSource(nameof(DiagonalFieldsTestCases))]
        public void get_fields_in_diagonal(int id, List<Field> expected)
        {
            Diagonal diagonal = new Diagonal(id);
            List<Field> fields = diagonal.GetFieldsIn();

            Assert.That(fields.Contains(expected[0]), Is.True);
            Assert.That(fields.Contains(expected[1]), Is.True);
            Assert.That(fields.Contains(expected[2]), Is.True);
        }

    }
}
