using Gladiator_Manager.Input;
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

        public void PickRank1Tourney(UserInput userInput)
        {
            DisplayRank1Tourneys();
            int choice = 99;

            do
            {
                choice = userInput.PickItemFromList(Rank1TourneyList);

                if(choice > 0)
                {
                    Console.WriteLine(Rank1TourneyList[choice - 1].Name);
                }

            } while (choice != 0);
        }

    }
}
