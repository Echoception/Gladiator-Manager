using Gladiator_Manager.Gladiators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Facilities
{
    internal class TrainingFields
    {
        public TrainingFields()
        {
            _rank = 1;
            _slot1 = new();
            _slot2 = new();
            _slot3 = new();
        }

        private int _rank { get; set; }
        private Gladiator _slot1 { get; set; }
        private Gladiator _slot2 { get; set; }
        private Gladiator _slot3 { get; set; }

        public int Rank => _rank;
        public Gladiator Slot1 => _slot1;
        public Gladiator Slot2 => _slot2;
        public Gladiator Slot3 => _slot3;


        

    }
}
