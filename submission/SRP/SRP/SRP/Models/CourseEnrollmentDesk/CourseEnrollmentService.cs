namespace SRP.Models;

public sealed class CourseEnrollmentService
{
    private readonly CourseEnrollmentState _state;
    private readonly int _capacity;

    public CourseEnrollmentService(CourseEnrollmentState state, int capacity)
    {
        _state = state;
        _capacity = capacity;
    }

    public string Register(string studentEmail)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email");
        var email = studentEmail.Trim();
        if (_state.IsSeated(email) || _state.IsWaitlisted(email)) return "ALREADY_REGISTERED";
        if (_state.SeatedCount < _capacity)
        {
            _state.Seat(email);
            return "SEATED";
        }
        return $"WAITLIST:{_state.AddToWaitlist(email)}";
    }

    public int WaitlistPosition(string studentEmail) => _state.WaitlistPosition(studentEmail);

    public void PromoteFromWaitlist(int seats)
    {
        while (seats > 0 && _state.SeatedCount < _capacity && _state.TryPromoteOne(out _))
            seats--;
    }
}