using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Goblin : Enemy
    {
        public Goblin(int hoge,int piyo,char fuga,NormalIO box) : base(hoge,piyo,fuga,box)
        {
            base.name = "ゴブリン"+fuga;

            base.HP = 100;
            base.MP = 10;
            base.starvation = 10000;
            base.stamina = 100;
            base.speed = 10;

            base.exp_demand = 1;

            base.MAX_HP = 100;
            base.MAX_MP = 10;
            base.MAX_starvation = 10000;
            base.MAX_stamina = 100;
            base.MAX_speed = 10;

            base.HP_gradient = 20;
            base.MP_gradient = 1;
            base.starvation_gradient = 1000;
            base.stamina_gradient = 100;
            base.speed_gradient = 10;
            
            base.armor = new Cloth();
            base.weapon = new Stick();
            base.items.Add(new SmokedMeat());
            base.symbol = 'ゴ';
        }
    }
}
