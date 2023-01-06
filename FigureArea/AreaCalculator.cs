
namespace FigureArea;

public class AreaCalculator
{
    public Figure GetArea(params double[] sides)
    {
        if (!CheckInputData(sides))
        {
            throw new ArgumentException("Введите корректные данные");
        }

        switch (sides.Length)
        {
            case 1:
            {
                return GetCircleArea(sides[0]);
            }

            case 3:
            {
                if (!IsValidTriangle(sides))
                {
                    throw new ArgumentException("Треугольника с такими сторонами не существует");
                }
            
                return GetTriangleArea(sides);
            }

            default:
            {
                throw new ArgumentException("Фигура неизвестна");
            }
        }
    }

    private bool CheckInputData(double[] sides)
    {
        return sides.Length != 0
               && sides.All(x => x > 0);
    }

    private bool IsValidTriangle(double[] sides)
    {
        return sides[0] + sides[1] > sides[2] &&
               sides[0] + sides[2] > sides[1] &&
               sides[1] + sides[2] > sides[0];
    }

    private Figure GetTriangleArea(params double[] sides)
    {
        Figure triangle = new();
        double area;
        if (HasRightAngle(sides))
        {
            area = sides[..2].Aggregate((a, b) => a * b) / 2;
            triangle.Name = FigureType.RightTriangle;
        }

        else
        {
            double halfPerimeter = sides.Sum() / 2;
            area = Math.Sqrt(halfPerimeter * (halfPerimeter - sides[0])
                                           * (halfPerimeter - sides[1])
                                           * (halfPerimeter - sides[2]));
            triangle.Name = FigureType.Triangle;
        }

        triangle.Area = RoundResult(area);
        return triangle;
    }

    private bool HasRightAngle(double[] sides)
    {
        sides = sides.OrderBy(x => x).ToArray();
        return  sides.Last() == Math.Sqrt(sides[..2].Select(x => Math.Pow(x, 2)).Sum());
    }

    private Figure GetCircleArea(double radius)
    {
        Figure circle = new();
        circle.Name = FigureType.Circle;
        
        double area = Math.PI * Math.Pow(radius, 2);
        circle.Area = RoundResult(area);
        return circle;
    }

    private double RoundResult(double area)
    {
        return Math.Round(area, 3);
    }
}