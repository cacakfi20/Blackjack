namespace Blackjack;


class Blackjack
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("BLACKJACK");
            Console.WriteLine("-----------");
            Console.WriteLine("Vyber možnost(1 - hrát, 2 - žebříček, 3 - pravidla, 4 - ukončit)");
            Console.ReadLine();
            //Card.CreateCard();
            Game.StartGame();
            //Card.write();    
        }
    }

}