namespace Blackjack;

public class Player
{
    public static string Name { get; set; }
    public static int Money { get; set; }
    public static int Bet { get; set; }
    
    public static int CardTotal { get; set; }
    public static Object[] Hand = new Object[0];

    // Hráč obrží kartu od dealera
    public static void GetCard(object card)
    {
        Array.Resize(ref Hand, Hand.Length + 1);
        Hand[Hand.Length - 1] = card;
    }

    // Vypíše karty v ruce
    public static void WriteHand()
    {
        Console.WriteLine("Vaše karty:");
        foreach (Card card in Hand)
        {
            Console.WriteLine($"{card.Value} {card.Color}");
        }
    }

    // pracuji s arrayem tudíž musim nastavit pro začnutí nové hry velikost ruky zpet na 0
    public static void ResetHand()
    {
        Array.Resize(ref Hand, 0);
    }
    
    // vložení částky + kontrola vstupu
    public static void BetMoney()
    {
        bool betting = true;
        while (betting)
        {
            int sazka;
            Console.WriteLine($"Kolik chceš vsadit? (Tvoje peníze: {Money})");
            string sazkaStr = Console.ReadLine();
            int.TryParse(sazkaStr, out sazka);
            // kontrola zda je input validní
            if (sazka > Money)
            {
                Console.WriteLine("Nemáš dostatek peněz");
            }
            else if (!int.TryParse(sazkaStr, out sazka))
            {
                Console.WriteLine("Musíš napsat částku");
            }
            else
            {
                Bet = sazka;
                Money = Money - sazka;
                Console.WriteLine($"Tvůj zustatek: {Money}");
                betting = false;
            }
        }
    }

    // spočítá karty v ruce  
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

        // ošetření Aček, kdy bude A = 1 a kdy A = 11
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
        Console.WriteLine($"Tvůj počet je: {CardTotal}");
    }

}