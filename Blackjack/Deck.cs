namespace Blackjack;

public class Deck
{
    public static Object[] deck = new Object[52];

    public static void CreateDeck()
    {
        Card.CreateCard();
    }
    public static void WriteDeck()
    {
        for (int i = 0; i < 52; i++)
        {
            //System.Diagnostics.Debug.WriteLine(deck[i]);
            Console.WriteLine(deck[i].ToString());
        }
    }
}