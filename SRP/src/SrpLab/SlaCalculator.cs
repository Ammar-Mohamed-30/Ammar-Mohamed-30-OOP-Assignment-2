namespace SrpLab;

public sealed class SlaCalculator
{
    public DateTimeOffset CalculateDeadline(string priority, DateTimeOffset openedAt)
    {
        var hours = priority switch
        {
            "P1" => 4,
            "P2" => 24,
            _ => 72
        };

        return openedAt.AddHours(hours);
    }

    public bool IsBreached(
        string priority,
        DateTimeOffset openedAt,
        DateTimeOffset now)
    {
        return now > CalculateDeadline(priority, openedAt);
    }
}