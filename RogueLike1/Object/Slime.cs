using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Slime : Enemy
    {
        public Slime(int hoge, int piyo, char fuga,NormalIO box) : base(hoge, piyo,fuga, box)
        {
            base.name = "スライム" + fuga;

            base.HP = 100;
            base.MP = 50;
            base.starvation = 10;
            base.stamina = 100;
            base.speed = 10;

            base.exp_demand = 1;

            base.MAX_HP = 100;
            base.MAX_MP = 50;
            base.MAX_starvation = 10;
            base.MAX_stamina = 100;
            base.MAX_speed = 10;

            base.HP_gradient = 50;
            base.MP_gradient = 10;
            base.starvation_gradient = 10;
            base.stamina_gradient = 100;
            base.speed_gradient = 10;

            base.symbol = 'ス';
        }
    }
}
