using System.Collections.Generic;
using System.Linq;

namespace PokerHandShowdown
{
    public static class PokerOperations
    {
        public static List<string> DefineTheWinners(Dictionary<string, Player> players)
        {
            var winnersList = new List<string>();
            if(players?.Any() == true)
            {
                CheckForFlushHand(players, winnersList);
                if (!winnersList.Any())
                {
                    CheckForThreeOfKindHand(players, winnersList);
                    if (!winnersList.Any())
                    {
                        var listOfPairPlayer = players.Values.Where(p => p.Hand.SetType == SetType.OnePair).ToArray();
                        if (listOfPairPlayer.Any())
                        {
                            GetRankWinner(winnersList, listOfPairPlayer);
                        }
                        else
                        {
                            var winners = players.OrderByDescending(p => p.Value.Hand.Score).GroupBy(g => g.Value.Hand.Score).First().ToArray();
                            winnersList.AddRange(winners.Select(x => x.Value.Name));
                        }
                    }
                }
            }

            return winnersList;
        }

        private static void CheckForThreeOfKindHand(Dictionary<string, Player> listOfWinningCards, List<string> winnersList)
        {
            var listOfPlayersThreeOfKind = listOfWinningCards.Values.Where(p => p.Hand.SetType == SetType.ThreeOfKind).ToArray();
            if (listOfPlayersThreeOfKind.Any())
            {
                GetRankWinner(winnersList, listOfPlayersThreeOfKind);
            }
        }

        private static void CheckForFlushHand(Dictionary<string, Player> listOfWinningCards, List<string> winnersList)
        {
            var listPlayersFlush = listOfWinningCards.Values.Where(p => p.Hand.SetType == SetType.Flush).ToArray();
            if (listPlayersFlush.Any())
            {
                if (listPlayersFlush.Length > 1)
                {
                    var winnersDictionary = listPlayersFlush.OrderByDescending(p => p.Hand.Score).GroupBy(p => p.Hand.Score);
                    var winners = winnersDictionary.Select(w => w.ToArray());
                    if (winners.First().Count() == 1)
                    {
                        winnersList.Add(winners.First().First().Name);
                    }
                    else
                    {
                        winnersList.AddRange(winners.First().Select(w => w.Name));
                    }
                }
                else
                {
                    winnersList.Add(listPlayersFlush.First().Name);
                }
            }
        }

        private static void GetRankWinner(List<string> winnersList, Player[] listOfPlayersThreeOfKind)
        {
            if (listOfPlayersThreeOfKind.Length > 1)
            {
                var winner = listOfPlayersThreeOfKind.OrderByDescending(p => p.Hand.Score).First();
                winnersList.Add(winner.Name);
            }
            else
            {
                var winner = listOfPlayersThreeOfKind.First();
                winnersList.Add(winner.Name);
            }
        }

    }
}
