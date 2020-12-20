using System;
using Xunit;
using ChildrensTable.Figures;
using ChildrensTable.Colors;

namespace Tests
{
    public class FigureTests
    {
        [Fact]
        public void CheckMethod_DueFigure_1()
        {
            // Arrange
            var figure = new FilmCircule(3);
            
            // Act
            Action act = () => figure.DueFigure(Color.BLACK);

            // Assert
            Assert.Throws<PaintException>(act);
        }

        [Fact]
        public void CheckMethod_DueFigure_2()
        {
            // Arrange
            var figure = new PaperCircule(2);

            // Act
            figure.DueFigure(Color.BLUE);
            Action act = () => figure.DueFigure(Color.RED);

            // Assert
            Assert.Equal(Color.BLUE, figure.Color);
            Assert.Throws<PaintException>(act);
        }

        [Fact]
        public void CheckMethod_DueFigure_3()
        {
            // Arrange
            var figure = new PlasticCircule(1);

            // Act
            figure.DueFigure(Color.BLACK);
            figure.DueFigure(Color.WHITE);

            // Assert
            Assert.Equal(Color.WHITE, figure.Color);
        }

        [Fact]
        public void CheckMethod_GetPerimeter()
        {
            double[] sizez_for_squad = new double[4] { 3, 3, 3, 3 };
            double[] sizes_for_triangle = new double[3] { 3, 4, 5 };
            var circule = new PaperCircule(4);
            var squad = new FilmSquad(sizez_for_squad);
            var triangle = new PlasticTriangle(sizes_for_triangle);

            // Act
            double expectedPerimeterCircule = (2 * Math.PI) * 4;

            // Assert
            Assert.Equal(expectedPerimeterCircule, circule.GetPerimeter());
            Assert.Equal(12, squad.GetPerimeter());
            Assert.Equal(12, triangle.GetPerimeter());
        }

        [Fact]
        public void CheckMethod_GetSquare()
        {
            // Arrange
            double[] sizez_for_squad = new double[4] { 3, 3, 3, 3 };
            double[] sizes_for_triangle = new double[3] { 3, 4, 5 };
            var circule = new PaperCircule(4);
            var squad = new FilmSquad(sizez_for_squad);
            var triangle = new PlasticTriangle(sizes_for_triangle);

            // Act
            double expectedSquareCircule = Math.Pow(4, 2) * Math.PI;

            // Assert
            Assert.Equal(expectedSquareCircule, circule.GetSquare());
            Assert.Equal(9, squad.GetSquare());
            Assert.Equal(6, triangle.GetSquare());
        }
    }
}
