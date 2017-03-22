﻿using System.Collections.Generic;
using NUnit.Framework;

namespace TicTacToeKata.Test
{
    [TestFixture]
    public class DiagonalShould
    {
        public static IEnumerable<TestCaseData> DiagonalFieldsTestCases
        {
            get
            {
                yield return new TestCaseData(1, new List<Field> { Field.Field1, Field.Field5, Field.Field9 });
                yield return new TestCaseData(2, new List<Field> { Field.Field3, Field.Field5, Field.Field7 });
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