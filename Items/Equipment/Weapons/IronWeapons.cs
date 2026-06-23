using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Items.Equipment.Weapons
{
    internal class IronWeapons
    {

        internal class IronDagger : BaseWeapon
        {
            public IronDagger()
            {
                Name = "Iron Dagger";
                Price = 25;
                Power = 10;
                Weight = 2;
            }
        }

        internal class  IronSword : BaseWeapon
        {
            public IronSword()
            {
                Name = "Iron Sword";
                Price = 30;
                Power = 15;
                Weight = 7;
            }
        }

        internal class IronAxe : BaseWeapon
        {
            public IronAxe()
            {
                Name = "Iron Axe";
                Price = 35;
                Power = 20;
                Weight = 10;
            }
        }

        internal class IronMace : BaseWeapon
        {
            public IronMace()
            {
                Name = "Iron Mace";
                Price = 40;
                Power = 25;
                Weight = 15;
            }
        }

        //---
    }
}
