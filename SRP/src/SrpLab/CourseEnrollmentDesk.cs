namespace SrpLab;

public sealed class CourseEnrollmentDesk
{
    private readonly HashSet<string> _seated =
        new(StringComparer.OrdinalIgnoreCase);

    private readonly List<string> _waitlist = new();

    private readonly EnrollmentService _enrollment;
    private readonly WelcomePacketFormatter _welcomeFormatter = new();
    private readonly TuitionInvoiceFormatter _invoiceFormatter = new();

    public int Capacity { get; }
    public decimal Tuition { get; }
    public string CourseCode { get; }

    public CourseEnrollmentDesk(
        string courseCode,
        int capacity,
        decimal tuition)
    {
        CourseCode = courseCode;
        Capacity = capacity;
        Tuition = tuition;

        _enrollment = new EnrollmentService(
            _seated,
            _waitlist,
            Capacity);
    }

    public string Register(string studentEmail)
    {
        return _enrollment.Register(studentEmail);
    }

    public int WaitlistPosition(string studentEmail)
    {
        return _enrollment.WaitlistPosition(studentEmail);
    }

    public string WelcomePacketMarkdown(
        string studentEmail,
        string studentName)
    {
        return _welcomeFormatter.Format(
            CourseCode,
            studentEmail,
            studentName,
            _enrollment);
    }

    public string TuitionInvoiceLine(string studentEmail)
    {
        return _invoiceFormatter.Format(
            CourseCode,
            studentEmail,
            Tuition,
            _seated);
    }

    public void PromoteFromWaitlist(int seats)
    {
        _enrollment.PromoteFromWaitlist(seats);
    }
}