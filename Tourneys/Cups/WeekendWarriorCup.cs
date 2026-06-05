using Gladiator_Manager.Items.Trophies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Tourneys.Cups
{
    internal class WeekendWarriorCup : BasicTourney
    {
        public WeekendWarriorCup()
        {
            CompetingGladiators = new();
            ListSize = 4;
            Name = "Weekend Warrior Cup";
            Completed = false;
            Trophy = new AllTrophies.WeekendWarriorTrophy();
        }



    }
}
