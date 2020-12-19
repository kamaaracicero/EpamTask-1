using ChildrensTable.Colors;
using System;

namespace ChildrensTable.Figures
{
    [Serializable]
    public class PlasticTriangle : Triangle
    {
        public PlasticTriangle(double[] sides)
            : base(sides)
        { }

        public PlasticTriangle(Figure figure, params double[] sides)
            : base(figure, sides)
        { }

        public PlasticTriangle()
        { }

        public override void DueFigure(Color color)
        {
            this.Color = color;
        }
    }
}
