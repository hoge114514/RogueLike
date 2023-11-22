using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class NPC : Character
    {
        string AI;

        public NPC(int hoge,int piyo, char fuga, NormalIO box) : base(hoge,piyo,box)
        {
            this.AI = "Assault";
        }

        public void ChangeAI(string hoge)
        {
            this.AI = hoge;
        }

        public void Action(NormalIO hoge)
        {
            if (this.AI == "Assault")
            {
                this.AssaultAI(hoge);
            }
        }

        public void AssaultAI(NormalIO hoge)
        {

            int x = hoge.player.getX() - this.getX();
            int y = hoge.player.getY() - this.getY();

            Random r = new Random();

            if (Math.Sqrt(x*x+y*y)<20)
            {
                if (y > 0)
                {
                    if ((double)x / (double)y > 4)
                    {

                        base.Move(1, 0);
                        if (this.world.MovingProcess(this) == false)
                        {

                        }
                    }
                    else if ((double)x / (double)y > 0.25)
                    {
                        base.Move(1, 1);
                        this.world.MovingProcess(this);
                    }
                    else if ((double)x / (double)y > -0.25)
                    {
                        base.Move(0, 1);
                        this.world.MovingProcess(this);
                    }
                    else if ((double)x / (double)y > -4)
                    {
                        base.Move(-1, 1);
                        this.world.MovingProcess(this);
                    }
                    else
                    {
                        base.Move(-1, 0);
                        this.world.MovingProcess(this);
                    }
;
                }
                else if (y < 0)
                {
                    if ((double)x / (double)y > 4)
                    {
                        base.Move(-1, 0);
                        this.world.MovingProcess(this);
                    }
                    else if ((double)x / (double)y > 0.25)
                    {
                        base.Move(-1, -1);
                        this.world.MovingProcess(this);
                    }
                    else if ((double)x / (double)y > -0.25)
                    {
                        base.Move(0, -1);
                        this.world.MovingProcess(this);
                    }
                    else if ((double)x / (double)y > -4)
                    {
                        base.Move(1, -1);
                        this.world.MovingProcess(this);
                    }
                    else
                    {
                        base.Move(1, 0);
                        this.world.MovingProcess(this);
                    }
                }
                else
                {
                    if (x > 0)
                    {
                        base.Move(1, 0);
                        this.world.MovingProcess(this);
                    }
                    else if (x < 0)
                    {
                        base.Move(-1, 0);
                        this.world.MovingProcess(this);
                    }
                    else
                    {
                        base.Move(0, 0);
                        this.world.MovingProcess(this);
                    }
                }


                if (Math.Abs(hoge.player.getX() - this.getX()) <= this.weapon.range && Math.Abs(hoge.player.getY() - this.getY()) <= this.weapon.range)
                {
                    this.Attack(hoge.player);
                }
            }
            else
            {
                base.Move(0, 0);
                this.world.MovingProcess(this);
            }

        }

    }
}
