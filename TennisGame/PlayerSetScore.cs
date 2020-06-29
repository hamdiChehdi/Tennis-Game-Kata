namespace TennisGame
{
    using TennisGame.Interfaces;

    public class PlayerSetScore : IPlayerSetScore
    {
        public IPlayer Player { get; set; }

        public int Score { get; set; }

        public int TiedBreakScore { get; set; }

        public PlayerSetScore(IPlayer player)
        {
            Player = player;
            Score = 0;
        }
    }
}
