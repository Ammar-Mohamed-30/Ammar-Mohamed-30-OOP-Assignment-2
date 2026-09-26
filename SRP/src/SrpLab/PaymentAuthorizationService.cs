namespace SrpLab;

public sealed class PaymentAuthorizationService
{
    public string Authorize(Basket basket, decimal grandTotal, string cardLast4)
    {
        var payload = $"{grandTotal:0.00}|{cardLast4}|{basket.Lines.Count}";
        var hash = payload.GetHashCode();

        return $"AUTH-{Math.Abs(hash):X8}";
    }
}   