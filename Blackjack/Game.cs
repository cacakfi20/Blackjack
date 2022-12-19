namespace Blackjack;

public class Game
{
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

    public static void NextCard()
    {
        if (Player.CardTotal != 21)
        {
            bool more = true;
            while (more)
            {
                Console.WriteLine("Chceš další kartu? a - ano, n - ne, d - double");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "d":
                        if (Player.Bet * 2 <= Player.Money + Player.Bet)
                        {
                            Player.Bet = Player.Bet * 2;
                            Player.Money = Player.Money - Player.Bet;
                            Dealer.DealCardPlayer();
                            Player.WriteHand();
                            Player.CountHand();
                            if (Player.CardTotal <= 21)
                            {
                                more = false;
                                while (Player.CardTotal > Dealer.CardTotal && Dealer.CardTotal < 21 )
                                {
                                    Dealer.DealCardDealer();
                                    Dealer.CountDealerHand();
                                }
                        
                                Dealer.WriteDealerCards();

                                if (Player.CardTotal == Dealer.CardTotal)
                                {
                                    Console.WriteLine("Remíza! Vsazené peníze se ti vrací.");
                                    Player.Money = Player.Money + Player.Bet;
                                }
                                else if (Player.CardTotal < Dealer.CardTotal && Dealer.CardTotal < 21 )
                                {
                                    Player.Money = Player.Money - 3 * Player.Bet;
                                    Console.WriteLine("Prohrál jsi");    
                                }
                                else
                                {
                                    Console.WriteLine("Vyhrál jsi!");
                                    Player.Money = Player.Money + 3 * Player.Bet;
                                }
                            }
                            else
                            {
                                Player.Money = Player.Money - 3 * Player.Bet;
                                Console.WriteLine("Prohrál jsi!1");
                            }
                        }
                        break;
                    case "y":
                        Dealer.DealCardPlayer();
                        Player.WriteHand();
                        Player.CountHand();
                        break;
                    case "n":
                        more = false;
                        while (Player.CardTotal > Dealer.CardTotal && Dealer.CardTotal < 21 )
                        {
                            Dealer.DealCardDealer();
                            Dealer.CountDealerHand();
                        }
                        
                        Dealer.WriteDealerCards();

                        if (Player.CardTotal == Dealer.CardTotal)
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
                        Console.WriteLine("vyber prosím buď 'y' nebo 'n'");
                        break;
                }
            }
        }
    }

    public static void Zebricek()
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Black Jack se hraje proti krupiérovi, kterému se zde říká dealer, tedy proti banku.");
        Console.WriteLine("Cílem hry je vytáhnout tolik karet, dokud nebude přebita dealerova karta, nesmí se však překročit počet bodů 21.");
        Console.WriteLine("Dealer má vždy jednu kartou ze dvou zakrytou. Po ukončení kola všech hráčů otáčí druhou kartu a následně přebíjí ostatní hrající hráče");
        Console.WriteLine("-------------------------------------");
    }

    public static void Pravidla()
    {
        
    }
}