using System;
using System.IO;
using _List;
using _CShapeFactory;

namespace _MyList
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
