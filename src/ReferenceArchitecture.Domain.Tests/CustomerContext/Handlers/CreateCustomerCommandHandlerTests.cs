using NUnit.Framework;
using ReferenceArchitecture.Domain.CustomerContext.Commands;

namespace ReferenceArchitecture.Domain.Tests.CustomerContext.Handlers
{
  public class CreateCustomerCommandHandlerTests : TestBase
  {
    [Test]
    public async Task ShouldReturnSuccessWhenCommandIsValid()
    {
      var commandBuilder = GetFaker<CreateCustomerCommand>()
        .RuleFor(c => c.Name, f => f.Name.FullName())
        .RuleFor(c => c.BirthDate, f => f.Person.DateOfBirth);

      var command = commandBuilder.Generate();

      var clienteId = new Random().Next();

      var result = await Mediator.SendCommand(command);

      Assert.IsTrue(result.IsValid);
      //Assert.AreEqual(clienteId, result.Result);
    }
  }
}
