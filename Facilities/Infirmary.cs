using Gladiator_Manager.Gladiators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Facilities
{
    internal class Infirmary
    {
        public Infirmary()
        {
            _rank = 1;
            _usingInfirmary = new();
        }


        private int _rank { get; set; }
        private List<Gladiator> _usingInfirmary { get; set; }

        public int Rank => _rank;
        public List<Gladiator> UsingInfirmary => _usingInfirmary;
        

    }
}
