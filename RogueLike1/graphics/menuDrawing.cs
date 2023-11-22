using System;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;


namespace RogueLike1
{
    public class menuDrawing : drawing
    {
        private Map layer1;

        public menuDrawing(Map layer1)
        {
            this.layer1 = layer1;
        }

        public void draw() { }
        public void refresh() { }
    }


}

