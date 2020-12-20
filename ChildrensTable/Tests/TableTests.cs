using Xunit;
using ChildrensTable;
using ChildrensTable.Colors;
using ChildrensTable.Figures;

namespace Tests
{
    public class TableTests
    {
        [Fact]
        public void MethodTest_CreateFigure()
        {
            // Arrange
            Table table = new Table();

            // Act
            table.CreateFigure(FigureShape.Circule, Material.Paper, 4);

            // Assert
            Assert.Equal("PaperCircule", table[0].GetType().Name);
        }

        [Fact]
        public void MethodTest_DueFigureByIndex()
        {
            // Arrange
            Table table = new Table();
            table.CreateFigure(FigureShape.Circule, Material.Paper, 2);

            // Act
            table.DueFigureByIndex(0, Color.BLACK);

            // Assert
            Assert.Equal(Color.BLACK, table[0].Color);
        }

        [Fact]
        public void MethodTest_PutAllFiguresInBox_1()
        {
            // Arrange
            Table table = new Table();
            table.CreateFigure(FigureShape.Triangle, Material.Film, 3, 3, 3);
            table.CreateFigure(FigureShape.Squad, Material.Paper, 3, 3, 3, 3);

            // Act
            table.PutAllFiguresInBox();

            // Assert
            Assert.Equal(2, table.Box.Count);
            Assert.Equal("PaperSquad", table.ViewFigureInBox(1).GetType().Name);
        }

        [Fact]
        public void MethodTest_PutAllFiguresInBox_2()
        {
            // Two indentical figure;
            // Arrange
            Table table = new Table();
            table.CreateFigure(FigureShape.Triangle, Material.Film, 3, 3, 3);
            table.CreateFigure(FigureShape.Triangle, Material.Film, 3, 3, 3);

            // Act
            table.PutAllFiguresInBox();

            // Assert
            Assert.Equal(1, table.Box.Count);
        }

        [Fact]
        public void MethodTest_GetFigureFromBox()
        {
            // Arrange
            Table table = new Table();
            table.CreateFigure(FigureShape.Circule, Material.Plastic, 2);
            table.CreateFigure(FigureShape.Triangle, Material.Film, 3, 3, 3);
            table.CreateFigure(FigureShape.Squad, Material.Paper, 4, 4, 4, 4);

            // Act
            table.PutAllFiguresInBox();
            table.GetFigureFromBox(1);

            // Assert
            Assert.Equal(2, table.Box.Count);
            Assert.Equal(1, table.Count);
            Assert.Equal("FilmTriangle", table[0].GetType().Name);
        }

        [Fact]
        public void MethodTest_ReplaceFigureInBox()
        {
            // Arrange
            Table table = new Table();
            table.CreateFigure(FigureShape.Circule, Material.Film, 2);
            table.CreateFigure(FigureShape.Circule, Material.Paper, 4);
            table.PutFigureInBox(1);

            // Act
            table.ReplaceFigureInBox(0, 0);

            // Assert
            Assert.Equal("PaperCircule", table[0].GetType().Name);
            Assert.Equal("FilmCircule", table.ViewFigureInBox(0)?.GetType().Name);
        }

        [Fact]
        public void MethodTest_FindFigureInBoxByPattern()
        {
            // Arrange
            Table table = new Table();
            table.CreateFigure(FigureShape.Circule, Material.Film, 2);
            table.CreateFigure(FigureShape.Circule, Material.Paper, 4);
            table.CreateFigure(FigureShape.Circule, Material.Plastic, 2);
            table.CreateFigure(FigureShape.Triangle, Material.Film, 3, 3, 3);
            table.CreateFigure(FigureShape.Squad, Material.Paper, 4, 4, 4, 4);
            table.PutAllFiguresInBox();

            double[] sides = new double[3] { 3, 3, 3 };
            Figure pattern = new FilmTriangle(sides);

            // Act
            int index = table.FindFigureInBoxByPattern(pattern);

            // Assert
            Assert.Equal(3, index);
        }
    }
}
