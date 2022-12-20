namespace Blackjack;


class Blackjack
{
    static void Main()
    {
        bool namebool = false;
        while (!namebool)
        {
            Console.WriteLine("Napiš svoje jméno...");
            string name = Console.ReadLine();
            bool empty = string.IsNullOrEmpty(name);
            bool space = string.IsNullOrWhiteSpace(name);
            if (empty || space)
            {
                Console.WriteLine("Nejedná se o validní string");
            }
            else
            {
                Player.Name = name;
                Player.Money = 5000;
                namebool = true;
            }
        }
        
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