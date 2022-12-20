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
        bool menu = true;

        while (menu)
        {
            Console.WriteLine("BLACKJACK");
            Console.WriteLine("-----------");
            Console.WriteLine("Vyber možnost(1 - hrát, 2 - žebříček, 3 - pravidla, 4 - ukončit)");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Game.StartGame();
                    Game.NextCard();
                    Game.ZebricekUloz();
                    break;
                case "2":
                    Game.ZebricekNapis();
                    break;
                case "3":
                    Game.Pravidla();
                    break;
                case "4":
                    menu = false;
                    break; 
            }
        }
    }

}