using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Items.Equipment.Armour
{
    internal abstract class BaseArmour : BaseItem
    {
        public BaseArmour()
        {
            Name = "";
            Price = 0;
            ArmourRating = 0;
            Weight = 0;
        }

        public int ArmourRating {  get; set; }
        public int Weight { get; set; }
    }
}
