namespace TennisGame
{
    using TennisGame.Interfaces;

    public class WinnerScore : IScore
    {
        public int Value 
        { 
            get
            {
                return 70;
            }  
        }

        public new string ToString()
        {
            return "Winner";
        }
    }
}
