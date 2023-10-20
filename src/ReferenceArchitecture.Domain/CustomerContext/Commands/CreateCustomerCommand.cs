using FluentValidation;
using ReferenceArchitecture.Shared.Mediator.Messaging;

namespace ReferenceArchitecture.Domain.CustomerContext.Commands
{
  public class CreateCustomerCommand : Command<int>
  {
    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public override bool IsValid()
    {
      var validator = new InlineValidator<CreateCustomerCommand>();

      validator.RuleFor(x => x.Name).NotEmpty().WithErrorCode("BASIC0001").WithMessage($"O campo '{nameof(Name)}' deve ser preenchido.");

      validator.RuleFor(x => x.BirthDate).NotEmpty().WithErrorCode("BASIC0001").WithMessage($"O campo '{nameof(BirthDate)}' deve ser preenchido.");

      ValidationResult = validator.Validate(this);
      return ValidationResult.IsValid;
    }
  }
}
