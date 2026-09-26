namespace SrpLab;

public sealed class AppointmentDesk
{
    private readonly HashSet<DateTimeOffset> _booked = new();

    private readonly AppointmentSlotCalculator _slotCalculator;
    private readonly AppointmentBookingService _bookingService;
    private readonly SmsReminderFormatter _smsFormatter = new();

    public TimeOnly Open { get; }
    public TimeOnly Close { get; }
    public int DurationMinutes { get; }

    public AppointmentDesk(
        TimeOnly open,
        TimeOnly close,
        int durationMinutes)
    {
        Open = open;
        Close = close;
        DurationMinutes = durationMinutes;

        _slotCalculator = new AppointmentSlotCalculator();

        _bookingService =
            new AppointmentBookingService(_booked);
    }

    public DateTimeOffset? FindNextSlot(
        DateTimeOffset from,
        int horizonHours)
    {
        return _slotCalculator.FindNextSlot(
            from,
            Open,
            Close,
            DurationMinutes,
            horizonHours,
            _booked);
    }

    public void TryBook(DateTimeOffset slot)
    {
        _bookingService.Book(slot);
    }

    public string SmsReminder(
        DateTimeOffset slot,
        string phone)
    {
        return _smsFormatter.Format(
            slot,
            phone);
    }
}