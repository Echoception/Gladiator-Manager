using Gladiator_Manager.Facilities;
using Gladiator_Manager.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Shops
{
    internal class FacilityUpgrades
    {


        public void Menu(UserInput userInput, Accommodations accommodations)
        {
            int choice = 99;

            do
            {

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("[1] - Rank-Up Accommodations");

                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch(choice)
                {
                    case 1:
                        accommodations.RankUp();
                        break;

                    case 0:
                        return;

                    default:
                        userInput.DisplayPickValidOptionText();
                        break;
                }

            } while (choice != 0);

        }

    }
}
