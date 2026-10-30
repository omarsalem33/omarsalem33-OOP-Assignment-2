namespace SRP.Models;

public sealed class CourseEnrollmentDesk
{
    private readonly CourseEnrollmentState _state = new();
    private readonly CourseEnrollmentService _enrollment;
    private readonly WelcomePacketMarkdownFormatter _welcome = new();
    private readonly TuitionInvoiceLineFormatter _invoice = new();

    public int Capacity { get; }
    public decimal Tuition { get; }
    public string CourseCode { get; }

    public CourseEnrollmentDesk(string courseCode, int capacity, decimal tuition)
    {
        CourseCode = courseCode;
        Capacity = capacity;
        Tuition = tuition;
        _enrollment = new CourseEnrollmentService(_state, Capacity);
    }

    public string Register(string studentEmail) => _enrollment.Register(studentEmail);
    public int WaitlistPosition(string studentEmail) => _enrollment.WaitlistPosition(studentEmail);
    public void PromoteFromWaitlist(int seats) => _enrollment.PromoteFromWaitlist(seats);

    public string WelcomePacketMarkdown(string studentEmail, string studentName)
        => _welcome.Format(CourseCode, _state.IsSeated(studentEmail), _state.WaitlistPosition(studentEmail), studentName);

    public string TuitionInvoiceLine(string studentEmail)
        => _invoice.Format(CourseCode, Tuition, _state.IsSeated(studentEmail));
}