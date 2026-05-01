using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Input
{
    internal class UserInput
    {






        public int PickValidInt()
        {
            bool validChoice = false;
            int result = 0;

            do
            {
                validChoice = int.TryParse(Console.ReadLine(), out result);

                if(!validChoice)
                {
                    DisplayPickValidNumberText();
                }

            } while (!validChoice);

            return result;
        }

        public int PickItemFromList<T>(List<T> list)
        {
            bool validChoice = false;
            int result = 0;

            do
            {

                int.TryParse(Console.ReadLine(), out result);

                if(result > list.Count || result < 0)
                {
                    DisplayPickValidOptionText();
                }
                else
                {
                    validChoice = true;
                }

            } while (!validChoice);

            return result;

        }

        public bool PickYesOrNo()
        {
            bool result = false;
            bool validChoice = false;

            Console.WriteLine("[1] - Yes");
            Console.WriteLine("[2] - No");

            int choice = PickValidInt();

            if(choice == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }


        public void DisplayPickValidOptionText()
        {
            Console.WriteLine("Pick a valid option");
            Console.ReadKey();
        }

        public void DisplayPickValidNumberText()
        {
            Console.WriteLine("Pick a valid number");
        }


        // ---
    }
}
