namespace SrpLab;

public sealed class KitchenTicketFormatter
{
    public string Format(
        IEnumerable<(string Item, List<string> Ingredients, int PrepMinutes)> items,
        int orderNumber,
        int eta,
        IReadOnlyList<string> allergens)
    {
        var width = 32;
        var line = new string('=', width);

        var body = string.Join(
            '\n',
            items.Select(i =>
                $"* {i.Item.ToUpperInvariant()} ({i.PrepMinutes}m)"));

        var allergyLine = allergens.Count == 0
            ? "ALLERGENS: none"
            : "ALLERGENS: " + string.Join(",", allergens);

        return $"{line}\n" +
               $"ORDER #{orderNumber}\n" +
               $"ETA {eta} MIN\n" +
               $"{body}\n" +
               $"{allergyLine}\n" +
               $"{line}\n";
    }

    public string ExpoLaneHint(
        IReadOnlyList<string> allergens,
        int eta)
    {
        if (allergens.Count > 0)
            return "LANE-ALLERGY";

        return eta > 20
            ? "LANE-SLOW"
            : "LANE-FAST";
    }
}