namespace SRP.Models;

public sealed class WelcomePacketMarkdownFormatter
{
    public string Format(string courseCode, bool seated, int waitlistPosition, string studentName)
    {
        var status = seated ? "confirmed seat" : $"waitlist #{waitlistPosition}";
        return $"# Welcome to {courseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
               $"Bring a laptop. Discord onboarding link: https://example.invalid/{courseCode.ToLowerInvariant()}\n";
    }
}