namespace TennisGame.Interfaces
{
    public interface IGame
    {
        bool GameEnd { get; }
        string GameScore { get; }
        IPlayer Winner { get; }

        void PlayerWinPoint(IPlayer player);

        string GetPlayerScore(IPlayer player);
    }
}