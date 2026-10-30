namespace SRP.Models.SupportTicket;

public sealed class SupportPublicReplyFormatter
{
    public string Format(string id, string agentName, string priority, DateTimeOffset deadline)
    {
        var apology = priority == "P1" ? "We are treating this as a critical incident." : "Thanks for reaching out.";
        return $"Hi,\n{apology}\nTicket {id} is with {agentName}. Next update before {deadline:u}.\n";
    }
}