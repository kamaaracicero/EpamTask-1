using ChildrensTable;
using ChildrensTable.Figures;
using ChildrensTable.Colors;
using System;
using System.Collections.Generic;

namespace Console_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new Table();

            table.MessageEvent += SendMessage;

            table.CreateFigure(FigureShape.Circule, Material.Paper, 4);
            table.CreateFigure(FigureShape.Circule, Material.Paper, 4);
            table.CreateFigure(FigureShape.Triangle, Material.Plastic, 3, 4, 5);
            table.CreateFigure(FigureShape.Squad, Material.Film, 6, 6, 6, 6);
            table.CreateFigure(FigureShape.Circule, Material.Film, 7);
            table.CreateFigure(FigureShape.Squad, Material.Plastic, 8, 8 , 8, 8);
            table.CreateFigure(FigureShape.Triangle, Material.Paper, 9, 10, 8);

            Console.WriteLine(table);

            table.PutAllFiguresInBox();

            Console.WriteLine(table);

        }

        public static void SendMessage(string mes)
        {
            Console.WriteLine(mes);
        }

        public static void WriteList(List<Figure> list, int index)
        {
            Console.Write("\n" + "My figures:" + index + "\n");

            foreach(Figure figure in list)
            {
                Console.Write("\t" + figure.GetType().Name + "\n");
            }
            Console.Write("\n");
        }
    }
}
