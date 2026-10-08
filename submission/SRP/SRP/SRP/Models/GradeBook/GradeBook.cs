namespace SRP.Models;


public sealed class GradeBook
{
    private readonly GradeScoreStore _scores = new();
    private readonly LetterGradePolicy _letterPolicy = new();
    private readonly HonorRollPolicy _honorPolicy = new();
    private readonly TranscriptFormatter _transcript = new();
    private readonly GradeBookCsvExporter _csv = new();

    public void Record(string studentId, decimal score) => _scores.Record(studentId, score);
    public decimal Average(string studentId) => _scores.Average(studentId);
    public string Letter(string studentId) => _letterPolicy.Get(Average(studentId));
    public bool MeetsHonorRoll(string studentId) => _honorPolicy.Qualifies(Average(studentId), Letter(studentId));
    public string TranscriptPlain(string studentId, string fullName)
        => _transcript.Format(studentId, fullName, Average(studentId), Letter(studentId), MeetsHonorRoll(studentId));
    public string ExportCsv()
        => _csv.Export(_scores.StudentIds(), Average, Letter, MeetsHonorRoll);
}