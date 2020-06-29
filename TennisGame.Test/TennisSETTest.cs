namespace TennisGame.Test
{
    using TennisGame.Interfaces;
    using Xunit;

    public class TennisSETTest
    {
        [Fact]
        public void SimpleTennisSETTest()
        {
            IPlayer player1 = new Player("Alex");
            IPlayer player2 = new Player("Dina");


            TennisSET tennisSET = new TennisSET(player1, player2);

            Play1WinGame(tennisSET, player2, player1);
            Play1WinGame(tennisSET, player1, player2);
            Play1WinGame(tennisSET, player1, player2);
            Play1WinGame(tennisSET, player1, player2);
            Play1WinGame(tennisSET, player1, player2);
            Play1WinGame(tennisSET, player1, player2);
            Play1WinGame(tennisSET, player1, player2);

            Assert.Equal($"(0, 6, 0)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal(player1, tennisSET.SETWinner);
        }

        [Fact]
        public void TieBreakSETTest()
        {
            IPlayer player1 = new Player("Alex");
            IPlayer player2 = new Player("Dina");


            TennisSET tennisSET = new TennisSET(player1, player2);

            Play1WinGame(tennisSET, player2, player1);
            Play1WinGame(tennisSET, player1, player2);

            Play1WinGame(tennisSET, player2, player1);
            Play1WinGame(tennisSET, player1, player2);

            Play1WinGame(tennisSET, player2, player1);
            Play1WinGame(tennisSET, player1, player2);

            Play1WinGame(tennisSET, player2, player1);
            Play1WinGame(tennisSET, player1, player2);

            Play1WinGame(tennisSET, player2, player1);
            Play1WinGame(tennisSET, player1, player2);

            Play1WinGame(tennisSET, player2, player1);
            Play1WinGame(tennisSET, player1, player2);

            Assert.Equal($"(0, 6, 0)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, 6, 0)", tennisSET.GetPlayerScore(player2).ToString());

            // TieBreak start

            tennisSET.PlayerWinPoint(player1);
            
            Assert.Equal($"(0, 6, 1)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, 6, 0)", tennisSET.GetPlayerScore(player2).ToString());

            tennisSET.PlayerWinPoint(player2);

            Assert.Equal($"(0, 6, 1)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, 6, 1)", tennisSET.GetPlayerScore(player2).ToString());

            tennisSET.PlayerWinPoint(player1);

            Assert.Equal($"(0, 6, 2)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, 6, 1)", tennisSET.GetPlayerScore(player2).ToString());

            tennisSET.PlayerWinPoint(player1);

            Assert.Equal($"(0, 6, 3)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, 6, 1)", tennisSET.GetPlayerScore(player2).ToString());

            tennisSET.PlayerWinPoint(player1);

            Assert.Equal($"(0, 6, 4)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, 6, 1)", tennisSET.GetPlayerScore(player2).ToString());

            tennisSET.PlayerWinPoint(player1);

            Assert.Equal($"(0, 6, 5)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, 6, 1)", tennisSET.GetPlayerScore(player2).ToString());

            tennisSET.PlayerWinPoint(player1);

            Assert.Equal($"(0, 6, 6)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, 6, 1)", tennisSET.GetPlayerScore(player2).ToString());

            tennisSET.PlayerWinPoint(player1);

            Assert.Equal($"(0, 7, 0)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, 6, 0)", tennisSET.GetPlayerScore(player2).ToString());

            Assert.Equal(player1, tennisSET.SETWinner);
        }

        void Play1WinGame(TennisSET tennisSET, IPlayer player1, IPlayer player2)
        {
            (_, int setScorePlayer1, _) = tennisSET.GetPlayerScore(player1);
            (_, int setScorePlayer2, _) = tennisSET.GetPlayerScore(player2);

            Assert.Equal($"(0, {setScorePlayer1}, 0)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, {setScorePlayer2}, 0)", tennisSET.GetPlayerScore(player2).ToString());

            // Player 1 wins 1 point
            tennisSET.PlayerWinPoint(player1);
            Assert.Equal($"(15, {setScorePlayer1}, 0)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, {setScorePlayer2}, 0)", tennisSET.GetPlayerScore(player2).ToString());

            // Player 1 wins 1 point
            tennisSET.PlayerWinPoint(player1);
            Assert.Equal($"(30, {setScorePlayer1}, 0)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, {setScorePlayer2}, 0)", tennisSET.GetPlayerScore(player2).ToString());

            // Player 2 wins 1 point
            tennisSET.PlayerWinPoint(player2);
            Assert.Equal($"(30, {setScorePlayer1}, 0)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(15, {setScorePlayer2}, 0)", tennisSET.GetPlayerScore(player2).ToString());

            // Player 1 wins 1 point
            tennisSET.PlayerWinPoint(player1);
            Assert.Equal($"(40, {setScorePlayer1}, 0)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(15, {setScorePlayer2}, 0)", tennisSET.GetPlayerScore(player2).ToString());

            // Player 2 wins 1 point
            tennisSET.PlayerWinPoint(player2);
            Assert.Equal($"(40, {setScorePlayer1}, 0)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(30, {setScorePlayer2}, 0)", tennisSET.GetPlayerScore(player2).ToString());

            // Player 1 wins 1 point
            tennisSET.PlayerWinPoint(player1);
            Assert.Equal($"(0, {setScorePlayer1 + 1}, 0)", tennisSET.GetPlayerScore(player1).ToString());
            Assert.Equal($"(0, {setScorePlayer2}, 0)", tennisSET.GetPlayerScore(player2).ToString());
        }

        
    }
}
