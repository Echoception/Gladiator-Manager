using Gladiator_Manager.BattleSystem;
using Gladiator_Manager.CustomTimer;
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
    internal class AllTourneys
    {
        public AllTourneys()
        {
            _rank1Tourneys = new();
        }


        private List<BasicTourney> _rank1Tourneys { get; set; }

        public List<BasicTourney> Rank1TourneyList => _rank1Tourneys;


        public void DisplayRank1Tourneys()
        {
            int count = 1;
            Console.Clear();
            Console.WriteLine();

            foreach(BasicTourney cup in _rank1Tourneys)
            {
                Console.WriteLine($"[{count}]  -  {cup.Name}");
            }

            Console.WriteLine($"{Environment.NewLine}[0] - EXIT");
        }

        public void UnlockRank1Tourneys()
        {
            FillRank1TourneyList();
        }

        private void FillRank1TourneyList()
        {
            WeekendWarriorCup weekendWarriorCup = new WeekendWarriorCup();

            _rank1Tourneys.Add(weekendWarriorCup);
        }

        public void PickRank1Tourney(UserInput userInput, BattleHandler battleHandler, Player player, GladiatorCreator gladiatorCreator, Ctimer timer)
        {
            DisplayRank1Tourneys();
            int choice = 99;
            bool canStart = false;

            do
            {
                choice = userInput.PickItemFromList(Rank1TourneyList);

                if (choice > 0)
                {
                    canStart = _rank1Tourneys[choice - 1].FillCompetingList(player, gladiatorCreator, userInput);
                    if (canStart)
                    {
                        _rank1Tourneys[choice - 1].StartTourney(battleHandler, timer);
                        //choice = 0;
                    }

                }

            } while (choice != 0 || !canStart);
        }

    }
}
