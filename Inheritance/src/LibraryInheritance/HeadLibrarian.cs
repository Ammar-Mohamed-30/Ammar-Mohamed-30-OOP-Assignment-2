namespace LibraryInheritance;

public class HeadLibrarian : Staff
{
    public HeadLibrarian(
        string personId,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary)
        : base(personId, fullName, phone, hireDate, monthlySalary, 400m)
    {
    }

    public void ChangeLateFee(LibraryItem item, decimal newFee)
    {
        item.ChangeLateFee(newFee);
    }

    public void Withdraw(LibraryItem item)
    {
        item.Withdraw();
    }

    public void Restore(LibraryItem item)
    {
        item.Restore();
    }
}
