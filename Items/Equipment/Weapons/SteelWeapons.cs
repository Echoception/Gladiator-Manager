using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Items.Equipment.Weapons
{
    internal class SteelWeapons
    {

        internal class SteelDagger : BaseWeapon
        {
            public SteelDagger()
            {
                Name = "Steel Dagger";
                Price = 35;
                Power = 15;
                Weight = 1;
            }
        }

        internal class SteelSword : BaseWeapon
        {
            public SteelSword()
            {
                Name = "Steel Sword";
                Price = 40;
                Power = 20;
                Weight = 6;
            }
        }

        internal class SteelAxe : BaseWeapon
        {
            public SteelAxe()
            {
                Name = "Steel Axe";
                Price = 45;
                Power = 25;
                Weight = 9;
            }
        }

        internal class SteelMace : BaseWeapon
        {
            public SteelMace()
            {
                Name = "Steel Mace";
                Price = 45;
                Power = 30;
                Weight = 14;
            }
        }


        //-----
    }
}
