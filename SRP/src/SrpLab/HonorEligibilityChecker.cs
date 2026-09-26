namespace SrpLab;

public sealed class HonorEligibilityChecker
{
    public bool IsHonor(IEnumerable<int> grades)
    {
        var list = grades.ToList();

        return list.Count > 0 &&
               list.Average() >= 90 &&
               list.All(g => g >= 85);
    }
}