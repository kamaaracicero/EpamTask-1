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
    }
}
