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

            for(int i = 0; i < _listLength; i++)
            {
                Gladiator gladiator = gladiatorCreator.CreateRandomGladiator();
                _gladiatorsForSale.Add(gladiator);
            }
        }

        private void DisplayGladiatorsForSale()
        {
            int count = 1;

            Console.Clear();
            Console.WriteLine($"{Environment.NewLine}Pick a gladiator to view: {Environment.NewLine}");

            foreach (var glad in GladiatorsForSale)
            {
                Console.WriteLine($"{count} - {glad.Name} - {glad.Rating}");
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
                        Console.WriteLine("Not implimented");
                        Console.ReadKey();
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
                        player.AddGladiatorToRoster(GladiatorsForSale[choice - 1], accommodations);
                        _gladiatorsForSale.Remove(GladiatorsForSale[choice - 1]);
                    }
                }

                DisplayGladiatorsForSale();

            } while (choice > 0);

            //Console.WriteLine("EXITED");
            //Console.ReadKey();
        }




    }
}
