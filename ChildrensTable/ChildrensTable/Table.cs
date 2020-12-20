using ChildrensTable.Figures;
using ChildrensTable.Colors;
using System.Collections.Generic;
using System.Text;
using System;

namespace ChildrensTable
{
    public class Table
    {
        /// <summary>
        /// Message delegate
        /// </summary>
        /// <param name="message"></param>
        public delegate void MessageHandler(string message);

        /// <summary>
        /// Event for message
        /// </summary>
        public event MessageHandler MessageEvent;

        /// <summary>
        /// Created figures count
        /// </summary>
        public int Count { 
            get
            {
                return createdFigures.Count;
            }
        }

        /// <summary>
        /// List of created figures
        /// </summary>
        List<Figure> createdFigures = new List<Figure>();

        /// <summary>
        /// Box class
        /// </summary>
        public Box Box = new Box();

        /// <summary>
        /// Standart constructor
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Figure this[int index]
        {
            get
            {
                return createdFigures[index];
            }
        }

        /// <summary>
        /// Method for creating a figure
        /// </summary>
        /// <param name="shape">Figure shape</param>
        /// <param name="material">Figure material</param>
        /// <param name="sides">Figure sides</param>
        public void CreateFigure(FigureShape shape, Material material, params double[] sides)
        {
            switch (shape)
            {
                case FigureShape.Circule:
                    switch (material)
                    {
                        case Material.Film:
                                createdFigures.Add(new FilmCircule(sides[0]));
                            break;
                        case Material.Paper:
                                createdFigures.Add(new PaperCircule(sides[0]));
                            break;
                        case Material.Plastic:
                                createdFigures.Add(new PlasticCircule(sides[0]));
                            break;
                    }
                    break;
                case FigureShape.Squad:
                    switch (material)
                    {
                        case Material.Film:
                            createdFigures.Add(new FilmSquad(sides));
                            break;
                        case Material.Paper:
                            createdFigures.Add(new PaperSquad(sides));
                            break;
                        case Material.Plastic:
                            createdFigures.Add(new PlasticSquad(sides));
                            break;
                    }
                    break;
                case FigureShape.Triangle:
                    switch (material)
                    {
                        case Material.Film:
                            createdFigures.Add(new FilmTriangle(sides));
                            break;
                        case Material.Paper:
                            createdFigures.Add(new PaperTriangle(sides));
                            break;
                        case Material.Plastic:
                            createdFigures.Add(new PlasticTriangle(sides));
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Method for a painting created figures
        /// </summary>
        /// <param name="index"></param>
        /// <param name="color"></param>
        public void DueFigureByIndex(int index, Color color)
        {
            try
            {
                createdFigures[index].DueFigure(color);
            }
            catch (PaintException ex)
            {
                MessageEvent?.Invoke(ex.Message);
            }
        }

        /// <summary>
        /// Put all created figures in box
        /// </summary>
        public void PutAllFiguresInBox()
        {
            try
            {
                this.Box.AddFigure(createdFigures, MessageEvent);
            }
            catch (Exception ex)
            {
                MessageEvent?.Invoke(ex.Message);
            }
        }

        /// <summary>
        /// Put created figure in box
        /// </summary>
        /// <param name="index">Figure index</param>
        public void PutFigureInBox(int index)
        {
            try
            {
                this.Box.AddFigure(createdFigures[index]);
            }
            catch (Exception ex)
            {
                MessageEvent?.Invoke(ex.Message);
            }
        }


        /*      // First variant
        /// <summary>
        /// View figure in box by index
        /// </summary>
        /// <param name="index">Figure index</param>
        public void ViewFigureInBox(int index)
        {
            try
            {
                var figure = Box.ViewFigureByIndex(index);
                MessageEvent?.Invoke(figure.GetType().Name + ' ' + figure.GetSides().ToString() + ' ');
            }
            catch (Exception ex)
            {
                MessageEvent?.Invoke(ex.Message);
            }
        }
        */

        // Second variant
        public Figure ViewFigureInBox(int index)
        {
            Figure figure;
            try
            {
                figure = Box.ViewFigureByIndex(index);
                return figure;
            }
            catch (Exception ex)
            {
                MessageEvent?.Invoke(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get figure from box
        /// </summary>
        /// <param name="index">Figure index</param>
        public void GetFigureFromBox(int index)
        {
            try
            {
                createdFigures.Add(Box.GetFigureByIndex(index));
            }
            catch (Exception ex)
            {
                MessageEvent?.Invoke(ex.Message);
            }
        }

        /// <summary>
        /// Replace figure in box by index
        /// </summary>
        /// <param name="newFigureindexInBox">New figure index in box</param>
        /// <param name="curFigureIndex">Figure index in created figures list</param>
        public void ReplaceFigureInBox(int newFigureindexInBox, int curFigureIndex)
        {
            try
            {
                Box.ReplaceByIndex(newFigureindexInBox, createdFigures[curFigureIndex]);
            }
            catch (Exception ex)
            {
                MessageEvent?.Invoke(ex.Message);
            }
        }

        public override string ToString()
        {
            StringBuilder @string = new StringBuilder();
            @string.Append("Created Figures:\n");
            if (createdFigures.Count != 0)
            {
                foreach (Figure figure in createdFigures)
                {
                    @string.Append("\tName:" + figure.GetType().Name + "\n\t\tPerimeter:" + figure.GetPerimeter() + "\n\t\tSquare:" + figure.GetSquare() + "\n\t\tColor:" + figure.Color + "\n\n");
                }
            }
            else @string.Append("\t--Empty--\n");
            @string.Append(Box);
            return @string.ToString();
        }
    }
}
