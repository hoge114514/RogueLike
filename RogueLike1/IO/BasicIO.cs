using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace RogueLike1
{
    [DataContract]
    public class BasicIO : IDisposable
    {
        [DataMember]
        public  Map scene;
        [DataMember]
        public  Object obj;
        [DataMember]
        public int x;
        [DataMember]
        public int y;

        public Boolean flag = true;

        public BasicIO()
        {
            
        }

        public BasicIO(int x,int y,Map hoge)
        {
            this.x = x;
            this.y = y;
            this.scene = hoge;
        }

        public void MoveCursor(int x, int y)
        {
            // 移動先のカーソル位置を決定する
            int destCursorLeft = this.y + x*2;
            int destCursorTop =  this.x + y;

            // カーソルの左位置の範囲からオーバーしていれば補正する
            if (destCursorLeft < 0)
            {
                destCursorLeft = 0;
            }
            if (destCursorLeft > Console.BufferWidth - 1)
            {
                destCursorLeft = Console.BufferWidth - 1;
            }

            // カーソルの上位置の範囲からオーバーしていれば補正する
            if (destCursorTop < 0)
            {
                destCursorTop = 0;
            }
            if (destCursorTop > Console.BufferHeight - 1)
            {
                destCursorTop = Console.BufferHeight - 1;
            }

            // カーソルの位置を移動する
            Console.SetCursorPosition(destCursorLeft, destCursorTop);

            
        }


        public virtual void Generate()
        {
            char c;
            int tmpx, tmpy;

            this.MoveCursor(0, 0);
            this.scene.Display();
            Console.CursorVisible = false;

            while (true)
            {

                tmpx = this.obj.getX();
                tmpy = this.obj.getY();
                c = Console.ReadKey(true).KeyChar;
                this.Input(c);

                if (this.scene.IsAccessable(this.obj.getX(), this.obj.getY()))
                {
                    this.scene.EditMap(this.obj.getSymbol(), this.obj.getX(), this.obj.getY());
                    this.scene.EraseMap(tmpx, tmpy);
                    this.MoveCursor(tmpy, tmpx);
                    this.scene.DotDisplay(tmpx, tmpy);
                }
                else
                {
                    this.obj.setX(tmpx);
                    this.obj.setY(tmpy);
                }


                this.MoveCursor(this.obj.getY(), this.obj.getX());
                this.scene.DotDisplay(this.obj.getX(), this.obj.getY());
            }
        }

        public virtual void Generate(BasicIO previous)
        {
            char c;
            int tmpx, tmpy;

            previous.Dispose();
            Console.Clear();
            this.MoveCursor(0, 0);
            this.scene.Display();
            Console.CursorVisible = false;

            while (true)
            {
                
                tmpx = this.obj.getX();
                tmpy = this.obj.getY();
                c = Console.ReadKey(true).KeyChar;
                this.Input(c);

                if (this.scene.IsAccessable(this.obj.getX(), this.obj.getY()))
                {
                    this.scene.EditMap(this.obj.getSymbol(), this.obj.getX(), this.obj.getY());
                    this.scene.EraseMap(tmpx, tmpy);
                    this.MoveCursor(tmpy, tmpx);
                    this.scene.DotDisplay(tmpx, tmpy);
                }
                else
                {
                    this.obj.setX(tmpx);
                    this.obj.setY(tmpy);
                }

                
                this.MoveCursor(this.obj.getY(), this.obj.getX());
                this.scene.DotDisplay(this.obj.getX(), this.obj.getY());

            }

        }

        protected virtual Boolean Input(char hoge)
        {
            return true;
        }

        public Boolean getFlag() {  return flag; }

        public void Dispose()
        {
           
        }

    }
}