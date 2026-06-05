using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Items.Equipment.Weapons
{
    internal class BronzeWeapons
    {

        internal class BronzeDagger : BaseWeapon
        {
            public BronzeDagger()
            {
                Name = "Bronze Dagger";
                Price = 15;
                Power = 5;
                Weight = 2;
            }
        }

        internal class BronzeSword : BaseWeapon
        {
            public BronzeSword()
            {
                Name = "Bronze Sword";
                Price = 20;
                Power = 10;
                Weight = 5;
            }
        }

        //-----
    }
}
