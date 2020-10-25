namespace PokerHandShowdown
{
    public interface IPlayer
    {
        string Name { get; set; }
        Hand Hand { get; set; }
    }
}