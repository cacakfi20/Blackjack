namespace Blackjack;

public class Card
{
    public static List<string> Value;
    public static List<string> Color;

    public Card()
    {
        Value = new List<string>() { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        Color = new List<string>() {"♤", "♧", "♡", "♢"};
    }

   public static void CreateCard()
    {
        foreach (string value in Value)
        {
            foreach (string color in Color)
            {
                string card = $"{value}, {color}";
                Deck.DeckAppend(card);
            }
        }
    }

    public static void write()
    {
        foreach (var VARIABLE in Value)
        {
            Console.WriteLine(VARIABLE);
        }
    } 
}