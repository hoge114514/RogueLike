using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike1
{
    public class MenuIO : BasicIO
    {

        protected Menu map;
        public Menu menu;
        
        protected Cursor cursor;
        public Selection[] selections;


        public MenuIO() : base()
        {

        }

        

        public MenuIO(int piyo,int fuga,Menu hoge) : base(piyo,fuga,hoge)
        {

            this.x = piyo;
            this.y = fuga;
            int y = 1, x = 1;
            this.menu = hoge;

            for (int i = 0; i < base.scene.map.Length; i++)
            {
                for (int j = 0; j < base.scene.map[i].Length; j++)
                {
                    if (base.scene.map[i][j] != '　' && base.scene.map[i][j] != '＠' && base.scene.map[i][j] != '＃')
                    {
                        y = i;
                        x = j;
                        goto LOOPEND;

                    }
                }
            }
            LOOPEND:;
            this.cursor = new Cursor(y, x - 2);
            base.obj = this.cursor;

            this.selections = new Selection[this.menu.NumOfSelection];
            for (int i = 0; i < this.selections.Length; i++)
            {
                this.selections[i] = new Selection(null, y + i * (this.menu.gap + 1), x - 2);
            }

            base.scene = hoge;
            base.scene.EditMap(base.obj.getSymbol(), y, x - 2);

        }

        public MenuIO(int fuga,int foo,Menu hoge, params BasicIO[] piyo) : base(fuga,foo,hoge)
        {

            this.x = fuga;
            this.y = foo;
            int y = 1, x = 1;
            this.menu = hoge;

            for (int i=0;i<base.scene.map.Length;i++)
            {
                for (int j = 0; j < base.scene.map[i].Length; j++)
                {
                    if (base.scene.map[i][j] != '　'　&& base.scene.map[i][j] != '＠'　&& base.scene.map[i][j] != '＃')
                    {
                        y = i;
                        x = j;
                        goto LOOPEND;

                    }
                }
            }
        LOOPEND:;
            this.cursor = new Cursor(y, x - 2);
            base.obj = this.cursor;

            this.selections = new Selection[piyo.Length];
            for (int i=0;i<this.selections.Length;i++)
            {
                this.selections[i] = new Selection(piyo[i], y + i*(this.menu.gap+1), x - 2);
            }

            base.scene = hoge;
            base.scene.EditMap(base.obj.getSymbol(),y,x - 2);

        }

        public override void Generate()
        {
            char c;
            int tmpx, tmpy;

            base.MoveCursor(0,0);
            this.scene.Display();
            Console.CursorVisible = false;

            while (true)
            {

                tmpx = this.obj.getX();
                tmpy = this.obj.getY();
                c = Console.ReadKey(true).KeyChar;
                //Console.Clear();
                if (this.Input(c))
                {
                    base.MoveCursor(0, 0);
                    this.scene.EraseMap();
                    return;
                }
                if (this.scene.IsAccessable(this.obj.getX(), this.obj.getY()))
                {
                    this.scene.EditMap(this.obj.getSymbol(), this.obj.getX(), this.obj.getY());
                    this.scene.EraseMap(tmpx, tmpy);
                    this.MoveCursor(tmpy,  tmpx);
                    this.scene.DotDisplay(tmpx, tmpy);
                }
                else
                {
                    this.obj.setX(tmpx);
                    this.obj.setY(tmpy);
                }

                //this.scene.Display();
                this.MoveCursor(this.obj.getY(),  this.obj.getX());
                this.scene.DotDisplay(this.obj.getX(), this.obj.getY());

            }

        }

        public int Selection()
        {
            char c;
            int tmpx, tmpy,z;

            base.MoveCursor(0, 0);
            this.scene.Display();
            Console.CursorVisible = false;

            while (true)
            {

                tmpx = this.obj.getX();
                tmpy = this.obj.getY();
                c = Console.ReadKey(true).KeyChar;
                //Console.Clear();
                z = this.Inputed(c);
                if (z!=-1)
                {
                    base.MoveCursor(0,0);
                    this.scene.EraseMap();
                    return z;
                }
                
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

                //this.scene.Display();
                this.MoveCursor(this.obj.getY(), this.obj.getX());
                this.scene.DotDisplay(this.obj.getX(), this.obj.getY());

            }

        }

        public int SelectionWithoutErase()
        {
            char c;
            int tmpx, tmpy, z;

            base.MoveCursor(0, 0);
            this.scene.Display();
            Console.CursorVisible = false;

            while (true)
            {

                tmpx = this.obj.getX();
                tmpy = this.obj.getY();
                c = Console.ReadKey(true).KeyChar;
                //Console.Clear();
                z = this.Inputed(c);
                if (z != -1)
                {
                    return z;
                }
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

                //this.scene.Display();
                this.MoveCursor(this.obj.getY(), this.obj.getX());
                this.scene.DotDisplay(this.obj.getX(), this.obj.getY());

            }

        }

        protected override Boolean Input(char c)
        {
            switch (c)
            {
                case '2':
                    this.cursor.Move(1*(this.menu.gap+1),0);
                    break;
                case '5':
                    if (this.Select())
                    {
                        return true;
                    }
                    break;
                case '8':
                    this.cursor.Move((-1)*(this.menu.gap+1),0);
                    break;
            }
            return false;
        }

        protected virtual Boolean Select()
        {
            for (int i=0;i<this.selections.Length;i++)
            {
                if (this.cursor.getX()==this.selections[i].x)
                {
                    this.selections[i].SceneHop();
                    return true;
                }
                
            }
            return false;
        }

        protected int Inputed(char c)
        {
            switch (c)
            {
                case '2':
                    this.cursor.Move(1 * (this.menu.gap + 1), 0);
                    break;
                case '5':
                    return Selected();
                case '8':
                    this.cursor.Move((-1) * (this.menu.gap + 1), 0);
                    break;
                case ' ':
                    return -2;
                    
            }
            return -1;
        }

        protected int Selected()
        {
            for (int i = 0; i < this.menu.NumOfSelection ; i++)
            {
                if (this.cursor.getX() == this.selections[i].x)
                {
                    return i;
                }

            }
            return -1;
        }

    }
}
