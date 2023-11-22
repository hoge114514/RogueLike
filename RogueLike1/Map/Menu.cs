using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Menu : Map
    {

        public int gap;
        public int NumOfSelection;

        public Menu(int fuga, params string[] foo) : base()
        {

            this.gap = fuga;
            this.NumOfSelection = foo.Length;
            int index = 0;

            for(int i = 1; i < foo.Length; i++)
            {
                if (foo[i].Length > foo[index].Length)
                {
                    index = i;
                }
            }
            base.GenerateFrame(this.gap + foo.Length +  this.gap* foo.Length + 2 ,foo[index].Length+8+1);

            char[] tmp;

            for (int i=0;i<foo.Length;i++)
            {
                tmp = foo[i].Insert(0, "　　　　").ToCharArray();

                for (int j=2;j<tmp.Length;j++)
                {
                    base.map[i * (this.gap+1) + this.gap + 1][j] = tmp[j];
                }
            }

        }

        public override Boolean IsAccessable(int k, int l)
        {
            if (k >= 2 && k < this.map.Length - this.gap && l >= 2 && l < this.map[k].Length - 2)
            {
                if (this.map[k][l] == '　')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }


    }
}
