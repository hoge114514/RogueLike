using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RogueLike1
{
    [DataContract]
    public class Character : Object
    {

        public double HP;
        public double MP;
        public double starvation;
        public double stamina;
        public double speed;
        public int level;
        public int exp;
        public Weapon weapon;
        public Armor armor;
        public List<Item> items;
        public Dictionary<string, int> SkillLevel;
        public Dictionary<string, int> SkillExp;

        public double MAX_HP;
        public double MAX_MP;
        public double MAX_starvation;
        public double MAX_stamina;
        public double MAX_speed;
        public int MAX_level;

        public double HP_gradient;
        public double MP_gradient;
        public double starvation_gradient;
        public double stamina_gradient;
        public double speed_gradient;
        public int exp_demand;

        public NormalIO world;


        public Character(int hoge, int piyo, NormalIO normal) : base(hoge,piyo)
        {
            this.world = normal;
            this.SkillLevel = new Dictionary<string, int>(){ {"伝説の武器",1}, {"剣",1}, {"弓",1}, {"杖",1}, {"拳",1 }, {"棒",1 } };
            this.SkillExp = new Dictionary<string, int>() { { "伝説の武器", 0 }, { "剣", 0 }, { "弓", 0 }, { "杖", 0 }, { "拳", 0 }, { "棒", 0 } };
            this.items = new List<Item>();
        }

        public void ItemUse(int ID)
        {
            this.items[ID].effect(this);
        }

        public double CalculateWeight()
        {
            double weight = 0;

            for (int i=0;i<this.items.Count;i++)
            {
                weight += this.items[i].weight;
            }
            if (armor != null) { weight += this.armor.weight; }
            if (weapon != null) { weight += this.weapon.weight; }
            
            return weight;
        }

        public void Attack(Character target)
        {
            this.world.box.AddMessage(this.name + "　の攻撃！");
            this.world.box.TextDisplay();
            Random r = new Random();
            double dist = Math.Sqrt((this.x - target.x) * (this.x - target.x) + (this.y - target.y) * (this.y - target.y));
            
            if (r.NextDouble() < this.weapon.accuracy / (this.weapon.dist_penaltiy * dist) * this.SkillLevel[this.weapon.name]*0.5)
            {
                double damage;
                if (target.armor == null)
                {
                    damage = this.weapon.attack / (this.weapon.dist_penaltiy * dist+1 ) * this.SkillLevel[this.weapon.name] * 0.5;
                }
                else
                {
                    damage = this.weapon.attack / (this.weapon.dist_penaltiy * dist+1 ) * this.SkillLevel[this.weapon.name] * 0.5 - target.armor.defence;
                }
                target.HP -= damage;

                if (target.armor!=null) {
                    target.armor.endurance--;
                    if (target.armor.endurance >= 0)
                    {
                        this.world.box.AddMessage(target.name + "　の　" + target.armor.name + "　が壊れた！");
                        target.armor = null;
                    }
                }

                this.SkillIncrement(this.weapon.name);

                this.stamina -= this.weapon.staminaConsumption;

                this.world.box.AddMessage(this.name + "　は　" + target.name + "　に　" + (int)damage + "ダメージを与えた！");
                this.world.box.TextDisplay();

                this.weapon.endurance--;

                if (this.weapon.endurance <= 0)
                {
                    this.world.box.AddMessage(this.weapon.name + "が　壊れてしまった！");
                    this.WeaponNullify();
                }

                if (target.HP <= 0)
                {
                    this.world.box.AddMessage(target.name + "　は　くたばった！");

                    this.GainExp(target);

                    ItemObject tmp = target.DropItem();
                    if (tmp != null)
                    {
                        this.world.items.Add(tmp);
                    }

                    if (target is Enemy)
                    {
                        for (int i = 0; i < this.world.enemies.Count; i++)
                        {
                            if (target == this.world.enemies[i])
                            {
                                this.world.MoveCursor(target.getY(),target.getX());
                                this.world.scene.DotDisplay(target.getX(),target.getY());
                                this.world.enemies.RemoveAt(i);
                            }
                        }
                    }
                    else if(target is Player)
                    {
                        this.world.box.AddMessage("ＧＡＭＥ　ＯＶＥＲ");
                        this.world.box.TextDisplay();
                        System.Threading.Thread.Sleep(3000);
                        Title piyo = new Title(2, "ＮＥＷ　ＧＡＭＥ", "ＬＯＡＤ　ＧＡＭＥ", "ＯＰＴＩＯＮＳ", "ＥＸＩＴ");
                        if (System.IO.Directory.Exists("./savedata/") == false)
                        {
                            System.IO.Directory.CreateDirectory("./savedata/");
                        }
                        string path = ("Stage1.txt");
                        NormalIO foo = new NormalIO(path);
                        path = "../../maps/Prologue.txt";
                        // TitleIO hoge = new TitleIO(piyo, new MovieIO(path, foo), new MovieIO(path, foo));
                        // hoge.Generate(hoge);
                    }

                }

                
            }else
            {
                this.world.box.AddMessage("しかし、" + this.name + "　の攻撃は外れた！");
            }
            this.world.box.TextDisplay();
        }



        public override void Move(int hoge, int piyo)
        {
            base.tmpx = base.x;
            base.tmpy = base.y;
            base.x += hoge;
            base.y += piyo;
        }

        public void GainExp(Character Sacrifice)
        {
            int exp = (Sacrifice.exp + Sacrifice.level * Sacrifice.exp_demand * 100) / 4;
            this.exp += exp;
            this.world.box.AddMessage(this.name+"　は　" + (exp) + "の経験値を獲得した！");
            if (this.exp >= this.level * this.exp_demand * 100)
            {
                int up = this.exp / (this.level * this.exp_demand * 100);
                this.exp -= this.level * this.exp_demand * 100;
                this.level += up;
                this.world.box.AddMessage(this.name + "　のレベルが　" + (up) + "上がった！");
                this.LevelUpdate(this.level);
            }
        }

        public void SkillIncrement(string skill)
        {
            this.SkillExp[skill]++;
            if (this.SkillExp[skill] >= this.SkillLevel[skill] * this.SkillLevel[skill] * 100)
            {
                this.SkillExp[skill] -= this.SkillLevel[skill] * this.SkillLevel[skill] * 100;
                this.SkillLevel[skill]++;
                this.world.box.AddMessage(this.name + "　の　" + skill + "スキルが上達した！");
            }
        }

        public void LevelUpdate(int hoge)
        {
            if(hoge > this.MAX_level)
            {
                this.level = this.MAX_level;
            }else
            {
                this.level = hoge;
            }
            

            this.HP += this.HP_gradient * this.level;
            this.MP += this.MP_gradient * this.level;
            this.starvation += this.starvation_gradient * this.level;
            this.stamina += this.HP_gradient * this.level;
            this.speed += this.speed_gradient * this.level;

            this.MAX_HP += this.HP_gradient * this.level;
            this.MAX_MP += this.MP_gradient * this.level;
            this.MAX_starvation += this.starvation_gradient * this.level;
            this.MAX_stamina += this.HP_gradient * this.level;
            this.MAX_speed += this.speed_gradient * this.level;
        }

        public void WeaponNullify()
        {
            this.weapon = new Faust();
        }

        public ItemObject DropItem()
        {
            if (this.items.Count == 0)
            {
                return null;
            }

            Random r = new Random();
            Random r1 = new Random(765);
            if (r.NextDouble()<0.5)
            {
                int n = r1.Next(0,this.items.Count);
                for (int i=0;i<this.items.Count;i++)
                {
                    if (i==n)
                    {
                        return new ItemObject(base.x,base.y,this.items[i]);
                    }
                }
            }

            return null;
        }

        public void PickItem(ItemObject hoge)
        {
            this.items.Add(hoge.item);
            for(int i = 0; i < this.world.items.Count; i++)
            {
                if (hoge == this.world.items[i])
                {
                    this.world.items.RemoveAt(i);
                }
            }
        }



    }
}
