namespace SrpLab;

public sealed class WardCensusExporter
{
    public string Export(
    IReadOnlyDictionary<int, string> bedPatient,
    IReadOnlyDictionary<int, int> acuityScores)
    {
        var lines = new List<string> { "bed,patient,acuity" };

    foreach (var bed in bedPatient.Keys.OrderBy(x => x))
        {
            lines.Add($"{bed},{bedPatient[bed]},{acuityScores[bed]}");
        }

        return string.Join('\n', lines);
    }

}
