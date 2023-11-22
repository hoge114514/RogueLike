using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Enemy : NPC
    {
        public Enemy(int hoge, int piyo, char fuga,NormalIO box) : base(hoge,piyo,fuga,box)
        {
            base.MAX_level = 999;
            base.WeaponNullify();
        }
    }
}
