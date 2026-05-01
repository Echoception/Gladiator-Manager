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


        public Gladiator CreateRandomGladiator()
        {
            // clamp generated stats so none or too weak or too op

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

    }
}
