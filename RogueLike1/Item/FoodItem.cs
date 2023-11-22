using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class FoodItem : Item
    {
        public double calories;
        public int BestBefore;
        
        public FoodItem() : base()
        {

        }

        public override void effect(Character hoge)
        {
            base.endurance--;
            hoge.starvation += this.calories;

        }
    }
}
