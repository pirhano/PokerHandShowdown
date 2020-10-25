using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PokerHandShowdown;
using Xunit;

namespace PokerHandShowdownTests
{
    public class PokerGameSessionTest : GameSessionCommun
    {
        private List<Card> _tokenCards;

        public PokerGameSessionTest()
        {
            _tokenCards = new List<Card>
            {
                new Card(PokerSuit.Heart, PokerRank.Four),
                new Card(PokerSuit.Diamond, PokerRank.Four),
                new Card(PokerSuit.Diamond, PokerRank.Three),
                new Card(PokerSuit.Spades, PokerRank.Four)
            };
        }

        [Fact]
        public void DispatchDuplicateCards()
        {
            var newCards = new List<Card>
            {
                new Card(PokerSuit.Diamond, PokerRank.Jack),
                new Card(PokerSuit.Diamond, PokerRank.Four),
                new Card(PokerSuit.Diamond, PokerRank.Three),
                new Card(PokerSuit.Heart, PokerRank.King)
            };

            (_tokenCards.Concat(newCards)).GroupBy(x => x).Any(g => g.Count() > 1).Should().BeTrue();
        }

        [Fact]
        public void DispatchDuplicateCard()
        { 
            Card item = new Card(PokerSuit.Diamond, PokerRank.Four);

            _tokenCards.Contains(item).Should().BeTrue();
        }

        [Fact]
        public void DispatchNewCards()
        {
            var newCards = new List<Card>
            {
                new Card(PokerSuit.Diamond, PokerRank.Jack),
                new Card(PokerSuit.Spades, PokerRank.Ace),
                new Card(PokerSuit.Spades, PokerRank.Three),
                new Card(PokerSuit.Heart, PokerRank.King)
            };

            (_tokenCards.Concat(newCards)).GroupBy(x => x).Any(g => g.Count() > 1).Should().BeFalse();
        }

        [Fact]
        public void DispatchNewCard()
        {
            Card item = new Card(PokerSuit.Spades, PokerRank.Jack);

            _tokenCards.Contains(item).Should().BeFalse();
        }

        [Fact]
        public void AddPlayer_Fail_Exist()
        {
            _pokerGameSession.AddPlayer("amber");

            Action act = () => _pokerGameSession.AddPlayer("amber");

            act.Should().Throw<InvalidOperationException>().WithMessage("Player Name exists");
        }

        [Fact]
        public void DispatchCard_Fail_PlayerNotExist()
        {
            Action act = () => _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card[]
                {
                    new Card(PokerSuit.Club,PokerRank.Four),
                    new Card(PokerSuit.Diamond,PokerRank.Four),
                    new Card(PokerSuit.Spades,PokerRank.Four),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });
            act.Should().Throw<NullReferenceException>().WithMessage("Player doesnt exists");
        }

        [Fact]
        public void DispatchCard_Fail_PlayerNotExist_SingleCard()
        {
            Action act = () => _pokerGameSession.DispatchCardsToPlayer("hicham",
                new Card(PokerSuit.Club,PokerRank.Four));
            act.Should().Throw<NullReferenceException>().WithMessage("Player doesnt exists");
        }

        [Fact]
        public void DispatchCard_Fail_InvalidCard()
        {
            _pokerGameSession.AddPlayer("hicham");
            _pokerGameSession.AddPlayer("amber");

            _pokerGameSession.DispatchCardsToPlayer("hicham", new Card(PokerSuit.Club, PokerRank.Ace));
            Action act = () => _pokerGameSession.DispatchCardsToPlayer("amber", new Card(PokerSuit.Club, PokerRank.Ace));

            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid Card Added!");
        }

        [Fact]
        public void DispatchCard_Fail_CouldntAddCard()
        {
            _pokerGameSession.AddPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Diamond,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Eight),
                    new Card(PokerSuit.Club,PokerRank.Eight),
                    new Card(PokerSuit.Heart,PokerRank.Ace),
                    new Card(PokerSuit.Heart,PokerRank.Seven),
                });
            Action act = () => _pokerGameSession.DispatchCardsToPlayer("kid", new Card(PokerSuit.Club, PokerRank.Ace));

            act.Should().Throw<Exception>().WithMessage("Couldnt Add card to hand");
        }

        [Fact]
        public void DispatchCard_Fail_InvalidCards()
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
             Action act = () => _pokerGameSession.DispatchCardsToPlayer("amber",
                new Card[]
                {
                    new Card(PokerSuit.Club,PokerRank.Jack),
                    new Card(PokerSuit.Spades,PokerRank.Ten),
                    new Card(PokerSuit.Spades,PokerRank.King),
                    new Card(PokerSuit.Spades,PokerRank.Ace),
                    new Card(PokerSuit.Spades,PokerRank.Seven),
                });
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid Cards Added!");
        }

        [Fact]
        public void DispatchCards_Fail_InvalidEntry_Empty()
        {
            Action act = () => _pokerGameSession.DispatchCardsToPlayer("", new Card[] { });
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid Entry");
        }

        [Fact]
        public void DispatchCards_Fail_InvalidEntry_Null()
        {
            Action act = () => _pokerGameSession.DispatchCardsToPlayer(null, null);
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid Entry");
        }

        [Fact]
        public void DispatchCards_Fail_InvalidEntry_Null_2()
        {
            Action act = () => _pokerGameSession.DispatchCardsToPlayer("amber", null);
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid Entry");
        }

        [Fact]
        public void DispatchCard_Fail_CouldntAddCards()
        {
            _pokerGameSession.AddPlayer("kid");

            _pokerGameSession.DispatchCardsToPlayer("kid", new Card(PokerSuit.Club, PokerRank.Ace));
            Action act = () => _pokerGameSession.DispatchCardsToPlayer("kid",
                new Card[]
                {
                    new Card(PokerSuit.Heart, PokerRank.Ace),
                    new Card(PokerSuit.Club,PokerRank.Four),
                    new Card(PokerSuit.Diamond,PokerRank.Four),
                    new Card(PokerSuit.Spades,PokerRank.Four),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });

            act.Should().Throw<Exception>().WithMessage("Couldnt Add cards to hand");
        }

        [Fact]
        public void DispatchCard_Fail_CouldntAddCard_InvalidData()
        {
            _pokerGameSession.AddPlayer("kid");

            Action act = () => _pokerGameSession.DispatchCardsToPlayer("kid", new Card(PokerSuit.None, PokerRank.Ace));

            act.Should().Throw<Exception>().WithMessage("Couldnt Add card to hand");
        }

        [Fact]
        public void DispatchCard_Fail_CouldntAddCards_InvalidData()
        {
            _pokerGameSession.AddPlayer("kid");

            Action act = () => _pokerGameSession.DispatchCardsToPlayer("kid",
                new Card[]
                {
                    new Card(0, 0),
                    new Card(PokerSuit.Club,PokerRank.Four),
                    new Card(PokerSuit.Diamond,PokerRank.Four),
                    new Card(PokerSuit.Spades,PokerRank.Four),
                    new Card(PokerSuit.Club,PokerRank.Jack),
                });

            act.Should().Throw<Exception>().WithMessage("Couldnt Add cards to hand");
        }

        [Fact]
        public void DispatchCard_Fail_InvalidEntry_Empty()
        {
            Action act = () => _pokerGameSession.DispatchCardsToPlayer("", default(Card));
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid Entry");
        }

        [Fact]
        public void DispatchCard_Fail_InvalidEntry_Null()
        {
            Action act = () => _pokerGameSession.DispatchCardsToPlayer(null, default(Card));
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid Entry");
        }

        [Fact]
        public void AddPlayer_Fail_InvalidPlayerName_Empty()
        {
            Action act = () => _pokerGameSession.AddPlayer("");
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid Player's Name");
        }
        
        [Fact]
        public void AddPlayer_Fail_InvalidPlayerName_Null()
        {
            Action act = () => _pokerGameSession.AddPlayer(null);
            act.Should().Throw<InvalidOperationException>().WithMessage("Invalid Player's Name");
        }

        [Fact]
        public void ProcessGameSession_Success_Flush()
        {
            ProcessGameSession_Success_Flush_Data();

            _pokerGameSession.DetermineTheWinner();

            _pokerGameSession.Winners.First().Should().Be("amber");
        }

        [Fact]
        public void ProcessGameSession_Success_Flush_Score()
        {
            ProcessGameSession_Success_Flush_Score_Data();

            _pokerGameSession.DetermineTheWinner();

            _pokerGameSession.Winners.First().Should().Be("amber");
        }

        [Fact]
        public void ProcessGameSession_Success_Flush_Tie()
        {
            ProcessGameSession_Success_Flush_Tie_Data();

            _pokerGameSession.DetermineTheWinner();

            _pokerGameSession.Winners.Count().Should().Be(2);
            _pokerGameSession.Winners.Should().Contain("amber");
            _pokerGameSession.Winners.Should().Contain("hicham");
        }

        [Fact]
        public void ProcessGameSession_Success_ThreeOfKind()
        {
            ProcessGameSession_Success_ThreeOfKind_Data();

            _pokerGameSession.DetermineTheWinner();

            _pokerGameSession.Winners.Count().Should().Be(1);
            _pokerGameSession.Winners.First().Should().Be("hicham");
        }

        [Fact]
        public void ProcessGameSession_Success_ThreeOfKind_Score()
        {
            ProcessGameSession_Success_ThreeOfKind_Score_Data();

            _pokerGameSession.DetermineTheWinner();

            _pokerGameSession.Winners.Count().Should().Be(1);
            _pokerGameSession.Winners.First().Should().Be("kid");
        }

        [Fact]
        public void ProcessGameSession_Success_Pair()
        {
            ProcessGameSession_Success_Pair_Data();

            _pokerGameSession.DetermineTheWinner();

            _pokerGameSession.Winners.Count().Should().Be(1);
            _pokerGameSession.Winners.First().Should().Be("kid");
        }

        [Fact]
        public void ProcessGameSession_Success_Pair_Score()
        {
            ProcessGameSession_Success_Pair_Score_Data();

            _pokerGameSession.DetermineTheWinner();

            _pokerGameSession.Winners.Count().Should().Be(1);
            _pokerGameSession.Winners.First().Should().Be("hicham");
        }

        [Fact]
        public void ProcessGameSession_Success_Score()
        {
            ProcessGameSession_Success_Score_Data();

            _pokerGameSession.DetermineTheWinner();

            _pokerGameSession.Winners.Count().Should().Be(1);
            _pokerGameSession.Winners.First().Should().Be("amber");
        }

        [Fact]
        public void ProcessGameSession_Success_Score_Tie()
        {
            ProcessGameSession_Success_Score_Tie_Data();

            _pokerGameSession.DetermineTheWinner();

            _pokerGameSession.Winners.Count().Should().Be(2);
            _pokerGameSession.Winners.Should().Contain("amber");
            _pokerGameSession.Winners.Should().Contain("kid");
        }
    }
}
