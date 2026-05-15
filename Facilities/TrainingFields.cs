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
    internal class TrainingFields
    {
        public TrainingFields()
        {
            _rank = 1;
            _inFacilities = new();
            _statChoice = [0, 0, 0];
        }

        private int _rank { get; set; }
        private List<Gladiator> _inFacilities { get; set; }
        private int[] _statChoice { get; set; }

        public int Rank => _rank;
        public List<Gladiator> InFacilities => _inFacilities;
        public int[] StatChoice => _statChoice;


        private int PickStatToRaise(UserInput userInput, Gladiator gladiator)
        {
            int choice = 99;

            do
            {
                Console.Clear();
                Console.WriteLine();  //  might not need
                gladiator.DisplayStats();
                Console.WriteLine();  // might not need

                Console.WriteLine("[1] - Health");
                Console.WriteLine("[2] - Attack");
                Console.WriteLine("[3] - Defence");
                Console.WriteLine("[4] - Speed");
                Console.WriteLine("[5] - Charisma");
                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                if(choice < 0 && choice > 6)
                {
                    userInput.DisplayPickValidOptionText();
                }

            } while (choice < 0 && choice > 6);

            return choice;
        }

        private void PickGladiatorToAdd(Player player, UserInput userInput)
        {
            Console.Clear();
            Console.WriteLine();

            Gladiator gladiator = player.PickGladiatorFromList(userInput);

            if (gladiator == null)
            {
                return;
            }
            else
            {
                AddToInFacilitiesList(gladiator, userInput);
            }
            
        }

        private void AddToInFacilitiesList(Gladiator gladiator, UserInput userInput)
        {
            int statIndex = 0;

            if(gladiator.InFacilities)
            {
                Console.WriteLine($"{gladiator.Name} is already using facilities");
                Console.ReadKey();
            }
            else if (_inFacilities.Count == 0)
            {
                statIndex = PickStatToRaise(userInput, gladiator);

                if (statIndex != 0)
                {
                    _statChoice[0] = statIndex;
                }
                else
                {
                    return;
                }

                gladiator.PutInFacilities();
                _inFacilities.Add(gladiator);
            }
            else if (_rank >= 2 && _inFacilities.Count == 1)
            {
                statIndex = PickStatToRaise(userInput, gladiator);

                if (statIndex != 0)
                {
                    _statChoice[1] = statIndex;
                }
                else
                {
                    return;
                }

                    gladiator.PutInFacilities();
                _inFacilities.Add(gladiator);
            }
            else if (_rank >= 3 && _inFacilities.Count == 2)
            {
                statIndex = PickStatToRaise(userInput, gladiator);

                if (statIndex != 0)
                {
                    _statChoice[2] = statIndex;
                }
                else
                {
                    return;
                }

                    gladiator.PutInFacilities();
                _inFacilities.Add(gladiator);
            }
            else
            {
                Console.WriteLine("You do not have space in your facilities");
                Console.ReadKey();
            }

        }

        private void DisplayUsingList()
        {
            int count = 1;

            Console.Clear();
            Console.WriteLine();

            if (_inFacilities.Count > 0)
            {
                foreach (Gladiator glad in _inFacilities)
                {
                    if (glad != null)
                    {
                        Console.WriteLine($"{count}: {glad.Name} - Rating: {glad.Rating}");
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void RemoveGladiatorFromFacilities(UserInput userInput)
        {
            Console.Clear();
            Console.WriteLine();

            DisplayUsingList();
            int choice = 99;

            Console.WriteLine("Pick a gladiator to remove: ");
            choice = userInput.PickItemFromList(InFacilities);

            if(choice > 0)
            {
                _inFacilities[choice - 1].RemoveFromFacilities();
                _inFacilities.RemoveAt(choice - 1);
            }

        }

        private void RaiseGladiatorStats()
        {
            int index = 0;

            foreach(Gladiator glad in _inFacilities)
            {
                switch(_statChoice[index])
                {
                    case 1:
                        glad.RaiseMaxHp();
                        break;
                    case 2:
                        glad.RaiseAttack();
                        break;
                    case 3:
                        glad.RaiseDefence();
                        break;
                    case 4:
                        glad.RaiseSpeed();
                        break;
                    case 5:
                        glad.RaiseCharisma();
                        break;
                }
                glad.RemoveFromFacilities();
                index++;
            }

        }
        
        public void WeeklyClear()
        {
            RaiseGladiatorStats();
            _inFacilities.Clear();
        }

        public void RankUp()
        {
            _rank += 1;
        }

        

        public void Menu(UserInput userInput, Player player)
        {
            int choice = 99;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("[1] - Train Gladiator");
                Console.WriteLine("[2] - Remove Gladiator");
                Console.WriteLine("[3] - View Gladiators in Facilities");

                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch(choice)
                {
                    case 1:
                        if (player.GladiatorList.Count > 0)
                        {
                            PickGladiatorToAdd(player, userInput);
                        }
                        else
                        {
                            Console.WriteLine("You have no Gladiators");
                            Console.ReadKey();
                        }
                            break;

                    case 2:
                        if (InFacilities.Count > 0)
                        {
                            RemoveGladiatorFromFacilities(userInput);
                        }
                        else
                        {
                            Console.WriteLine("The facility is empty");
                            Console.ReadKey();
                        }
                            break;

                    case 3:
                        if (InFacilities.Count > 0)
                        {
                            DisplayUsingList();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("The facility is empty");
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


        //----
    }
}
