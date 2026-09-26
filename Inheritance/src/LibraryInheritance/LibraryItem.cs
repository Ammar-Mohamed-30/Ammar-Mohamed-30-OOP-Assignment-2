namespace LibraryInheritance;

public class LibraryItem
{
    public string CatalogNumber { get; }
    public string Title { get; }

    public decimal BaseLateFee { get; private set; }

    public bool IsWithdrawn { get; private set; }

    public bool IsOnLoan { get; private set; }

    public int LoanPeriodDays { get; }

    private decimal FeeMultiplier { get; }

    protected LibraryItem(
        string catalogNumber,
        string title,
        decimal baseLateFee,
        int loanPeriodDays,
        decimal feeMultiplier)
    {
        if (string.IsNullOrWhiteSpace(catalogNumber))
            throw new ArgumentException("Catalog number cannot be empty.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        if (baseLateFee <= 0)
            throw new ArgumentException("Late fee must be greater than zero.");

        CatalogNumber = catalogNumber;
        Title = title;
        BaseLateFee = baseLateFee;
        LoanPeriodDays = loanPeriodDays;
        FeeMultiplier = feeMultiplier;
    }

    public decimal DailyLateFee => BaseLateFee * FeeMultiplier;

    public void ChangeLateFee(decimal newFee)
    {
        if (newFee <= 0)
            throw new ArgumentException("Late fee must be greater than zero.");

        BaseLateFee = newFee;
    }

    public void Withdraw()
    {
        IsWithdrawn = true;
    }

    public void Restore()
    {
        IsWithdrawn = false;
    }

    internal void MarkAsBorrowed()
    {
        IsOnLoan = true;
    }

    internal void MarkAsReturned()
    {
        IsOnLoan = false;
    }
}