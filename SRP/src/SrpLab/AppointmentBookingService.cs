namespace SrpLab;

public sealed class AppointmentBookingService
{
    private readonly HashSet<DateTimeOffset> _booked;

    public AppointmentBookingService(
        HashSet<DateTimeOffset> booked)
    {
        _booked = booked;
    }

    public void Book(DateTimeOffset slot)
    {
        if (!_booked.Add(slot))
            throw new InvalidOperationException(
                "Slot already booked.");
    }

    public bool IsBooked(DateTimeOffset slot)
    {
        return _booked.Contains(slot);
    }
}