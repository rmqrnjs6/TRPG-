using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp3.enumset;

namespace ConsoleApp3
{
    public class Player
    {
        public string name { get; set; }
        public Job job { get; set; }
        public int level { get; set; } = 1;
        public int OffensivePower { get; set; } = 10;
        public int DeffensivePower { get; set; } = 5;
        public int HP { get; set; }  = 50;
        public int Gold { get; set; }  = 100000;

        public List<Inventory> InventoryItems { get; set; } = new List<Inventory>();
        public int TotalOffpower
        {
            get
            {
                return OffensivePower + InventoryItems
                    .Where(item => item.IsEquipped)
                    .Sum(item => item.OffensivePower);

            }
        }
        public int TotalDefenspower
        {
            get
            {
                return DeffensivePower + InventoryItems
                    .Where(item => item.IsEquipped)
                    .Sum(item => item.DefensivePower);

            }
        }

    }
}
