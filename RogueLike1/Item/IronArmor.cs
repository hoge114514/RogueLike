using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class IronArmor : Armor
    {
        public IronArmor() : base()
        {
            base.name = "鉄の鎧";
            this.defence = 100;
            base.endurance = 50;
            base.weight = 100;
        }
    }
}
