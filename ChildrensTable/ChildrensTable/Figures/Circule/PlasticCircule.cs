using ChildrensTable.Colors;
using System;

namespace ChildrensTable.Figures
{
    [Serializable]
    public class PlasticCircule : Circule
    {
        public PlasticCircule(double radius) 
            : base(radius)
        { }

        public PlasticCircule(Figure figure, double radius) 
            : base (figure, radius)
        { }

        public PlasticCircule()
        { }

        public override void DueFigure(Color color)
        {
            this.Color = color;
        }
    }
}
