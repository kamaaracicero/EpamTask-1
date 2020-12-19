using ChildrensTable.Colors;
using System;

namespace ChildrensTable.Figures
{
    /// <summary>
    /// Film circule class
    /// </summary>
    [Serializable]
    public class FilmCircule : Circule
    {
        public FilmCircule(double radius)
            : base(radius)
        { }

        public FilmCircule(Figure figure, double radius)
            : base(figure, radius)
        { }

        public FilmCircule()
        { }

        public override void DueFigure(Color color)
        {
            throw new PaintException("The figure cannot be painted!");
        }
    }
}
