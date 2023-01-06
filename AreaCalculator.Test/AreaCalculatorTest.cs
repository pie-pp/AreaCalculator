using FigureArea;

namespace AreaCalculator.Test;

public class AreaCalculatorTest
{
    private FigureArea.AreaCalculator _calculator;
    
    [SetUp]
    public void Setup()
    {
        _calculator = new FigureArea.AreaCalculator();
    }

    [Test]
    public void GetArea_InvalidInputData()
    {
        ArgumentException? invalidTriangle = Assert.Throws<ArgumentException>(() =>
            _calculator.GetArea(-1));
        Assert.That(invalidTriangle?.Message, Is.EqualTo("Введите корректные данные"));
    }

    [Test]
    public void GetTriangleArea_InvalidTriangle()
    {
        ArgumentException? invalidTriangle = Assert.Throws<ArgumentException>(() => 
            _calculator.GetArea(10, 2, 3));
        Assert.That(invalidTriangle?.Message, Is.EqualTo("Треугольника с такими сторонами не существует"));
    }

    [Test]
    public void GetArea_InvalidFigure()
    {
        ArgumentException? invalidTriangle = Assert.Throws<ArgumentException>(() =>
            _calculator.GetArea(10, 2));
        Assert.That(invalidTriangle?.Message, Is.EqualTo("Фигура неизвестна"));
    }
    
    
    [Test]
    public void GetTriangleArea_EmptyInputData()
    {
        ArgumentException? invalidTriangle = Assert.Throws<ArgumentException>(() =>
            _calculator.GetArea());
        Assert.That(invalidTriangle?.Message, Is.EqualTo("Введите корректные данные"));
    }
    
    [Test]
    public void GetTriangleArea_GetArea()
    {
        Figure triangle = _calculator.GetArea(10, 2, 11);
        Assert.That(triangle.Area, Is.EqualTo(9.052));
    }
    
    [Test]
    public void GetTriangleArea_TriangleType()
    {
        Figure triangle = _calculator.GetArea(10, 2, 11);
        Assert.That(triangle.Name, Is.EqualTo(FigureType.Triangle));
    }

    [Test]
    public void GetTriangleArea_RightAngle()
    {
        Figure triangle = _calculator.GetArea(3, 4, 5);
        Assert.That(triangle.Area, Is.EqualTo(6));
    }
    
    [Test]
    public void GetTriangleArea_RightTriangleType()
    {
        Figure triangle = _calculator.GetArea(3, 4, 5);
        Assert.That(triangle.Name, Is.EqualTo(FigureType.RightTriangle));
    }

    [Test]
    public void GetCircleArea_GetArea()
    {
        Figure circle = _calculator.GetArea(3);
        Assert.That(circle.Area, Is.EqualTo(28.274));
    }
    
    [Test]
    public void GetCircleArea_CircleType()
    {
        Figure circle = _calculator.GetArea(3);
        Assert.That(circle.Name, Is.EqualTo(FigureType.Circle));
    }
}