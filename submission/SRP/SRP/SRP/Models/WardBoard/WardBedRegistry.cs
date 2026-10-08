namespace SRP.Models;

public sealed class WardBedRegistry
{
    private readonly Dictionary<int, string> _bedPatient = new();
    private readonly Dictionary<int, int> _vitalsScore = new();

    public void Assign(int bed, string patientId, int acuity)
    {
        _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
        _vitalsScore[bed] = acuity;
    }

    public bool TryGet(int bed, out string patient, out int acuity)
    {
        if (_bedPatient.TryGetValue(bed, out var foundPatient))
        {
            patient = foundPatient;
            acuity = _vitalsScore[bed];
            return true;
        }
        acuity = 0;
        patient = string.Empty;
        return false;
    }

    public IEnumerable<(int Bed, string Patient, int Acuity)> All()
        => _bedPatient.Keys.OrderBy(x => x).Select(b => (b, _bedPatient[b], _vitalsScore[b]));
}