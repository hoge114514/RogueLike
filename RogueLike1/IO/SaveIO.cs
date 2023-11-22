using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using static System.Console;

namespace RogueLike1
{
    public class SaveIO : BasicIO
    {
        NormalIO status;

        public SaveIO(NormalIO normal) : base()
        {
            this.status = normal;
        }


        public override void Generate()
        {
            
            this.status.box.AddMessage("セーブを行います");
            this.status.box.TextDisplay();

            string[] files = Directory.GetFiles("./savedata/", "*", System.IO.SearchOption.AllDirectories);
            using (StreamWriter s = new StreamWriter("./savedata/"+files.Length+".json"))
            {
                var serializer = new DataContractJsonSerializer(typeof(NormalIO));
                serializer.WriteObject(s.BaseStream,this.status);
            }

            this.status.box.AddMessage("セーブが完了しました");
            this.status.box.TextDisplay();

        }
    }
}
