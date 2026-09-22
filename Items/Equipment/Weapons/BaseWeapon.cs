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

        public void DisplayStats()
        {
            Console.WriteLine($"{Environment.NewLine}Name: {Name}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Power: {Power}");
            Console.WriteLine($"Weight: {Weight}");
        }

    }
}
