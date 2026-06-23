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
    internal class JourneyMansCup : BasicTourney
    {
        public JourneyMansCup()
        {
            CompetingGladiators = new();
            ListSize = 8;
            Name = "Journeyman's Cup";
            Completed = false;
            Trophy = new AllTrophies.JourneyMansTrophy();
            LootTable = FillLootTable();
        }


        private List<BaseItem> FillLootTable()
        {
            IronWeapons.IronSword ironSword = new();
            IronWeapons.IronAxe ironAxe = new();
            CommonArmour.IronArmour ironArmour = new();

            List<BaseItem> itemList = [ironSword, ironAxe, ironArmour];
            return itemList;
        }

    }
}
