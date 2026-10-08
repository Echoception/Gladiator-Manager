using Gladiator_Manager.PlayerClass;
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
        private int _rank1UpgradeCost = 500;
        private int _rank2UpgradeCost = 1000;


        public int AccommodationSize => _accommodationSize;
        public int Rank => _rank;
        public int Rank1UpgradeCost => _rank1UpgradeCost;
        public int Rank2UpgradeCost => _rank2UpgradeCost;
        private int _slotsToGainOnRankUp = 3;


        private void RankUp()
        {
            _rank++;
        }

        public void UpgradeToRank2(Player player)
        {
            if(player.Gold >= _rank1UpgradeCost)
            {
                player.RemoveGold(_rank1UpgradeCost);
                RankUp();
                DisplayConfirmUpgrade();
            }
            else
            {
                DisplayNotEnoughGold();
            }
        }

        private void UpgradeToRank3(Player player)
        {
            if(player.Gold >= _rank2UpgradeCost)
            {
                player.RemoveGold(_rank2UpgradeCost);
                RankUp();
                DisplayConfirmUpgrade();
            }
            else
            {
                DisplayNotEnoughGold();
            }
        }

        private void DisplayNotEnoughGold()
        {
            Console.WriteLine("You do not have enough gold for that upgrade");
            Console.ReadKey();
        }

        private void DisplayConfirmUpgrade()
        {
            Console.WriteLine($"You have upgraded your accommodations to rank: {Rank}");
            Console.ReadKey();
        }

        public void BuyUpgrade(Player player)
        {
            switch(Rank)
            {
                case 1:
                    UpgradeToRank2(player);
                    break;
                case 2:
                    UpgradeToRank3(player);
                    break;
                case 3:
                    Console.WriteLine("Your accommodations are at max rank");
                    Console.ReadKey();
                    break;
            }
        }

        //----
    }
}
