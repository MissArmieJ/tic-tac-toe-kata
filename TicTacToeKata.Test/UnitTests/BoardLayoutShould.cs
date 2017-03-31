using System.Collections.Generic;
using NUnit.Framework;
using TicTacToeKata.Board;

namespace TicTacToeKata.Test.UnitTests
{
    [TestFixture]
    public class BoardLayoutShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void have_3_columns()
        {
            List<Column> columns = BoardLayout.Columns();

            Assert.That(columns.Count, Is.EqualTo(3));
        }

        [Test]
        public void have_3_rows()
        {
            List<Row> rows = BoardLayout.Rows();

            Assert.That(rows.Count, Is.EqualTo(3));
        }

        [Test]
        public void have_2_diagonals()
        {
            List<Diagonal> diagonals = BoardLayout.Diagonals();

            Assert.That(diagonals.Count, Is.EqualTo(2));
        }
    }
}
