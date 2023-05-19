using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _6th_LAB_OOP
{
    public class MyList : List
    {
        public void LoadShapes(StreamReader stream, CShapeFactory shapeFactory)
        {
            char code; int size = Convert.ToInt32(stream.ReadLine());

            for (int i = 0; i < size; i++)
            {
                code = Convert.ToChar(stream.ReadLine());
                Add(shapeFactory.createShape(code));
                this.Get(this.GetSize() - 1).Load(stream, shapeFactory);
            }
        }
    }
}
