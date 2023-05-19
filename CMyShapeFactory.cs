﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using StorageClassLibrary;
using System.Drawing;

namespace _6th_LAB_OOP
{
    public abstract class CShapeFactory
    {
        public abstract CShape createShape(char code);
        ~CShapeFactory() { }
    }

    public class CMyShapeFactory : CShapeFactory
    {
        public override CShape createShape(char code)
        {
            CShape shape = null;
            switch (code)
            {
                case 'C':
                    shape = new CCircle(0, 0, Color.White);
                    break;
                case 'T':
                    shape = new CTriangle(0, 0, Color.White);
                    break;
                case 'S':
                    shape = new CSquare(0, 0, Color.White);
                    break;
                case 'G':
                    shape = null;
                    break;
            }
            return shape;
        }
    }
}
