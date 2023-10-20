using ReferenceArchitecture.Shared.Mediator.Messaging;

namespace ReferenceArchitecture.Shared.Mediator
{
  /// <summary>
  /// Represents the mediator handler.
  /// </summary>
  public interface IMediatorHandler
  {
    /// <summary>
    /// Asynchronously send a request to a single handler.
    /// </summary>
    /// <param name="command">The command to send.</param>
    /// <typeparam name="TResult">The type of result expected.</typeparam>
    /// <returns>A task that represents <see cref="CommandResponse{TResult}" /> after the command is handled.</returns>
    Task<CommandResponse<TResult>> SendCommand<TResult>(Command<TResult> command);

    /// <summary>
    /// Asynchronously send a notification to multiple handlers.
    /// </summary>
    /// <param name="event">The event.</param>
    Task PublishEvent<TEvent>(TEvent @event) where TEvent : Event;
  }
}