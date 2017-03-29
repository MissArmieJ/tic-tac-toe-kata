using System.Collections.Generic;
using NUnit.Framework;

namespace TicTacToeKata.Test
{
    [TestFixture]
    public class BoardLayoutShould
    {
//        private BoardLayout _layout;

        [SetUp]
        public void Setup()
        {
//            _layout = new BoardLayout();
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
