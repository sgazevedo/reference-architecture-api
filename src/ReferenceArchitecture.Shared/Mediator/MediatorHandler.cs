using System.Runtime.CompilerServices;
using ReferenceArchitecture.Shared.Mediator.Messaging;
using MediatR;

namespace ReferenceArchitecture.Shared.Mediator
{
  /// <inheritdoc />
  public class MediatorHandler : IMediatorHandler
  {
    private readonly IMediator mediator;

    /// <inheritdoc />
    public MediatorHandler(IMediator mediator) 
      => this.mediator = mediator;

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Task<CommandResponse<TResult>> SendCommand<TResult>(Command<TResult> command) 
      => mediator.Send(command);

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public virtual Task PublishEvent<TEvent>(TEvent @event) where TEvent : Event
      => mediator.Publish(@event);
  }
}
