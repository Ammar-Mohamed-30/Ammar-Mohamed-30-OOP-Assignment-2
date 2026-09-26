namespace SrpLab;

public sealed class TranscriptFormatter
{
    public string Format(
        string studentId,
        string studentName,
        double average,
        string letter,
        bool honor)
    {
        return $"TRANSCRIPT\n" +
               $"Student: {studentName} ({studentId})\n" +
               $"Average: {average:0.##}\n" +
               $"Letter: {letter}\n" +
               $"Honor: {honor}";
    }
}