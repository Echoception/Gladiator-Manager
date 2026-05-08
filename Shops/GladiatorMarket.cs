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
            Gladiator gladiator = new Gladiator("OP", 200, 100, 100, 100, 100);
            for (int i = 0; i < _listLength; i++)
            {
                _gladiatorsForSale.Add(gladiator);
            }

            //for(int i = 0; i < _listLength; i++)
            //{
            //    Gladiator gladiator = gladiatorCreator.CreateRandomGladiator();
            //    _gladiatorsForSale.Add(gladiator);
            //}
        }

        private void DisplayGladiatorsForSale()
        {
            int count = 1;

            Console.Clear();
            Console.WriteLine($"{Environment.NewLine}Pick a gladiator to view: {Environment.NewLine}");

            foreach (var glad in GladiatorsForSale)
            {
                Console.WriteLine($"[{count}] {glad.Name} - {glad.Rating}");
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

        public void BuyGladiators(Player player, UserInput userInput, Accommodations accommodations)
        {

            DisplayGladiatorsForSale();
 
            int choice = 99;

            do
            { 
            
                choice = userInput.PickItemFromList(GladiatorsForSale);
            
                if (choice > 0)
                {
                    Console.Clear();
                    GladiatorsForSale[choice - 1].DisplayStats();
                    Console.WriteLine($"{Environment.NewLine}Would you like to buy this gladiator? {Environment.NewLine}");
                    bool buy = userInput.PickYesOrNo();

                    if(buy)
                    {
                        if(player.GladiatorList.Count >= accommodations.AccommodationSize)
                        {
                            Console.WriteLine("You do not have enough space in your accommodations");
                            Console.ReadKey();
                        }
                        else
                        {
                            _gladiatorsForSale[choice - 1].IsPlayersTrue();
                            player.AddGladiatorToRoster(GladiatorsForSale[choice - 1]);
                            _gladiatorsForSale.Remove(GladiatorsForSale[choice - 1]);
                        }
                    }
                }

                DisplayGladiatorsForSale();

            } while (choice > 0);

            //Console.WriteLine("EXITED");
            //Console.ReadKey();
        }

        public void SellGladiators(Player player, UserInput userInput)
        {
            Console.Clear();

            if (player.GladiatorList.Count > 0)
            {
                Console.WriteLine($"{Environment.NewLine}Pick a gladiator to sell: ");

                player.DisplayGladiatorList();
                Console.WriteLine();
                Console.WriteLine("[0] - EXIT");
                int choice = userInput.PickItemFromList(player.GladiatorList);

                if (choice > 0)
                {
                    Console.WriteLine($"{Environment.NewLine}Are you sure you want to sell {player.GladiatorList[choice - 1].Name}?");
                    bool confirm = userInput.PickYesOrNo();

                    if (confirm)
                    {
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
