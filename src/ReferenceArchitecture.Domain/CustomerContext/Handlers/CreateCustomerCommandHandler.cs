using ReferenceArchitecture.Domain.CustomerContext.Commands;
using ReferenceArchitecture.Shared.Mediator.Messaging;

namespace ReferenceArchitecture.Domain.CustomerContext.Handlers
{
  public class CreateCustomerCommandHandler : CommandHandler<CreateCustomerCommand, int>
  {

    public override Task<CommandResponse<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
      if (!request.IsValid()) 
        return Task.FromResult(Response(request.ValidationResult));

      return Task.FromResult(Response(int.MaxValue));
    }
  }
}
