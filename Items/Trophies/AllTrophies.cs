using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Items.Trophies
{
    internal class AllTrophies
    {
        internal class WeekendWarriorTrophy : BaseTrophy
        {
            public WeekendWarriorTrophy()
            {
                Name = "Weekend Warrior Trophy";
            }
        }

        internal class JourneyMansTrophy : BaseTrophy
        {
            public JourneyMansTrophy()
            {
                Name = "Journey Mans Trophy";
            }
        }

        internal class VeteransCupTrophy : BaseTrophy
        {
            public VeteransCupTrophy()
            {
                Name = "Veterans Cup Trophy";
            }
        }


        //----
    }
}
