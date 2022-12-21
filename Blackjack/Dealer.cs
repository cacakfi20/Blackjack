namespace Blackjack;

public class Dealer
{
    public static Object[] Hand = new Object[0];
    public static int CardTotal { get; set; }

    // rozdá kartu hráči
    public static void DealCardPlayer()
    {
        Player.GetCard(Deck.ReturnCardFromTopDeck());
        Deck.RemoveTopCard();
    }
    
    // pracuji s arrayem tudíž musim nastavit pro začnutí nové hry velikost ruky zpet na 0
    public static void ResetHand()
    {
        Array.Resize(ref Hand, 0);
    }

    // dealer dá kartu sobě
    public static void DealCardDealer()
    {
        Array.Resize(ref Hand, Hand.Length + 1);
        Hand[Hand.Length - 1] = Deck.ReturnCardFromTopDeck();
        Deck.RemoveTopCard();
    }

    // vypíše dealerovi karty
    public static void WriteDealerCards()
    {
        Console.WriteLine("Dealerovi karty:");
        foreach (Card card in Hand)
        {
            Console.WriteLine($"{card.Value} {card.Color}" );
        }
    }
    
    // spočítá dealerovu ruku
    public static void CountDealerHand()
    {
        int totalValue = 0;
        int aceCount = 0;
        foreach (Card card in Hand)
        {
            switch (card.Value)
            {
                case "A":
                    totalValue += 11;
                    aceCount++;
                    break;
                case "J":
                    totalValue += 10;
                    break;
                case "Q":
                    totalValue += 10;
                    break;
                case "K":
                    totalValue += 10;
                    break;
                default:
                    totalValue += int.Parse(card.Value);
                    break;
            }
        }

        if (totalValue > 21 && aceCount > 0)
        {
            for (int i = 0; i < aceCount; i++)
            {
                if (totalValue > 21)
                {
                    totalValue -= 10;
                }
                else
                {
                    break;
                }
            }
        }

        CardTotal = totalValue;
    }

}