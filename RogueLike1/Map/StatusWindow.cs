using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class StatusWindow : TextBox
    {
        public StatusWindow(int hoge, int piyo, int fuga, int foo) : base(hoge, piyo, fuga, foo)
        {
            
        }

        public void StatusUpdate(Character target)
        {

            for(int i = 0; i < this.message.Length; i++)
            {
                for(int j = 0; j < this.message[i].Length; j++)
                {
                    this.message[i][j] = '　';
                }
            }

            message[0][0] = '　';

            message[1] = ("ＮＡＭＥ：　"+target.name).ToCharArray();
            message[4] = ("ＬＥＶＥＬ：　" + target.level).ToCharArray();
            message[6] = ("ＮＥＸＴ：　" + (target.level * target.exp_demand * 100 - target.exp)).ToCharArray();

            message[10] = ("ＨＰ：　" + (int)target.HP).ToCharArray();
            message[12] = ("ＭＰ：　" + (int)target.MP).ToCharArray();
            message[18] = ("ＥＮＥＲＧＹ：　" + (int)target.starvation).ToCharArray();
            message[16] = ("ＳＴＡＭＩＮＡ：　" + (int)target.stamina).ToCharArray();

            message[22] = ("ＷＥＡＰＯＮ：　" + target.weapon.name).ToCharArray();
            if (target.armor!=null) {
                message[24] = ("ＡＲＭＯＲ：　" + target.armor.name).ToCharArray();
            }
            else
            {
                message[24] = ("ＡＲＭＯＲ：　なし").ToCharArray();
            }

            message[28] = ("ＷＥＩＧＨＴ：　"+target.CalculateWeight()).ToCharArray();

        }
    }
}
