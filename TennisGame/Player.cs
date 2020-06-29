namespace TennisGame
{
    using TennisGame.Interfaces;

    public class Player : IPlayer
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
