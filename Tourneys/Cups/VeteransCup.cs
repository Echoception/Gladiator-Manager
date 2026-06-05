using Gladiator_Manager.Items.Trophies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Tourneys.Cups
{
    internal class VeteransCup : BasicTourney
    {
        public VeteransCup()
        {
            CompetingGladiators = new();
            ListSize = 16;
            Name = "Veteran's Cup";
            Completed = false;
            Trophy = new AllTrophies.VeteransCupTrophy();
        }


    }
}
