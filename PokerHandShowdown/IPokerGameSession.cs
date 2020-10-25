using System.Collections.Generic;

namespace PokerHandShowdown
{
    public interface IPokerGameSession
    {
        Dictionary<string, Player> Players { get; }
        List<string> Winners { get; }

        void AddPlayer(string playerName);
        void AddPlayer(string playerName, Card[] cards);
        void DetermineTheWinner();
        void DispatchCardsToPlayer(string playerName, Card card);
        void DispatchCardsToPlayer(string playerName, Card[] cards);
        void PreparePlayersHands();
    }
}