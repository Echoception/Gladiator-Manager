using Gladiator_Manager.Gladiators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.SystemCreators
{
    internal class GladiatorCreator
    {
        public GladiatorCreator()
        {
            gladiatorNames = new();
        }

        private GladiatorNames gladiatorNames { get; set; }
        // add createLowerAvgGlad  80 : 65 = 68  hp:75 - 80  all others 65 - 70
        // add createMediumAvgGlad  90 : 75 = 78  hp:80 - 85  all others 70 - 75
        // h     90 : 80 = 82         85 - 90     ao  75 - 80

        public Gladiator CreateLowerGladiator()
        {
            Random random = new();
            string name = gladiatorNames.GetRandomName();
            int health = random.Next(75, 81);
            int attack = random.Next(30, 35);
            int defence = random.Next(30, 35);
            int speed = random.Next(30, 35);
            int charisma = random.Next(30, 35);

            Gladiator gladiator = new Gladiator(name, health, attack, defence, speed, charisma);
            return gladiator;
        }

        public Gladiator CreateMediumGladiator()
        {
            Random random = new();

            string name = gladiatorNames.GetRandomName();
            int health = random.Next(80, 86);
            int attack = random.Next(35, 40);
            int defence = random.Next(35, 40);
            int speed = random.Next(35, 40);
            int charisma = random.Next(35, 40);

            Gladiator gladiator = new Gladiator(name, health, attack, defence, speed, charisma);
            return gladiator;
        }

        public Gladiator CreateHighGladiator()
        {
            Random random = new();

            string name = gladiatorNames.GetRandomName();
            int health = random.Next(85, 91);
            int attack = random.Next(40, 45);
            int defence = random.Next(40, 45);
            int speed = random.Next(40, 45);
            int charisma = random.Next(40, 45);

            Gladiator gladiator = new Gladiator(name, health, attack, defence, speed, charisma);
            return gladiator;
        }

        public Gladiator CreateRandomGladiator()
        {
            // clamp generated stats so none or too weak or too op - 75 hp / 70 everything = 71avg
            // 85 hp / 80 everything = 81 avg
            GladiatorNames gladiatorNames = new GladiatorNames();
            Random random = new Random();

            string name = gladiatorNames.GetRandomName();
            int health = random.Next(50, 86);
            int attack = random.Next(20, 41);
            int defence = random.Next(20, 41);
            int speed = random.Next(20, 41);
            int charisma = random.Next(20, 41);

            Gladiator gladiator = new Gladiator(name, health, attack, defence, speed, charisma);

            return gladiator;
        }

        //-----
    }
}
