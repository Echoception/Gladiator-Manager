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
        }

        private int _maxHealth { get; set; }
        private int _health { get; set; }
        private int _attack { get; set; }
        private int _defence { get; set; }
        private int _speed { get; set; }
        private int _charisma { get; set; }

        public string Name { get; set; }

        private bool _usingFacilities = false;

        public int MaxHealth => _maxHealth;
        public int Health => _health;
        public int Attack => _attack;
        public int Defence => _defence;
        public int Speed => _speed;
        public int Charisma => _charisma;
        public int Rating => ((_maxHealth + (_attack * 2) + (_defence * 2) + (_speed * 2) + (_charisma* 2)) / 5);

        // going to need methods for take damage and fields for weapon and armour slots

        public void DisplayStats()
        {
            Console.WriteLine($"{Environment.NewLine}Name: {Name}  -  {Rating}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Defence: {Defence}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Charisma: {Charisma} {Environment.NewLine}");
        }

        public void TakeDamage(Gladiator attackingGladiator)
        {
            int lvl = 20;
            int basePower = 20;
            
            if(attackingGladiator != null)
            {
                int damage = ((2 * lvl + 2) / 5) * basePower * attackingGladiator.Attack / Defence / 50 + 2;
                _health -= damage;
            }
        }
    }
}
