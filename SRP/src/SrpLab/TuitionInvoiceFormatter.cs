namespace SrpLab;

public sealed class TuitionInvoiceFormatter
{
    public string Format(
        string courseCode,
        string studentEmail,
        decimal tuition,
        HashSet<string> seated)
    {
        if (!seated.Contains(studentEmail))
            return $"{courseCode},WAITLIST,0.00";

        var vat = Math.Round(tuition * 0.14m, 2);
        var total = tuition + vat;

        return $"{courseCode},TUITION,{tuition:0.00},VAT,{vat:0.00},TOTAL,{total:0.00}";
    }
}