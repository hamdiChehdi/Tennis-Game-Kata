namespace TennisGame.Test
{
    using TennisGame.Interfaces;
    using Xunit;

    public class GameTest
    {
        [Fact]
        public void SimpleGameTest()
        {
            IPlayer player1 = new Player("Alex");
            IPlayer player2 = new Player("Dina");
            IGame game = new Game(player1, player2);

            // Player 1 wins 1 point
            game.PlayerWinPoint(player1);
            Assert.Equal("Player 1 : 15 Player 2 : 0", game.GameScore);

            // Player 1 wins 1 point
            game.PlayerWinPoint(player1);
            Assert.Equal("Player 1 : 30 Player 2 : 0", game.GameScore);

            // Player 2 wins 1 point
            game.PlayerWinPoint(player2);
            Assert.Equal("Player 1 : 30 Player 2 : 15", game.GameScore);

            // Player 1 wins 1 point
            game.PlayerWinPoint(player1);
            Assert.Equal("Player 1 : 40 Player 2 : 15", game.GameScore);

            // Player 2 wins 1 point
            game.PlayerWinPoint(player2);
            Assert.Equal("Player 1 : 40 Player 2 : 30", game.GameScore);

            // Player 1 wins 1 point
            game.PlayerWinPoint(player1);
            Assert.Equal("Alex wins!", game.GameScore);
            Assert.True(game.GameEnd);
        }

        [Fact]
        public void DeuceTest()
        {
            IPlayer player1 = new Player("Alex");
            IPlayer player2 = new Player("Dina");
            IGame game = new Game(player1, player2);

            // Player 1 wins 1 point
            game.PlayerWinPoint(player1);
            Assert.Equal("Player 1 : 15 Player 2 : 0", game.GameScore);

            // Player 1 wins 1 point
            game.PlayerWinPoint(player1);
            Assert.Equal("Player 1 : 30 Player 2 : 0", game.GameScore);

            // Player 2 wins 1 point
            game.PlayerWinPoint(player2);
            Assert.Equal("Player 1 : 30 Player 2 : 15", game.GameScore);

            // Player 1 wins 1 point
            game.PlayerWinPoint(player1);
            Assert.Equal("Player 1 : 40 Player 2 : 15", game.GameScore);

            // Player 2 wins 1 point
            game.PlayerWinPoint(player2);
            Assert.Equal("Player 1 : 40 Player 2 : 30", game.GameScore);

            // Player 2 wins 1 point
            game.PlayerWinPoint(player2);
            Assert.Equal("Player 1 : DEUCE Player 2 : DEUCE", game.GameScore);

            // Player 2 wins 1 point
            game.PlayerWinPoint(player2);
            Assert.Equal("Player 1 : 40 Player 2 : ADVANTAGE", game.GameScore);

            // Player 1 wins 1 point
            game.PlayerWinPoint(player1);
            Assert.Equal("Player 1 : DEUCE Player 2 : DEUCE", game.GameScore);

            // Player 1 wins 1 point
            game.PlayerWinPoint(player1);
            Assert.Equal("Player 1 : ADVANTAGE Player 2 : 40", game.GameScore);

            // Player 1 wins 1 point
            game.PlayerWinPoint(player1);
            Assert.Equal("Alex wins!", game.GameScore);
            Assert.True(game.GameEnd);
        }
    }
}
