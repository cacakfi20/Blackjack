namespace Blackjack;


class Blackjack
{
    static void Main()
    {
        Console.WriteLine("Napiš svoje jméno...");
        string name = Console.ReadLine();
        Player.Name = name;
        Player.Money = 5000;
        
        Console.WriteLine($"Vítej hráči '{Player.Name}'");

        while (true)
        {
            Console.WriteLine("BLACKJACK");
            Console.WriteLine("-----------");
            Console.WriteLine("Vyber možnost(1 - hrát, 2 - žebříček, 3 - pravidla, 4 - ukončit)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Game.StartGame();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
            }
        }
    }

}