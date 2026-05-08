using Gladiator_Manager.BattleSystem;
using Gladiator_Manager.CustomTimer;
using Gladiator_Manager.Input;
using Gladiator_Manager.PlayerClass;
using Gladiator_Manager.SystemCreators;
using Gladiator_Manager.Tourneys.Cups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Tourneys
{
    internal class AllTourneys
    {
        public AllTourneys()
        {
            _rank1Tourneys = new Rank1Tourneys();

            _rank2Unlocked = false;
        }


        private Rank1Tourneys _rank1Tourneys { get; set; }
        
        private bool _rank2Unlocked { get; set; }

        public Rank1Tourneys Rank1Tourneys => _rank1Tourneys;

        public bool Rank2Unlocked => _rank2Unlocked;


        public void MainMenu(UserInput userInput, BattleHandler battleHandler, Player player, GladiatorCreator gladiatorCreator, Ctimer timer, Rank1Tourneys rank1Tourneys)
        {
            int choice = 99;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("[1] - Rank 1 Tournaments");
                Console.WriteLine("[2] - Rank 2 Tournaments");

                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch(choice)
                {
                    case 1:
                        rank1Tourneys.PickRank1Tourney(userInput, battleHandler, player, gladiatorCreator, timer, rank1Tourneys.Rank1TourneyList);
                        break;

                    case 2:  //  if(rank2 !unloced && checkForUnlocked = true)  { add to eank2 list }
                        break;

                    case 3:
                        break;

                    case 0:
                        return;

                    default:
                        userInput.DisplayPickValidOptionText();
                        break;
                }

            } while (choice != 0);

        }

        private bool CheckForRank2Unlocked()
        {
            bool result = _rank1Tourneys.Rank1TourneyList.All(x => x.Completed = true);
            return result;
        }

        private void FillRank2List()
        {

        }

        //-----
    }
}
