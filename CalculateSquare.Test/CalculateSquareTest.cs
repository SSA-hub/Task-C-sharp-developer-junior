using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CalculateSquare.Test;

public class CalculateSquareTest
{
    [Fact]
    public void CircleTest()
    {
        var cs = new CalculateSquare();

        var s = cs.CalculateFigureSquare("Circle", new List<double> { 3 });

        Assert.Equal(Math.PI * 9, s);
    }

    [Fact]
    public void TriangleTest()
    {
        var cs = new CalculateSquare();

        var s = cs.CalculateFigureSquare("Triangle", new List<double> { 3, 4, 5 });

        Assert.Equal(6, s);
    }

    [Theory]
    [InlineData("Circle")]
    [InlineData("Circle", 1, 2)]
    [InlineData("Triangle", 3, 4)]
    [InlineData("Triangle", 1, 2, 3, 4)]
    public void InfoCountError(string figureName, params double[] figureInfo)
    {
        var cs = new CalculateSquare();

        var s = cs.CalculateFigureSquare(figureName, figureInfo.ToList());

        Assert.Equal(-1, s);
    }

    [Fact]
    public void AddNewFigureTest()
    {
        var cs = new CalculateSquare();

        var result = cs.AddFigure("Rectangle", list => list.Count == 2 ? list[0] * list[1] : -1);
        Assert.True(result);
        var s = cs.CalculateFigureSquare("Rectangle", new List<double> { 2, 3 });

        Assert.Equal(6, s);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(-1, 1, 2)]
    [InlineData(6, 3, 4, 5)]
    [InlineData(-1, 1, 2, 3, 4)]
    public void CalculateSquareWithoutFigureNameTest(double expectedAns, params double[] info)
    {
        var s = CalculateSquare.CalculateSquareWithoutFigureName(info.ToList());

        Assert.Equal(expectedAns, s);
    }

    [Theory]
    [InlineData(true, 3, 4, 5)]
    [InlineData(true, 3, 5, 4)]
    [InlineData(false, 3, 5, 7)]
    public void IsTriangleRectangular(bool expectedAns, params double[] info)
    {
        var result = CalculateSquare.IsTriangleRectangular(info.ToList());

        Assert.Equal(expectedAns, result);
    }
}