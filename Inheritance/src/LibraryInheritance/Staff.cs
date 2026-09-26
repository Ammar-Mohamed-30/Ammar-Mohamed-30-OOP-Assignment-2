namespace LibraryInheritance;

public class Staff : Person
{
    public DateTime HireDate { get; }

    public decimal MonthlySalary { get; private set; }

    private decimal ResponsibilityAllowance { get; }

    protected Staff(
        string personId,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary,
        decimal responsibilityAllowance)
        : base(personId, fullName, phone)
    {
        HireDate = hireDate;
        MonthlySalary = monthlySalary;
        ResponsibilityAllowance = responsibilityAllowance;
    }

    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0)
            throw new ArgumentException("Raise percentage must be greater than zero.");

        MonthlySalary += MonthlySalary * percentage / 100m;
    }

    public decimal MonthlyPay => MonthlySalary + ResponsibilityAllowance;
}