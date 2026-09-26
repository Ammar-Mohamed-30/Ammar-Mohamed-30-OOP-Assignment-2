namespace SrpLab;

public sealed class LoanDecisionLetterFormatter
{
    public string Format(
        string applicantName,
        decimal requestedAmount,
        decimal riskScore,
        bool isEligible,
        IReadOnlyList<string> documents)
    {
        if (isEligible)
        {
            return $"Dear {applicantName},\n" +
                   $"Your request for {requestedAmount:C} is pre-approved (risk {riskScore:0}).\n" +
                   $"Please upload: {string.Join("; ", documents)}.\n";
        }

        return $"Dear {applicantName},\n" +
               $"We are unable to approve {requestedAmount:C} at this time.\n" +
               $"Reference risk={riskScore:0}. You may reapply after improving documentation.\n";
    }

    public string FormatCsvRow(
        string applicationId,
        int creditScore,
        int employmentMonths,
        bool hasCollateral,
        decimal riskScore,
        bool isEligible)
    {
        return $"{applicationId}," +
               $"{creditScore}," +
               $"{employmentMonths}," +
               $"{(hasCollateral ? 1 : 0)}," +
               $"{riskScore:0.00}," +
               $"{(isEligible ? "Y" : "N")}";
    }
}