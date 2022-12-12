namespace Blackjack;

public class Game
{
    public static void StartGame()
    {
        bool game = true;
        while (game)
        {
            Card.CreateCard();
            Deck.WriteDeck();
            Console.ReadLine();
        }
    }
}