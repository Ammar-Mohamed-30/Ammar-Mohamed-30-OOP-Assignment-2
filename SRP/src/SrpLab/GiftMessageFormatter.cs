namespace SrpLab;

public sealed class GiftMessageFormatter
{
    public string Format(Basket basket, string fromName, decimal grandTotal)
    {
        var items = string.Join(", ", basket.Lines.Select(l => l.Sku));

        return $"Dear friend,\n" +
               $"A gift from {fromName} awaits ({items}).\n" +
               $"Total surprise value: {grandTotal:C}\n";
    }
}