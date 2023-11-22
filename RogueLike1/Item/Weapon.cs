using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Weapon : Item
    {

        public int range;
        public double attack;
        public double staminaConsumption;
        public double accuracy;
        public double dist_penaltiy;

        public Weapon() : base()
        {
            
        }



        public override void effect(Character hoge)
        {
            throw new NotImplementedException();
        }
    }
}
