using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Gun : Weapon
    {
        public Gun() : base()
        {
            base.name = "伝説の武器";
            this.range = 5;
            this.attack = 10000;
            this.accuracy = 0.9;
            base.endurance = 30000;
            this.dist_penaltiy = 0.8;
            this.staminaConsumption = 0.01;
            base.weight = 50;
        }
    }
}
