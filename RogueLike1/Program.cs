using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLike1;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.IO;

namespace RogueLike1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.SetWindowSize(135, 55);
            Console.SetBufferSize(135, 55);


            Console.Title = "ろーぐらいく";

            //IME状態の取得

            //new Map(40, 40,'＠').WriteMap("../../maps/Stage1.txt");

            Title title = new Title(2,"ＮＥＷ　ＧＡＭＥ","ＬＯＡＤ　ＧＡＭＥ","ＯＰＴＩＯＮＳ","ＥＸＩＴ");

            // セーブデータディレクトリ
            if (System.IO.Directory.Exists("./savedata/") == false)
            {
                System.IO.Directory.CreateDirectory("./savedata/");
            }

            // Stageデータ
            string[] mapPaths = new string[2]{ "Stage1.txt" , "Stage1.txt" };
            string[] moviePaths = new string[2] { "../../maps/Prologue.txt", "../../maps/Prologue.txt" };

            Manager manager = new Manager(title, mapPaths, moviePaths);
            manager.startGame();
        }
    }
}
