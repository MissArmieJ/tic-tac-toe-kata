using System.Collections.Generic;
using NUnit.Framework;
using TicTacToeKata.Board;

namespace TicTacToeKata.Test.UnitTests
{
    [TestFixture]
    public class BoardFieldsShould
    {
        [Test]
        public void have_9_fields()
        {
            List<Field> fields = BoardFields.Fields();

            Assert.That(fields.Count, Is.EqualTo(9));
        }


    }
}
