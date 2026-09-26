namespace SrpLab;

public sealed class KitchenTicket
{
    private readonly List<(string Item, List<string> Ingredients, int PrepMinutes)> _items = new();

    private readonly AllergenDetector _allergenDetector = new();
    private readonly KitchenEtaCalculator _etaCalculator;
    private readonly KitchenTicketFormatter _formatter = new();

    public KitchenTicket()
    {
        _etaCalculator = new KitchenEtaCalculator(_allergenDetector);
    }

    public void AddItem(
        string item,
        IEnumerable<string> ingredients,
        int prepMinutes)
    {
        _items.Add((
            item,
            ingredients
                .Select(i => i.Trim().ToLowerInvariant())
                .ToList(),
            prepMinutes));
    }

    public IReadOnlyList<string> DetectAllergens()
    {
        return _allergenDetector.Detect(
            _items.Select(i => i.Ingredients));
    }

    public int EstimatedReadyMinutes(int openStations)
    {
        return _etaCalculator.Calculate(
            _items,
            openStations);
    }

    public string RenderThermalTicket(int orderNumber)
    {
        return _formatter.Format(
            _items,
            orderNumber,
            EstimatedReadyMinutes(2),
            DetectAllergens());
    }

    public string ExpoLaneHint()
    {
        return _formatter.ExpoLaneHint(
            DetectAllergens(),
            EstimatedReadyMinutes(2));
    }
}