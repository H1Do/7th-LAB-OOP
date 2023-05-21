using _CShape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CShapeFactory
{
    public abstract class CShapeFactory // Абстрактная фабрика для фигур
    {
        public abstract CShape createShape(char code);
        ~CShapeFactory() { }
    }
}
