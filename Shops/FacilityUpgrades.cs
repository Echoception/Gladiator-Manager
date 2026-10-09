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
                player.DisplayGold();
                Console.WriteLine();
                Console.WriteLine("[1] - Rank-Up Accommodations");
                Console.WriteLine("[2] - Rank-Up TrainingFields");
                Console.WriteLine("[3] - Rank-Up Infirmary");

                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch (choice)
                {
                    case 1:
                        BuyAccommodationUpgrade(player, accommodations, userInput);
                        break;

                    case 2:
                        BuyTrainingFieldsUpgrade(player, trainingFields, userInput);
                        break;

                    case 3:
                        BuyInfirmaryUpgrade(player, infirmary, userInput);
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
            bool confirm = false;
            Console.Clear();
            Console.WriteLine();
            player.DisplayGold();
            Console.WriteLine();
            
            switch(accommodations.Rank)
            {
                case 1:
                    Console.WriteLine($"Accommodation upgrade costs {accommodations.Rank1UpgradeCost}g");
                    Console.WriteLine("Would you like to buy this upgrade?");
                    confirm = userInput.PickYesOrNo();

                    if(confirm)
                    {
                        accommodations.UpgradeToRank2(player);
                    }

                    break;
                case 2:
                    Console.WriteLine($"Accommodation upgrade costs {accommodations.Rank2UpgradeCost}g");
                    Console.WriteLine("Would you like to buy this upgrade?");
                    confirm = userInput.PickYesOrNo();

                    if(confirm)
                    {
                        accommodations.UpgradeToRank3(player);
                    }

                    break;
                case 3:
                    Console.WriteLine("Your accommodations are at max rank");
                    Console.ReadKey();
                    break;
                case 0:
                    return;
            }
        }

        private void BuyTrainingFieldsUpgrade(Player player, TrainingFields trainingFields, UserInput userInput)
        {
            bool confirm = false;
            Console.Clear();
            Console.WriteLine();
            player.DisplayGold();
            Console.WriteLine();

            switch(trainingFields.Rank)
            {
                case 1:
                    Console.WriteLine($"Training Fields upgrade cost {trainingFields.Rank1UpgradeCost}g");
                    Console.WriteLine("Would you like to buy this upgrade?");
                    confirm = userInput.PickYesOrNo();

                    if(confirm)
                    {
                        trainingFields.UpgradeToRank2(player);
                    }

                    break;
                case 2:
                    Console.WriteLine($"Training Fields upgrade costs {trainingFields.Rank2UpgradeCost}g");
                    Console.WriteLine("Would you like to buy this upgrade?");
                    confirm = userInput.PickYesOrNo();

                    if(confirm)
                    {
                        trainingFields.UpgradeToRank3(player);
                    }

                    break;
                case 3:
                    Console.WriteLine("Your training fields are max rank");
                    Console.ReadKey();
                    break;
                case 0:
                    return;
            }

        }

        
        private void BuyInfirmaryUpgrade(Player player, Infirmary infirmary, UserInput userInput)
        {
            bool confirm = false;
            Console.Clear();
            Console.WriteLine();
            player.DisplayGold();
            Console.WriteLine();

            switch(infirmary.Rank)
            {
                case 1:
                    Console.WriteLine($"Infirmary upgrade costs {infirmary.Rank1UpgradeCost}g");
                    Console.WriteLine("Would you like to buy this upgrade?");
                    confirm = userInput.PickYesOrNo();

                    if(confirm)
                    {
                        infirmary.UpgradeToRank2(player);
                    }

                    break;
                case 2:
                    Console.WriteLine($"Infirmary upgrade costs {infirmary.Rank2UpgradeCost}g");
                    Console.WriteLine("Would you like to buy this upgrade?");
                    confirm = userInput.PickYesOrNo();

                    if(confirm)
                    {
                        infirmary.UpgradeToRank3(player);
                    }

                    break;
                case 3:
                    Console.WriteLine("Your infirmary is already max rank");
                    Console.ReadKey();
                    break;
                case 0:
                    return;
            }

        }

        //-----
    }
}
