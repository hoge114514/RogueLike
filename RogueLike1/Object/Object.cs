using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RogueLike1
{
    [KnownType(typeof(Character))]
    [KnownType(typeof(Cursor))]
    [DataContract]
    public class Object
    {

        protected char symbol;
        protected int x, y;
        public int tmpx, tmpy;
        public string name;

        public Object(int fuga,int piyo)
        {
            this.x = fuga;
            this.y = piyo;
        }

        public virtual void Move(int hoge,int piyo)
        {
            
        }

        public int getX()
        {
            return this.x;
        }

        public void setX(int hoge)
        {
            this.x = hoge;
        }

        public int getY()
        {
            return this.y;
        }

        public void setY(int hoge)
        {
            this.y = hoge;
        }

        public char getSymbol()
        {
            return this.symbol;
        }

    }
}
