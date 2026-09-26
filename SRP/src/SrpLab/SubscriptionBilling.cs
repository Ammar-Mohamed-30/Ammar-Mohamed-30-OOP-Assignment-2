namespace SrpLab;

public sealed class SubscriptionBilling
{
    private readonly ProrationCalculator _prorationCalculator = new();
    private readonly InvoiceNumberGenerator _invoiceGenerator = new();
    private readonly BillingMessageFormatter _formatter = new();

    public string CustomerId { get; }
    public decimal MonthlyPrice { get; }
    public DateOnly PeriodStart { get; }
    public DateOnly PeriodEnd { get; }
    public int FailedPayments { get; private set; }

    public SubscriptionBilling(
        string customerId,
        decimal monthlyPrice,
        DateOnly periodStart,
        DateOnly periodEnd)
    {
        CustomerId = customerId;
        MonthlyPrice = monthlyPrice;
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
    }

    public decimal Prorate(DateOnly activeFrom)
    {
        return _prorationCalculator.Calculate(
            MonthlyPrice,
            PeriodStart,
            PeriodEnd,
            activeFrom);
    }

    public string NextInvoiceNumber()
    {
        return _invoiceGenerator.Generate(PeriodStart);
    }

    public void RegisterFailedPayment()
    {
        FailedPayments++;
    }

    public string DunningEmail(
        string customerName,
        DateOnly asOf)
    {
        var amount = Prorate(PeriodStart);
        var invoice = NextInvoiceNumber();

        return _formatter.DunningEmail(
            customerName,
            asOf,
            amount,
            invoice,
            FailedPayments);
    }

    public string LedgerJournalLine(DateOnly activeFrom)
    {
        var invoice = NextInvoiceNumber();
        var amount = Prorate(activeFrom);

        return _formatter.LedgerJournalLine(
            CustomerId,
            invoice,
            amount);
    }
}