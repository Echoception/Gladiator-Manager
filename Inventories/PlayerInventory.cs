using Gladiator_Manager.Gladiators;
using Gladiator_Manager.Input;
using Gladiator_Manager.Items;
using Gladiator_Manager.Items.Equipment.Armour;
using Gladiator_Manager.Items.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Inventories
{
    internal class PlayerInventory : BaseInventory
    {

        public PlayerInventory()
        {
            _weaponList = new();
            _armourList = new();
        }

        private List<BaseWeapon> _weaponList { get; set; }
        private List<BaseArmour> _armourList { get; set; }

        public List<BaseWeapon> WeaponList => _weaponList;
        public List<BaseArmour> ArmourList => _armourList;

        private void UpdateWeaponList()
        {
            _weaponList.Clear();

            foreach(BaseItem item in ItemList)
            {
                if(item is BaseWeapon)
                {
                    _weaponList.Add((BaseWeapon)item);
                }
            }
            _weaponList = _weaponList.OrderBy(x => x.Name).ToList();
        }

        private void UpdateArmourList()
        {
            _armourList.Clear();

            foreach(BaseItem item in ItemList)
            {
                if(item is BaseArmour)
                {
                    _armourList.Add((BaseArmour)item);
                }
            }

            _armourList = _armourList.OrderBy(x => x.Name).ToList();
        }

        public void PickWeaponToEquip(UserInput userInput, Gladiator gladiator)
        {
            DisplayWeapons();
            Console.WriteLine("[0] - EXIT");
            int choice = userInput.PickItemFromList(WeaponList);

            if(choice > 0)
            {
                gladiator.EquipWeapon(WeaponList[choice - 1], ItemList);
            }
            else
            {
                return;
            }
        }

        public void PickArmourToEquip(UserInput userInput, Gladiator gladiator)
        {
            DisplayArmour();
            Console.WriteLine("[0] - EXIT");
            int choice = userInput.PickItemFromList(ArmourList);

            if(choice > 0)
            {
                gladiator.EquipArmour(ArmourList[choice - 1], ItemList);
            }
            else
            {
                return;
            }
        }

        private void DisplayWeapons()
        {
            UpdateWeaponList();
            int count = 1;
            Console.Clear();
            Console.WriteLine();

            foreach(BaseWeapon weapon in WeaponList)
            {
                Console.WriteLine($"[{count}] - {weapon.Name}");
                count++;
            }
        }

        private void DisplayArmour()
        {
            UpdateArmourList();
            int count = 1;
            Console.Clear();
            Console.WriteLine();

            foreach(BaseArmour armour in ArmourList)
            {
                Console.WriteLine($"[{count}] - {armour.Name}");
                count++;
            }
        }

        //----
    }
}
