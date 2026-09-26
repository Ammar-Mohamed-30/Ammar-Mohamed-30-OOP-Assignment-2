namespace SrpLab;

public sealed class SupportReplyFormatter
{
    public string Format(
        string ticketId,
        string priority,
        string agentName,
        DateTimeOffset slaDeadline)
    {
        var message = priority == "P1"
            ? "We are treating this as a critical incident."
            : "Thanks for reaching out.";

        return $"Hi,\n{message}\n" +
               $"Ticket {ticketId} is with {agentName}. " +
               $"Next update before {slaDeadline:u}.\n";
    }

    public string FormatInternalEscalation(
        string ticketId,
        string priority,
        DateTimeOffset slaDeadline)
    {
        return $"ESCALATE {ticketId} priority={priority} " +
               $"breachAt={slaDeadline:u} keywords-scanned=yes";
    }
}