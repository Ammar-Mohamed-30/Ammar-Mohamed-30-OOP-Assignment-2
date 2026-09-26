namespace SrpLab;

public sealed class LoanDesk
{
    private readonly LoanRiskCalculator _riskCalculator = new();
    private readonly LoanDocumentProvider _documentProvider = new();
    private readonly LoanDecisionLetterFormatter _formatter = new();

    public decimal RequestedAmount { get; }
    public int CreditScore { get; }
    public int EmploymentMonths { get; }
    public bool HasCollateral { get; }

    public LoanDesk(
        decimal requestedAmount,
        int creditScore,
        int employmentMonths,
        bool hasCollateral)
    {
        RequestedAmount = requestedAmount;
        CreditScore = creditScore;
        EmploymentMonths = employmentMonths;
        HasCollateral = hasCollateral;
    }

    public decimal RiskScore()
    {
        return _riskCalculator.Calculate(
            RequestedAmount,
            CreditScore,
            EmploymentMonths,
            HasCollateral);
    }

    public bool IsEligible()
    {
        return _riskCalculator.IsEligible(
            RequestedAmount,
            CreditScore,
            EmploymentMonths,
            HasCollateral);
    }

    public IReadOnlyList<string> RequiredDocuments()
    {
        return _documentProvider.GetRequiredDocuments(
            RequestedAmount,
            EmploymentMonths,
            HasCollateral,
            IsEligible());
    }

    public string DecisionLetter(string applicantName)
    {
        return _formatter.Format(
            applicantName,
            RequestedAmount,
            RiskScore(),
            IsEligible(),
            RequiredDocuments());
    }

    public string UnderwriterCsvRow(string applicationId)
    {
        return _formatter.FormatCsvRow(
            applicationId,
            CreditScore,
            EmploymentMonths,
            HasCollateral,
            RiskScore(),
            IsEligible());
    }
}