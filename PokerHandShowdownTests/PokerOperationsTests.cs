using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PokerHandShowdown;
using Xunit;

namespace PokerHandShowdownTests
{
    public class PokerOperationsTests : GameSessionCommun
    {

        [Fact]
        public void ProcessGameSession_Success_Score()
        {
            ProcessGameSession_Success_Score_Data();

            var winners = PokerOperations.DefineTheWinners(_pokerGameSession.Players);

            winners.Count.Should().Be(1);
            winners.First().Should().Be("amber");
        }

        [Fact]
        public void ProcessGameSession_Success_Flush()
        {
            ProcessGameSession_Success_Flush_Data();

            var winners = PokerOperations.DefineTheWinners(_pokerGameSession.Players);

            winners.First().Should().Be("amber");
        }

        [Fact]
        public void ProcessGameSession_Success_Flush_Score()
        {
            ProcessGameSession_Success_Flush_Score_Data();

            var winners = PokerOperations.DefineTheWinners(_pokerGameSession.Players);

            winners.First().Should().Be("amber");
        }

        [Fact]
        public void ProcessGameSession_Success_ThreeOfKind()
        {
            ProcessGameSession_Success_ThreeOfKind_Data();

            var winners = PokerOperations.DefineTheWinners(_pokerGameSession.Players);

            winners.Count().Should().Be(1);
            winners.First().Should().Be("hicham");
        }

        [Fact]
        public void ProcessGameSession_Success_Flush_Tie()
        {
            ProcessGameSession_Success_Flush_Tie_Data();

            var winners = PokerOperations.DefineTheWinners(_pokerGameSession.Players);

            winners.Count().Should().Be(2);
            winners.Should().Contain("amber");
            winners.Should().Contain("hicham");
        }

        [Fact]
        public void ProcessGameSession_Success_ThreeOfKind_Score()
        {
            ProcessGameSession_Success_ThreeOfKind_Score_Data();

            var winners = PokerOperations.DefineTheWinners(_pokerGameSession.Players);

            winners.Count().Should().Be(1);
            winners.First().Should().Be("kid");
        }

        [Fact]
        public void ProcessGameSession_Success_Pair()
        {
            ProcessGameSession_Success_Pair_Data();

            var winners = PokerOperations.DefineTheWinners(_pokerGameSession.Players);

            winners.Count().Should().Be(1);
            winners.First().Should().Be("kid");
        }

        [Fact]
        public void ProcessGameSession_Success_Pair_Score()
        {
            ProcessGameSession_Success_Pair_Score_Data();

            var winners = PokerOperations.DefineTheWinners(_pokerGameSession.Players);

            winners.Count().Should().Be(1);
            winners.First().Should().Be("hicham");
        }

        [Fact]
        public void ProcessGameSession_Success_Score_Tie()
        {
            ProcessGameSession_Success_Score_Tie_Data();

            var winners = PokerOperations.DefineTheWinners(_pokerGameSession.Players);

            winners.Count.Should().Be(2);
            winners.Should().Contain("amber");
            winners.Should().Contain("kid");
        }

        [Fact]
        public void DefineTheWinners_ReturnNoWinner_NullList()
        {
            PokerOperations.DefineTheWinners(null).Should().BeEmpty();
        }

        [Fact]
        public void DefineTheWinners_ReturnNoWinner_EmptyList()
        {
            PokerOperations.DefineTheWinners(new Dictionary<string, Player>()).Should().BeEmpty();
        }
    }
}
