using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RogueLike1
{
    public class MovieIO : BasicIO
    {

        string path;
        NormalIO next;
        char[][] phrase;
        public int current;
        public int end;



        public MovieIO(string path) : base()
        {
            this.flag = true;
            this.path = path;
            this.current = 0;
            this.end = 0;

            string[] hoge = { "" };

            try
            {
                hoge = File.ReadAllLines(this.path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            this.phrase = new char[hoge.Length][];
            for (int i = 0; i < hoge.Length; i++)
            {
                this.phrase[i] = hoge[i].ToCharArray();
            }

            

        }

        public override void Generate()
        {
            char c;
            Console.Clear();
            Console.CursorVisible = true;
            Console.CursorVisible = true;

            Console.WriteLine();
            Console.WriteLine();

            this.NextLine();

            while (flag)
            {

                c = Console.ReadKey(true).KeyChar;

                this.Input(c);

            }
        }

        public override void Generate(BasicIO previous)
        {
            char c;
            Console.Clear();
            Console.CursorVisible = true;

            Console.WriteLine();
            Console.WriteLine();
            
            this.NextLine();

            while (flag)
            {
                
                c = Console.ReadKey(true).KeyChar;
                
                this.Input(c);
                
            }
        }

        private Boolean NextLine()
        {

            if (this.current!=this.phrase.Length)
            {
                for (int i=0;i<10;i++)
                {
                    Console.Write(" ");
                }
                Console.Write(this.phrase[this.current]);

                this.end = this.phrase[this.current].Length;
                this.current++;
                return false;
            }
            else
            {
                return true;
            }
        }

        protected override Boolean Input(char c)
        {
            Boolean hoge;
            switch (c)
            {
                case '5':
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    hoge = this.NextLine();
                    if (hoge){
                        // next.Generate(this);
                        this.flag = false;
                    }
                    break;                
            }
            return true;
        }

    }
}
