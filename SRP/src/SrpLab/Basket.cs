namespace SrpLab;

public sealed class Basket
{
    private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();

    public void AddLine(string sku, decimal price, int qty)
    {
        if (qty <= 0)
            throw new ArgumentOutOfRangeException(nameof(qty));

        _lines.Add((sku, price, qty));
    }

    public IReadOnlyList<(string Sku, decimal Price, int Qty)> Lines => _lines;
}