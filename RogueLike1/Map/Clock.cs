using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class Clock : TextBox
    {
        public Clock(int hoge, int piyo, int fuga, int foo) : base(hoge, piyo, fuga, foo)
        {

        }

        public void SyncTime(int time)
        {
            for (int i = 0; i < this.message.Length; i++)
            {
                for (int j = 0; j < this.message[i].Length; j++)
                {
                    this.message[i][j] = '　';
                }
            }

            this.message[0][0] = '　';
            this.message[1] = ("　　　　　" + (time / 1440 + 1) + "日目").ToCharArray();
            this.message[4] = ("　　　　　" + string.Format("{0:D2}", (time / 60  % 24 )) + "： " + string.Format("{0:D2}", (time % 60))).ToCharArray();
        }
    }
}
