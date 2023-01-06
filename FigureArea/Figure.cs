namespace FigureArea;

public class Figure
{
    public FigureType Name { get; set; }
    public double Area { get; set; }

    public Figure()
    {
        
    }

    public Figure(FigureType figureType)
    {
        Name = figureType;
    }
}