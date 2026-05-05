using Gladiator_Manager.Facilities;
using Gladiator_Manager.Gladiators;
using Gladiator_Manager.Input;
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
        }

        private List<Gladiator> _gladiatorList { get; set; }
        private int _rank { get; set; }
        // Inventory
        // Gold
        // Trophies?
        // rank? - controls roster size?  if not use lvl / upgrade system

        public List<Gladiator> GladiatorList => _gladiatorList;
        public int Rank => _rank;


        public void DisplayGladiatorList()
        {
            int count = 1;
            Console.WriteLine();
            foreach(Gladiator glad in _gladiatorList)
            {
                Console.WriteLine($"[{count}] {glad.Name}  -  {glad.Rating}");
                count++;
            }
            //Console.ReadKey();
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


        //-----
    }
}
