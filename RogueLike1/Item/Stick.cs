using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Stick : Weapon
    {
        public Stick() : base()
        {
            base.name = "棒";
            this.range = 1;
            this.attack = 10;
            this.accuracy = 0.8;
            base.endurance = 100;
            this.dist_penaltiy = 1;
            this.staminaConsumption = 30;
            this.weight = 50;
        }
    }
}
