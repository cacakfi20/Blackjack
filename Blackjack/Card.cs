namespace Blackjack;

public class Card
{
    public static string[] ValueArr = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    public static string[] ColorArr = new string[] {"Hearts", "Diamonds", "Clubs", "Spades"};
    public string Value;
    public string Color;
    
    public Card(string value, string color)
    {
        Value = value;
        Color = color;
    }
    
    public static void CreateCard()
    {
        int index = 0;
        foreach (string val in ValueArr)
        {
            foreach (string col in ColorArr)
            {
                Card card = new Card(val, col);
                //Console.WriteLine($"{card.Value}, {card.Color}");
                Deck.deck[index] = card;
                index++;
            }
        }
    }
}