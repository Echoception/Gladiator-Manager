using Gladiator_Manager.Items.Equipment.Armour;
using Gladiator_Manager.Items.Equipment.Weapons;
using Gladiator_Manager.PlayerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Gladiators
{
    internal class Gladiator
    {

        public Gladiator()
        {
            // create empty holder
            Name = "";
            _weapon = _unarmed;
            _armour = _unarmoured;
        }

        public Gladiator(string name, int health, int attack, int defence, int speed, int charisma)
        {
            Name = name;
            _maxHealth = health;
            _health = health;
            _attack = attack;
            _defence = defence;
            _speed = speed;
            _charisma = charisma;
            _weapon = _unarmed;
            _armour = _unarmoured;
        }

        private int _maxHealth { get; set; }
        private int _health { get; set; }
        private int _attack { get; set; }
        private int _defence { get; set; }
        private int _speed { get; set; }
        private int _charisma { get; set; }
        private BaseWeapon _weapon { get; set; }
        private BaseArmour _armour { get; set; }

        public string Name { get; set; }


        private BaseWeapon _unarmed = new Unarmed();
        private BaseArmour _unarmoured = new Unarmoured();

        private bool _usingFacilities = false;
        private bool _isPlayers = false;
        private bool _inFacilities = false;

        public int MaxHealth => _maxHealth;
        public int Health => Math.Clamp(_health, 0, MaxHealth);
        public int Attack => _attack;
        public int Defence => _defence;
        public int Speed => _speed;
        public int Charisma => _charisma;
        public int Rating => ((_maxHealth + (_attack * 2) + (_defence * 2) + (_speed * 2) + (_charisma* 2)) / 5);
        public int BuyPrice => Rating * 3; //  could change to 4 ????
        public int SalePrice => Rating * 3;
        public bool IsPlayers => _isPlayers;
        public bool InFacilities => _inFacilities;
        public BaseWeapon Weapon => _weapon;
        public BaseArmour Armour => _armour;


        public void DisplayStats()
        {
            Console.WriteLine($"{Environment.NewLine}Name: {Name}  -  Rating {Rating}");
            Console.WriteLine($"Health: {Health} / {MaxHealth}");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Defence: {Defence}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Charisma: {Charisma} {Environment.NewLine}");
            Console.WriteLine($"Weapon: {Weapon.Name}");
            Console.WriteLine($"Armour: {Armour.Name} {Environment.NewLine}");
        }

        public void TakeDamage(Gladiator attackingGladiator)
        {
            int lvl = 20;
            int basePower = 20;
            
            if(attackingGladiator != null)
            {
                int damage = ((2 * lvl + 2) / 5) * basePower * (attackingGladiator.Attack + attackingGladiator.Weapon.Power) / (Defence + Armour.ArmourRating) / 50 + 2;
                _health = Math.Clamp(_health -= damage, 0, MaxHealth);

                Console.WriteLine();
                //Console.WriteLine($"{attackingGladiator.Name} hit {Name} for {damage} damage");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{attackingGladiator.Name} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("hit ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{Name} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("for ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{damage} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("damage");
            }
        }

        public void IsPlayersTrue() => _isPlayers = true;
        public void IsPlayersFalse() => _isPlayers = false;
        public void PutInFacilities() => _inFacilities = true;
        public void RemoveFromFacilities() => _inFacilities = false;

        public void RaiseMaxHp() => _maxHealth += 2;
        public void RaiseAttack() => _attack++;
        public void RaiseDefence() => _defence++;
        public void RaiseSpeed() => _speed++;
        public void RaiseCharisma() => _charisma++;
        public void WeeklyHeal() => _health = Math.Clamp(_health += 20, 0, MaxHealth);
        public void InfirmaryHeal(int heal) => _health = Math.Clamp(_health += heal, 0, MaxHealth);

        public void DisplayBuyPrice()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{BuyPrice} gold");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplaySalePrice()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{SalePrice} gold");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void EquipWeapon(BaseWeapon weapon)
        {
            _weapon = weapon;
        }

        public void EquipArmour(BaseArmour armour)
        {
            _armour = armour;
        }

        public void RemoveWeapon(Player player)
        {
            player.Inventory.AddItem(Weapon);
            _weapon = _unarmed;
        }

        public void RemoveArmour(Player player)
        {
            player.Inventory.AddItem(Armour);
            _armour = _unarmoured;
        }

        //----
    }
}
