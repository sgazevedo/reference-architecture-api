using MediatR;

namespace ReferenceArchitecture.Shared.Mediator.Messaging
{
  /// <summary>
  /// Represents an event.
  /// </summary>
  public abstract class Event : Message, INotification
  {
    /// <summary>
    /// Creates a new instance of <see cref="Event" />.
    /// </summary>
    protected Event()
    {
      Timestamp = DateTime.Now;
    }

    /// <summary>
    /// Retrieves the Timestamp for this event.
    /// </summary>
    /// <value>The timestamp that this event was created.</value>
    public DateTime Timestamp { get; private set; }
  }
}