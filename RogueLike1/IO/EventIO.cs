using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class EventIO : BasicIO
    {

        TextBox text;

        public EventIO(Map hoge, TextBox piyo) : base(0,0,hoge)
        {
            this.text = piyo;
        }
    }
}
