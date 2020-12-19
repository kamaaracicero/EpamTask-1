using System;

namespace ChildrensTable.Figures
{
    /// <summary>
    /// Squad class
    /// </summary>
    [Serializable]
    public abstract class Squad : Figure
    {
        public Squad(double[] sides)
            : base (sides)
        { }

        public Squad(Figure figure, double[] sides)
        {
            double square = Math.Pow(sides[0], 2);
            if (figure.GetSquare() < square)
                throw new FigureException("Can't cut a squade from this figure");
            else
            {
                this.sides = sides;
                Color = figure.Color;
            }
        }

        public Squad()
            : base()
        { }

        public override double GetPerimeter()
        {
            return sides[0] * 4;
        }

        public override double GetSquare()
        {
            return Math.Pow(sides[0], 2);
        }
    }
}
