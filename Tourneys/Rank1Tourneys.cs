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
    internal class Rank1Tourneys : RankXTourney
    {
        public Rank1Tourneys()
        {
            _rank1TourneyList = new();
        }

        private List<BasicTourney> _rank1TourneyList;

        public List<BasicTourney> Rank1TourneyList => _rank1TourneyList;


        public void UnlockRank1Tourneys()
        {
            FillRank1TourneyList();
        }

        private void FillRank1TourneyList()
        {
            WeekendWarriorCup weekendWarriorCup = new WeekendWarriorCup();

            _rank1TourneyList.Add(weekendWarriorCup);
        }

        

    }
}
