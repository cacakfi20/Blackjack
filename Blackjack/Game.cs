namespace Blackjack;

public class Game
{
    public static void StartGame()
    {
        bool game = true;
        while (game)
        {
            Deck.CreateDeck();
            Deck.Shuffle();
            Deck.WriteDeck();
            Console.ReadLine();
        }
    }

    public static void Zebricek()
    {
        
    }

    public static void Pravidla()
    {
        
    }
}