using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Items
{
    internal abstract class BaseItem
    {
        public BaseItem()
        {
            Name = "";
            Price = 0;
        }

        public string Name { get; set; }
        public int Price { get; set; }

    }
}
