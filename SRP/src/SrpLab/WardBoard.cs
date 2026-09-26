namespace SrpLab;

public sealed class WardBoard
{
    private readonly WardRegistry _registry = new();
    private readonly AcuityCalculator _acuityCalculator = new();
    private readonly PagerAlertService _pagerAlertService = new();
    private readonly HandoffNoteFormatter _handoffFormatter = new();
    private readonly WardCensusExporter _censusExporter = new();

public void AssignBed(int bed, string patientId, int heartRate, int spo2)
    {
        var acuity = _acuityCalculator.Calculate(heartRate, spo2);

        _registry.AssignBed(bed, patientId, acuity);
        _pagerAlertService.CheckAndLog(bed, acuity);
    }

    public int ScoreAcuity(int heartRate, int spo2)
    {
        return _acuityCalculator.Calculate(heartRate, spo2);
    }

    public string BuildHandoffNote(int bed)
    {
        if (!_registry.TryGetBed(bed, out var patient))
            return $"Bed {bed}: empty";

        var acuity = _registry.GetAcuity(bed);

        return _handoffFormatter.Format(bed, patient, acuity);
    }

    public IReadOnlyList<string> DrainPagerLog()
    {
        return _pagerAlertService.DrainLog();
    }

    public string ExportCensusCsv()
    {
        return _censusExporter.Export(
            _registry.BedPatients,
            _registry.AcuityScores);
    }

}
