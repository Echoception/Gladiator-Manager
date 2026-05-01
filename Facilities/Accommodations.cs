using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Facilities
{
    internal class Accommodations
    {
        public Accommodations()
        {
            _rank = 1;
        }

        private int _rank { get; set; }
        private int _accommodationSize => _rank * _slotsToGainOnRankUp;

        public int AccommodationSize => _accommodationSize;
        public int Rank => _rank;

        private int _slotsToGainOnRankUp = 3;
    }
}
