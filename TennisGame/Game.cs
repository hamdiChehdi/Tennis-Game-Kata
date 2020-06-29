namespace TennisGame
{
    using System;
    using TennisGame.Interfaces;

    public class Game : IGame
    {
        private IPlayerScore playerScore1;
        private IPlayerScore playerScore2;

        public Game(IPlayer player1, IPlayer player2)
        {
            playerScore1 = new PlayerScore(player1); 
            playerScore2 = new PlayerScore(player2);
        }

        public void PlayerWinPoint(IPlayer player)
        {
            if (playerScore1.Player == player)
            {
                RoundPoint(playerScore1, playerScore2);
            }
            else
            if (playerScore2.Player == player)
            {
                RoundPoint(playerScore2, playerScore1);
            }
            else
            {
                throw new Exception("Call Game.PlayerWinPoint with Unknow player");
            }
        }

        private void RoundPoint(IPlayerScore pointWinner, IPlayerScore pointLoser)
        {
            if (pointWinner.HasAdvantage)
            {
                pointWinner.WinTheGame();
                return;
            }

            if (pointLoser.HasAdvantage)
            {
                pointWinner.DeuceScore();
                pointLoser.DeuceScore();
                return;
            }

            if (pointWinner.IsDeuce)
            {
                pointWinner.TakeTheAdvantage();
                pointLoser.FortyScore();
                return;
            }

            if (pointWinner.HasLessThanFortyPoints && pointLoser.HasLessThanFortyPoints)
            {
                pointWinner.IncreaseScore();
                return;
            }

            if (pointWinner.HasFortyPoints)
            {
                pointWinner.WinTheGame();
                return;
            }

            pointWinner.IncreaseScore();

            if (pointWinner.HasFortyPoints && pointLoser.HasFortyPoints)
            {
                pointWinner.DeuceScore();
                pointLoser.DeuceScore();
            }
        }

        public string GameScore
        {
            get
            {
                if (GameEnd)
                {
                    return $"{playerScore1.Player.Name} wins!";
                }

                return $"Player 1 : {playerScore1.GetScore()} Player 2 : {playerScore2.GetScore()}";
            }
        }

        public bool GameEnd => Winner != null;

        public IPlayer Winner
        {
            get
            {
                if (playerScore1.IsWinner)
                {
                    return playerScore1.Player;
                }

                if (playerScore2.IsWinner)
                {
                    return playerScore2.Player;
                }

                return null;
            }
        }

        public string GetPlayerScore(IPlayer player)
        {
            if (playerScore1.Player == player)
            {
                return playerScore1.GetScore();
            }

            if (playerScore2.Player == player)
            {
                return playerScore2.GetScore();
            }

            throw new Exception("Call Game.GetPlayerScore with Unknow player");
        }
    }
}
