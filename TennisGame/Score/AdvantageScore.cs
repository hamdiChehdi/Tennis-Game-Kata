namespace TennisGame
{
    using TennisGame.Interfaces;

    public class AdvantageScore : IScore
    {
        public int Value
        {
            get
            {
                return 60;
            }
        }

        public new string ToString()
        {
            return "ADVANTAGE";
        }
    }

}
