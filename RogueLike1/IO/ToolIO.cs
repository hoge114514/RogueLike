using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class ToolIO : BasicIO
    {
        NormalIO status;

        public ToolIO(NormalIO normal) : base()
        {
            this.status = normal;
        }


        public override void Generate()
        {
            int c,d;

            if (this.status.player.items.Count == 0)
            {
                this.status.box.AddMessage("道具を持っていません");
            }
            else
            {
                string[] list = new string[this.status.player.items.Count];
                for (int i=0;i< this.status.player.items.Count;i++)
                {
                    list[i] = this.status.player.items[i].name;
                }
            REVERSE:;
                c = new MenuIO(this.status.menu.x + 5, this.status.menu.y + 10, new Menu(1,list)).SelectionWithoutErase();
                if (c==-2)
                {
                    return;
                }
                d = new MenuIO(this.status.menu.x + 10, this.status.menu.y + 15, new Menu(1, "使う", "装備")).Selection();
                if (d==-2)
                {
                    goto REVERSE;
                }

                if (d == 0)
                {
                    if (this.status.player.items[c] is FoodItem)
                    {
                        this.status.player.items[c].effect(this.status.player);
                        this.status.player.items[c].endurance--;
                        this.status.box.AddMessage(this.status.player.name + "は" + this.status.player.items[c].name + "を　食べた！");
                        if (this.status.player.items[c].endurance<=0)
                        {
                            this.status.player.items.RemoveAt(c);
                        }
                    }
                    else
                    {
                        this.status.box.AddMessage("しかし、何も起こらなかった！");
                    }
                }
                else
                {
                    if (this.status.player.items[c] is Weapon)
                    {
                        this.status.player.items.Add(this.status.player.weapon);
                        this.status.player.weapon = (Weapon)this.status.player.items[c];
                        this.status.player.items.RemoveAt(c);
                    }
                    else if (this.status.player.items[c] is Armor)
                    {
                        this.status.player.items.Add(this.status.player.armor);
                        this.status.player.armor = (Armor)this.status.player.items[c];
                        this.status.player.items.RemoveAt(c);
                    }
                    else
                    {
                        this.status.box.AddMessage("装備できません");
                        this.status.box.TextDisplay();
                        goto REVERSE;
                    }
                }
                
            }

            this.status.box.TextDisplay();
        }
    }
}
