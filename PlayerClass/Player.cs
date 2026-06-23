using Gladiator_Manager.Facilities;
using Gladiator_Manager.Gladiators;
using Gladiator_Manager.Input;
using Gladiator_Manager.Inventories;
using Gladiator_Manager.Items.Trophies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.PlayerClass
{
    internal class Player
    {
        public Player()
        {
            _gladiatorList = new();
            _trophyDictionary = new();
            _gold = 60000; // default 500?
            _inventory = new();
        }

        private List<Gladiator> _gladiatorList { get; set; }
        private Dictionary<BaseTrophy, int> _trophyDictionary { get; set; }
        private PlayerInventory _inventory { get; set; }
        private int _rank { get; set; }
        private int _gold { get; set; }

        // rank? - controls roster size?  if not use lvl / upgrade system

        public List<Gladiator> GladiatorList => _gladiatorList;
        public Dictionary<BaseTrophy, int> TrophyDictionary => _trophyDictionary;
        public PlayerInventory Inventory => _inventory;
        public int Rank => _rank;
        public int Gold => _gold;


        public void DisplayGold()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Gold} gold");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void RemoveGold(int goldToRemove)
        {
            _gold -= goldToRemove;
        }

        public void AddGold(int goldToAdd)
        {
            _gold += goldToAdd;
        }

        public void DisplayGladiatorList()
        {
            int count = 1;
            Console.WriteLine();
            foreach(Gladiator glad in _gladiatorList)
            {
                Console.Write($"[{count}] {glad.Name} - Rating {glad.Rating}");
                if(glad.InFacilities)
                {
                    Console.Write("    [ Using Facilities ]");
                }
                count++;
                Console.WriteLine();
            }
        }


        public void ViewGladiatorInList(UserInput userInput)
        {
            int choice = 99;

            do
            {
                Console.Clear();
                Console.WriteLine();
                DisplayGladiatorList();

                Console.WriteLine();
                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickItemFromList(GladiatorList);

                if (choice > 0)
                {
                    Console.Clear();
                    Console.WriteLine();
                    GladiatorList[choice - 1].DisplayStats();
                    Console.ReadKey();
                }

            } while (choice > 0);
        }

        public void AddGladiatorToRoster(Gladiator gladiator)
        {
                _gladiatorList.Add(gladiator);
        }

        public void RemoveGladiatorFromList(int index)
        {
            _gladiatorList.RemoveAt(index);
        }

        public Gladiator PickGladiatorFromList(UserInput userInput)
        {
            int choice = 99;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Pick a gladiator: {Environment.NewLine}");
            DisplayGladiatorList();
            Console.WriteLine($"{Environment.NewLine}[0] - EXIT");

            choice = userInput.PickItemFromList(GladiatorList);

            if(choice > 0)
            {
                Gladiator gladiator = GladiatorList[choice - 1];
                return gladiator;
            }
            else
            {
                Gladiator nullGlad = null;
                return nullGlad;
            }
            
        }

        public void AddTrophy(BaseTrophy trophy)  //   Add to inventory??
        {
            if(TrophyDictionary.ContainsKey(trophy))
            {
                int newValue = 0;

                _trophyDictionary.TryGetValue(trophy, out newValue);
                _trophyDictionary[trophy] += 1;
            }
            else
            {
                _trophyDictionary.Add(trophy, 1);
            }
        }

        public void ShowTrophies()    //   Add to inventory??
        {
            Console.Clear();
            Console.WriteLine();

            for(int i = 0; i < _trophyDictionary.Count; i++)
            {
                Console.WriteLine($"{_trophyDictionary.ElementAt(i).Key.Name} - x{_trophyDictionary.ElementAt(i).Value}");
            }

        }

        public void WeeklyHeal()
        {
            foreach(Gladiator glad in _gladiatorList)
            {
                glad.WeeklyHeal();
            }
        }

        //-----
    }
}
