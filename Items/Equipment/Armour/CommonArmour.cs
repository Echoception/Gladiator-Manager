using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Items.Equipment.Armour
{
    internal class CommonArmour
    {

        internal class LeatherArmour : BaseArmour
        {
            public LeatherArmour()
            {
                Name = "Leather Armour";
                Price = 50;
                ArmourRating = 10;
                Weight = 6;
            }
        }

    }
}
