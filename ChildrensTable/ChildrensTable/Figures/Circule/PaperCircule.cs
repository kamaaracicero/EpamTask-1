using ChildrensTable.Colors;
using System;

namespace ChildrensTable.Figures
{
    /// <summary>
    /// Paper circule class
    /// </summary>
    [Serializable]
    public class PaperCircule : Circule
    {
        public PaperCircule(double radius)
            : base(radius)
        { }

        public PaperCircule(Figure figure, double radius)
            : base(figure, radius)
        { }

        public PaperCircule()
        { }

        public override void DueFigure(Color color)
        {
            if (this.Color == Color.NO_COLOR) Color = color;
            else throw new PaintException("The figure was already painted");
        }
    }
}
