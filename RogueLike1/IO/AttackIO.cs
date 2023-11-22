using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RogueLike1
{
    [DataContract]
    public class AttackIO : BasicIO
    {
        [DataMember]
        NormalIO status;

        public AttackIO(NormalIO normal) : base()
        {
            this.status = normal;
        }

        private List<Enemy> Attackables()
        {
            List<Enemy> list = new List<Enemy>();
            for (int i=0;i<this.status.enemies.Count;i++) {
                double absx = Math.Abs(this.status.player.getX() - this.status.enemies[i].getX());
                double absy = Math.Abs(this.status.player.getY() - this.status.enemies[i].getY());
                if (this.status.player.weapon.range >= absx && this.status.player.weapon.range >= absx) {
                    list.Add(this.status.enemies[i]);
                }
            }
            return list;
        }

        public override void Generate()
        {
            int c;


            List<Enemy> candidates = this.Attackables();
            string[] names = new string[candidates.Count];
            for (int i=0;i<names.Length;i++)
            {
                names[i] = candidates[i].name;
            }

            if (candidates.Count == 0)
            {
                this.status.box.AddMessage("攻撃可能な対象がいません");
            }
            else
            {
                c = new MenuIO(this.status.menu.x + 5, this.status.menu.y + 10, new Menu(1, names)).Selection();
                if (c == -2)
                {
                    return;
                }
                this.status.player.Attack(candidates[c]);

            }
            this.status.box.TextDisplay();
        }

       
    }
}
