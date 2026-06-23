using Gladiator_Manager.Items;
using Gladiator_Manager.Items.Equipment.Armour;
using Gladiator_Manager.Items.Equipment.Weapons;
using Gladiator_Manager.Items.Trophies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Tourneys.Cups
{
    internal class WeekendWarriorCup : BasicTourney
    {
        public WeekendWarriorCup()
        {
            CompetingGladiators = new();
            ListSize = 4;
            Name = "Weekend Warrior Cup";
            Completed = false;
            Trophy = new AllTrophies.WeekendWarriorTrophy();
            LootTable = FillLootTable();
        }


        private List<BaseItem> FillLootTable()
        {
            BronzeWeapons.BronzeDagger bronzeDagger = new();
            BronzeWeapons.BronzeSword bronzeSword = new();
            CommonArmour.LeatherArmour leatherArmour = new();

            List<BaseItem> itemTable = [bronzeDagger, bronzeSword, leatherArmour];
            return itemTable;
        }

    }
}
