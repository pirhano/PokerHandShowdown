using System;
namespace PokerHandShowdown
{
    public class Player : IPlayer
    {
        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }

        public string Name { get; set; }
        public Hand Hand { get; set; }
    }
}
