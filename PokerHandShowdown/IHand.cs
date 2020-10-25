namespace PokerHandShowdown
{
    public interface IHand
    {
        Card[] Cards { get; }
        int Score { get; }
        SetType SetType { get; }
        Card[] DominantRank { get; }

        bool AddCard(PokerSuit suit, PokerRank rank);
        bool AddCards(Card[] cards);
        void PrepareHand();
    }
}