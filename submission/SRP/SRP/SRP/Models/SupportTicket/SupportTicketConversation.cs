namespace SRP.Models.SupportTicket;

public sealed class SupportTicketConversation
{
    public string Subject { get; private set; }
    public string Body { get; private set; }

    public SupportTicketConversation(string subject, string body)
    {
        Subject = subject;
        Body = body;
    }

    public void Append(string text) => Body += "\n---\n" + text;
    public string SearchText() => (Subject + " " + Body).ToLowerInvariant();
}