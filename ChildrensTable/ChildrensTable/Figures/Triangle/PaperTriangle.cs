using ChildrensTable.Colors;
using System;

namespace ChildrensTable.Figures
{
    /// <summary>
    /// Paper triangle class
    /// </summary>
    [Serializable]
    public class PaperTriangle : Triangle
    {
        public PaperTriangle(double[] sides)
            : base(sides)
        { }

        public PaperTriangle(Figure figure, params double[] sides)
            : base(figure, sides)
        { }

        public PaperTriangle()
        { }

        public override void DueFigure(Color color)
        {
            if (this.Color == Color.NO_COLOR) Color = color;
            else throw new PaintException("The figure was already painted");
        }
    }
}
