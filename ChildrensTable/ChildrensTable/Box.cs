using ChildrensTable.Figures;
using ChildrensTable.DoubleExtensions;
using ChildrensTable.Colors;
using System.Collections.Generic;
using System.Text;

namespace ChildrensTable
{
    /// <summary>
    /// Box class. Can handle 20 figures
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Box capacity
        /// </summary>
        private const int capacity = 20;

        /// <summary>
        /// List of figures
        /// </summary>
        private List<Figure> storedFigures;

        /// <summary>
        /// Number of figures in a box
        /// </summary>
        public int Count { get => storedFigures.Count; }

        public Box()
        {
            storedFigures = new List<Figure>();
        }

        /// <summary>
        /// Add a single figure to the box
        /// </summary>
        /// <param name="figure">Figure</param>
        internal void AddFigure(Figure figure)
        {
            if (Count < capacity)
                if (!IsAlreadyContained(figure.GetType().Name, figure.GetSides()))
                    storedFigures.Add(figure);
                else throw new BoxException("Figure is already containded.");
            else
                throw new BoxCapacityException();
        }

        /// <summary>
        /// Add multiple figures to the box.
        /// </summary>
        /// <param name="figuresList">List of figures</param>
        internal void AddFigure(List<Figure> figuresList, Table.MessageHandler messanger)
        {
            for(int index = 0; index < figuresList.Count; index++)
            {
                if (storedFigures.Count < capacity)
                {
                    if (!IsAlreadyContained(figuresList[index].GetType().Name, figuresList[index].GetSides()))
                    {
                        storedFigures.Add(figuresList[index]);
                        figuresList.RemoveAt(index);
                        index--;
                    }
                    else
                        messanger?.Invoke(figuresList[index].GetType().Name + " is already contained. Figure was skipped.");
                }
                else throw new BoxCapacityException();
            }
        }

        /// <summary>
        /// Get a copy of the figure without removing it from the box
        /// </summary>
        /// <param name="index">Figure index</param>
        /// <returns></returns>
        internal Figure ViewFigureByIndex(int index)
        {
            if (index < 20 && index >= 0)
                return storedFigures[index];
            else throw new BoxException("Index out of range");
        }

        /// <summary>
        /// Take the figure out of the box
        /// </summary>
        /// <param name="index">Figure index</param>
        /// <returns></returns>
        internal Figure GetFigureByIndex(int index)
        {
            if (index < 20 && index >= 0)
            {
                Figure figure = storedFigures[index];
                storedFigures.RemoveAt(index);
                return figure;
            }
            else throw new BoxException("Index out of range");
        }

        /// <summary>
        /// Replace figure by index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="figure"></param>
        internal void ReplaceByIndex(int index, Figure figure)
        {
            if (index < 20 && index >= 0)
            {
                storedFigures.RemoveAt(index);
                storedFigures.Insert(index, figure);
            }
            else throw new BoxException("Index out of range");
        }

        /// <summary>
        /// Find the index of a figure for a given pattern
        /// </summary>
        /// <param name="figure">Pattern</param>
        /// <returns>Index</returns>
        internal int FindFigureByPattern(Figure figure)
        {
            string figureName = figure.GetType().Name;
            double[] figureSides = figure.GetSides();
            
            for(int index = 0; index < storedFigures.Count; index++)
            {
                if(storedFigures[index].GetType().Name == figureName && storedFigures[index].GetSides().EqualTo(figureSides))
                {
                    return index;
                }
            }
            throw new BoxException("The box does not contain this figure");
        }

        /// <summary>
        /// Get the total area of all figures
        /// </summary>
        /// <returns></returns>
        public double TotalSquare()
        {
            double totalAr = 0;
            foreach(Figure figure in storedFigures)
            {
                totalAr += figure.GetSquare();
            }
            return totalAr;
        }

        /// <summary>
        /// Get the total perimeter of all figures
        /// </summary>
        /// <returns></returns>
        public double TotalPerimeter()
        {
            double totalPer = 0;
            foreach(Figure figure in storedFigures)
            {
                totalPer += figure.GetPerimeter();
            }
            return totalPer;
        }

        /// <summary>
        /// Get all figures of a given shape
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        internal List<Figure> GetAllFigures(FigureShape shape)
        {
            List<Figure> figures = new List<Figure>();
            for(int index = 0; index < storedFigures.Count; index++)
            {
                if (storedFigures[index].GetType().Name.Contains(shape.ToString()))
                {
                    figures.Add(storedFigures[index]);
                    storedFigures.RemoveAt(index);
                    index--;
                }
            }
            return figures;
        }

        /// <summary>
        /// Get all figures of a given material
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        internal List<Figure> GetAllFigures(Material material)
        {
            List<Figure> figures = new List<Figure>();
            for (int index = 0; index < storedFigures.Count; index++)
            {
                if (storedFigures[index].GetType().Name.Contains(material.ToString()))
                {
                    figures.Add(storedFigures[index]);
                    storedFigures.RemoveAt(index);
                    index--;
                }
            }
            return figures;
        }

        /// <summary>
        /// Returns list of plastic figures, that weren't due
        /// </summary>
        /// <returns></returns>
        internal List<Figure> GetAllPlasticNoColor()
        {
            List<Figure> figures = new List<Figure>();
            for (int index = 0; index < storedFigures.Count; index++)
            {
                if (storedFigures[index].GetType().Name.Contains(Material.Plastic.ToString()) && 
                    storedFigures[index].Color == Color.NO_COLOR)
                {
                    figures.Add(storedFigures[index]);
                    storedFigures.RemoveAt(index);
                    index--;
                }
            }
            return figures;
        }

        /// <summary>
        /// Saving all stored figures
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="mode">false:using XmlWriter; true:using StreamReader</param>
        public void Save(string path, bool mode = false)
        {
            switch (mode)
            {
                case false:
                    XmlHelper.SaveInXml_XmlWriter(path, storedFigures);
                    break;
                case true:
                    XmlHelper.SaveInXml_StreamWriter(path, storedFigures);
                    break;
            }
        }

        /// <summary>
        /// Load list of figures from file
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="mode">false:using XmlWriter; true:using StreamReader</param>
        public void Load(string path, bool mode = false)
        {
            switch (mode)
            {
                case false:
                    storedFigures = XmlHelper.ReadFromXml_XmlReader(path);
                    break;
                case true:
                    storedFigures = XmlHelper.ReadFromXml_StreamReader(path);
                    break;
            }

        }


        /// <summary>
        /// Indicates whether the figure is contained in the box
        /// </summary>
        /// <param name="figureName">Figure name</param>
        /// <param name="sides">Array of sides</param>>
        /// <returns>true if figure is contained; otherwise, false</returns>
        private bool IsAlreadyContained(string figureName, double[] sides)
        {
            foreach(Figure figure in storedFigures)
            {
                if (figure.GetType().Name == figureName && figure.GetSides().EqualTo(sides))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Overrided standart method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            @string.Append("Boxed Figures:\n");
            if (storedFigures.Count != 0)
            {
                foreach (Figure figure in storedFigures)
                {
                    @string.Append("\tName:" + figure.GetType().Name + "\n");
                }
            }
            else @string.Append("\t--Empty--\n");
            return @string.ToString();
        }
    }
}
