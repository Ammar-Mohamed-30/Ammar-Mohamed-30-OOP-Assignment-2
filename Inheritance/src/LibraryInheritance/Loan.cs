namespace LibraryInheritance;

public class Loan
{
    public string LoanId { get; }
    public DateTime BorrowDate { get; }
    public Member Member { get; }
    public LibraryItem Item { get; }

    public DateTime DueDate => BorrowDate.AddDays(Item.LoanPeriodDays);

    public LoanStatus Status { get; private set; }

    public DateTime? ReturnDate { get; private set; }

    public decimal LateFee
    {
        get
        {
            if (!ReturnDate.HasValue || ReturnDate.Value <= DueDate)
                return 0m;

            int lateDays = (ReturnDate.Value.Date - DueDate.Date).Days;

            decimal feeBeforeDiscount = lateDays * Item.DailyLateFee;
            decimal discount = feeBeforeDiscount * Member.DiscountPercentage / 100m;

            return feeBeforeDiscount - discount;
        }
    }

    public Loan(
        string loanId,
        DateTime borrowDate,
        Member member,
        LibraryItem item)
    {
        if (string.IsNullOrWhiteSpace(loanId))
            throw new ArgumentException("Loan ID cannot be empty.");

        LoanId = loanId;
        BorrowDate = borrowDate;
        Member = member;
        Item = item;
        Status = LoanStatus.Borrowed;
    }

    public void Return(DateTime returnDate)
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Only a borrowed loan can be returned.");

        if (returnDate < BorrowDate)
            throw new ArgumentException("Return date cannot be earlier than borrow date.");

        ReturnDate = returnDate;
        Status = LoanStatus.Returned;

        Item.MarkAsReturned();
        Member.RecordReturnedLoan();
    }

    public void MarkAsLost()
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException("Only a borrowed loan can be marked as lost.");

        Status = LoanStatus.Lost;
        Item.MarkAsReturned();
    }
}