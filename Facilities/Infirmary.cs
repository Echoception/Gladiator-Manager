using Gladiator_Manager.Gladiators;
using Gladiator_Manager.Input;
using Gladiator_Manager.PlayerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Facilities
{
    internal class Infirmary
    {
        public Infirmary()
        {
            _rank = 1;
            _healAmount = 20 * _rank;
            _usingInfirmary = new();
        }


        private int _healAmount { get; set; }
        private int _rank { get; set; }
        private List<Gladiator> _usingInfirmary { get; set; }

        public int HealAmount => _healAmount;
        public int Rank => _rank;
        public List<Gladiator> UsingInfirmary => _usingInfirmary;



        private void PickGladiatorToAdd(Player player, UserInput userInput)
        {
            Console.Clear();
            Console.WriteLine();

            Gladiator glad = player.PickGladiatorFromList(userInput);

            if (glad == null)
            {
                return;
            }
            else
            {
                AddToInfirmary(glad);
            }

        }

        private void AddToInfirmary(Gladiator gladiator)
        {
            if(gladiator.InFacilities)
            {
                Console.WriteLine($"{gladiator.Name} is already using facilities");
                Console.ReadKey();
            }
            else if (_usingInfirmary.Count == 0)
            {
                _usingInfirmary.Add(gladiator);
                gladiator.PutInFacilities();
            }
            else if (_usingInfirmary.Count == 1 && _rank >= 2)
            {
                _usingInfirmary.Add(gladiator);
                gladiator.PutInFacilities();
            }
            else if (_usingInfirmary.Count == 2 && _rank >= 3)
            {
                _usingInfirmary.Add(gladiator);
                gladiator.PutInFacilities();
            }
            else
            {
                Console.WriteLine("You do not have space in your facilities");
                Console.ReadKey();
            }

        }

        private void RemoveFromInfirmary(UserInput userInput)
        {
            Console.Clear();
            Console.WriteLine();

            DisplayGladiatorsInInfirmary();
            int choice = 99;

            Console.WriteLine("Pick a Gladiator to remove");
            choice = userInput.PickValidInt();

            if(choice > 0)
            {
                _usingInfirmary[choice - 1].RemoveFromFacilities();
                _usingInfirmary.RemoveAt(choice - 1);
            }

        }

        public void DisplayGladiatorsInInfirmary()
        {
            Console.Clear();
            Console.WriteLine();
            int count = 1;

            foreach(Gladiator glad in _usingInfirmary)
            {
                if(glad != null)
                {
                    Console.WriteLine($"[{count}]: {glad.Name} - Rating: {glad.Rating}");
                    count++;
                }
                else
                {
                    break;
                }
            }

        }

        public void InfirmaryMenu(Player player, UserInput userInput)
        {
            int choice = 99;

            do
            {

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("[1] - Heal Gladiator");
                Console.WriteLine("[2] - Remove - NI");
                Console.WriteLine("[3] - View Gladiators in Infirmary - NI");

                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch (choice)
                {
                    case 1:
                        if(player.GladiatorList.Count > 0)
                        {
                            PickGladiatorToAdd(player, userInput);
                        }
                        else
                        {
                            Console.WriteLine("You have no Gladiators to add");
                            Console.ReadKey();
                        }
                            break;

                    case 2:
                        if(_usingInfirmary.Count > 0)
                        {
                            RemoveFromInfirmary(userInput);
                        }
                        else
                        {
                            Console.WriteLine("The Infirmary is empty");
                            Console.ReadKey();
                        }
                            break;

                    case 3:
                        if(_usingInfirmary.Count > 0)
                        {
                            DisplayGladiatorsInInfirmary();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("The Infirmary is empty");
                            Console.ReadKey();
                        }
                            break;

                    case 0:
                        return;

                    default:
                        userInput.DisplayPickValidOptionText();
                        break;
                }

            } while (choice != 0);

        }

        public void RankUp()
        {
            _rank += 1;
        }

        public void WeeklyClear()
        {
            foreach(Gladiator glad in _usingInfirmary)
            {
                if(glad != null)
                {
                    glad.InfirmaryHeal(HealAmount);
                    glad.RemoveFromFacilities();
                }
                else
                {
                    break;
                }
            }

            _usingInfirmary.Clear();
        }

        //----
    }
}
