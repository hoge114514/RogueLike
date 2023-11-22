using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class ItemObject : Object
    {
        public Item item;
        public ItemObject(int hoge,int fuga,Item item) : base(hoge,fuga)
        {
            this.item = item;
            base.symbol = this.item.name[0];
        }
    }
}
