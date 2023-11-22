using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Cloth : Armor
    {
        public Cloth() : base()
        {
            base.name = "革の腰巾着";
            this.defence = 3;
            base.endurance = 10;
            base.weight = 1;
        }
    }
}
