using MediatR;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace ReferenceArchitecture.Shared.Mediator.Messaging
{

  /// <summary>
  /// Defines the base class for a command.
  /// </summary>
  /// <typeparam name="TResult">The type of result</typeparam>
  public abstract class Command<TResult> : IRequest<CommandResponse<TResult>>
  {
    /// <summary>
    /// The list of validation errors created by the method call IsValid.
    /// </summary>
    [JsonIgnore]
    public ValidationResult ValidationResult { get; protected set; } = new();

    /// <summary>
    /// Checks if the command is in a valid state.
    /// </summary>
    /// <returns>True if valid, false otherwise.</returns>
    public virtual bool IsValid() => true;
  }
}
