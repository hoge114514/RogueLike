using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class SearchIO : BasicIO
    {

        NormalIO status;

        public SearchIO(NormalIO normal) : base()
        {
            this.status = normal;
        }

        public override void Generate()
        {
            int c;

            Console.CursorVisible = true;

            if (this.status.DoubledObject(this.status.player) == null)
            {
                this.status.box.AddMessage("足元には何もありません");
            }
            else
            {
                this.status.box.AddMessage("足元に　" + this.status.DoubledObject(this.status.player).name + "　が落ちています");
                if(this.status.DoubledObject(this.status.player) is ItemObject)
                {
                    this.status.box.AddMessage("拾いますか？");
                    this.status.box.TextDisplay();
                    c = new MenuIO(this.status.menu.x + 5, this.status.menu.y + 10, new Menu(1, "はい","いいえ")).Selection();
                    if (c==0)
                    {
                        this.status.box.AddMessage(this.status.player.name + "　は　" + this.status.DoubledObject(this.status.player).name + "　を獲得した！");
                        this.status.player.PickItem((ItemObject)this.status.DoubledObject(this.status.player));
                        this.status.box.TextDisplay();
                    }
                }
                //c = Console.ReadKey(true).KeyChar;
                //this.Input(c);
            }
            this.status.box.TextDisplay();
        }

        protected override Boolean Input(char c)
        {
            switch (c)
            {
                case ' ':
                    
                    break;
            }
            return false;
        }

    }
}
