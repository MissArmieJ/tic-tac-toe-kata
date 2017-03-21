using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace TicTacToeKata.Test
{
    [TestFixture]
    public class TicTacToeGameShould
    {
        private IBoard board;
        private TicTacToeGame game;

        [SetUp]
        public void Setup()
        {
            board = Substitute.For<IBoard>();
            game = new TicTacToeGame(board);
        }

        //a game is over when all fields are taken
//        [Test]
//        public void be_over_when_all_fields_on_board_are_taken()
//        {
//            board.AnyEmptyFields().Returns(false);
//
//            GameResult result = game.Play();
//
//            Assert.That(result.IsOver(), Is.EqualTo(true));
//        }
//
//        [Test]
//        public void not_be_over_when_any_fields_on_board_are_still_open()
//        {
//            board.AnyEmptyFields().Returns(true);
//
//            game = new TicTacToeGame(board);
//            GameResult result = game.Play();
//
//            Assert.That(result.IsOver(), Is.EqualTo(false));
//        }

        //there are two player in the game (X and O)
        [Test]
        public void have_player_X()
        {
            List<Player> players = game.Players();

            Assert.That(players.Contains(Player.X), Is.True);
        }

        [Test]
        public void have_player_O()
        {
            List<Player> players = game.Players();

            Assert.That(players.Contains(Player.O), Is.True);
        }

        //a game is over when all fields in a column are taken by a player

    }
}
