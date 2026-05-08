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
            Accommodations accommodations, GladiatorCreator gladiatorCreator, MainMarket mainMarket, AllTourneys allTourneys, Ctimer timer, FacilityUpgrades facilityUpgrades)
        {
            Console.WriteLine();
            dateHandler.DisplayDate();
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}");
            Menu(player, gladiatorMarket, battleHandler, userInput, dateHandler, accommodations, gladiatorCreator, mainMarket, allTourneys, timer, facilityUpgrades);
        }

        public void Menu(Player player, GladiatorMarket gladiatorMarket, BattleHandler battleHandler, UserInput userInput, DateHandler dateHandler,
            Accommodations accommodations, GladiatorCreator gladiatorCreator, MainMarket mainMarket, AllTourneys allTourneys, Ctimer timer, FacilityUpgrades facilityUpgrades)
        { 

            Console.WriteLine("[1] - Go to the Market");
            Console.WriteLine("[2] - Fight");
            Console.WriteLine("[3] - Training Fields");

            Console.WriteLine("[6] - Display Gladiator roster");
            Console.WriteLine("[7] - Advance to next week");

            int choice = userInput.PickValidInt();

            switch (choice)
            {
                case 1:
                    mainMarket.Menu(userInput, gladiatorMarket, player, accommodations, facilityUpgrades);
                    break;

                case 2:

                    if(player.GladiatorList.Count > 0)
                    {
                        allTourneys.MainMenu(userInput, battleHandler, player, gladiatorCreator, timer, allTourneys.Rank1Tourneys);
                    }
                    else
                    {
                        Console.WriteLine("You have no gladiators");
                        Console.ReadKey();
                    }

                        break;

                case 6:
                    player.ViewGladiatorInList(userInput);
                    break;

                case 7:
                    dateHandler.AdvanceWeek(gladiatorMarket, gladiatorCreator);
                    break;

                default:
                    Console.WriteLine("Pick an option from the menu");
                    break;
            }
        }

    }
}
