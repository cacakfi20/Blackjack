using System.Runtime.Serialization;

namespace Blackjack;

public class Game
{
    // funkce pro započetí hry (vytvoreni a zamichani baliku, 1 karta pro dealera, 2 pro hráče, vypsani rukou)
    public static void StartGame()
    {
        Deck.ResetDeck();
        Dealer.ResetHand();
        Player.ResetHand();
        Console.Clear();
        Player.BetMoney();
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
    }

    // metoda pro další kartu pro hráče/double/ukončení + kontrola vyhry nebo prohry
    public static void NextCard()
    {
        if (Player.CardTotal != 21)
        {
            bool more = true;
            while (more)
            {
                Console.WriteLine("Chceš další kartu? a - ano, n - ne, d - double");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choice)
                {
                    // case double down - zvojnásobení sázky + poslední karta
                    case 'd':
                        if (Player.Bet * 2 <= Player.Money + Player.Bet)
                        {
                            more = false;
                            Player.Money = Player.Money - Player.Bet;
                            Dealer.DealCardPlayer();
                            Player.WriteHand();
                            Player.CountHand();
                            if (Player.CardTotal <= 21)
                            {
                                while (Player.CardTotal > Dealer.CardTotal && Dealer.CardTotal <= 21 )
                                {
                                    Dealer.DealCardDealer();
                                    Dealer.CountDealerHand();
                                }
                        
                                Dealer.WriteDealerCards();

                                if (Dealer.CardTotal ==  21)
                                {
                                    Console.WriteLine("Prohrál jsi!");
                                }

                                else if (Player.CardTotal == Dealer.CardTotal)
                                {
                                    Console.WriteLine("Remíza! Vsazené peníze se ti vrací.");
                                    Player.Money = Player.Money + Player.Bet * 2;
                                }
                                else if (Player.CardTotal < Dealer.CardTotal && Dealer.CardTotal < 21 )
                                {
                                    Console.WriteLine("Prohrál jsi");    
                                }
                                else
                                {
                                    Console.WriteLine("Vyhrál jsi!");
                                    Player.Money = Player.Money + 4 * Player.Bet;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Prohrál jsi!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Na double nemáš dostatek peněz");
                        }
                        break;
                    // case ano - dalsi karta pro hrace
                    case 'a':
                        Console.Clear();
                        Dealer.DealCardPlayer();
                        Player.WriteHand();
                        Player.CountHand();
                        Dealer.WriteDealerCards();
                        Dealer.CountDealerHand();
                        if (Player.CardTotal == 21 )
                        {
                            Console.WriteLine("Vyhrál jsi!");
                            Player.Money = Player.Money + 2 * Player.Bet;
                            more = false;
                        }
                        if (Player.CardTotal > 21)
                        {
                            Console.WriteLine("Prohrál jsi!");
                            more = false;
                        }
                        break;
                    // case ne - hráč neobdří kartu a v lízání karet pokračuje dealer
                    case 'n':
                        Console.Clear();
                        Player.WriteHand();
                        Player.CountHand();
                        more = false;
                        while (Player.CardTotal > Dealer.CardTotal && Dealer.CardTotal < 21 )
                        {
                            Dealer.DealCardDealer();
                            Dealer.CountDealerHand();
                        }
                        
                        Dealer.WriteDealerCards();
                        Console.WriteLine($"Dealerův součet je: {Dealer.CardTotal} ");

                        if (Dealer.CardTotal == 21)
                        {
                            Console.WriteLine("Prohrál jsi!");
                        }

                        else if (Player.CardTotal == Dealer.CardTotal)
                        {
                            Console.WriteLine("Remíza! Vsazené peníze se ti vrací.");
                            Player.Money = Player.Money + Player.Bet;
                        }
                        else if (Player.CardTotal < Dealer.CardTotal && Dealer.CardTotal < 21 )
                        {
                            Console.WriteLine("Prohrál jsi");    
                        }
                        else
                        {
                            Console.WriteLine("Vyhrál jsi!");
                            Player.Money = Player.Money + 2 * Player.Bet;
                        }
                        break;
                    default:
                        Console.WriteLine("vyber prosím buď 'a', 'n', nebo 'd'");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Vyhrál jsi!");
            Player.Money += 2 * Player.Bet;
        }
    }

    // ulozeni do zebricku po kazdem kole pokud je skore lepsi nez bylo kdysi na stejné jméno
    public static void ZebricekUloz()
    {
        string path = @"zebricek.csv";
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        
        StreamReader sr = new StreamReader(path);
        List<string[]> data = new List<string[]>();

        string line;
        bool nick_name = false;

        while((line = sr.ReadLine()) != null)
        {
            string[] fields = line.Split(';');
            Int32.TryParse(fields[1], out int value);
            if (fields[0] == Player.Name && value < Player.Money)
            {
                fields[1] = Player.Money.ToString();
                nick_name = true;
            }
            else if (fields[0] == Player.Name && value >= Player.Money)
            {
                nick_name = true;
            }
            data.Add(fields);
        }

        if (!nick_name)
        {
            string[] pole = new string[2];
            pole[0] = Player.Name;
            pole[1] = Player.Money.ToString();
            data.Add(pole);
        }

        sr.Close();

        StreamWriter sw = new StreamWriter(path);
        foreach (string[] udaj in data)
        {
            string newline = string.Format("{0};{1}", udaj[0], udaj[1]);
            sw.WriteLine(newline);
        }

        sw.Close();
    }

    // Vypíše 5 nejlepších hráčů + jejich skore
    public static void ZebricekNapis()
    {
        string path = @"zebricek.csv";
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }

        StreamReader sr = new StreamReader(path);
        List<Tuple<string, int>> data = new List<Tuple<string, int>>();

        string line;
        bool nick_name = false;

        while ((line = sr.ReadLine()) != null)
        {
            string[] fields = line.Split(";");
            Int32.TryParse(fields[1], out int value);
            string name = fields[0];
            Tuple<string, int> pole = new Tuple<string, int>(name, value);
            data.Add(pole);
        }

        data = data.OrderByDescending(x => x.Item2).ToList();
        var best = data.Take(5);

        int i = 0;
        foreach (Tuple<string, int> pair in best)
        {
            Console.Write($"{i}. ");
            Console.WriteLine($"{pair.Item1} - {pair.Item2}");
            i++;
        }

        sr.Close();
    }

    // Vypíše pravidla
    public static void Pravidla()
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Black Jack se hraje proti krupiérovi, kterému se zde říká dealer, tedy proti banku.");
        Console.WriteLine("Cílem hry je vytáhnout tolik karet, dokud nebude přebita dealerova karta, nesmí se však překročit počet bodů 21.");
        Console.WriteLine("Dealer má vždy jednu kartou ze dvou zakrytou. Po ukončení kola všech hráčů otáčí druhou kartu a následně přebíjí ostatní hrající hráče");
        Console.WriteLine("-------------------------------------");
    }
}