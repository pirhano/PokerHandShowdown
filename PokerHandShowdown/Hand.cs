using System;
using System.Linq;
namespace PokerHandShowdown
{
    /// <summary>
    /// Poker player's hand.
    /// </summary>
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
        /// <summary>
        /// Cards in hand
        /// </summary>
        public Card[] Cards { get; private set; }
        /// <summary>
        /// Full cards score.
        /// </summary>
        public int Score { get; private set; }
        /// <summary>
        /// Type of card winning.
        /// </summary>
        public SetType SetType { get; private set; }

        /// <summary>
        /// Dominant rank array.
        /// </summary>
        public Card[] DominantRank { get; private set; }

        /// <summary>
        /// Add one card to player.
        /// </summary>
        /// <param name="suit">suit.</param>
        /// <param name="rank">rank.</param>
        /// <returns>true if added <otherwise>false.</otherwise></returns>
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

        /// <summary>
        /// Clear hand from cards.
        /// </summary>
        public void ClearHand()
        {
            _cardCount = 0;
        }

        /// <summary>
        /// Add array card to player.
        /// </summary>
        /// <param name="cards">array of card.</param>
        /// <returns>true if added <otherwise>false.</otherwise></returns>
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

        /// <summary>
        /// organize hand, prepare score and winning cards.
        /// </summary>
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
        /// <summary>
        /// Calculate full score.
        /// </summary>
        private void CalculateScore()
        {
            Score = Cards.Select(x => (int)x.Rank).Sum();
        }

        /// <summary>
        /// Order cards in hand descending by rank.
        /// </summary>
        private void OrderCardsByRank()
        {
            Cards = Cards.OrderByDescending(q => q.Rank).ToArray();
        }

        /// <summary>
        /// Check if hand has flush cards.
        /// </summary>
        /// <returns>true if its flush.<otherwise>false.</otherwise></returns>
        private bool HandHasFlush()
        {
            var flush = Cards.GroupBy(x => x.Suit).ToArray().OrderByDescending(r => r.Count()).First();

            return flush.Count().Equals(MAX_CARDS);
        }

        /// <summary>
        /// Check if hand has N of kind cards.
        /// N could be 3 or 4.
        /// </summary>
        /// <returns>true if its N of kind.<otherwise>false.</otherwise></returns>
        private bool HandHasNOfKind()
        {
            return DominantRank.Count() >= THREE_OF_KIND;
        }

        /// <summary>
        /// Check if hand has pair of rank.
        /// </summary>
        /// <returns>true if its pair.<otherwise>false.</otherwise></returns>
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
