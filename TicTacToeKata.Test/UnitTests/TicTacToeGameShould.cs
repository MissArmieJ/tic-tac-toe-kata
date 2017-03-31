using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TicTacToeKata.Board;
using TicTacToeKata.Game;

namespace TicTacToeKata.Test.UnitTests
{
    [TestFixture]
    public class TicTacToeGameShould
    {
        private IConsole _console;
        private IBoard _board;
        private TicTacToeGame _game;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();
            _board = Substitute.For<IBoard>();
            _game = new TicTacToeGame(_console, _board);
        }

        [Test]
        public void be_over_when_all_fields_on_board_are_taken()
        {
            _board.HasAnyEmptyFields().Returns(false);

            bool isOver = _game.IsOver();

            _board.Received().HasAnyEmptyFields();
            Assert.That(isOver, Is.EqualTo(true));
        }

        [Test]
        public void not_be_over_when_any_fields_on_board_are_still_open()
        {
            _board.HasAnyEmptyFields().Returns(true);

            var isOver = _game.IsOver();

            _board.Received().HasAnyEmptyFields();
            Assert.That(isOver, Is.EqualTo(false));
        }

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
        public void be_over_when_the_board_has_a_winning_line()
        {
            _board.HasWinningLine().Returns(true);

            var isOver = _game.IsOver();

            _board.Received().HasWinningLine();
            Assert.That(isOver, Is.EqualTo(true));
        }

        [Test]
        public void play_until_the_game_is_over()
        {
            _console.GetField()
                .Returns(
                    x => Field.TopLeft, 
                    o => Field.MidCentre, 
                    x => Field.MidLeft, 
                    o => Field.TopRight,
                    x => Field.BottomLeft);

            var game = new TicTacToeGame(_console, _board);

            game.Play();

            Assert.That(game.IsOver(), Is.EqualTo(true));

        }
    }
}
