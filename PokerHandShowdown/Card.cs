using System;
namespace PokerHandShowdown
{
    public struct Card
    {
        public PokerSuit Suit;
        public PokerRank Rank;

        public Card(PokerSuit suit, PokerRank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override bool Equals(object obj)
        {
            return obj is Card other &&
                   Suit == other.Suit &&
                   Rank == other.Rank;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Suit, Rank);
        }

        public void Deconstruct(out PokerSuit suit, out PokerRank rank)
        {
            suit = Suit;
            rank = Rank;
        }

        public static implicit operator (PokerSuit, PokerRank)(Card value)
        {
            return (value.Suit, value.Rank);
        }

        public static implicit operator Card((PokerSuit, PokerRank) value)
        {
            return new Card(value.Item1, value.Item2);
        }
    }
}
