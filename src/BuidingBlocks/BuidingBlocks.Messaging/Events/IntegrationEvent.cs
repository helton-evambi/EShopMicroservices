namespace BuidingBlocks.Messaging.Events;

public record IntegrationEvent
{
    public Guid Id => Guid.NewGuid();
    public DateTime OcocurredOn => DateTime.UtcNow;
    public string EventType => GetType().AssemblyQualifiedName;
}
