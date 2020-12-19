using System;
using System.Collections.Generic;
using System.Text;

namespace ChildrensTable.Figures
{
    /// <summary>
    /// Triangle class
    /// </summary>
    [Serializable]
    public abstract class Triangle : Figure
    {
        public Triangle(double[] sides)
            : base(sides)
        { }

        public Triangle(Figure figure, double[] sides)
        {
            double a = sides[0], b = sides[1], c = sides[2];
            double p = (a + b + c) / 2;
            double square = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            if (figure.GetSquare() < square)
                throw new FigureException("Can't cut a triangle from this figure");
            else
            {
                this.sides = sides;
                Color = figure.Color;
            }
        }

        public Triangle()
            : base()
        { }

        public override double GetPerimeter()
        {
            double perimetr = 0.0;
            foreach (double side in this.sides)
                perimetr += side;
            return perimetr;
        }

        public override double GetSquare()
        {
            double a = sides[0], b = sides[1], c = sides[2];
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
