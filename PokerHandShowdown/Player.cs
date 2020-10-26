namespace PokerHandShowdown
{
    /// <summary>
    /// Poker player.
    /// </summary>
    public class Player : IPlayer
    {
        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }
        /// <summary>
        /// Name of poker player.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Hand of poker player.
        /// </summary>
        public Hand Hand { get; set; }
    }
}
