using Gladiator_Manager.Input;
using Gladiator_Manager.Inventories;
using Gladiator_Manager.Items;
using Gladiator_Manager.Items.Equipment.Armour;
using Gladiator_Manager.Items.Equipment.Weapons;
using Gladiator_Manager.PlayerClass;
using Gladiator_Manager.Tourneys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Shops
{
    internal class EquipmentShop
    {
        public EquipmentShop()
        {
            ShopInventory = new();
            GenerateBaseInventory();
        }

        private bool _ironUnlocked = false;
        private bool _steelUnlocked = false;

        public ShopInventory ShopInventory { get; set; }

        public bool IronUnlocked => _ironUnlocked;
        public bool SteelUnlocked => _steelUnlocked;

        public void BuyOrSellMenu(Player player, UserInput userInput, AllTourneys allTourneys)
        {
            int choice = 99;
            do
            {
                Console.Clear();
                Console.WriteLine();
                player.DisplayGold();

                Console.WriteLine($"{Environment.NewLine}Would you like to buy or sell:{Environment.NewLine}");
                Console.WriteLine("[1] - Buy");
                Console.WriteLine("[2] - Sell");
                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch (choice)
                {
                    case 1:
                        Buy(player, userInput, allTourneys);
                        break;

                    case 2:
                        Sell(player, userInput);
                        break;

                    case 0:
                        return;

                    default:
                        userInput.DisplayPickValidOptionText();
                        break;
                }

            } while (choice != 0);
        }

        private void Buy(Player player, UserInput userInput, AllTourneys allTourneys)
        {
            allTourneys.CheckForRankUnlocksShop();
            _ironUnlocked = CheckIfIronAlreadyAdded(allTourneys);
            _steelUnlocked = CheckIfSteelAlreadyAdded(allTourneys);

            int choice = 99;
            do
            {
                Console.Clear();
                Console.WriteLine();
                player.DisplayGold();
                Console.WriteLine();

                Console.WriteLine("[1] - Weapons");
                Console.WriteLine("[2] - Armour");
                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch(choice)
                {
                    case 1:
                        BuyWeapons(player, userInput);
                        break;
                    case 2:
                        BuyArmour(player, userInput);
                        break;
                    case 0:
                        return;
                    default:
                        userInput.DisplayPickValidOptionText();
                        break;
                }

            } while (choice != 0);
        }

        private void BuyWeapons(Player player, UserInput userInput)
        {
            int choice = 99;

            do
            {
                Console.Clear();
                Console.WriteLine();
                player.DisplayGold();
                ShopInventory.DisplayWeapons();
                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickItemFromList(ShopInventory.WeaponList);

                if(choice > 0)
                {
                    Console.Clear();
                    Console.WriteLine();
                    player.DisplayGold();

                    ShopInventory.WeaponList[choice - 1].DisplayStats();
                    Console.WriteLine();
                    Console.WriteLine($"{Environment.NewLine}Would you like to buy this item?{Environment.NewLine}");
                    bool buy = userInput.PickYesOrNo();

                    if (buy && player.Gold >= ShopInventory.WeaponList[choice - 1].Price)
                    {
                        player.RemoveGold(ShopInventory.WeaponList[choice - 1].Price);
                        player.Inventory.AddItem(ShopInventory.WeaponList[choice - 1]);
                    }
                    else if (player.Gold < ShopInventory.WeaponList[choice - 1].Price)
                    {
                        Console.WriteLine("You do not have enough gold to buy that");
                        Console.ReadKey();
                    }

                }

            } while (choice != 0);
        }

        private void BuyArmour(Player player, UserInput userInput)
        {
            int choice = 99;

            do
            {
                Console.Clear();
                Console.WriteLine();
                player.DisplayGold();

                ShopInventory.DisplayArmour();
                Console.WriteLine("[0] - EXIT");
                choice = userInput.PickItemFromList(ShopInventory.ArmourList);

                if(choice > 0)
                {
                    Console.Clear();
                    Console.WriteLine();
                    player.DisplayGold();

                    ShopInventory.ArmourList[choice - 1].DisplayStats();
                    Console.WriteLine();
                    Console.WriteLine($"{Environment.NewLine}Would you like to buy this item?{Environment.NewLine}");
                    bool buy = userInput.PickYesOrNo();

                    if (buy && player.Gold >= ShopInventory.ArmourList[choice - 1].Price)
                    {
                        player.RemoveGold(ShopInventory.ArmourList[choice - 1].Price);
                        player.Inventory.AddItem(ShopInventory.ArmourList[choice - 1]);
                    }
                    else if(player.Gold < ShopInventory.ArmourList[choice - 1].Price)
                    {
                        Console.WriteLine("You do not have enough gold to buy that");
                        Console.ReadKey();
                    }
                }

            }while(choice  != 0);
        }

        private void Sell(Player player, UserInput userInput)
        {
            Console.Clear();

            if(player.Inventory.ItemList.Count > 0)
            {
                int count = 1;
                Console.WriteLine();
                player.DisplayGold();
                Console.WriteLine($"{Environment.NewLine}Pick an item to sell: {Environment.NewLine}");

                foreach(BaseItem item in player.Inventory.ItemList)
                {
                    Console.WriteLine($"[{count}] {item.Name} - Value: {item.Price}");
                    count++;
                }

                Console.WriteLine();
                Console.WriteLine("[0] - EXIT");
                int choice = userInput.PickItemFromList(player.Inventory.ItemList);

                if(choice > 0)
                {
                    Console.WriteLine($"{Environment.NewLine}Are you sure you want to sell {player.Inventory.ItemList[choice - 1].Name}?");
                    bool confirm = userInput.PickYesOrNo();

                    if(confirm)
                    {
                        player.AddGold(player.Inventory.ItemList[choice - 1].Price);
                        player.Inventory.RemoveItem(choice - 1);
                    }
                }

            }
            else
            {
                Console.WriteLine("You have no items to sell");
                Console.ReadKey();
                return;
            }

        }

        private void GenerateBaseInventory()
        {
            BronzeWeapons bronzeWeapons = new();

            List<BaseWeapon> weaponInventory = new();
            
            foreach(BaseWeapon weapon in bronzeWeapons.BronzeWeaponList)
            {
                ShopInventory.WeaponList.Add(weapon);
            }

            CommonArmour.LeatherArmour leatherArmour = new();
            CommonArmour.BronzeArmour bronzeArmour = new();

            ShopInventory.ArmourList.Add(leatherArmour);
            ShopInventory.ArmourList.Add(bronzeArmour);
        }

        private bool CheckIfIronAlreadyAdded(AllTourneys allTourneys)
        {
            if(allTourneys.Rank2Unlocked && IronUnlocked)
            {
                return true;
            }
            else if(allTourneys.Rank2Unlocked && !IronUnlocked)
            {
                AddIronEquipment();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfSteelAlreadyAdded(AllTourneys allTourneys)
        {
            if(allTourneys.Rank3Unlocked && SteelUnlocked)
            {
                return true;
            }
            else if(allTourneys.Rank3Unlocked && !SteelUnlocked)
            {
                AddSteelEquipment();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddIronEquipment()
        {
            IronWeapons ironWeapons = new();

            foreach(BaseWeapon weapon in ironWeapons.IronWeaponList)
            {
                ShopInventory.WeaponList.Add(weapon);
            }

            CommonArmour.IronArmour ironArmour = new();
            ShopInventory.ArmourList.Add(ironArmour);
        }

        private void AddSteelEquipment()
        {
            SteelWeapons steelWeapons = new();

            foreach(BaseWeapon weapon in  steelWeapons.SteelWeaponList)
            {
                ShopInventory.WeaponList.Add(weapon);
            }

            CommonArmour.SteelArmour steelArmour = new();
            ShopInventory.ArmourList.Add(steelArmour);
        }

        //-------
    }
}
