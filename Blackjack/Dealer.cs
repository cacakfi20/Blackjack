namespace Blackjack;

public class Dealer
{
    private static Object[] Hand = new Object[0];

    public static void DealCardPlayer()
    {
        Player.GetCard(Deck.ReturnCardFromTopDeck());
        Deck.RemoveTopCard();
    }

    public static void DealCardDealer()
    {
        Array.Resize(ref Hand, Hand.Length + 1);
        Hand[Hand.Length - 1] = Deck.ReturnCardFromTopDeck();
    }

    public static void WriteDealerCards()
    {
        Console.WriteLine("Dealerovi karty:");
        foreach (Card card in Hand)
        {
            Console.WriteLine(card.Value + card.Color);
        }
    }
    
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

        if (totalValue > 21 && aceCount > 1)
        {
            totalValue -= 10;
        }
        Console.WriteLine(totalValue);
    }

}