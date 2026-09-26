namespace SrpLab;

public sealed class EnrollmentService
{
    private readonly HashSet<string> _seated;
    private readonly List<string> _waitlist;
    private readonly int _capacity;

    public EnrollmentService(
        HashSet<string> seated,
        List<string> waitlist,
        int capacity)
    {
        _seated = seated;
        _waitlist = waitlist;
        _capacity = capacity;
    }

    public string Register(string studentEmail)
    {
        if (string.IsNullOrWhiteSpace(studentEmail))
            throw new ArgumentException("email");

        var email = studentEmail.Trim();

        if (_seated.Contains(email) || _waitlist.Contains(email))
            return "ALREADY_REGISTERED";

        if (_seated.Count < _capacity)
        {
            _seated.Add(email);
            return "SEATED";
        }

        _waitlist.Add(email);
        return $"WAITLIST:{_waitlist.Count}";
    }

    public int WaitlistPosition(string studentEmail)
    {
        var idx = _waitlist.FindIndex(
            x => x.Equals(studentEmail, StringComparison.OrdinalIgnoreCase));

        return idx < 0 ? -1 : idx + 1;
    }

    public void PromoteFromWaitlist(int seats)
    {
        while (seats > 0 &&
               _waitlist.Count > 0 &&
               _seated.Count < _capacity)
        {
            var next = _waitlist[0];
            _waitlist.RemoveAt(0);
            _seated.Add(next);
            seats--;
        }
    }
}