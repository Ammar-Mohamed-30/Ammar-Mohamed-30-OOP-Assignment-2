namespace SrpLab;

public sealed class GradeCalculator
{
    public double Average(IEnumerable<int> grades)
    {
        var list = grades.ToList();

        if (list.Count == 0)
            return 0;

        return list.Average();
    }

    public string Letter(double average)
    {
        return average switch
        {
            >= 90 => "A",
            >= 80 => "B",
            >= 70 => "C",
            >= 60 => "D",
            _ => "F"
        };
    }
}