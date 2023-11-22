using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class TitleIO : MenuIO
    {
        public TitleIO(Title hoge) : base(10,20,hoge)
        {
           
        }

        protected override Boolean Select()
        {
            for (int i = 0; i < this.selections.Length; i++)
            {
                if (this.cursor.getX() == this.selections[i].x)
                {
                    //this.selections[i].SceneHop(this);
                    this.flag = false;
                    return true;
                }
            }
            return false;
        }
    }
}
