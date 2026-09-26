namespace SrpLab;

public sealed class AppointmentSlotCalculator
{
    public DateTimeOffset? FindNextSlot(
        DateTimeOffset from,
        TimeOnly open,
        TimeOnly close,
        int durationMinutes,
        int horizonHours,
        IReadOnlySet<DateTimeOffset> booked)
    {
        var end = from.AddHours(horizonHours);
        var current = from;

        while (current <= end)
        {
            var localTime = TimeOnly.FromDateTime(current.DateTime);

            if (localTime < open)
            {
                var dateTime = current.Date.Add(open.ToTimeSpan());

                current = new DateTimeOffset(
                    dateTime,
                    current.Offset);
            }

            var slotEnd = current.AddMinutes(durationMinutes);

            var slotStartTime =
                TimeOnly.FromDateTime(current.DateTime);

            var slotEndTime =
                TimeOnly.FromDateTime(slotEnd.DateTime);

            if (slotStartTime >= open &&
                slotEndTime <= close &&
                !booked.Contains(current))
            {
                return current;
            }

            current = current.AddMinutes(durationMinutes);
        }

        return null;
    }
}