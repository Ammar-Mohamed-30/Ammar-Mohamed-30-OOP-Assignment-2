namespace SrpLab;

public sealed class ShortageDetector
{
    public IReadOnlyList<string> Detect(
        IEnumerable<(string Sku, string Aisle, int Bin, int Requested, int Available)> needs)
    {
        return needs
            .Where(x => x.Requested > x.Available)
            .Select(x => x.Sku)
            .ToList();
    }
}