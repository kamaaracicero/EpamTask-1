using ChildrensTable.Colors;
using System;

namespace ChildrensTable.Figures
{
    [Serializable]
    public class FilmSquad : Squad
    {
        public FilmSquad(double[] sides)
            : base(sides)
        { }

        public FilmSquad(Figure figure, params double[] sides)
            : base(figure, sides)
        { }

        public FilmSquad()
        { }

        public override void DueFigure(Color color)
        {
            throw new PaintException("The figure cannot be painted!");
        }
    }
}
