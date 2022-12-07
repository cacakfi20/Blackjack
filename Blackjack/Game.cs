namespace Blackjack;

public class Game
{
    public static void StartGame()
    {
        bool game = true;
        while (game)
        {
            Deck.CreateDeck();
            Deck.WriteDeck();
        }
    }
}