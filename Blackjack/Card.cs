namespace Blackjack;

public class Card
{
    public List<string> Value;
    public List<string> Color;

    public Card(List<string> _value, List<string> _color)
    {
        Value = new List<string>() { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        Color = new List<string>() {"♤", "♧", "♡", "♢"};
    }

    public string CreateCard()
    {
        foreach (var value in Value)
        {
            foreach (var color in Color)
            {
                return value + color;
            }
        }
    }
}