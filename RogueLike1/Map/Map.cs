using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RogueLike1
{
    public class Map
    {
        public char[][] map;
        public int LongestIndex = 0;
        protected string path;
        protected int x;
        protected int y;

        public Map()
        {

        }

        public Map(int hoge,int piyo)
        {
            this.GenerateFrame(hoge, piyo);
        }

        public Map(int hoge, int piyo,char fuga)
        {
            this.GenerateFrame(hoge, piyo,fuga);
        }

        public Map(char[][] hoge)
        {
            this.map = hoge;
        }

        public Map(string hoge)
        {

            this.path = hoge;
            this.ReadMap();

        }

        protected void ReadMap()
        {
            string[] hoge = { "" };

            try
            {
                hoge = File.ReadAllLines(this.path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            this.map = new char[hoge.Length][];
            for (int i = 0; i < hoge.Length; i++)
            {
                if(hoge[this.LongestIndex].Length < hoge[i].Length)
                {
                    this.LongestIndex = i;
                }
                this.map[i] = hoge[i].ToCharArray();
            }
        }
        public void WriteMap(string path)
        {
            using(StreamWriter s = new StreamWriter(path))
            {
                for (int i=0;i<this.map.Length;i++)
                {
                    for (int j=0;j<this.map[i].Length;j++)
                    {
                        s.Write(this.map[i][j]);
                    }
                    s.Write("\n");
                }
            }
            
        }

        public void PlaceObstacles()
        {
            Random r = new Random();
            Random r1 = new Random(300);
            Random r2 = new Random(2000098);
            char[][][] set = new char[10][][];
            for (int i=0;i<10;i++)
            {
                int hoge = r.Next(0, 5);
                set[i] = new char[hoge][];
                for (int j=0;j<hoge;j++)
                {
                    int piyo = r1.Next(0, 5);
                    set[i][j] = new char[piyo];
                    for (int k=0;k<piyo;k++)
                    {
                        set[i][j][k] = '＠';
                    }
                }
            }

            for (int i=0;i<3;i++)
            {
                int hoge = r.Next(1,this.map.Length-6);
                int piyo = r1.Next(1, this.map[0].Length - 6);
                int fuga = r2.Next(0,9);
                for (int j = hoge; j < set[fuga].Length; j++)
                {
                    for (int k = piyo; k < set[fuga][j].Length; k++)
                    {
                        this.map[j][k] = set[fuga][j-hoge][k-piyo];
                    }
                }
            }
            
        }

        public void GenerateFrame(int x,int y)
        {
            this.map = new char[x][];
            for(int i = 0; i < x; i++)
            {
                this.map[i] = new char[y];
            }
            for (int i = 0; i < this.map.Length; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == 0 || j == 0 || i == this.map.Length - 1 || j == this.map[i].Length - 1)
                    {
                        this.map[i][j] = ('＃');
                    }
                    else
                    {
                        this.map[i][j] = ('　');
                    }
                }
            }
        }

        public void GenerateFrame(int x, int y,char hoge)
        {
            this.map = new char[x][];
            for (int i = 0; i < x; i++)
            {
                this.map[i] = new char[y];
            }
            for (int i = 0; i < this.map.Length; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (i == 0 || j == 0 || i == this.map.Length - 1 || j == this.map[i].Length - 1)
                    {
                        this.map[i][j] = (hoge);
                    }
                    else
                    {
                        this.map[i][j] = ('　');
                    }
                }
            }
        }

        public virtual Boolean IsAccessable(int k,int l)
        {
            if (k >= 0 && k < this.map.Length && l >= 0 && l < this.map[k].Length)
            {
                if (this.map[k][l] != '＠')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            
        }

        public Boolean IsErasable(int k, int l)
        {
            if (this.map == null)
            {
                return false;
            }
            if (k >= 0 && k < this.map.Length && l >= 0 && l < this.map[k].Length)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public Boolean EditMap(char hoge,int fuga,int piyo)
        {
            if (this.IsAccessable(fuga,piyo))
            {
                this.map[fuga][piyo] = hoge;
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean EraseMap(int fuga, int piyo)
        {
            if (this.IsErasable(fuga, piyo))
            {
                this.map[fuga][piyo] = '　';
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EraseMap()
        {
            int hoge = Console.CursorLeft, piyo = Console.CursorTop;

            for (int i = 0; i < this.map.Length; i++)
            {
                for (int j = 0; j < this.map[i].Length; j++)
                {
                    Console.SetCursorPosition(hoge + j * 2, piyo + i);
                    Console.Write("　");
                }
            }
        }

        public virtual void Display()
        {
            if (this.map==null)
            {
                return;
            }

            int hoge = Console.CursorLeft, piyo = Console.CursorTop;

            for (int i = 0; i < this. map.Length;i++)
            {
                for (int j=0; j<this.map[i].Length;j++)
                {
                    Console.SetCursorPosition(hoge+j*2,piyo+i);
                    Console.Write(this.map[i][j]);
                }
            }
        }

        public virtual void Display(int hoge,int piyo,int fuga,int foo)
        {

            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            if (this.map == null)
            {
                return;
            }
            for (int i = hoge; i < fuga; i++)
            {
                for (int j = piyo; j < foo; j++)
                {
                    Console.SetCursorPosition(x + j*2,y + i);
                    Console.Write(this.map[i][j]);
                }
            }
        }

        public virtual void DotDisplay(int x,int y)
        {
            if (this.map == null)
            {
                return;
            }

            Console.Write(this.map[x][y]);
        }
    }
}
