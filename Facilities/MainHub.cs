using Gladiator_Manager.BattleSystem;
using Gladiator_Manager.CustomTimer;
using Gladiator_Manager.DateSystem;
using Gladiator_Manager.Gladiators; //  <----    for Tod the gladiator in " Menu - case 2 "
using Gladiator_Manager.Input;
using Gladiator_Manager.PlayerClass;
using Gladiator_Manager.Shops;
using Gladiator_Manager.SystemCreators;
using Gladiator_Manager.Tourneys;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Facilities
{
    internal class MainHub
    {

        // List of facilities
        // Menu of options

        public void DisplayMainHub(Player player, GladiatorMarket gladiatorMarket, BattleHandler battleHandler, UserInput userInput, DateHandler dateHandler,
            Accommodations accommodations, GladiatorCreator gladiatorCreator, MainMarket mainMarket, AllTourneys allTourneys, Ctimer timer, FacilityUpgrades facilityUpgrades,
            TrainingFields trainingFields, Infirmary infirmary)
        {
            Console.WriteLine();
            player.DisplayGold();
            Console.WriteLine();
            dateHandler.DisplayDate();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}");
            Menu(player, gladiatorMarket, battleHandler, userInput, dateHandler, accommodations, gladiatorCreator, mainMarket, allTourneys, timer, facilityUpgrades, trainingFields, infirmary);
        }

        public void Menu(Player player, GladiatorMarket gladiatorMarket, BattleHandler battleHandler, UserInput userInput, DateHandler dateHandler,
            Accommodations accommodations, GladiatorCreator gladiatorCreator, MainMarket mainMarket, AllTourneys allTourneys, Ctimer timer, FacilityUpgrades facilityUpgrades,
            TrainingFields trainingFields, Infirmary infirmary)
        {

            Console.WriteLine("[1] - Go to the Market");
            Console.WriteLine("[2] - Fight");
            Console.WriteLine("[3] - Training Fields");
            Console.WriteLine("[4] - Infirmary");
            Console.WriteLine("[5] - View Inventory");
            Console.WriteLine("[6] - Display Gladiator roster");
            Console.WriteLine("[7] - Advance to next week");
            Console.WriteLine("[9] - Show Trophies");

            int choice = userInput.PickValidInt();

            switch (choice)
            {
                case 1:
                    mainMarket.Menu(userInput, gladiatorMarket, player, accommodations, facilityUpgrades, trainingFields, infirmary);
                    break;

                case 2:

                    if (player.GladiatorList.Count > 0)
                    {
                        allTourneys.MainMenu(userInput, battleHandler, player, gladiatorCreator, timer);
                    }
                    else
                    {
                        Console.WriteLine("You have no gladiators");
                        Console.ReadKey();
                    }

                    break;

                case 3:
                    trainingFields.Menu(userInput, player);
                    break;

                case 4:
                    infirmary.InfirmaryMenu(player, userInput);
                    break;

                case 5:
                    if(player.Inventory.ItemList.Count > 0)
                    {
                        player.Inventory.DisplayItems();
                    }
                    else
                    {
                        Console.WriteLine("Your inventory is empty");
                    }
                    Console.ReadKey();
                        break;

                case 6:
                    player.ViewGladiatorInList(userInput);
                    break;

                case 7:
                    dateHandler.AdvanceWeek(gladiatorMarket, gladiatorCreator, trainingFields, player, infirmary, allTourneys);
                    break;

                case 9:  //   move to inventory
                    if(player.TrophyDictionary.Count > 0)
                    {
                        player.ShowTrophies();
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You dont have any Trophies");
                        Console.ReadKey();
                    }
                        break;

                default:
                    Console.WriteLine("Pick an option from the menu");
                    break;
            }
        }

    }
}
