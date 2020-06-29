namespace TennisGame.Interfaces
{
    public interface IPlayerSetScore
    {
        IPlayer Player { get; set; }
        int Score { get; set; }
        int TiedBreakScore { get; set; }
    }
}