namespace SrpLab;

public sealed class PickerScriptFormatter
{
    public string Format(
        IEnumerable<(string Sku, string Aisle, int Bin, int Requested, int Available)> needs,
        PickQuantityCalculator calculator,
        ShortageDetector shortageDetector)
    {
        var list = needs.ToList();

        var lines = list.Select(x =>
        {
            var pick = calculator.CalculatePickQuantity(
                x.Requested,
                x.Available);

            return $"{list.IndexOf(x) + 1}. " +
                   $"Go aisle {x.Aisle} bin {x.Bin}: " +
                   $"pick {pick} × {x.Sku}";
        }).ToList();

        var shortages = shortageDetector.Detect(list);

        if (shortages.Count > 0)
            lines.Add("SHORTAGES: " + string.Join(",", shortages));

        return string.Join(Environment.NewLine, lines);
    }
}