using System;
using PokerHandShowdown;

namespace PokerHandShowdownTests
{
    public class GameSessionCommun
    {
        public PokerGameSession _pokerGameSession = new PokerGameSession();

        public void ProcessGameSession_Success_Pair_Score_Data()
        {
            _pokerGameSession.AddPlayer("hicham");
            _pokerGameSession.AddPlayer("amber");

            _pokerGameSession.DispatchCardsToPlayer("hicham", new Card(PokerSuit.Club, PokerRank.Ace));
            _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card[]
                {
                    new Card(PokerSuit.Heart,PokerRank.Eight),
                    new Card(PokerSuit.Diamond,PokerRank.Eight),
                    new Card(PokerSuit.Spades,PokerRank.Nine),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });
            _pokerGameSession.DispatchCardsToPlayer("amber",
                new Card[]
                {
                    new Card(PokerSuit.Spades,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Ten),
                    new Card(PokerSuit.Spades,PokerRank.King),
                    new Card(PokerSuit.Diamond,PokerRank.Ace),
                    new Card(PokerSuit.Club,PokerRank.Seven),
                });
            _pokerGameSession.AddPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Diamond,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Eight),
                    new Card(PokerSuit.Club,PokerRank.Eight),
                    new Card(PokerSuit.Heart,PokerRank.Ace),
                    new Card(PokerSuit.Heart,PokerRank.Seven),
                });

            _pokerGameSession.PreparePlayersHands();
        }


        public void ProcessGameSession_Success_Flush_Data()
        {
            _pokerGameSession.AddPlayer("hicham");
            _pokerGameSession.AddPlayer("amber");

            _pokerGameSession.DispatchCardsToPlayer("hicham", new Card(PokerSuit.Club, PokerRank.Ace));
            _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card[]
                {
                    new Card(PokerSuit.Club,PokerRank.Four),
                    new Card(PokerSuit.Diamond,PokerRank.Four),
                    new Card(PokerSuit.Spades,PokerRank.Four),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });
            _pokerGameSession.DispatchCardsToPlayer("amber",
                new Card[]
                {
                    new Card(PokerSuit.Spades,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Ten),
                    new Card(PokerSuit.Spades,PokerRank.King),
                    new Card(PokerSuit.Spades,PokerRank.Ace),
                    new Card(PokerSuit.Spades,PokerRank.Seven),
                });
            _pokerGameSession.AddPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Diamond,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Eight),
                    new Card(PokerSuit.Club,PokerRank.Eight),
                    new Card(PokerSuit.Heart,PokerRank.Ace),
                    new Card(PokerSuit.Heart,PokerRank.Seven),
                });

            _pokerGameSession.PreparePlayersHands();
        }

        public void ProcessGameSession_Success_Flush_Score_Data()
        {
            _pokerGameSession.AddPlayer("hicham");
            _pokerGameSession.AddPlayer("amber");

            _pokerGameSession.DispatchCardsToPlayer("hicham", new Card(PokerSuit.Club, PokerRank.Ace));
            _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card[]
                {
                    new Card(PokerSuit.Club,PokerRank.Four),
                    new Card(PokerSuit.Diamond,PokerRank.Four),
                    new Card(PokerSuit.Spades,PokerRank.Four),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });
            _pokerGameSession.DispatchCardsToPlayer("amber",
                new Card[]
                {
                    new Card(PokerSuit.Spades,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Ten),
                    new Card(PokerSuit.Spades,PokerRank.King),
                    new Card(PokerSuit.Spades,PokerRank.Ace),
                    new Card(PokerSuit.Spades,PokerRank.Seven),
                });
            _pokerGameSession.AddPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Heart,PokerRank.Jack),
                    new Card(PokerSuit.Heart,PokerRank.Eight),
                    new Card(PokerSuit.Heart,PokerRank.Nine),
                    new Card(PokerSuit.Heart,PokerRank.Ace),
                    new Card(PokerSuit.Heart,PokerRank.Seven),
                });

            _pokerGameSession.PreparePlayersHands();
        }

        public void ProcessGameSession_Success_Flush_Tie_Data()
        {
            _pokerGameSession.AddPlayer("hicham");
            _pokerGameSession.AddPlayer("amber");

            _pokerGameSession.DispatchCardsToPlayer("hicham", new Card(PokerSuit.Club, PokerRank.Ace));
            _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card[]
                {
                    new Card(PokerSuit.Club,PokerRank.Jack),
                    new Card(PokerSuit.Club,PokerRank.Ten),
                    new Card(PokerSuit.Club,PokerRank.King),
                    new Card(PokerSuit.Club,PokerRank.Seven),
                });
            _pokerGameSession.DispatchCardsToPlayer("amber",
                new Card[]
                {
                    new Card(PokerSuit.Spades,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Ten),
                    new Card(PokerSuit.Spades,PokerRank.King),
                    new Card(PokerSuit.Spades,PokerRank.Ace),
                    new Card(PokerSuit.Spades,PokerRank.Seven),
                });
            _pokerGameSession.AddPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Heart,PokerRank.Jack),
                    new Card(PokerSuit.Heart,PokerRank.Eight),
                    new Card(PokerSuit.Heart,PokerRank.Nine),
                    new Card(PokerSuit.Heart,PokerRank.Ace),
                    new Card(PokerSuit.Heart,PokerRank.Seven),
                });

            _pokerGameSession.PreparePlayersHands();
        }

        public void ProcessGameSession_Success_ThreeOfKind_Data()
        {
            _pokerGameSession.AddPlayer("hicham");
            _pokerGameSession.AddPlayer("amber");

            _pokerGameSession.DispatchCardsToPlayer("hicham", new Card(PokerSuit.Club, PokerRank.Ace));
            _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card[]
                {
                    new Card(PokerSuit.Club,PokerRank.Four),
                    new Card(PokerSuit.Diamond,PokerRank.Four),
                    new Card(PokerSuit.Spades,PokerRank.Four),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });
            _pokerGameSession.DispatchCardsToPlayer("amber",
                new Card[]
                {
                    new Card(PokerSuit.Spades,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Ten),
                    new Card(PokerSuit.Spades,PokerRank.King),
                    new Card(PokerSuit.Diamond,PokerRank.Ace),
                    new Card(PokerSuit.Club,PokerRank.Seven),
                });
            _pokerGameSession.AddPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Diamond,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Eight),
                    new Card(PokerSuit.Club,PokerRank.Eight),
                    new Card(PokerSuit.Heart,PokerRank.Ace),
                    new Card(PokerSuit.Heart,PokerRank.Seven),
                });

            _pokerGameSession.PreparePlayersHands();
        }

        public void ProcessGameSession_Success_ThreeOfKind_Score_Data()
        {
            _pokerGameSession.AddPlayer("hicham");
            _pokerGameSession.AddPlayer("amber");

            _pokerGameSession.DispatchCardsToPlayer("hicham", new Card(PokerSuit.Club, PokerRank.Ace));
            _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card[]
                {
                    new Card(PokerSuit.Club,PokerRank.Four),
                    new Card(PokerSuit.Diamond,PokerRank.Four),
                    new Card(PokerSuit.Spades,PokerRank.Four),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });
            _pokerGameSession.DispatchCardsToPlayer("amber",
                new Card[]
                {
                    new Card(PokerSuit.Spades,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Ten),
                    new Card(PokerSuit.Spades,PokerRank.King),
                    new Card(PokerSuit.Diamond,PokerRank.Ace),
                    new Card(PokerSuit.Club,PokerRank.Seven),
                });
            _pokerGameSession.AddPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Diamond,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Eight),
                    new Card(PokerSuit.Club,PokerRank.Eight),
                    new Card(PokerSuit.Heart,PokerRank.Eight),
                    new Card(PokerSuit.Heart,PokerRank.Seven),
                });

            _pokerGameSession.PreparePlayersHands();
        }

        public void ProcessGameSession_Success_Pair_Data()
        {
            _pokerGameSession.AddPlayer("hicham");
            _pokerGameSession.AddPlayer("amber");

            _pokerGameSession.DispatchCardsToPlayer("hicham", new Card(PokerSuit.Club, PokerRank.Ace));
            _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card[]
                {
                    new Card(PokerSuit.Club,PokerRank.Four),
                    new Card(PokerSuit.Diamond,PokerRank.Four),
                    new Card(PokerSuit.Spades,PokerRank.Nine),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });
            _pokerGameSession.DispatchCardsToPlayer("amber",
                new Card[]
                {
                    new Card(PokerSuit.Spades,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Ten),
                    new Card(PokerSuit.Spades,PokerRank.King),
                    new Card(PokerSuit.Diamond,PokerRank.Ace),
                    new Card(PokerSuit.Club,PokerRank.Seven),
                });
            _pokerGameSession.AddPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Diamond,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Eight),
                    new Card(PokerSuit.Club,PokerRank.Eight),
                    new Card(PokerSuit.Heart,PokerRank.Ace),
                    new Card(PokerSuit.Heart,PokerRank.Seven),
                });

            _pokerGameSession.PreparePlayersHands();
        }

        public void ProcessGameSession_Success_Score_Data()
        {
            _pokerGameSession.AddPlayer("hicham");
            _pokerGameSession.AddPlayer("amber");

            _pokerGameSession.DispatchCardsToPlayer("hicham", new Card(PokerSuit.Club, PokerRank.Ace));
            _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card[]
                {
                    new Card(PokerSuit.Heart,PokerRank.Eight),
                    new Card(PokerSuit.Diamond,PokerRank.Five),
                    new Card(PokerSuit.Spades,PokerRank.Nine),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });
            _pokerGameSession.DispatchCardsToPlayer("amber",
                new Card[]
                {
                    new Card(PokerSuit.Spades,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Ten),
                    new Card(PokerSuit.Spades,PokerRank.King),
                    new Card(PokerSuit.Diamond,PokerRank.Ace),
                    new Card(PokerSuit.Club,PokerRank.Seven),
                });
            _pokerGameSession.AddPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Diamond,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Eight),
                    new Card(PokerSuit.Club,PokerRank.Four),
                    new Card(PokerSuit.Heart,PokerRank.Ace),
                    new Card(PokerSuit.Heart,PokerRank.Seven),
                });

            _pokerGameSession.PreparePlayersHands();
        }

        public void ProcessGameSession_Success_Score_Tie_Data()
        {
            _pokerGameSession.AddPlayer("hicham");
            _pokerGameSession.AddPlayer("amber");

            _pokerGameSession.DispatchCardsToPlayer("hicham", new Card(PokerSuit.Club, PokerRank.Ace));
            _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card[]
                {
                    new Card(PokerSuit.Heart,PokerRank.Eight),
                    new Card(PokerSuit.Diamond,PokerRank.Five),
                    new Card(PokerSuit.Spades,PokerRank.Nine),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });
            _pokerGameSession.DispatchCardsToPlayer("amber",
                new Card[]
                {
                    new Card(PokerSuit.Spades,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Ten),
                    new Card(PokerSuit.Spades,PokerRank.King),
                    new Card(PokerSuit.Diamond,PokerRank.Ace),
                    new Card(PokerSuit.Club,PokerRank.Seven),
                });
            _pokerGameSession.AddPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Diamond,PokerRank.Jack),
                    new Card(PokerSuit.Heart,PokerRank.Ten),
                    new Card(PokerSuit.Club,PokerRank.King),
                    new Card(PokerSuit.Heart,PokerRank.Ace),
                    new Card(PokerSuit.Heart,PokerRank.Seven),
                });

            _pokerGameSession.PreparePlayersHands();
        }

    }
}
