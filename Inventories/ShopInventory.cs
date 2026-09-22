using Gladiator_Manager.Items.Equipment.Armour;
using Gladiator_Manager.Items.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Inventories
{
    internal class ShopInventory
    {
        public ShopInventory()
        {
            WeaponList = new();
            ArmourList = new();
        }


        public List<BaseWeapon> WeaponList { get; set; }
        public List<BaseArmour> ArmourList { get; set; }
        
        public void DisplayWeapons()
        {
            Console.WriteLine();
            int count = 1;

            foreach(BaseWeapon weapon in WeaponList)
            {
                Console.WriteLine($"[{count}] - {weapon.Name}");
                count++;
            }
        }

        public void DisplayArmour()
        {
            Console.WriteLine();
            int count = 1;

            foreach(BaseArmour armour in ArmourList)
            {
                Console.WriteLine($"[{count}] - {armour.Name}");
                count++;
            }
        }

    }
}
