using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract bool IsLegal();
        public abstract void DrawShape();
    }

    public class Rectangle : Shape
    {
        protected double length;
        protected double width;

        public Rectangle(double tLength, double tWidth)
        {
            length = tLength;
            width = tWidth;
        }

        public override double GetArea()
        {
            return length * width;
        }
        public override bool IsLegal()
        {
            return (length > 0 && width > 0);
        }
        public override void DrawShape()
        {
            Console.WriteLine("Rectangle: " +
                " length:" + length +
                " width:" + width);
        }
    }

    public class Square : Rectangle
    {
        public Square(double tLength):base(tLength, tLength)
        {
            
        }
        public override void DrawShape()
        {
            Console.WriteLine("Square: " +
                " length:" + length);
        }
    }

    public class Triangle : Shape
    {
        protected double a, b, c;

        public Triangle(double tA, double tB, double tC)
        {
            a = tA;
            b = tB;
            c = tC;
        }

        public override double GetArea()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public override bool IsLegal()
        {
            return (a > 0 && b > 0 && c > 0 && a < b + c && b < a + c && c < a + b);
        }
        public override void DrawShape()
        {
            Console.WriteLine("Triangle: " +
                " edges:" + a +" " + b + " " + c);
        }
    }

    public class ShapeFactory
    {
        public Shape GetShape(string shapeType)
        {
            if (shapeType == null) return null;
            Random random = new Random((int)DateTime.Now.Ticks);
            int maxsize = random.Next(100);
            if (shapeType == "Rectangle")
            {
                double a = random.NextDouble() * maxsize;
                double b = random.NextDouble() * maxsize;
                return new Rectangle(a, b);
            }
            else if (shapeType == "Square")
            {
                double a = random.NextDouble() * maxsize;
                return new Square(a);
            }
            else if(shapeType == "Triangle")
            {
                double a = random.NextDouble() * maxsize;
                double b = random.NextDouble() * maxsize;
                double c = random.NextDouble() * maxsize;
                return new Triangle(a, b, c);
            }
            return null;
        }
    }
}
