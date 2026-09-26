namespace SrpLab;

public sealed class BillingMessageFormatter
{
    public string DunningEmail(
        string customerName,
        DateOnly asOf,
        decimal amount,
        string invoice,
        int failedPayments)
    {
        var severity = failedPayments switch
        {
            <= 1 => "friendly reminder",
            2 => "second notice",
            _ => "final notice before suspension"
        };

        return $"Subject: {severity} {invoice}\n" +
               $"Hi {customerName},\n" +
               $"Balance {amount:C} as of {asOf:o} ({failedPayments} failures).\n";
    }

    public string LedgerJournalLine(
        string customerId,
        string invoice,
        decimal amount)
    {
        return $"{customerId},{invoice},{amount:0.00},AR-SUB";
    }
}