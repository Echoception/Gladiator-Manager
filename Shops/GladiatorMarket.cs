using Gladiator_Manager.Facilities;
using Gladiator_Manager.Gladiators;
using Gladiator_Manager.Input;
using Gladiator_Manager.PlayerClass;
using Gladiator_Manager.SystemCreators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Shops
{
    internal class GladiatorMarket
    {
        public GladiatorMarket()
        {
            _gladiatorsForSale = new();
            _rank = 1;
        }


        private List<Gladiator> _gladiatorsForSale { get; set; }
        private int _rank { get; set; }
        private int _listLength => 3 * _rank;


        public List<Gladiator> GladiatorsForSale => _gladiatorsForSale;
        public int Rank => _rank;



        public void RandomiseGladiatorsForSale(GladiatorCreator gladiatorCreator)
        {
            _gladiatorsForSale.Clear();
            //Gladiator gladiator = new Gladiator("OP", 200, 100, 100, 100, 100);
            //for (int i = 0; i < _listLength; i++)
            //{
            //    _gladiatorsForSale.Add(gladiator);
            //}

            for (int i = 0; i < _listLength; i++)
            {
                Gladiator gladiator = gladiatorCreator.CreateRandomGladiator();
                _gladiatorsForSale.Add(gladiator);
            }
        }

        private void DisplayGladiatorsForSale(Player player)
        {
            int count = 1;

            Console.Clear();
            Console.WriteLine();
            player.DisplayGold();

            Console.WriteLine($"{Environment.NewLine}Pick a gladiator to view: {Environment.NewLine}");

            foreach (var glad in GladiatorsForSale)
            {
                Console.Write($"[{count}] {glad.Name} - Rating {glad.Rating} - Price:  ");
                glad.DisplayBuyPrice();
                Console.WriteLine();

                count++;
            }

            Console.WriteLine($"{Environment.NewLine}Press 0 to EXIT");
        }

        public void BuyOrSellMenu(UserInput userInput, Player player, Accommodations accommodations)
        {
            int choice = 99;
            do
            {
                Console.Clear();
                Console.WriteLine();
                player.DisplayGold();

                Console.WriteLine($"{Environment.NewLine}Would you like to buy or sell: {Environment.NewLine}");
                Console.WriteLine("[1] - Buy");
                Console.WriteLine("[2] - Sell");
                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch (choice)
                {
                    case 1:
                        BuyGladiators(player, userInput, accommodations);
                        break;

                    case 2:
                        SellGladiators(player, userInput);
                        break;

                    case 0:
                        return;

                    default:
                        userInput.DisplayPickValidOptionText();
                        break;
                }
            } while (choice != 0);
        }

        private void BuyGladiators(Player player, UserInput userInput, Accommodations accommodations)
        {

            DisplayGladiatorsForSale(player);
 
            int choice = 99;

            do
            { 
            
                choice = userInput.PickItemFromList(GladiatorsForSale);
            
                if (choice > 0)
                {
                    Console.Clear();
                    Console.WriteLine();
                    player.DisplayGold();

                    GladiatorsForSale[choice - 1].DisplayStats();
                    GladiatorsForSale[choice - 1].DisplayBuyPrice();
                    Console.WriteLine();
                    Console.WriteLine($"{Environment.NewLine}Would you like to buy this gladiator? {Environment.NewLine}");
                    bool buy = userInput.PickYesOrNo();

                    if(buy && player.Gold >= GladiatorsForSale[choice - 1].BuyPrice)
                    {
                        if(player.GladiatorList.Count >= accommodations.AccommodationSize)
                        {
                            Console.WriteLine("You do not have enough space in your accommodations");
                            Console.ReadKey();
                        }
                        else
                        {
                            player.RemoveGold(GladiatorsForSale[choice - 1].BuyPrice);
                            _gladiatorsForSale[choice - 1].IsPlayersTrue();
                            player.AddGladiatorToRoster(GladiatorsForSale[choice - 1]);
                            _gladiatorsForSale.Remove(GladiatorsForSale[choice - 1]);
                        }
                    }
                    else
                    {
                        if(choice == 0)
                        {
                            Console.WriteLine("You do not have enough gold");
                            Console.ReadKey();
                        }
                    }
                }

                DisplayGladiatorsForSale(player);

            } while (choice > 0);

        }

        private void SellGladiators(Player player, UserInput userInput)
        {
            Console.Clear();

            if (player.GladiatorList.Count > 0)
            {
                int count = 1;
                Console.WriteLine();
                player.DisplayGold();
                
                Console.WriteLine($"{Environment.NewLine}Pick a gladiator to sell: {Environment.NewLine}");

                foreach(Gladiator glad in player.GladiatorList)
                {
                    Console.Write($"[{count}] {glad.Name} - Rating {glad.Rating} - Price:  ");
                    glad.DisplaySalePrice();

                    if (glad.InFacilities)
                    {
                        Console.Write("    [ Using Facilities ]");
                    }
                    Console.WriteLine();
                    count++;
                }

                Console.WriteLine();
                Console.WriteLine("[0] - EXIT");
                int choice = userInput.PickItemFromList(player.GladiatorList);

                if (choice > 0)
                {
                    Console.WriteLine($"{Environment.NewLine}Are you sure you want to sell {player.GladiatorList[choice - 1].Name}?");
                    bool confirm = userInput.PickYesOrNo();

                    if (confirm)
                    {
                        player.AddGold(player.GladiatorList[choice - 1].SalePrice);
                        player.RemoveGladiatorFromList(choice - 1);
                    }
                    else
                    {
                        return;
                    }

                }
            }
            else
            {
                Console.WriteLine("You have no gladiators to sell");
                Console.ReadKey();
            }



            //----
        }
    }
}
