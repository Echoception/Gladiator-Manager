using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Items.Equipment.Weapons
{
    internal abstract class BaseWeapon : BaseItem
    {
        public BaseWeapon()
        {
            Name = "";
            Price = 0;
            Power = 0;
            Weight = 0;
        }

        public int Power { get; set; }
        public int Weight { get; set; }
    }
}
