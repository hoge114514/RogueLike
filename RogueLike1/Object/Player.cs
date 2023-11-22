using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RogueLike1
{
    [DataContract]
    public class Player : Character
    {
        public Player(int hoge,int piyo,NormalIO box) : base(hoge,piyo,box)
        {
            base.name = "プレイヤー";
            base.HP = 100000000;
            base.MAX_level = 999;
            base.stamina = 10000;
            base.MAX_stamina = 10000;
            base.starvation = 1000;
            base.MAX_starvation = 1000;
            base.LevelUpdate(99);
            base.exp_demand = 10;
            base.symbol = 'Ｐ';
            base.SkillLevel["伝説の武器"]++;
            this.weapon = new Gun();
            base.items.Add(new SmokedMeat());
            base.items.Add(new Gun());
        }

        
        

    }
}
