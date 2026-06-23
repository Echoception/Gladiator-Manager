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
                ArmourRating = 8;
                Weight = 4;
            }
        }

        internal class BronzeArmour : BaseArmour
        { 
            public BronzeArmour()
            {
                Name = "Bronze Armour";
                Price = 100;
                ArmourRating = 15;
                Weight = 11;
            }
        }

        internal class IronArmour : BaseArmour
        {
            public IronArmour()
            {
                Name = "Iron Armour";
                Price = 150;
                ArmourRating = 20;
                Weight = 9;
            }
        }

    }
}
