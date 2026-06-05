using Gladiator_Manager.BattleSystem;
using Gladiator_Manager.CustomTimer;
using Gladiator_Manager.Gladiators;
using Gladiator_Manager.Input;
using Gladiator_Manager.PlayerClass;
using Gladiator_Manager.SystemCreators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Tourneys.TourneyRanks
{
    internal abstract class RankXTourney
    {

        public void DisplayRankXTourneys(List<BasicTourney> tourneyList)
        {
            int count = 1;
            Console.Clear();
            Console.WriteLine();

            foreach (BasicTourney cup in tourneyList)
            {
                Console.WriteLine($"[{count}]  -  {cup.Name}");
            }

            Console.WriteLine($"{Environment.NewLine}[0] - EXIT");
        }

        public void PickRankXTourney(UserInput userInput, BattleHandler battleHandler, Player player, GladiatorCreator gladiatorCreator, Ctimer timer, List<BasicTourney> tourneyList)
        {
            DisplayRankXTourneys(tourneyList);
            int choice = 99;
            bool canStart = false;

            do
            {
                choice = userInput.PickItemFromList(tourneyList);

                if (choice > 0)
                {
                    if (tourneyList[choice - 1].CompletedThisWeek)
                    {
                        Console.WriteLine("You have already competed in this tournament this week");
                        Console.ReadKey();
                        return;
                    }

                    Gladiator playerGladiator = player.PickGladiatorFromList(userInput);
                    if(playerGladiator != null)
                    {
                        canStart = tourneyList[choice - 1].FillCompetingList(playerGladiator, gladiatorCreator, userInput);
                        if (canStart)
                        {
                            tourneyList[choice - 1].StartTourney(battleHandler, timer, player);
                            //choice = 0;
                        }
                    }
                    else
                    {
                        return;
                    }

                    //canStart = tourneyList[choice - 1].FillCompetingList(playerGladiator, gladiatorCreator, userInput);
                    //if (canStart)
                    //{
                    //    tourneyList[choice - 1].StartTourney(battleHandler, timer);
                    //    //choice = 0;
                    //}

                }

            } while (choice != 0 && !canStart);
        }

    }
}
