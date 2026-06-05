using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Items.Trophies
{
    internal abstract class BaseTrophy : BaseItem
    {
        public BaseTrophy()
        {
            Name = "";
            Price = 0;
        }

    }
}
