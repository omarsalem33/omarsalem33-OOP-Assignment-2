namespace SRP.Models;

public sealed class CourseEnrollmentState
{
    private readonly HashSet<string> _seated = new(StringComparer.OrdinalIgnoreCase);
    private readonly List<string> _waitlist = new();

    public int SeatedCount => _seated.Count;
    public bool IsSeated(string email) => _seated.Contains(email);
    public bool IsWaitlisted(string email) => _waitlist.Contains(email);
    public int WaitlistPosition(string email)
    {
        var idx = _waitlist.FindIndex(x => x.Equals(email, StringComparison.OrdinalIgnoreCase));
        return idx < 0 ? -1 : idx + 1;
    }

    public void Seat(string email) => _seated.Add(email);
    public int AddToWaitlist(string email)
    {
        _waitlist.Add(email);
        return _waitlist.Count;
    }

    public bool TryPromoteOne(out string email)
    {
        if (_waitlist.Count == 0) { email = string.Empty; return false; }
        email = _waitlist[0];
        _waitlist.RemoveAt(0);
        _seated.Add(email);
        return true;
    }
}