namespace SrpLab;

public sealed class WarehousePickList
{
    private readonly List<(string Sku, string Aisle, int Bin, int Requested, int Available)> _needs = new();

    private readonly PickQuantityCalculator _quantityCalculator = new();
    private readonly ShortageDetector _shortageDetector = new();
    private readonly PickerScriptFormatter _formatter = new();

    public void AddNeed(
        string sku,
        string aisle,
        int bin,
        int requested,
        int available)
    {
        _needs.Add((
            sku,
            aisle,
            bin,
            requested,
            available));
    }

    public IReadOnlyList<string> GetShortages()
    {
        return _shortageDetector.Detect(_needs);
    }

    public string PickerScript()
    {
        return _formatter.Format(
            _needs,
            _quantityCalculator,
            _shortageDetector);
    }
}