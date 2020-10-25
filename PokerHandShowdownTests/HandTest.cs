using System;
using System.Linq;
using FluentAssertions;
using PokerHandShowdown;
using Xunit;

namespace PokerHandShowdownTests
{
    public class HandTest
    {
        private Hand _hand;

        public HandTest()
        {
            _hand = new Hand();
        }

        [Fact]
        public void EmptyHands()
        {
            var hand = new Hand();

            var cardCount = _hand.Cards.Where(c => c.Rank != 0).Count();

            cardCount.Should().Be(0);

            var flushCount = hand.Cards.GroupBy(x => x.Suit).Count();

            var pairSum = hand.Cards.GroupBy(x => x.Rank).Count();

            flushCount.Should().Be(1);

            pairSum.Should().Be(1);

        }

        [Fact]
        public void AddCards_MultipleCards()
        {
            _hand.AddCard(PokerSuit.Club, PokerRank.King);
            _hand.AddCard(PokerSuit.Club, PokerRank.Ace);
            _hand.AddCard(PokerSuit.Club, PokerRank.Three);
            _hand.AddCard(PokerSuit.Club, PokerRank.Jack);
            _hand.AddCard(PokerSuit.Diamond, PokerRank.Four);

            var cardCount = _hand.Cards.Where(c => c.Rank != 0).Count();
            cardCount.Should().Be(5);
        }

        [Fact]
        public void FlushTest()
        {
            _hand.AddCard(PokerSuit.Club, PokerRank.King);
            _hand.AddCard(PokerSuit.Club, PokerRank.Ace);
            _hand.AddCard(PokerSuit.Club, PokerRank.Three);
            _hand.AddCard(PokerSuit.Club, PokerRank.Jack);
            _hand.AddCard(PokerSuit.Club, PokerRank.Four);
      
            _hand.PrepareHand();

            _hand.SetType.Should().Be(SetType.Flush);
        }

        [Fact]
        public void PairTest()
        {
            _hand.AddCard(PokerSuit.Club, PokerRank.King);
            _hand.AddCard(PokerSuit.Heart, PokerRank.Four);
            _hand.AddCard(PokerSuit.Club, PokerRank.Three);
            _hand.AddCard(PokerSuit.Heart, PokerRank.Three);
            _hand.AddCard(PokerSuit.Diamond, PokerRank.Four);

            _hand.PrepareHand();

            _hand.SetType.Should().Be(SetType.OnePair);
        }

        [Fact]
        public void NKindTest()
        {
            _hand.AddCard(PokerSuit.Club, PokerRank.King);
            _hand.AddCard(PokerSuit.Heart, PokerRank.Four);
            _hand.AddCard(PokerSuit.Club, PokerRank.Three);
            _hand.AddCard(PokerSuit.Heart, PokerRank.Three);
            _hand.AddCard(PokerSuit.Diamond, PokerRank.Three);

            _hand.PrepareHand();

            _hand.SetType.Should().Be(SetType.ThreeOfKind);
        }

        [Fact]
        public void NoTypeSet()
        {
            _hand.AddCard(PokerSuit.Club, PokerRank.King);
            _hand.AddCard(PokerSuit.Heart, PokerRank.Four);
            _hand.AddCard(PokerSuit.Club, PokerRank.Three);
            _hand.AddCard(PokerSuit.Heart, PokerRank.Nine);
            _hand.AddCard(PokerSuit.Diamond, PokerRank.Jack);

            _hand.PrepareHand();

            _hand.SetType.Should().Be(SetType.None);
        }

        [Fact]
        public void ScoreTest()
        {
            _hand.AddCard(PokerSuit.Club, PokerRank.King);
            _hand.AddCard(PokerSuit.Club, PokerRank.Ace);
            _hand.AddCard(PokerSuit.Club, PokerRank.Three);
            _hand.AddCard(PokerSuit.Club, PokerRank.Jack);
            _hand.AddCard(PokerSuit.Club, PokerRank.Four);

            _hand.PrepareHand();

            _hand.Score.Should().Be(45);
        }

        [Fact]
        public void AddCard()
        {
            _hand.AddCard(0, 0).Should().BeFalse();
            _hand.AddCard(PokerSuit.Club, PokerRank.Ace).Should().BeTrue();
        }

        [Fact]
        public void AddCards()
        {
            _hand.AddCards(
                new Card[] { new Card(PokerSuit.Club, PokerRank.Three),
                new Card(PokerSuit.Club, PokerRank.Jack) }).Should().BeTrue();

            _hand.AddCards(
                  new Card[] { new Card(PokerSuit.None, PokerRank.Three),
                new Card(PokerSuit.Club, PokerRank.Nine) }).Should().BeFalse();
        }

        [Fact]
        public void PrepareHandTestFail()
        {
            Action act = () => _hand.PrepareHand();
            act.Should().Throw<Exception>().WithMessage("Invalid card hand");
        }
    }
}
