namespace TennisGame
{
    using System;
    using TennisGame.Interfaces;

    public class TennisSET
    {
        private IGame currentGame;
        private IPlayerSetScore player1SetScore;
        private IPlayerSetScore player2SetScore;
        private bool tieBreakActivated;

        public TennisSET(IPlayer player1, IPlayer player2)
        {
            player1SetScore = new PlayerSetScore(player1);
            player2SetScore = new PlayerSetScore(player2);
            StartNewGame();
        }

        public void PlayerWinPoint(IPlayer player)
        {
            if (SETMatchEnd)
            {
                return;
            }

            if (player1SetScore.Player == player)
            {
                RoundPoint(player1SetScore, player2SetScore);
            }
            else if (player2SetScore.Player == player)
            {
                RoundPoint(player2SetScore, player1SetScore);
            }
            else
            {
                throw new Exception("Call TennisSET.PlayerWinPoint with Unknow player");
            }
        }

        private void RoundPoint(IPlayerSetScore roundWinner, IPlayerSetScore roundLoser)
        {
            if (tieBreakActivated)
            {
                TieBreakRoundFinished(roundWinner, roundLoser);
                return;
            }

            currentGame.PlayerWinPoint(roundWinner.Player);

            if (currentGame.GameEnd)
            {
                CurrentGameFinished(roundWinner, roundLoser);
            }
        }

        private void TieBreakRoundFinished(IPlayerSetScore roundWinner, IPlayerSetScore roundLoser)
        {
            roundWinner.TiedBreakScore++;

            if (roundWinner.TiedBreakScore >= 7 && roundWinner.TiedBreakScore - roundLoser.TiedBreakScore >= 2)
            {
                roundWinner.TiedBreakScore = 0;
                roundWinner.Score++;
                roundLoser.TiedBreakScore = 0;
                SETWinner = roundWinner.Player;
            }
        }
        
        private void CurrentGameFinished(IPlayerSetScore gameWinner, IPlayerSetScore gameLoser)
        {
            gameWinner.Score++;

            if ((gameWinner.Score == 6 && gameLoser.Score <= 4) || gameWinner.Score == 7)
            {
                SETWinner = gameWinner.Player;
            }

            if (gameWinner.Score == 6 && gameLoser.Score == 6)
            {
                tieBreakActivated = true;
            }

            StartNewGame();
        }

        private IPlayerSetScore GetPlayerSetScore(IPlayer player)
        {
            if (player1SetScore.Player == player)
            {
                return player1SetScore;
            }

            if (player2SetScore.Player == player)
            {
                return player2SetScore;
            }

            throw new Exception("Call TennisSET.GetPlayerSetScore with Unknow player");
        }

        private void StartNewGame()
        {
            currentGame = new Game(player1SetScore.Player, player2SetScore.Player); 
        }

        public IPlayer SETWinner { get; private set; }

        public bool SETMatchEnd => SETWinner != null;

        public (string, int, int) GetPlayerScore(IPlayer player) 
        {
            var playerSetScore = GetPlayerSetScore(player);

            return (currentGame.GetPlayerScore(player), playerSetScore.Score, playerSetScore.TiedBreakScore);
        }

    }
}
