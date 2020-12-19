using ChildrensTable.Colors;
using System;

namespace ChildrensTable.Figures
{
    [Serializable]
    public class FilmTriangle : Triangle
    {
        public FilmTriangle(double[] sides)
            : base(sides)
        { }

        public FilmTriangle(Figure figure, params double[] sides)
            : base(figure, sides)
        { }

        public FilmTriangle()
        { }

        public override void DueFigure(Color color)
        {
            throw new PaintException("The figure cannot be painted!");
        }
    }
}
