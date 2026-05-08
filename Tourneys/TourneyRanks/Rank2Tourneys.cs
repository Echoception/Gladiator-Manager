using Gladiator_Manager.Tourneys.Cups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Tourneys.TourneyRanks
{
    internal class Rank2Tourneys : RankXTourney
    {
        public Rank2Tourneys()
        {
            _rank2TourneyList = new();
        }

        private List<BasicTourney> _rank2TourneyList { get; set; }

        public List<BasicTourney> Rank2TourneyList => _rank2TourneyList;


        public void UnlockRank2Tourneys()
        {
            FillRank2TourneyList();
        }

        private void FillRank2TourneyList()
        {
            JourneyMansCup journeyMansCup = new JourneyMansCup();

            _rank2TourneyList.Add(journeyMansCup);
        }


    }
}
