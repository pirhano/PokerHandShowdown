using System;
using System.Collections.Generic;
using System.Linq;
using PokerHandShowdown;

namespace PokerHandShowdownDemo
{
    class Program
    {
        static IPokerGameSession pokerGameSession = new PokerGameSession();
        static Dictionary<int, Card> cards = new Dictionary<int, Card>(52);

        static void Main(string[] args)
        {
            GenerateDeck();
            Console.WriteLine("##########| Poker Hand Showdown |##########");
            MainMenu();
        }

        private static void GenerateDeck()
        {
            var index = 0;
            foreach (PokerSuit suit in ((PokerSuit[])Enum.GetValues(typeof(PokerSuit))).Where(s => !s.Equals(PokerSuit.None)))
            {
                foreach (PokerRank rank in (PokerRank[])Enum.GetValues(typeof(PokerRank)))
                {
                    cards.Add(index++, new Card(suit, rank));
                }
            }
        }
        private static void DisplayDeck()
        {
            foreach (var card in cards)
            {
                if(card.Key%6==0)
                Console.WriteLine($"[{card.Key} ({card.Value.Rank},{card.Value.Suit})],");
                else
                Console.Write($"[{card.Key} ({card.Value.Rank},{card.Value.Suit})],");
            }
        }

        private static void AddCardsMenu()
        {
            Console.WriteLine();
            Console.WriteLine("###| Please Select one of the following options. |###");
            Console.WriteLine("###| 1. Dispatch Single Card. |###");
            Console.WriteLine("###| 2. Dispatch Cards. |###");
            Console.WriteLine("###| 3. Go Back. |###");
            Console.WriteLine("###| 4. Quit. |###");
            var option = Console.ReadKey().KeyChar.ToString();
            switch (option)
            {
                case "1":
                    DisplayDeck();
                    Console.WriteLine();
                    Console.WriteLine("###| Please Pick from the Deck above index of card to add. |###");
                    var index = Console.ReadLine().ToString();
                    var card = cards[int.Parse(index)];
                    Console.WriteLine($"||({card.Rank},{card.Suit}) picked!||");
                    Console.WriteLine("###| Please Enter player participant name: |###");
                    var playerName = Console.ReadLine().ToString();
                    pokerGameSession.DispatchCardsToPlayer(playerName, card);
                    AddCardsMenu();
                    break;
                case "2":
                    AddCardsMenu();
                    break;
                case "3":
                    MainMenu();
                    break;
                case "4": Environment.Exit(0); break;
            }
        }

        private static void AddPlayersMenu()
        {
            Console.WriteLine();
            Console.WriteLine("###| Please Select one of the following options. |###");
            Console.WriteLine("###| 1. Add Player. |###");
            Console.WriteLine("###| 2. Add Player and Cards. |###");
            Console.WriteLine("###| 3. Go Back. |###");
            Console.WriteLine("###| 4. Quit. |###");
            var option = Console.ReadKey().KeyChar.ToString();
            switch (option)
            {
                case "1":
                    Console.WriteLine("###| Please Enter Participant's name. |###");
                    var playerName = Console.ReadLine().ToString();
                    pokerGameSession.AddPlayer(playerName);
                    Console.WriteLine($"||({playerName}) added!||");
                    AddPlayersMenu();
                    break;
                case "2":
                    Console.WriteLine("###| Please Enter Participant's name. |###");
                    var playerName1 = Console.ReadLine().ToString();
                    Console.WriteLine();
                    DisplayDeck();
                    Console.WriteLine("###| Please Pick from the Deck above up to 5 indexs of cards to add.\r\n press enter after each index, when you finish press * |###");
                    var playerCards = new List<Card>();
                    for(var i = 0; i > 5; i++)
                    {
                        var index = Console.ReadLine().ToString();
                        if (index.Equals("*"))
                        {
                            break;
                        }
                        playerCards.Add(cards[int.Parse(index)]);
                    }
                    pokerGameSession.AddPlayer(playerName1,playerCards.ToArray());
                    Console.WriteLine($"||({playerName1}) added! || ");
                    AddPlayersMenu();
                    break;
                case "3":
                    MainMenu();
                    break;
                case "4": Environment.Exit(0); break;
            }
        }

        private static void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("###| Please Select one of the following options by pressing the number indicated and hit enter. |###");
            Console.WriteLine("###| 0. Show Cards to Determine the winner. |###");
            Console.WriteLine("###| 1. Add Players. |###");
            Console.WriteLine("###| 2. Add Cards. |###");
            Console.WriteLine("###| 3. Remove player. |###");
            Console.WriteLine("###| 4. Empty hands. |###");
            Console.WriteLine("###| 5. Get new Session. |###");
            Console.WriteLine("###| 6. Quit. |###");
            var option = Console.ReadKey().KeyChar.ToString();
            switch (option)
            {
                case "0":
                    ProcessGameSession();
                    break;
                case "1":
                    AddPlayersMenu();
                    break;
                case "2":
                    AddCardsMenu();
                    break;
                case "3":
                    Console.WriteLine("###| Please Enter name of participant(case sensitive). |###");
                    var playerName = Console.ReadLine().ToString();
                    try
                    {
                        pokerGameSession.RemoveParticipant(playerName);
                        Console.WriteLine($"||Player {playerName} removed||");
                    }
                    catch (Exception ex) when (ex is InvalidOperationException || ex is NullReferenceException)
                    {
                        Console.WriteLine($"!!!| Error {ex.Message}|!!!");
                    }
                    MainMenu();
                    break;
                case "4":
                    pokerGameSession.EmptyHands();
                    Console.WriteLine("||Hands Empty deck full||");
                    MainMenu();
                    break;
                case "5":
                    pokerGameSession.ClearSession();
                    Console.WriteLine("||New session created||");
                    MainMenu();
                    break;
                case "6": Environment.Exit(0); break;
                default:
                    Console.WriteLine(" Invalid Option");
                    MainMenu();
                    return;
            }
        }

        private static void ProcessGameSession()
        {
            throw new NotImplementedException();
        }
    }
}
