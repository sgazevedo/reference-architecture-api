using NUnit.Framework;
using ReferenceArchitecture.Domain.CustomerContext.Commands;

namespace ReferenceArchitecture.Domain.Tests.CustomerContext.Commands
{
  public class CreateCustomerCommandTests : TestBase
  {
    [Test]
    public void ShouldReturnSuccessWhenCommandIsValid()
    {
      var commandBuilder = GetFaker<CreateCustomerCommand>()
        .RuleFor(c => c.Name, f => f.Name.FullName())
        .RuleFor(c => c.BirthDate, f => f.Person.DateOfBirth);

      var command = commandBuilder.Generate();      

      Assert.That(command.IsValid(), Is.True);
    }

    [Test]
    [TestCase(null, "O campo 'Name' deve ser preenchido.")]
    [TestCase("", "O campo 'Name' deve ser preenchido.")]
    public void ShouldReturnErrorWhenNameIsInvalid(string invalidName, string errorMessage)
    {
      var commandBuilder = GetFaker<CreateCustomerCommand>()
        .RuleFor(c => c.Name, invalidName)
        .RuleFor(c => c.BirthDate, f => f.Person.DateOfBirth);

      var command = commandBuilder.Generate();

      Assert.That(command.IsValid(), Is.False);
      Assert.That(command.ValidationResult.Errors.First().ErrorMessage, Is.EqualTo(errorMessage));
    }

    [Test]
    [TestCase("0001-01-01", "O campo 'BirthDate' deve ser preenchido.")]
    public void ShouldReturnErrorWhenBirthDateIsInvalid(DateTime invalidBirthDate, string errorMessage)
    {
      var commandBuilder = GetFaker<CreateCustomerCommand>()
        .RuleFor(c => c.Name, f => f.Name.FullName())
        .RuleFor(c => c.BirthDate, invalidBirthDate);

      var command = commandBuilder.Generate();

      Assert.That(command.IsValid(), Is.False);
      Assert.That(command.ValidationResult.Errors.First().ErrorMessage, Is.EqualTo(errorMessage));
    }
  }
}
