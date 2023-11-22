using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace RogueLike1
{

    public class NormalIO : BasicIO
    {

        public Player player;

        public TextBox box;

        public StatusWindow status;

        public List<Enemy> enemies;

        public List<ItemObject> items;

        public MenuIO menu;
        
        public string stage;

        public int time = 1000;
        public Clock clock;
      
        public NormalIO(string path) : base(0,0, new Map("../../maps/"+path))
        {
            base.scene = new Map("../../maps/"+path);
            this.stage = path;

            this.box = new TextBox(0, 42 ,10,40);
            this.status = new StatusWindow(42,0,40,20);
            this.clock = new Clock(42,42,10,20);

            Menu menu = new Menu(1, "調べる", "攻撃", "道具");//, "命令", "地図", "仲間", "セーブ", "中断");
            MenuIO  order, map, quit;
            SearchIO search = new SearchIO(this);
            AttackIO attack = new AttackIO(this);
            ToolIO tool = new ToolIO(this);
            SaveIO save = new SaveIO(this);
            this.menu = new MenuIO(2,40,menu, search, attack,tool,save);

            this.player = new Player(20, 20, this);
            base.obj = this.player;



            this.enemies = new List<Enemy>();
            this.InitializeEnemies();
            this.items = new List<ItemObject>();


        }



        public override void Generate()
        {
            char c;

            Console.Clear();
            MoveCursor(0, 0);
            this.scene.Display(0, 0, 40, 40);

            this.MoveCursor(this.obj.getY(), this.obj.getX());
            Console.Write(this.obj.getSymbol());

            for (int i = 0; i < this.enemies.Count; i++)
            {
                this.MoveCursor(this.enemies[i].getY(), this.enemies[i].getX());
                Console.Write(this.enemies[i].getSymbol());
            }

            this.MoveCursor(0, 42);
            this.box.Display();
            this.MoveCursor(42, 0);
            this.status.Display();
            this.status.StatusUpdate(this.player);
            this.status.TextDisplay();
            this.MoveCursor(42, 42);
            this.clock.Display();
            this.clock.SyncTime(this.time);
            this.clock.TextDisplay();

            Console.CursorVisible = false;

            while (flag)
            {

                c = Console.ReadKey(true).KeyChar;

                if (this.Input(c))
                {
                    base.MoveCursor(0, 0);
                    this.scene.Display();
                }

                this.MovingProcess(this.player);


                for (int i = 0; i < this.enemies.Count; i++)
                {
                    this.enemies[i].Action(this);
                }
                /*
                MoveCursor(0, 0);
                this.scene.Display();
                */
                for (int i = 0; i < this.enemies.Count; i++)
                {
                    this.MoveCursor(this.enemies[i].getY(), this.enemies[i].getX());
                    Console.Write(this.enemies[i].getSymbol());
                }
                for (int i = 0; i < this.items.Count; i++)
                {
                    this.MoveCursor(this.items[i].getY(), this.items[i].getX());
                    Console.Write(this.items[i].getSymbol());
                }

                this.MoveCursor(this.player.getY(), this.player.getX());
                Console.Write(this.player.getSymbol());

                this.staminaRegain();
                this.starvationUpdate();

                this.status.StatusUpdate(this.player);
                this.status.TextDisplay();

                this.time++;
                this.clock.SyncTime(this.time);
                this.clock.TextDisplay();

                if (this.enemies.Count == 0)
                {
                    // this.MoveToNextStage();
                    this.flag = false;
                }

            }
        }


        public override void Generate(BasicIO previous)
        {
            char c;

            previous.Dispose();

            Console.Clear();
            MoveCursor(0, 0);
            this.scene.Display(0,0,40,40);

            this.MoveCursor(this.obj.getY(), this.obj.getX());
            Console.Write(this.obj.getSymbol());

            for (int i=0;i<this.enemies.Count;i++)
            {
                this.MoveCursor(this.enemies[i].getY(),this.enemies[i].getX());
                Console.Write(this.enemies[i].getSymbol());
            }

            this.MoveCursor(0,42);
            this.box.Display();
            this.MoveCursor(42, 0);
            this.status.Display();
            this.status.StatusUpdate(this.player);
            this.status.TextDisplay();
            this.MoveCursor(42, 42);
            this.clock.Display();
            this.clock.SyncTime(this.time);
            this.clock.TextDisplay();

            Console.CursorVisible = false;

            while (flag)
            {

                
                c = Console.ReadKey(true).KeyChar;

                if (this.Input(c))
                {
                    base.MoveCursor(0,0);
                    this.scene.Display();
                }

                this.MovingProcess(this.player);
                

                for (int i = 0; i < this.enemies.Count; i++)
                {
                    this.enemies[i].Action(this);
                }
                /*
                MoveCursor(0, 0);
                this.scene.Display();
                */
                for (int i = 0; i < this.enemies.Count; i++)
                {
                    this.MoveCursor(this.enemies[i].getY(), this.enemies[i].getX());
                    Console.Write(this.enemies[i].getSymbol());
                }
                for (int i=0;i<this.items.Count;i++)
                {
                    this.MoveCursor(this.items[i].getY(), this.items[i].getX());
                    Console.Write(this.items[i].getSymbol());
                }

                this.MoveCursor(this.player.getY(), this.player.getX());
                Console.Write(this.player.getSymbol());

                this.staminaRegain();
                this.starvationUpdate();

                this.status.StatusUpdate(this.player);
                this.status.TextDisplay();

                this.time++;
                this.clock.SyncTime(this.time);
                this.clock.TextDisplay();

                if (this.enemies.Count==0)
                {
                    // this.MoveToNextStage();
                    this.flag = false;
                }

            }
        }
      

        public Boolean MovingProcess(Character hoge)
        {
            if (this.scene.IsAccessable(hoge.getX(), hoge.getY()) )
            {
                if (this.NotDoubled(hoge))
                {
                    this.MoveCursor(hoge.tmpy, hoge.tmpx);
                    this.scene.DotDisplay(hoge.tmpx, hoge.tmpy);
                    return true;
                }
                else
                {
                    if (this.DoubledObject(hoge) is Character)
                    {
                        hoge.Attack((Character)this.DoubledObject(hoge));
                        hoge.setX(hoge.tmpx);
                        hoge.setY(hoge.tmpy);
                        return false;
                    }
                    else
                    {
                        hoge.setX(hoge.tmpx);
                        hoge.setY(hoge.tmpy);
                        return false;
                    }
                }
                
            }
            else
            {
                hoge.setX(hoge.tmpx);
                hoge.setY(hoge.tmpy);
                return false;
            }
        }
        
        public void MoveToNextStage()
        {
            this.scene.GenerateFrame(40, 40, '＠');
            this.scene.PlaceObstacles();
            this.Generate(this);
        }

        public void InitializeEnemies()
        {
            Random r1 = new Random();

            string[] lines = { "" };
            int NumOfEnemies,AveLev;
            string[] types;

            try
            {
                lines = File.ReadAllLines("../../StageInfo/"+this.stage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            NumOfEnemies = int.Parse(lines[0]);
            AveLev = int.Parse(lines[1]);
            types = new string[lines.Length - 2];
            for (int i=0;i<types.Length;i++)
            {
                types[i] = lines[i + 2];
            }


            Random r2 = new Random(300);
            Random r3 = new Random(5000);


            Dictionary<string, int> counter = new Dictionary<string, int>();
            for (int j = 0; j < types.Length; j++)
            {
                counter.Add(types[j], 0);
            }

            for (int i = 0; i < NumOfEnemies;)
            {
                int r = r3.Next(0, types.Length);
                if (types[r] == "ゴブリン")
                {
                    enemies.Add(new Goblin(1, 1, (char)('Ａ' + counter["ゴブリン"]), this));
                    enemies[i].LevelUpdate(AveLev + r2.Next(-3, 3));
                    counter["ゴブリン"]++;
                    i++;
                }
                else if (types[r] == "スライム")
                {
                    enemies.Add(new Slime(1, 1, (char)('Ａ' + counter["スライム"]), this));
                    enemies[i].LevelUpdate(AveLev + r2.Next(-3, 3));
                    counter["スライム"]++;
                    i++;
                }
                else if (types[r] == "でーもん")
                {
                    enemies.Add(new Demon(1, 1, (char)('Ａ' + counter["でーもん"]), this));
                    enemies[i].LevelUpdate(AveLev + r2.Next(-3, 3));
                    counter["でーもん"]++;
                    i++;
                }

            }
            for (int i = 0; i < NumOfEnemies;)
            {
                enemies[i].setX((r1.Next(1, this.scene.map.Length - 1)));
                enemies[i].setY((r2.Next(1, this.scene.map[this.scene.LongestIndex].Length-1)));

                if (this.NotDoubled(enemies[i]) && this.scene.IsAccessable(enemies[i].getX(),enemies[i].getY()))
                {
                    i++;
                }



            }


        }

        public Boolean NotDoubled(Object hoge)
        {
            int c = 0;
            if (this.player.getX()==hoge.getX() && this.player.getY() == hoge.getY())
            {
                if(this.player != hoge)
                {
                    c++;
                }
                   
            }
            for(int i = 0; i < this.enemies.Count; i++)
            {
                if (this.enemies[i] != hoge)
                {
                    if (this.enemies[i].getX() == hoge.getX() && this.enemies[i].getY() == hoge.getY())
                    {
                        c++;
                    }
                }
            }

            if (c==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Object DoubledObject(Object hoge)
        {
            int c = 0;
            if (this.player.getX() == hoge.getX() && this.player.getY() == hoge.getY())
            {
                if (hoge != this.player)
                {
                    return this.player;
                }
                
            }
            for (int i = 0; i < this.enemies.Count; i++)
            {
                if (this.enemies[i] != hoge)
                {
                    if (this.enemies[i].getX() == hoge.getX() && this.enemies[i].getY() == hoge.getY())
                    {
                        return this.enemies[i];
                    }
                }
            }
            for (int i=0;i<this.items.Count;i++)
            {
                if (this.items[i].getX() == hoge.getX() && this.items[i].getY() == hoge.getY())
                {
                    return this.items[i];
                }
            }

            return null;
        }

        public void staminaRegain()
        {
            double dist = Math.Abs(this.player.tmpx - this.player.getX()) + Math.Abs(this.player.tmpy - this.player.getY());
            this.player.stamina += this.player.MAX_stamina/10 * this.player.starvation / this.player.MAX_starvation - dist * this.player.CalculateWeight();
            if (this.player.stamina > this.player.MAX_stamina)
            {
                this.player.stamina = this.player.MAX_stamina;
            }
            for (int i=0;i<this.enemies.Count;i++)
            {
                dist = Math.Abs(this.enemies[i].tmpx - this.enemies[i].getX()) + Math.Abs(this.enemies[i].tmpy - this.enemies[i].getY());
                this.enemies[i].stamina += 50 * this.enemies[i].starvation/this.enemies[i].MAX_starvation - dist * this.enemies[i].CalculateWeight();
                if (this.enemies[i].stamina > this.enemies[i].MAX_stamina)
                {
                    this.enemies[i].stamina = this.enemies[i].MAX_stamina;
                }
            }
        }

        public void starvationUpdate()
        {
            double dist = Math.Abs(this.player.tmpx - this.player.getX()) + Math.Abs(this.player.tmpy - this.player.getY());
            this.player.stamina -= 100;
            for (int i = 0; i < this.enemies.Count; i++)
            {
                dist = Math.Abs(this.enemies[i].tmpx - this.enemies[i].getX()) + Math.Abs(this.enemies[i].tmpy - this.enemies[i].getY());
                this.enemies[i].stamina -= 1 + dist * this.enemies[i].CalculateWeight();
            }
        }

        public void GenerateItem()
        {

        }

        public void GenerateEnemy()
        {

        }


        protected override Boolean Input(char c)
        {
            switch (c)
            {
                case '1':
                    this.player.Move(1, -1);
                    break;
                case '2':
                    this.player.Move(1, 0);
                    break;
                case '3':
                    this.player.Move(1, 1);
                    break;
                case '4':
                    this.player.Move(0, -1);
                    break;
                case '6':
                    this.player.Move(0, 1);
                    break;
                case '7':
                    this.player.Move(-1, -1);
                    break;
                case '8':
                    this.player.Move(-1, 0);
                    break;
                case '9':
                    this.player.Move(-1, 1);
                    break;
                case ' ':
                    this.menu.Generate();
                    return true;
                default:
                    this.player.Move(0, 0);
                    break;
            }
            return false;
        }
    }
}
