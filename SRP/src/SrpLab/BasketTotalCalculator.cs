namespace SrpLab;

public sealed class BasketTotalCalculator
{
    public decimal Calculate(Basket basket, decimal discount, bool giftWrap)
    {
        var subtotal = basket.Lines.Sum(l => l.Price * l.Qty);

        var total = subtotal - discount;

        if (giftWrap)
            total += 4.99m;

        return Math.Max(0m, total);
    }
}