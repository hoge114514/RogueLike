using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    abstract public class Item
    {

        public string name;
        public double endurance;
        public double weight;

        public Item()
        {

        }

        public abstract void effect(Character hoge);
        
    }
}
