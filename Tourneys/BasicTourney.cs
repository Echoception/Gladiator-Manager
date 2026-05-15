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

namespace Gladiator_Manager.Tourneys
{
    internal abstract class BasicTourney
    {
        public BasicTourney()
        {
            CompetingGladiators = new();
            ListSize = 0;
            Name = "";
            Completed = false;
        }

        public List<Gladiator> CompetingGladiators { get; set; }

        public int ListSize { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }


        public void DisplayCompetingGladiators()
        {
            if(CompetingGladiators != null)
            {
                int count = 1;
                Console.Clear();
                Console.WriteLine();

                foreach(Gladiator glad in CompetingGladiators)
                {
                    Console.WriteLine($"{count}: {glad.Name}  -  {glad.Rating}");
                    count++;
                }
                Console.ReadKey();
            }
        }

        public bool FillCompetingList(Player player, GladiatorCreator gladiatorCreator, UserInput userInput)
        {
            CompetingGladiators.Clear();
            Gladiator playerGlad = player.PickGladiatorFromList(userInput);

            if (playerGlad != null && !playerGlad.InFacilities)
            {
                CompetingGladiators.Add(playerGlad);

                for (int i = 1; i < ListSize; i++)
                {
                    Gladiator gladiator = gladiatorCreator.CreateRandomGladiator();
                    CompetingGladiators.Add(gladiator);
                }
                return true;
            }
            else
            {
                Console.WriteLine($"{playerGlad.Name} is using facilities");
                return false;
            }

        }


        private void RunTourneyRound(BattleHandler battleHandler, Ctimer timer)
        {
            DisplayCompetingGladiators();

            for(int i = 0; i < CompetingGladiators.Count; i++)
            {
                Console.Clear();
                CompetingGladiators.Remove(StartTourneyBattle(CompetingGladiators[i], CompetingGladiators[i + 1], battleHandler, timer));

                if (CompetingGladiators[i].IsPlayers)   //  Better formatting for the user end
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine($"{Environment.NewLine} {CompetingGladiators[i].Name} won the round");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }

        public void StartTourney(BattleHandler battleHandler, Ctimer timer)
        {
            int roundCount = 1;

            do
            {
                RunTourneyRound(battleHandler, timer);
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"End of round {roundCount}");
                Console.ReadKey();
                roundCount++;
            } while (CompetingGladiators.Count > 1);

            Console.Clear();
            Console.WriteLine();

            if (CompetingGladiators[0].IsPlayers)  //  Better formatting for the user end
            {
                Completed = true;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"{CompetingGladiators[0].Name} wins the tournament");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        //public List<Gladiator> RunTourneyRound(BattleHandler battleHandler)
        //{
        //    List<Gladiator> roundWinners = new();
        //    var gladiatorHolder = new Gladiator();

        //    switch(CompetingGladiators.Count)
        //    {
        //        case 1:
        //            Console.WriteLine($"{CompetingGladiators[0].Name} won the Tournament");
        //            break;

        //        case 2:

        //            Console.Clear();
        //            Console.WriteLine($"semi-final{Environment.NewLine}");
        //            gladiatorHolder = StartTourneyBattle(CompetingGladiators[0], CompetingGladiators[1], battleHandler);
        //            Console.WriteLine($"{gladiatorHolder.Name} won the round");
        //            roundWinners.Add(gladiatorHolder);

        //            break;

        //        case 4:

        //            Console.Clear();
        //            Console.WriteLine($"4 remain{Environment.NewLine}");
        //            roundWinners.Add(StartTourneyBattle(CompetingGladiators[0], CompetingGladiators[1], battleHandler));

        //            break;

        //        case 8:
        //            break;

        //        case 16:
        //            break;

        //        default:
        //            break;
        //    }

        //    return roundWinners;
        //}

        private Gladiator StartTourneyBattle(Gladiator glad1, Gladiator glad2, BattleHandler battleHandler, Ctimer timer)
        {
            battleHandler.Battle(glad1, glad2, timer);

            if(glad1.Health > 0)
            {
                return glad2;
            }
            else
            {
                return glad1;
            }
        }

        //---
    }
}
