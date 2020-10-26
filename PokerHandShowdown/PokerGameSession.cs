using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandShowdown
{
    public class PokerGameSession : IPokerGameSession
    {
        List<Card> TokenCards = new List<Card>();
        public Dictionary<string, Player> Players { get; } = new Dictionary<string, Player>();
        public List<string> Winners { get; private set; }

        public void DetermineTheWinners()
        {
            Winners = PokerOperations.DefineTheWinners(Players);
        }

        public void AddPlayer(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new InvalidOperationException("Invalid Player's Name");
            }
            if (PlayerExists(playerName))
            {
                throw new InvalidOperationException("Player Name exists");
            }
            Players.Add(playerName, new Player(playerName));
        }

        /// <summary>
        /// Check if Participant already exists.
        /// </summary>
        /// <param name="playerName">players name.</param>
        /// <returns>true if found<otherwise>false</otherwise></returns>
        private bool PlayerExists(string playerName)
        {
            return Players.ContainsKey(playerName);
        }

        public void AddPlayer(string playerName, Card[] cards)
        {
            AddPlayer(playerName);
            DispatchCardsToPlayer(playerName, cards);
            TokenCards.AddRange(cards);
        }

        public void DispatchCardsToPlayer(string playerName, Card card)
        {
            if (string.IsNullOrEmpty(playerName) || card.Equals(default(Card)))
            {
                throw new InvalidOperationException("Invalid Entry");
            }

            if (!PlayerExists(playerName))
            {
                throw new NullReferenceException("Player doesnt exists");
            }
            else
            {
                if (TokenCards.Contains(card))
                {
                    throw new InvalidOperationException("Invalid Card Added!");
                }
                var added = Players[playerName].Hand.AddCard(card.Suit, card.Rank);
                if (added)
                {
                    TokenCards.Add(card);
                }
                else
                {
                    throw new Exception("Couldnt Add card to hand");
                }
            }
        }

        public void DispatchCardsToPlayer(string playerName, Card[] cards)
        {
            if (string.IsNullOrEmpty(playerName) || !(cards?.Any() == true))
            {
                throw new InvalidOperationException("Invalid Entry");
            }
            if (!PlayerExists(playerName))
            {
                throw new NullReferenceException("Player doesnt exists");
            }
            else
            {
                if (CheckForDuplicatesCards(cards))
                {
                    throw new InvalidOperationException("Invalid Cards Added!");
                }
                var added = Players[playerName].Hand.AddCards(cards);
                if (added)
                {
                    TokenCards.AddRange(cards);
                }
                else
                {
                    throw new Exception("Couldnt Add cards to hand");
                }
            }
        }

        /// <summary>
        /// Check if there is any duplicate cards.
        /// </summary>
        /// <param name="cards">cards to check</param>
        /// <returns>true if duplicates present<otherwise>false.</otherwise></returns>
        private bool CheckForDuplicatesCards(Card[] cards)
        {
            return TokenCards.Concat(cards)
                                .GroupBy(x => x)
                                .Any(g => g.Count() > 1);
        }

        /// <summary>
        /// Clear session from players.
        /// </summary>
        public void ClearSession()
        {
            Players.Clear();
            TokenCards.Clear();
            Winners.Clear();
        }

        /// <summary>
        /// Remove player from game session.
        /// </summary>
        /// <param name="playerName"></param>
        public void RemoveParticipant(string playerName)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new InvalidOperationException("Invalid Entry");
            }
            if (!PlayerExists(playerName))
            {
                throw new NullReferenceException("Player doesnt exists");
            }
            Players.Remove(playerName);
            EmptyHands();
        }

        /// <summary>
        /// Empty participants hands.
        /// </summary>
        public void EmptyHands()
        {
            foreach (var player in Players)
            {
                player.Value.Hand.ClearHand();
            }
            TokenCards.Clear();
            Winners.Clear();
        }

        public void PreparePlayersHands()
        {
            foreach (var player in Players)
            {
                player.Value.Hand.PrepareHand();
            }
        }
    }
}
