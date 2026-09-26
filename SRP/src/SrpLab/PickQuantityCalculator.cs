namespace SrpLab;

public sealed class PickQuantityCalculator
{
    public int CalculatePickQuantity(
        int requested,
        int available)
    {
        return Math.Min(requested, Math.Max(available, 0));
    }

    public int CalculateShortage(
        int requested,
        int available)
    {
        return Math.Max(0, requested - available);
    }
}