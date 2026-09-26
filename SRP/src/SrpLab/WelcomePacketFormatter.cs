namespace SrpLab;

public sealed class WelcomePacketFormatter
{
    public string Format(
        string courseCode,
        string studentEmail,
        string studentName,
        EnrollmentService enrollment)
    {
        var status = enrollment.WaitlistPosition(studentEmail) > 0
            ? $"waitlist #{enrollment.WaitlistPosition(studentEmail)}"
            : "confirmed seat";

        return $"# Welcome to {courseCode}\n" +
               $"Hi {studentName},\n" +
               $"Your status: **{status}**.\n" +
               $"Bring a laptop. Discord onboarding link: " +
               $"https://example.invalid/{courseCode.ToLowerInvariant()}\n";
    }
}