using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Tourneys.Cups
{
    internal class JourneyMansCup : BasicTourney
    {
        public JourneyMansCup()
        {
            CompetingGladiators = new();
            ListSize = 8;
            Name = "Journeyman's Cup";
            Completed = false;
        }


    }
}
