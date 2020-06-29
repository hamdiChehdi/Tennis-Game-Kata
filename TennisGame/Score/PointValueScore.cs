namespace TennisGame
{
    using TennisGame.Interfaces;

    public class PointValueScore : IScore
    {
        private int points;

        public PointValueScore(int points = 0)
        {
            this.points = points;
        }

        public new string ToString()
        {
            return points.ToString();
        }

        public int Value
        {
            get
            {
                return points;
            }
        }
    }
}
