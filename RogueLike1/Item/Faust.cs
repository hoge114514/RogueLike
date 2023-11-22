using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Faust : Weapon
    {
        public Faust() : base()
        {
            base.name = "拳";
            this.range = 0;
            this.attack = 10;
            this.accuracy = 0.8;
            base.endurance = 1145141919;
            this.dist_penaltiy = 1;
            this.staminaConsumption = 10;
        }
    }
}
