using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class TextBox : Map
    {
        public int x;
        public int y;
        protected char[][] message;
        public int current = 0;
        public int end;

        public TextBox(int hoge,int piyo,int hight,int width) : base()
        {
            this.x = hoge;
            this.y = piyo;
            base.GenerateFrame(hight,width);
            this.message = new char[hight - 4][];
            for (int i = 0; i < hight - 4; i++)
            {
                this.message[i] = new char[width - 4];
            }
        }

        public void AddMessage(string message)
        {
            int rows = message.Length / (base.map[0].Length-4) + 1;
            int j = 0;
            char[] tmp = message.ToCharArray();
            char[][] show = new char[rows][];
            for (int i= 0;i<rows;i++)
            {
                show[i] = new char[base.map[0].Length-4];
            }
            for(int i = 0,c=0; i < rows; i++)
            {
                for(j=0;j< this.message[i].Length; j++,c++)
                {
                    if (c>=tmp.Length)
                    {
                        show[i][ j] = '　';
                    }
                    else
                    {
                        show[i][ j] = tmp[c];
                    }
                }
            }

            if (this.current >= this.message.Length)
            {
                for (int i = 0; i < this.message.Length - rows; i++)
                {
                    for (j = 0; j < this.message[i].Length; j++)
                    {
                        this.message[i][j] = this.message[i + rows][j];
                        this.message[i + rows][j] = '　';
                    }
                }
                this.current = this.message.Length - rows;
            }

            for (int i=0;i<show.Length;i++)
            {
                for (j=0;j<show[i].Length;j++)
                {
                    this.message[i + this.current][j] = show[i][j];
                }
            }
            this.current += rows;

            /*

                        for (int i=0;i<this.message.Length; i++)
                        {
                            for (j=0;j<this.message[i].Length;j++)
                            {
                                base.map[i + 2][j + 2] = this.message[i][j];
                            }
                        }
                        this.end = j;
            */
        }

        public void TextDisplay()
        {

            if (this.message[0][0]=='\0')
            {
                return;
            }
            int destCursorLeft = (this.x+2) * 2;
            int destCursorTop = this.y + 2;
            int destCursorRight = this.message[0].Length;


            for (int i=0;i<this.message.Length;i++)
            {
                for (int j=0;j<this.message[i].Length;j++)
                {
                    Console.SetCursorPosition(destCursorLeft + j*2, destCursorTop + i);
                    if (this.message[i][j]!='　')
                    {
                        destCursorRight = j;
                    }
                    Console.Write(this.message[i][j]);
                }
            }

            //Console.SetCursorPosition(this.x + 5 + destCursorRight*2,  destCursorTop );

        }



    }
}
