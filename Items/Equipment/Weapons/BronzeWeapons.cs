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
                Weight = 3;
            }
        }

        internal class BronzeSword : BaseWeapon
        {
            public BronzeSword()
            {
                Name = "Bronze Sword";
                Price = 20;
                Power = 10;
                Weight = 8;
            }

            internal class BronzeAxe : BaseWeapon
            {
                public BronzeAxe()
                {
                    Name = "Bronze Axe";
                    Price = 25;
                    Power = 15;
                    Weight = 11;
                }
            }

            internal class BronzeMace : BaseWeapon
            {
                public BronzeMace()
                {
                    Name = "Bronze Mace";
                    Price = 30;
                    Power = 20;
                    Weight = 16;
                }
            }

        }

        //-----
    }
}
