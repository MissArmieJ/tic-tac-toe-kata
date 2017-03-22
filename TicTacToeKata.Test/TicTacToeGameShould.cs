using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace TicTacToeKata.Test
{
    [TestFixture]
    public class TicTacToeGameShould
    {
        private IBoard _board;
        private TicTacToeGame _game;

        [SetUp]
        public void Setup()
        {
            _board = Substitute.For<IBoard>();
            _game = new TicTacToeGame(_board);
        }

        //a game is over when all fields are taken
        [Test]
        public void be_over_when_all_fields_on_board_are_taken()
        {
            _board.AnyEmptyFields().Returns(false);

            bool isOver = _game.IsOver();

            _board.Received().AnyEmptyFields();
            Assert.That(isOver, Is.EqualTo(true));
        }

        [Test]
        public void not_be_over_when_any_fields_on_board_are_still_open()
        {
            _board.AnyEmptyFields().Returns(true);

            var isOver = _game.IsOver();

            _board.Received().AnyEmptyFields();
            Assert.That(isOver, Is.EqualTo(false));
        }

        //there are two player in the game (X and O)
        [Test]
        public void have_player_X()
        {
            List<Player> players = _game.Players();

            Assert.That(players.Contains(Player.X), Is.True);
        }

        [Test]
        public void have_player_O()
        {
            List<Player> players = _game.Players();

            Assert.That(players.Contains(Player.O), Is.True);
        }

        //a game is over when all fields in a column are taken by a player
        [Test]
        public void be_over_when_all_fields_in_a_column_are_taken_by_a_player()
        {
            _board.WinningColumn().Returns(1);

            var isOver = _game.IsOver();

            _board.Received().WinningColumn();
            Assert.That(isOver, Is.EqualTo(true));
        }
        //a game is over when all fields in a row are taken by a player
        [Test]
        public void be_over_when_all_fields_in_a_row_are_taken_by_a_player()
        {
            _board.WinningRow().Returns(2);

            var isOver = _game.IsOver();

            _board.Received().WinningRow();
            Assert.That(isOver, Is.EqualTo(true));
        }

        //a game is over when all fields in a diagonal are taken by a player
        [Test]
        public void be_over_when_all_fields_in_a_diagonal_are_taken_by_a_player()
        {
            _board.WinningDiagonal().Returns(1);

            var isOver = _game.IsOver();

            _board.Received().WinningDiagonal();
            Assert.That(isOver, Is.EqualTo(true));
        }

    }
}
