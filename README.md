# Poker Hand Showdown

## Requirements:

Implement a library (in C#) which evaluates who are the winner(s) among several 5 card
poker hands. Need only need to implement a subset of the regular poker hands: Flush, Three of a Kind, One Pair and High Card.
Create a sample unit test for the library.
    
## Assumptions:
    - Poker hands by power are Flush, Three of a Kind, One Pair and High Card.
    - Ace is the Highest number in the deck.
    - The highest ranking hand is the winning hand. There is always at least one winner.
    - The number of hands/Players is a positive random integer.
    - The number of cards in a hand is a positive of 5 cards.
    - Only one Deck is used for each game session (No duplicate cards).
    - If one or more players are winning we called a Tie.
    - There is a possibility of having same score for all winning category.

### Tools used :
   - Git/SourceTree
   - Visual Studio Mac
   - Visual Paradigm

### Project solution contains:

    1. Demo Application (Console Application)
    2. .NetCore (Class Library)
    3. XUnit Test Prpject (Unit test)

## Detailed Algorithm and initial diagram

#### *Algorithm for each hand*.
1. Check for Flush
2. Order the card array descending by rank
3. Check if all cards has same suit
4. If its true return flush.
5. Otherwise 
6. Find dominant rank.
7. Check if dominant rank present more three or more time in hand.
8. If its true return ThreeOfKind.
9. Otherwise
10. Check if dominant rank is present two times in one hand
11. If its true return Pair
12. Calculate full score by sum all ranks in the hand

#### *Algorithm for each game session*.
1. Input player's name.
2. Check player's name existance/validate.
3. Add Player.
4. Distribute Card/Cards.
5. Validate Card/Cards.
6. Prepare players hands.
7. Check of winners.
8. Return Winners.

![Action Diagram \{different from final implementation\}](PokerHandShowdown/Basic Activity Diagram.vpd.png)

