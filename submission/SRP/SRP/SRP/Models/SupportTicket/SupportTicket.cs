namespace SRP.Models.SupportTicket;

public sealed class SupportTicket
{
    private readonly SupportTicketConversation _conversation;
    private readonly SupportPriorityClassifier _priorityClassifier = new();
    private readonly SupportSlaPolicy _sla = new();
    private readonly SupportPublicReplyFormatter _reply = new();
    private readonly SupportEscalationFormatter _escalation = new();

    public string Id { get; }
    public string Subject => _conversation.Subject;
    public string Body => _conversation.Body;
    public DateTimeOffset OpenedAt { get; }
    public string Priority { get; private set; }

    public SupportTicket(string id, string subject, string body, DateTimeOffset openedAt)
    {
        Id = id;
        _conversation = new SupportTicketConversation(subject, body);
        OpenedAt = openedAt;
        Priority = _priorityClassifier.Classify(Subject, Body);
    }

    public void AppendCustomerMessage(string text)
    {
        _conversation.Append(text);
        RecalculatePriorityFromText();
    }

    public void RecalculatePriorityFromText()
        => Priority = _priorityClassifier.Classify(Subject, Body);

    public DateTimeOffset SlaDeadline() => _sla.Deadline(Priority, OpenedAt);
    public bool IsBreached(DateTimeOffset now) => now > SlaDeadline();
    public string DraftPublicReply(string agentName) => _reply.Format(Id, agentName, Priority, SlaDeadline());
    public string InternalEscalationBlurb() => _escalation.Format(Id, Priority, SlaDeadline());
}
