using Gladiator_Manager.Facilities;
using Gladiator_Manager.Input;
using Gladiator_Manager.PlayerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Shops
{   // Gladiator market, Item Market, Facility upgrades, if food is added
    internal class MainMarket
    {


        public void Menu(UserInput userInput, GladiatorMarket gladiatorMarket, Player player, Accommodations accommodations, FacilityUpgrades facilityUpgrades,
            TrainingFields trainingFields, Infirmary infirmary)
        {
            int choice = 99;

            do
            {
                Console.Clear();
                Console.WriteLine();
                player.DisplayGold();
                Console.WriteLine();

                Console.WriteLine("[1] - Gladiator Market");
                Console.WriteLine("[2] - Item Market");
                Console.WriteLine("[3] - Facility upgrades");
                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch (choice)
                {
                    case 1:
                        gladiatorMarket.BuyOrSellMenu(userInput, player, accommodations);
                        break;

                    case 2:
                        Console.WriteLine("Not Implimented");
                        break;

                    case 3:
                        facilityUpgrades.Menu(userInput, accommodations, trainingFields, infirmary);
                        break;

                    case 0:
                        return;

                    default:
                        userInput.DisplayPickValidOptionText();
                        break;
                }
            } while (choice != 0);

        }

    }
}
