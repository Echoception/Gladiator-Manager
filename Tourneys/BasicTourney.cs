using Gladiator_Manager.Gladiators;
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
        }

        public List<Gladiator> CompetingGladiators { get; set; }

        public int ListSize { get; set; }
        public string Name { get; set; }


        public void DisplayCompetingGladiators()
        {
            if(CompetingGladiators != null)
            {
                Console.Clear();
                Console.WriteLine();

                foreach(Gladiator glad in CompetingGladiators)
                {
                    Console.WriteLine($"{glad.Name}  -  {glad.Rating}");
                }
                Console.ReadKey();
            }
        }

        public void FillCompetingList(Gladiator playerGladiator, GladiatorCreator gladiatorCreator)
        {
            CompetingGladiators.Clear();
            CompetingGladiators.Add(playerGladiator);

            for(int i = 1; i < ListSize; i++)
            {
                Gladiator gladiator = gladiatorCreator.CreateRandomGladiator();
                CompetingGladiators.Add(gladiator);
            }

        }

        //  add tourney battle stuff here, switch(listOfCompetingGladiators.count) 1: winner, 2: B, 4: B, 8: B, 16: B   might need two lists?


        //---
    }
}
