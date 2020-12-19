using ChildrensTable.Colors;
using System;

namespace ChildrensTable.Figures
{
    [Serializable]
    public class PlasticSquad : Squad
    {
        public PlasticSquad(double[] sides)
            : base(sides)
        { }

        public PlasticSquad(Figure figure, params double[] sides)
            : base(figure, sides)
        { }

        public PlasticSquad()
        { }

        public override void DueFigure(Color color)
        {
            this.Color = color;
        }
    }
}
