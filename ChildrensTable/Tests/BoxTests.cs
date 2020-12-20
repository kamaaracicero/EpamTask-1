using Xunit;
using ChildrensTable;
using ChildrensTable.Figures;
using ChildrensTable.Colors;

namespace Tests
{
    public class BoxTests
    {
        [Fact]
        public void MethodTest_TotalPerimeter()
        {
            // Arrange
            Table table = new Table();
            table.CreateFigure(FigureShape.Triangle, Material.Film, 3, 3, 3);
            table.CreateFigure(FigureShape.Squad, Material.Paper, 4, 4, 4, 4);

            // Act
            table.PutAllFiguresInBox();
            double perimeter = table.Box.TotalPerimeter();

            // Assert
            Assert.Equal(25, perimeter);
        }

        [Fact]
        public void MethodTest_TotalSquare()
        {
            // Arrange
            Table table = new Table();
            table.CreateFigure(FigureShape.Triangle, Material.Film, 3, 4, 5);
            table.CreateFigure(FigureShape.Squad, Material.Paper, 4, 4, 4, 4);
            table.CreateFigure(FigureShape.Squad, Material.Paper, 5, 5, 5, 5);

            // Act
            table.PutAllFiguresInBox();
            double square = table.Box.TotalSquare();

            // Assert
            Assert.Equal(47, square);
        }
    }
}
