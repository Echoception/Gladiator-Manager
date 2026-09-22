using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Items.Equipment.Weapons
{
    internal class BronzeWeapons
    {
        public BronzeWeapons()
        {
            _bronzeWeaponList = GenerateBronzeWeapons();
        }

        private List<BaseWeapon> _bronzeWeaponList { get; set; }

        public List<BaseWeapon> BronzeWeaponList => _bronzeWeaponList;

        private List<BaseWeapon> GenerateBronzeWeapons()
        {
            BronzeDagger bronzeDagger = new();
            BronzeSword bronzeSword = new();
            BronzeAxe bronzeAxe = new();
            BronzeMace bronzeMace = new();

            List<BaseWeapon> bronzeWeapons = new();

            bronzeWeapons.Add(bronzeDagger);
            bronzeWeapons.Add(bronzeSword);
            bronzeWeapons.Add(bronzeAxe);
            bronzeWeapons.Add(bronzeMace);

            return bronzeWeapons;
        }

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



        //-----
    }
}
