using Gladiator_Manager.Tourneys.Cups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Tourneys.TourneyRanks
{
    internal class Rank3Tourneys : RankXTourney
    {
        public Rank3Tourneys()
        {
            _rank3TourneyList = new();
        }

        private List<BasicTourney> _rank3TourneyList { get; set; }

        public List<BasicTourney> Rank3TourneyList => _rank3TourneyList;

        public void UnlockRank3Tourney()
        {
            FillRank3TourneyList();
        }


        private void FillRank3TourneyList()
        {
            VeteransCup veteransCup = new VeteransCup();

            _rank3TourneyList.Add(veteransCup);
        }

    }
}
