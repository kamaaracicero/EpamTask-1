using System;

namespace ChildrensTable.Figures
{
    /// <summary>
    /// Circule class
    /// </summary>
    [Serializable]
    public abstract class Circule : Figure
    {
        public Circule(double radius)
        {
            sides[0] = radius;
        }

        public Circule(Figure figure, double radius)
        {
            double square = Math.Pow(radius, 2) * Math.PI;
            if (figure.GetSquare() < square || GetMaterial(this) != GetMaterial(figure))
                throw new FigureException("Can't cut a circule from this figure");
            else
            {
                sides[0] = radius;
                Color = figure.Color;
            }
        }

        public Circule()
            : base()
        { }

        public override double GetPerimeter()
        {
            return (2 * Math.PI) * sides[0];

        }

        public override double GetSquare()
        {
            return Math.Pow(sides[0], 2) * Math.PI;
        }
    }
}
