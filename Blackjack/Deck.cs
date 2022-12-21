namespace Blackjack;
using System.Linq;

public class Deck
{
    private static Object[] deck = new Object[52];

    // vytvoření decku
    public static void CreateDeck()
    {
        string[] ValueArr = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        string[] ColorArr = {"Hearts", "Diamonds", "Clubs", "Spades"};

        // stejný princip jako v Pythonu minulý rok
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
    
    // funkci nepoužívám (při práci pouze pro kontrolu zda vše funguje jak má)
    public static void WriteDeck()
    {
        foreach (Card card in deck)
        {
            Console.WriteLine(card.Value + card.Color);
        }
    }

    // zamíchá balík
    public static void Shuffle()
    {
        Random rnd = new Random();
        deck = deck.OrderBy(x => rnd.Next()).ToArray();
    }

    // vrátí první kartu v balíku
    public static object ReturnCardFromTopDeck()
    {
        return deck[deck.Length-1];
    }

    // odebere první kartu v balíku (šlo by sloučit s funkcí nad)
    public static void RemoveTopCard()
    {
        Array.Resize(ref deck, deck.Length - 1);
    }

    // pracuji s arrayem tudíž musim nastavit pro začnutí nové hry velikost baliku zpet na 52
    public static void ResetDeck()
    {
        Array.Resize(ref deck, 52);
    }
}