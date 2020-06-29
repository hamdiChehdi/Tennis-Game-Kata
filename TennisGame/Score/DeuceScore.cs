namespace TennisGame
{
    using TennisGame.Interfaces;

    public class DeuceScore : IScore
    {
        public int Value
        {
            get
            {
                return 50;
            }
        }

        public new string ToString()
        {
            return "DEUCE";
        }        
    }
}
