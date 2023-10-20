using FluentValidation.Results;
using MediatR;

namespace ReferenceArchitecture.Shared.Mediator.Messaging
{
  /// <summary>Defines the base class for a handler of a command.</summary>
  /// <typeparam name="TCommand">The type of the command</typeparam>
  /// <typeparam name="TResult">The type of result</typeparam>
  public abstract class CommandHandler<TCommand, TResult> : IRequestHandler<TCommand, CommandResponse<TResult>>
      where TCommand : Command<TResult>
  {
    private readonly ValidationResult validationResult;

    /// <summary>
    /// Instantiates a new CommandHandler.
    /// </summary>
    protected CommandHandler()
    {
      validationResult = new();
    }

    /// <summary>
    /// Whether validation of the command succeeded
    /// </summary>
    protected bool IsValid => validationResult.IsValid;

    /// <summary>
    /// Handles the command provided.
    /// </summary>
    /// <param name="request">The command that triggered this action.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the response for this command indicating.</returns>
    public abstract Task<CommandResponse<TResult>> Handle(TCommand request, CancellationToken cancellationToken);

    /// <summary>
    /// Adds an error into the validationResult list of errors.
    /// </summary>
    /// <param name="message">The message describing the error.</param>
    protected void AddError(string message) =>
        validationResult.Errors.Add(new ValidationFailure(string.Empty, message));

    /// <summary>
    /// Adds an error into the validationResult list of errors.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="message">The message describing the error.</param>
    protected void AddError(string errorCode, string message) =>
        validationResult.Errors.Add(new ValidationFailure(string.Empty, message) { ErrorCode = errorCode });

    /// <summary>
    /// Creates a response for the command providing a result.
    /// </summary>
    /// <param name="result">The result of the operation.</param>
    /// <returns>The <see cref="CommandResponse{TResult}" /> containing the result.</returns>
    protected CommandResponse<TResult> Response(TResult result)
    {
      return new CommandResponse<TResult>(result, validationResult);
    }

    /// <summary>
    /// Creates a response for the command without result value.
    /// </summary>
    /// <returns>
    /// The <see cref="CommandResponse{TResult}" /> containing a default instance of <typeparamref name="TResult"/>.
    /// </returns>

    protected CommandResponse<TResult?> Response()
    {
      return new CommandResponse<TResult?>(default, validationResult);
    }

    /// <summary>
    /// Creates a response for the command without result value and a custom <see cref="ValidationResult" />.
    /// </summary>
    /// <param name="validationResult"></param>
    /// <returns>
    /// The <see cref="CommandResponse{TResult}" /> containing a default instance of
    /// <typeparamref name="TResult"/> and the <paramref name="validationResult"/> provided.
    /// </returns>
    protected CommandResponse<TResult?> Response(ValidationResult validationResult)
    {
      return new CommandResponse<TResult?>(default, validationResult);
    }
  }
}