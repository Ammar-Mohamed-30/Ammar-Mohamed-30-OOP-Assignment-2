namespace SrpLab;

public sealed class WardRegistry
{
    private readonly Dictionary<int, string> _bedPatient = new();
    private readonly Dictionary<int, int> _acuityScores = new();

public void AssignBed(int bed, string patientId, int acuity)
    {
        if (bed <= 0)
            throw new ArgumentOutOfRangeException(nameof(bed));

        if (string.IsNullOrWhiteSpace(patientId))
            throw new ArgumentException("patient required");

        _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
        _acuityScores[bed] = acuity;
    }

    public bool TryGetBed(int bed, out string patient)
    {
        return _bedPatient.TryGetValue(bed, out patient!);
    }

    public int GetAcuity(int bed)
    {
        return _acuityScores[bed];
    }

    public IReadOnlyDictionary<int, string> BedPatients => _bedPatient;
    public IReadOnlyDictionary<int, int> AcuityScores => _acuityScores;

}
