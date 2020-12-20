using System;
using ChildrensTable.Colors;
using System.Xml.Serialization;

namespace ChildrensTable.Figures
{
    /// <summary>
    /// Figure class
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Circule))]
    [XmlInclude(typeof(FilmCircule))]
    [XmlInclude(typeof(PaperCircule))]
    [XmlInclude(typeof(PlasticCircule))]
    [XmlInclude(typeof(Squad))]
    [XmlInclude(typeof(FilmSquad))]
    [XmlInclude(typeof(PaperSquad))]
    [XmlInclude(typeof(PlasticSquad))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(FilmTriangle))]
    [XmlInclude(typeof(PaperTriangle))]
    [XmlInclude(typeof(PlasticTriangle))]
    public class Figure
    {
        /// <summary>
        /// Figure color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Figure sides
        /// </summary>
        public double[] sides = new double[1];

        /// <summary>
        /// Standart constructor for heirs
        /// </summary>
        /// <param name="sides">Figure sides</param>
        protected Figure(double[] sides)
        {
            this.sides = sides;
        }

        /// <summary>
        /// Standart empty constructor
        /// </summary>
        protected Figure()
        { }

        /// <summary>
        /// Return array of sides
        /// </summary>
        /// <returns>Array of sides</returns>
        public double[] GetSides()
        {
            return sides;
        }

        /// <summary>
        /// Method for painting the figure
        /// </summary>
        /// <param name="color">New color</param>
        public virtual void DueFigure(Color color)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get figure square
        /// </summary>
        /// <returns>Double value</returns>
        public virtual double GetSquare()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get figure perimeter
        /// </summary>
        /// <returns>Double value</returns>
        public virtual double GetPerimeter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for getting material
        /// </summary>
        /// <param name="figure">Figure</param>
        /// <returns>1 - Film;2 - Paper;3 - Plastic;</returns>
        protected static int GetMaterial(Figure figure)
        {
            if (figure.GetType().Name.Contains("Film")) return 1;
            else if (figure.GetType().Name.Contains("Paper")) return 2;
            else return 3;
        }
    }
}
