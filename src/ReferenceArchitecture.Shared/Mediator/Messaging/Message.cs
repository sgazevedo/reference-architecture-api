namespace ReferenceArchitecture.Shared.Mediator.Messaging
{
  /// <summary>
  /// Represents a message.
  /// </summary>
  public abstract class Message
  {
    /// <summary>
    /// Creates a new instance of <see cref="Message" />
    /// </summary>
    protected Message()
    {
      MessageType = GetType().Name;
    }

    /// <summary>
    /// The message type.
    /// </summary>
    public string MessageType { get; protected set; }

    /// <summary>
    /// The aggregate id.
    /// </summary>
    public Guid AggregateId { get; protected set; }
  }
}