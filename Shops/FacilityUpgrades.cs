using Gladiator_Manager.Facilities;
using Gladiator_Manager.Input;
using Gladiator_Manager.PlayerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Shops
{
    internal class FacilityUpgrades
    {


        public void Menu(UserInput userInput, Accommodations accommodations, TrainingFields trainingFields, Infirmary infirmary, Player player)
        {
            int choice = 99;

            do
            {

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("[1] - Rank-Up Accommodations");
                Console.WriteLine("[2] - Rank-Up TrainingFields");
                Console.WriteLine("[3] - Rank-Up Infirmary");

                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch (choice)
                {
                    case 1:
                        accommodations.BuyUpgrade(player);
                        break;

                    case 2:
                        trainingFields.BuyUpgrade(player);
                        break;

                    case 3:
                        infirmary.BuyUpgrade(player);
                        break;

                    case 0:
                        return;

                    default:
                        userInput.DisplayPickValidOptionText();
                        break;
                }

            } while (choice != 0);

        }
        
        private void BuyAccommodationUpgrade(Player player, Accommodations accommodations, UserInput userInput)
        {
            Console.Clear();
            Console.WriteLine();
            
            switch(accommodations.Rank)
            {
                case 1:
                    Console.WriteLine($"Accommodation upgrade costs {accommodations.Rank2UpgradeCost}g");
                    Console.WriteLine("Would you like to buy this upgrade?");
                    bool confirm = userInput.PickYesOrNo();

                    if(confirm)
                    {
                        accommodations.UpgradeToRank2(player);
                    }

                    break;
                case 2:

                    break;
                case 3:
                    Console.WriteLine("Your accommodations are at max rank");
                    Console.ReadKey();
                    break;
                case 0:
                    return;
            }
        }

        //-----
    }
}
