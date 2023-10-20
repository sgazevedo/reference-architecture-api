using FluentValidation.Results;

namespace ReferenceArchitecture.Shared.Mediator.Messaging
{
  /// <summary>
  /// Defines a base class for a command response.
  /// </summary>
  /// <typeparam name="TResult">The type of result</typeparam>
  public class CommandResponse<TResult>
  {
    /// <summary>
    /// Creates an instance of class <see cref="CommandResponse{TResult}"/>
    /// </summary>
    /// <param name="result">The result returned from this command.</param>
    /// <param name="validationResult">The validation error list.</param>
    public CommandResponse(TResult result, ValidationResult validationResult)
    {
      this.Result = result;

      this.Errors = validationResult == null ?
        Array.Empty<ValidationFailure>() :
        validationResult.Errors.ToArray();
    }

    /// <summary>
    /// Indicates if the command is valid.
    /// </summary>
    public bool IsValid => !Errors.Any();

    /// <summary>
    /// Retrieves the returned result from the command.
    /// </summary>
    public TResult Result { get; private set; }

    /// <summary>
    /// Retrieves the validation error list.
    /// </summary>
    public IEnumerable<ValidationFailure> Errors { get; private set; }
  }
}