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
            Console.WriteLine();
            foreach(Gladiator glad in _gladiatorList)
            {
                Console.WriteLine($"{glad.Name}  -  {glad.Rating}");
            }
            //Console.ReadKey();
        }

        public void AddGladiatorToRoster(Gladiator gladiator, Accommodations accommodations)
        {
            if(GladiatorList.Count >= accommodations.AccommodationSize)
            {
                Console.WriteLine("You do not have enough space in your accommodations");
                Console.ReadKey();
            }
            else
            {
                _gladiatorList.Add(gladiator);
            }
        }

        public Gladiator PickGladiatorFromList(UserInput userInput)
        {
            int choice = 99;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Pick a gladiator: {Environment.NewLine}");
            DisplayGladiatorList();

            choice = userInput.PickItemFromList(GladiatorList);

            Gladiator gladiator = GladiatorList[choice - 1];

            return gladiator;
        }

        //-----
    }
}
