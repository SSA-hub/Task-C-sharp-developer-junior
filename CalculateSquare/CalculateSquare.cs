namespace CalculateSquare;

public class CalculateSquare
{
    private readonly Dictionary<string, Func<List<double>, double>> _squareFunctions =
        new()
        {
            { "Circle", list => list.Count == 1 ? Math.PI * list.First() * list.First() : -1 },
            {
                "Triangle",
                list => list.Count == 3
                    ? Math.Sqrt(list.Sum() / 2 * (list.Sum() / 2 - list[0]) * (list.Sum() / 2 - list[1]) *
                                (list.Sum() / 2 - list[2]))
                    : -1
            }
        };

    public static double CalculateSquareWithoutFigureName(List<double> info)
    {
        return info.Count switch
        {
            1 => Math.PI * info.First() * info.First(),
            3 => Math.Sqrt(info.Sum() / 2 * (info.Sum() / 2 - info[0]) * (info.Sum() / 2 - info[1]) *
                           (info.Sum() / 2 - info[2])),
            _ => -1
        };
    }

    public static bool IsTriangleRectangular(IReadOnlyList<double> sides)
    {
        var flag = false;
        for (var i = 0; i < 3; i++)
        for (var j = 0; j < 3; j++)
        for (var k = 0; k < 3; k++)
            if (j != i && k != i && k != j)
            {
                flag = flag || Math.Abs(sides[i] * sides[i] + sides[j] * sides[j] - sides[k] * sides[k]) == 0;
                if (flag) return flag;
            }

        return flag;
    }

    public bool AddFigure(string figureName, Func<List<double>, double> squareFunction)
    {
        return _squareFunctions.TryAdd(figureName, squareFunction);
    }

    public double CalculateFigureSquare(string figureName, List<double> figureInfo)
    {
        _squareFunctions.TryGetValue(figureName, out var squareFunction);
        if (squareFunction != null) return squareFunction(figureInfo);
        return -2;
    }
}