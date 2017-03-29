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

        [Test]
        public void be_over_when_all_fields_in_a_column_are_taken_by_a_player()
        {
            _board.WinningColumn().Returns(1);

            var isOver = _game.IsOver();

            _board.Received().WinningColumn();
            Assert.That(isOver, Is.EqualTo(true));
        }

        [Test]
        public void be_over_when_all_fields_in_a_row_are_taken_by_a_player()
        {
            _board.WinningRow().Returns(2);

            var isOver = _game.IsOver();

            _board.Received().WinningRow();
            Assert.That(isOver, Is.EqualTo(true));
        }

        [Test]
        public void be_over_when_all_fields_in_a_diagonal_are_taken_by_a_player()
        {
            _board.WinningDiagonal().Returns(1);

            var isOver = _game.IsOver();

            _board.Received().WinningDiagonal();
            Assert.That(isOver, Is.EqualTo(true));
        }

        [Test]
        public void play_until_the_game_is_over()
        {
            _game.Play();

            Assert.That(_game.IsOver(), Is.EqualTo(true));

        }
        //players take turns taking fields until the game is over
        //        [Test]
        //        public void switch_players_during_play_until_the_game_is_over()
        //        {
        //            //perhaps check sequence of methods called on players?
        //        }
    }
}
