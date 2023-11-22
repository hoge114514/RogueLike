using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace RogueLike1
{
    public class LoadIO : MenuIO
    {
        public LoadIO() : base()
        {

            string[] names = Directory.GetFiles("./savedata/");
            base.menu = new Menu(2,names);

            NormalIO[] data = new NormalIO[names.Length];
            for (int i = 0; i < data.Length; i++)
            {
                using (var sr = new StreamReader((names[i])))
                {
                    var serializer = new DataContractJsonSerializer(typeof(NormalIO));
                    data[i] = (NormalIO)serializer.ReadObject(sr.BaseStream);
                }
            }

            this.selections = new Selection[names.Length];
            for (int i = 0; i < this.selections.Length; i++)
            {
                this.selections[i] = new Selection(data[i], 1 + this.menu.gap + i * this.menu.gap, 4 - 2);
            }
        }
    }
}
