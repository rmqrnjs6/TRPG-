using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Inventory
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int OffensivePower { get; set; }
        public int DefensivePower { get; set; }
        public bool IsEquipped { get; set; }

        public Inventory(string name, string type, int OffPower, int DeffPower)
        {
            Name = name;
            Type = type;
            OffensivePower = OffPower;
            DefensivePower = DeffPower;
            IsEquipped = false;
        }

        public override string ToString()
        {
            string equippedText = IsEquipped ? "(장착 중)" : "";
            return $"{Name}{equippedText} 타입: {Type} | 공격력 +{OffensivePower} | 방어력 +{DefensivePower}";
        }
    }
}