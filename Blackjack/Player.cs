namespace Blackjack;

public class Player
{
    public static string Name { get; set; }
    public static int Money { get; set; }
    private static Object[] Hand = new Object[0];

    public static void GetCard(object card)
    {
        Array.Resize(ref Hand, Hand.Length + 1);
        Hand[Hand.Length - 1] = card;
    }

    public static void WriteHand()
    {
        Console.WriteLine("Vaše karty:");
        foreach (Card card in Hand)
        {
            Console.WriteLine(card.Value + card.Color);
        }
    }

    public static void CountHand()
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