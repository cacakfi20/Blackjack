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
            Console.WriteLine("------------");
            Dealer.DealCardPlayer();
            Dealer.DealCardPlayer();
            Player.WriteHand();
            Player.CountHand();
            Dealer.DealCardDealer();
            Dealer.WriteDealerCards();
            Dealer.CountDealerHand();
            Console.WriteLine("------------");
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