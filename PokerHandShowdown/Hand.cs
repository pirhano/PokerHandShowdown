using System;
using System.Linq;
namespace PokerHandShowdown
{
    public class Hand : IHand
    {
        private const int PAIR = 2;
        private const int MAX_CARDS = 5;
        private const int ELEMENT_NOT_EXIST = -1;
        private const int THREE_OF_KIND = 3;

        private int _cardCount = 0;

        public Hand()
        {
            Cards = new Card[MAX_CARDS];
        }

        public Card[] Cards { get; private set; }
        public int Score { get; private set; }
        public SetType SetType { get; private set; }

        public Card[] DominantRank { get; private set; }

        public bool AddCard(PokerSuit suit, PokerRank rank)
        {
            if((int)rank >= 2 && !suit.Equals(PokerSuit.None))
            {
                if (_cardCount < MAX_CARDS)
                {
                    var indexCard = Array.IndexOf(Cards, ((suit, rank)));
                    if (indexCard == ELEMENT_NOT_EXIST)
                    {
                        Cards[_cardCount++] = new Card(suit, rank);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool AddCards(Card[] cards)
        {
            if ((cards.Length + _cardCount) <= MAX_CARDS)
            {
                foreach (var card in cards)
                {
                    if ((int)card.Rank < 2 || card.Suit.Equals(PokerSuit.None))
                    {
                        return false;
                    }
                    Cards[_cardCount++] = card;
                }
                return true;
            }
            return false;
        }

        public void PrepareHand()
        {
            if (_cardCount != MAX_CARDS)
            {
                throw new Exception("Invalid card hand");
            }
            OrderCardsByRank();
            if (HandHasFlush())
            {
                SetType = SetType.Flush;
            }
            else
            {
                FindDominantRank();

                if (HandHasNOfKind())
                {
                    SetType = SetType.ThreeOfKind;
                }
                else if (HandHasPair())
                {
                    SetType = SetType.OnePair;
                }
            }
            CalculateScore();
        }

        private void CalculateScore()
        {
            Score = Cards.Select(x => (int)x.Rank).Sum();
        }

        private void OrderCardsByRank()
        {
            Cards = Cards.OrderByDescending(q => q.Rank).ToArray();
        }

        private bool HandHasFlush()
        {
            var flush = Cards.GroupBy(x => x.Suit).ToArray().OrderByDescending(r => r.Count()).First();

            return flush.Count().Equals(MAX_CARDS);
        }

        private bool HandHasNOfKind()
        {
            return DominantRank.Count() >= THREE_OF_KIND;
        }

        private bool HandHasPair()
        {
            return DominantRank.Count() == PAIR;
        }

        private void FindDominantRank()
        {
            DominantRank = Cards.GroupBy(x => x.Rank).ToArray().OrderByDescending(r => r.Count()).First().ToArray();
        }
    }
}
