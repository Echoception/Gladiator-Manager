using Gladiator_Manager.Facilities;
using Gladiator_Manager.PlayerClass;
using Gladiator_Manager.Shops;
using Gladiator_Manager.SystemCreators;
using Gladiator_Manager.Tourneys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.DateSystem
{
    internal class DateHandler
    {
        public DateHandler()
        {
            _currentGameDate = _startingDate;
        }


        private DateOnly _currentGameDate { get; set; }

        public DateOnly CurrentGameDate => _currentGameDate;

        private DateOnly _startingDate = new DateOnly(34, 1, 1);


        public void DisplayDate()
        {
            Console.WriteLine($"{_currentGameDate.Day} of {Months[_currentGameDate.Month - 1]} - {_currentGameDate.Year}AD");
        }
        
        public void AdvanceWeek(GladiatorMarket gladiatorMarket, GladiatorCreator gladiatorCreator, TrainingFields trainingFields, Player player, Infirmary infirmary,
                    AllTourneys allTourneys)
        {
            allTourneys.WeeklyClear();
            infirmary.WeeklyClear();
            trainingFields.WeeklyClear();
            player.WeeklyHeal();
            gladiatorMarket.RandomiseGladiatorsForSale(gladiatorCreator);
            _currentGameDate = _currentGameDate.AddDays(7);
        }


        public string[] Months =
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };

        // ----
    }
}
