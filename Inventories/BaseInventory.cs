using Gladiator_Manager.Items;
using Gladiator_Manager.Tourneys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.Inventories
{
    internal abstract class BaseInventory
    {
        public BaseInventory()
        {
            ItemList = new();
        }

        public List<BaseItem> ItemList { get; set; }

        public void DisplayItems()
        {
            int count = 1;

            Console.Clear();
            Console.WriteLine();

            foreach(BaseItem item in ItemList)
            {
                Console.WriteLine($"[{count}] - {item.Name}");
                count++;
            }

        }

        public void AddItem(BaseItem item)
        {
            ItemList.Add(item);
        }

        public void RemoveItem(int index)
        {
            ItemList.RemoveAt(index);
        }
    }
}
