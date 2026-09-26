namespace LibraryInheritance;

public class Member : Person
{
    private readonly List<Loan> _loans = new();

    public IReadOnlyList<Loan> Loans => _loans;

    public int MaxLoans { get; }

    public decimal DiscountPercentage { get; }

    protected int ReadingPointsValue { get; private set; }

    protected int PointsPerReturnedLoan { get; }

    protected Member(
        string personId,
        string fullName,
        string phone,
        int maxLoans,
        decimal discountPercentage,
        int pointsPerReturnedLoan)
        : base(personId, fullName, phone)
    {
        MaxLoans = maxLoans;
        DiscountPercentage = discountPercentage;
        PointsPerReturnedLoan = pointsPerReturnedLoan;
    }

    public Loan Borrow(
        LibraryItem item,
        string loanId,
        DateTime borrowDate)
    {
        int activeLoans = 0;

        foreach (Loan existingLoan in _loans)
        {
            if (existingLoan.Status == LoanStatus.Borrowed)
            {
                activeLoans++;
            }
        }

        if (activeLoans >= MaxLoans)
            throw new InvalidOperationException(
                "Member has reached the maximum number of active loans.");

        if (item.IsWithdrawn)
            throw new InvalidOperationException(
                "A withdrawn item cannot be borrowed.");

        if (item.IsOnLoan)
            throw new InvalidOperationException(
                "The item is already on loan.");

        Loan newLoan = new Loan(
            loanId,
            borrowDate,
            this,
            item);

        _loans.Add(newLoan);
        item.MarkAsBorrowed();

        return newLoan;
    }

    internal void RecordReturnedLoan()
    {
        ReadingPointsValue += PointsPerReturnedLoan;
    }
}