using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RogueLike1
{
    public class Selection 
    {

        public BasicIO next;
        public int x;
        public int y;



        public Selection(BasicIO hoge,int fuga,int piyo)
        {
            this.next = hoge;
            this.x = fuga;
            this.y = piyo;
        }

        public virtual void SceneHop()
        {
            this.next.Generate();
        }
        public virtual void SceneHop(BasicIO previous)
        {
            this.next.Generate(previous);
        }
    }
}
