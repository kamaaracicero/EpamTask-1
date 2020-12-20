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
            Table table = new Table();
            table.CreateFigure(FigureShape.Circule, Material.Plastic, 2);
            table.CreateFigure(FigureShape.Triangle, Material.Film, 3, 3, 3);
            table.CreateFigure(FigureShape.Squad, Material.Paper, 4, 4, 4, 4)
                ;
        }
    }
}
