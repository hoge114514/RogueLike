using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class SmokedMeat : FoodItem
    {
        public SmokedMeat() : base()
        {
            base.name = "燻製肉";
            base.endurance = 1;
            base.calories = 100;
        }
    }
}
