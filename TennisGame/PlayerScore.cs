namespace TennisGame
{
    using TennisGame.Interfaces;

    public class PlayerScore : IPlayerScore
    {
        public IPlayer Player { get; }

        public IScore Score { get; set; }

        public PlayerScore(IPlayer player)
        {
            Player = player;
            Score = new PointValueScore();
        }

        public void IncreaseScore()
        {
            Score = NextPointValueScore(Score);
        }

        public void WinTheGame()
        {
            Score = new WinnerScore();
        }

        public void DeuceScore()
        {
            Score = new DeuceScore();
        }

        public void TakeTheAdvantage()
        {
            Score = new AdvantageScore();
        }

        public void FortyScore()
        {
            Score = new PointValueScore(40);
        }

        private PointValueScore NextPointValueScore(IScore score)
        {
            return score.Value switch
            {
                0 => new PointValueScore(15),
                15 => new PointValueScore(30),
                _ => new PointValueScore(40)
            };
        }

        public string GetScore() => Score.ToString();

        public bool HasLessThanFortyPoints => Score is PointValueScore pointValueScore && pointValueScore.Value < 40;

        public bool HasFortyPoints => Score is PointValueScore pointValueScore && pointValueScore.Value == 40;

        public bool HasAdvantage => Score is AdvantageScore;

        public bool IsWinner => Score is WinnerScore;

        public bool IsDeuce => Score is DeuceScore;

    }
}
