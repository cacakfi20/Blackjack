namespace Blackjack;

public class Deck
{
    public static List<string> Cards { get; set; }

    public static void CreateDeck()
    {
        Card.CreateCard();
    }
    public static void DeckAppend(string card)
    {
        Cards.Add(card);
    }

    public static void WriteDeck()
    {
        foreach (var VARIABLE in Cards)
        {
            Console.WriteLine(VARIABLE);
        }
    }
}