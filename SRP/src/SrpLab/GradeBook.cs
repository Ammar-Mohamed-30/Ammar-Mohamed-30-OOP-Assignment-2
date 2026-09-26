namespace SrpLab;

public sealed class GradeBook
{
    private readonly Dictionary<string, List<int>> _grades = new();

    private readonly GradeCalculator _calculator = new();
    private readonly HonorEligibilityChecker _honorChecker = new();
    private readonly TranscriptFormatter _formatter = new();

    public void Record(string studentId, int grade)
    {
        if (!_grades.TryGetValue(studentId, out var list))
        {
            list = new List<int>();
            _grades[studentId] = list;
        }

        list.Add(grade);
    }

    public double Average(string studentId)
    {
        return _calculator.Average(GetGrades(studentId));
    }

    public string Letter(string studentId)
    {
        return _calculator.Letter(
            Average(studentId));
    }

    public bool IsHonor(string studentId)
    {
        return _honorChecker.IsHonor(
            GetGrades(studentId));
    }

    public string TranscriptPlain(
        string studentId,
        string studentName)
    {
        var average = Average(studentId);
        var letter = _calculator.Letter(average);
        var honor = IsHonor(studentId);

        return _formatter.Format(
            studentId,
            studentName,
            average,
            letter,
            honor);
    }

    private IReadOnlyList<int> GetGrades(string studentId)
    {
        return _grades.TryGetValue(studentId, out var list)
            ? list
            : Array.Empty<int>();
    }
}