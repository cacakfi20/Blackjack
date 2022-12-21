namespace Blackjack;


class Blackjack
{
    // základní logika hry 
    static void Main()
    {
        // kontrola jména
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

        // hlavní menu
        while (menu)
        {
            Console.WriteLine("-----------");
            Console.WriteLine("BLACKJACK");
            Console.WriteLine("-----------");
            Console.WriteLine("Vyber možnost(1 - hrát, 2 - žebříček, 3 - pravidla, 4 - ukončit)");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (choice)
            {
                // case hrát
                case '1':
                    if (Player.Money > 0)
                    {
                        Game.StartGame();
                        Game.NextCard();
                        Game.ZebricekUloz();
                    }
                    else
                    {
                        Console.WriteLine("Nemáš peníze na další hru");
                        Console.WriteLine("Chceš začít znovu (a - ano, n - zpět do menu, k - konec)");
                        char ch = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        switch (ch)
                        {
                            // case hrát znovu na stejne jmeno s novyma penezma
                            case 'a':
                                Player.Money = 5000;
                                Game.StartGame();
                                Game.NextCard();
                                Game.ZebricekUloz();
                                break;
                            // case na navrat do menu (pokud by se chtěl hráč podívat na žebricek nebo pravidla)
                            case 'n':
                                break;
                            // case na ukonceni hry
                            case 'k':
                                menu = false;
                                break;
                        }
                    }
                    break;
                // case zebricek
                case '2':
                    Game.ZebricekNapis();
                    break;
                // case pravidla
                case '3':
                    Game.Pravidla();
                    break;
                // case ukonceni hry
                case '4':
                    menu = false;
                    break; 
            }
        }
    }

}