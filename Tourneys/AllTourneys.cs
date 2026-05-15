using Gladiator_Manager.BattleSystem;
using Gladiator_Manager.CustomTimer;
using Gladiator_Manager.Input;
using Gladiator_Manager.PlayerClass;
using Gladiator_Manager.SystemCreators;
using Gladiator_Manager.Tourneys.Cups;
using Gladiator_Manager.Tourneys.TourneyRanks;
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
            _rank2Tourneys = new Rank2Tourneys();
            _rank3Tourneys = new Rank3Tourneys();
            _rank2Unlocked = false;
            _rank3Unlocked = false;
        }


        private Rank1Tourneys _rank1Tourneys { get; set; }
        private Rank2Tourneys _rank2Tourneys { get; set; }
        private Rank3Tourneys _rank3Tourneys { get; set; }

        private bool _rank2Unlocked { get; set; }
        private bool _rank3Unlocked { get; set; }

        public Rank1Tourneys Rank1Tourneys => _rank1Tourneys;
        public Rank2Tourneys Rank2Tourneys => _rank2Tourneys;
        public Rank3Tourneys Rank3Tourneys => _rank3Tourneys;

        public bool Rank2Unlocked => _rank2Unlocked;
        public bool Rank3Unlocked => _rank3Unlocked;

        private bool CheckAvailableGladiators(Player player)
        {
            bool result = player.GladiatorList.All(x => x.InFacilities);
            return result;
        }

        public void MainMenu(UserInput userInput, BattleHandler battleHandler, Player player, GladiatorCreator gladiatorCreator, Ctimer timer)
        {
            int choice = 99;
            if(!_rank2Unlocked)
            {
                _rank2Unlocked = CheckForRank2Unlocked();
                if(_rank2Unlocked)
                {
                    _rank2Tourneys.UnlockRank2Tourneys();
                }
            }

            if(!_rank3Unlocked)
            {
                _rank3Unlocked = CheckForRank3Unlocked();
                if(_rank3Unlocked)
                {
                    _rank3Tourneys.UnlockRank3Tourney();
                }
            }

            if(CheckAvailableGladiators(player))
            {
                Console.WriteLine("You do not have the gladiators available to do that");
                Console.ReadKey();
                return;
            }


           // do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("[1] - Rank 1 Tournaments");
                Console.WriteLine("[2] - Rank 2 Tournaments");
                Console.WriteLine("[3] - Rank 3 Tournaments");
                Console.WriteLine("[0] - EXIT");

                choice = userInput.PickValidInt();

                switch(choice)
                {
                    case 1:
                        _rank1Tourneys.PickRankXTourney(userInput, battleHandler, player, gladiatorCreator, timer, _rank1Tourneys.Rank1TourneyList);
                        break;

                    case 2: 

                        if(Rank2Unlocked)
                        {
                            _rank2Tourneys.PickRankXTourney(userInput, battleHandler, player, gladiatorCreator, timer, _rank2Tourneys.Rank2TourneyList);
                        }
                        else
                        {
                            Console.WriteLine("You have not unlocked Rank 2 Tournaments yet");
                            Console.ReadKey();
                        }

                            break;

                    case 3:

                        if(Rank2Unlocked)
                        {
                            _rank3Tourneys.PickRankXTourney(userInput, battleHandler, player, gladiatorCreator, timer, _rank3Tourneys.Rank3TourneyList);
                        }
                        else
                        {
                            Console.WriteLine("You have not unlocked Rank 3 Tournaments yet");
                            Console.ReadKey();
                        }

                            break;

                    case 0:
                        return;

                    default:
                        userInput.DisplayPickValidOptionText();
                        MainMenu(userInput, battleHandler, player, gladiatorCreator, timer);
                        break;
                }

            }// while (choice != 0);

        }

        private bool CheckForRank2Unlocked()
        {
            bool result = _rank1Tourneys.Rank1TourneyList.All(x => x.Completed);
            return result;
        }

        private bool CheckForRank3Unlocked()
        {
            bool result = _rank2Tourneys.Rank2TourneyList.All(x => x.Completed);
            return result;
        }

        //-----
    }
}
