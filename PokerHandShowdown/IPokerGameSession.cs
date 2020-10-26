using System.Collections.Generic;

namespace PokerHandShowdown
{
    /// <summary>
    /// One Poker Session.
    /// </summary>
    public interface IPokerGameSession
    {
        /// <summary>
        /// Dictionary of participants.
        /// </summary>
        Dictionary<string, Player> Players { get; }
        /// <summary>
        /// Collection of winners.
        /// </summary>
        List<string> Winners { get; }
        /// <summary>
        /// Add player to participants.
        /// </summary>
        /// <param name="playerName">players name.</param>
        void AddPlayer(string playerName);
        /// <summary>
        /// Add player to participants
        /// and his array of card.
        /// </summary>
        /// <param name="playerName">players name.</param>
        /// <param name="cards">array of card</param>
        void AddPlayer(string playerName, Card[] cards);
        /// <summary>
        /// Find the winners.
        /// </summary>
        void DetermineTheWinners();
        /// <summary>
        /// Dispatch unique card to a specific player
        /// </summary>
        /// <param name="playerName">players name.</param>
        /// <param name="card">card</param>
        void DispatchCardsToPlayer(string playerName, Card card);
        /// <summary>
        /// Dispatch an array of unique cards to a specific player.
        /// </summary>
        /// <param name="playerName">players name.</param>
        /// <param name="cards">array of cards.</param>
        void DispatchCardsToPlayer(string playerName, Card[] cards);
        /// <summary>
        /// Prepare all participants to check their cards in hands.
        /// </summary>
        void PreparePlayersHands();
        /// <summary>
        /// Clear session from players.
        /// </summary>
        public void ClearSession();
        /// <summary>
        /// Remove player from game session.
        /// </summary>
        /// <param name="playerName"></param>
        public void RemoveParticipant(string playerName);
        /// <summary>
        /// Empty participants hands.
        /// </summary>
        public void EmptyHands();
    }
}