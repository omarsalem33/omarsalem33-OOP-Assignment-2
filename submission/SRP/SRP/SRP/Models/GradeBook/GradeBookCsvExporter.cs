namespace SRP.Models;

public sealed class GradeBookCsvExporter
{
    public string Export(IEnumerable<string> studentIds, Func<string, decimal> average, Func<string, string> letter, Func<string, bool> honor)
    {
        var rows = new List<string> { "studentId,average,letter,honor" };
        foreach (var id in studentIds.OrderBy(x => x))
            rows.Add($"{id},{average(id)},{letter(id)},{(honor(id) ? 1 : 0)}");
        return string.Join('\n', rows);
    }
}