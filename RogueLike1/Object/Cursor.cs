using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RogueLike1
{
    [DataContract]
    public class Cursor : Object
    {

        public Cursor(int fuga,int piyo) : base(fuga, piyo)
        {
            base.symbol = '＞';


        }

        public override void Move(int hoge, int piyo)
        {
            base.tmpx = base.x;
            base.x += hoge;
        }
    }
}
