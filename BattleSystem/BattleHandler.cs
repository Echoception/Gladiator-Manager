using Gladiator_Manager.CustomTimer;
using Gladiator_Manager.Gladiators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.BattleSystem
{
    internal class BattleHandler
    {// Add turnCount?



        public void Battle(Gladiator glad1, Gladiator glad2, Ctimer timer)
        {
            if(glad1 != null && glad2 != null)
            {
                do
                {
                    Console.Clear();
                    ShowHealthValues(glad1, glad2);

                    if (glad1.Health > 0)
                    {
                        glad2.TakeDamage(glad1);
                        timer.StartTimer();
                    }

                    Console.Clear();
                    ShowHealthValues(glad1, glad2);

                    if (glad2.Health > 0)
                    {
                        glad1.TakeDamage(glad2);
                        timer.StartTimer();
                    }

                } while (glad1.Health > 0 && glad2.Health > 0);

                Console.Clear();
                ShowHealthValues(glad1, glad2);
                Console.ReadKey();
            }

        }

        public void ShowHealthValues(Gladiator glad1, Gladiator glad2)
        {
            //Console.WriteLine($"{glad1.Name} - {glad1.Health} \t\t {glad2.Name} - {glad2.Health}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{glad1.Name} : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{glad1.Health} / {glad1.MaxHealth} HP\t\t");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{glad2.Name} : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{glad2.Health} / {glad2.MaxHealth} HP");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //----
    }
}
