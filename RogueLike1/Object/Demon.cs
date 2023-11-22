using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Demon : Enemy
    {
        public Demon(int hoge,int piyo,char fuga,NormalIO box) : base(hoge,piyo,fuga,box)
        {
            base.name = "でーもん" + fuga;

            base.HP = 500;
            base.MP = 1000;
            base.starvation = 100;
            base.stamina = 300;
            base.speed = 4;

            base.exp_demand = 2;

            base.MAX_HP = 500;
            base.MAX_MP = 1000;
            base.MAX_starvation = 100;
            base.MAX_stamina = 300;
            base.MAX_speed = 4;

            base.HP_gradient = 25;
            base.MP_gradient = 300;
            base.starvation_gradient = 50;
            base.stamina_gradient = 50;
            base.speed_gradient = 2;

            base.armor = new Cloth();

            base.symbol = 'で';
        }
    }
}
