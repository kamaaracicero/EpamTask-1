using ChildrensTable.Figures;
using ChildrensTable.Colors;
using System.Collections.Generic;
using System.Text;
using System;

namespace ChildrensTable
{
    public class Table
    {
        public delegate void MessageHandler(string mes);
        public event MessageHandler MessageEvent;

        public Box box = new Box();

        public List<Figure> createdFigures = new List<Figure>();

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

        public void PutAllFiguresInBox()
        {
            try
            {
                box.AddFigure(createdFigures, MessageEvent);
            }
            catch (Exception ex)
            {
                MessageEvent?.Invoke(ex.Message);
            }
        }

        public void PutFigureInBox(int index)
        {
            try
            {
                box.AddFigure(createdFigures[index]);
            }
            catch (Exception ex)
            {
                MessageEvent?.Invoke(ex.Message);
            }
        }

        public void SaveFiguresInBox(string path)
        {
            try
            {
                box.Save(path);
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
            @string.Append(box);
            return @string.ToString();
        }
    }
}
