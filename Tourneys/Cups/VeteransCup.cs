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
    internal class VeteransCup : BasicTourney
    {
        public VeteransCup()
        {
            CompetingGladiators = new();
            ListSize = 16;
            Name = "Veteran's Cup";
            Completed = false;
            Trophy = new AllTrophies.VeteransCupTrophy();
            LootTable = FillLootTable();
        }

        private List<BaseItem> FillLootTable()
        {
            SteelWeapons.SteelSword steelSword = new();
            SteelWeapons.SteelAxe steelAxe = new();
            CommonArmour.SteelArmour steelArmour = new();

            List<BaseItem> itemList= [steelSword, steelAxe, steelArmour];
            return itemList;
        }


    }
}
