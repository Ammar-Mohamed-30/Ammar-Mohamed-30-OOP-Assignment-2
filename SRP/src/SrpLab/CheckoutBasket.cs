namespace SrpLab;

public sealed class CheckoutBasket
{
    private readonly Basket _basket = new();
    private readonly CouponDiscountCalculator _couponCalculator = new();
    private readonly BasketTotalCalculator _totalCalculator = new();
    private readonly GiftMessageFormatter _giftFormatter = new();
    private readonly PaymentAuthorizationService _paymentService = new();

    private string? _couponRaw;
    private bool _giftWrap;

    public void AddLine(string sku, decimal price, int qty)
    {
        _basket.AddLine(sku, price, qty);
    }

    public void ApplyCouponText(string? couponText)
    {
        _couponRaw = couponText;
    }

    public void EnableGiftWrap()
    {
        _giftWrap = true;
    }

    public decimal SubTotal()
    {
        return _basket.Lines.Sum(l => l.Price * l.Qty);
    }

    public decimal DiscountAmount()
    {
        return _couponCalculator.Calculate(_basket, _couponRaw);
    }

    public decimal GrandTotal()
    {
        return _totalCalculator.Calculate(
            _basket,
            DiscountAmount(),
            _giftWrap);
    }

    public string GiftMessageCard(string fromName)
    {
        return _giftFormatter.Format(
            _basket,
            fromName,
            GrandTotal());
    }

    public string AuthorizePaymentStub(string cardLast4)
    {
        return _paymentService.Authorize(
            _basket,
            GrandTotal(),
            cardLast4);
    }
}