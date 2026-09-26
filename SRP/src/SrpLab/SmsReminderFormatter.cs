namespace SrpLab;

public sealed class SmsReminderFormatter
{
    public string Format(
        DateTimeOffset slot,
        string phone)
    {
        return $"Reminder: appointment at {slot:u}. " +
               $"Reply YES to confirm. Phone: {phone}";
    }
}