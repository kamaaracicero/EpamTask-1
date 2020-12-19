using ChildrensTable.Colors;
using System;

namespace ChildrensTable.Figures
{
    [Serializable]
    public class PaperSquad : Squad
    {
        public PaperSquad(double[] sides)
            : base(sides)
        { }

        public PaperSquad(Figure figure, params double[] sides)
            : base(figure, sides)
        { }

        public PaperSquad()
        { }

        public override void DueFigure(Color color)
        {
            if (this.Color == Color.NO_COLOR) Color = color;
            else throw new PaintException("The figure was already painted");
        }
    }
}
