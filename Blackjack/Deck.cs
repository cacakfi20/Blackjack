namespace Blackjack;
using System.Linq;

public class Deck
{
    private static Object[] deck = new Object[52];

    public static void CreateDeck()
    {
        string[] ValueArr = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        string[] ColorArr = {"Hearts", "Diamonds", "Clubs", "Spades"};
        
        int index = 0;
        foreach (string val in ValueArr)
        {
            foreach (string col in ColorArr)
            {
                Card card = new Card(val, col);
                deck[index] = card;
                index++;
            }
        }
    }
    public static void WriteDeck()
    {
        foreach (Card card in deck)
        {
            Console.WriteLine(card.Value + card.Color);
        }
    }

    public static void Shuffle()
    {
        Random rnd = new Random();
        deck = deck.OrderBy(x => rnd.Next()).ToArray();
    }
}