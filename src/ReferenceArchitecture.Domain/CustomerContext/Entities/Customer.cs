using ReferenceArchitecture.Shared.Domain;

namespace ReferenceArchitecture.Domain.CustomerContext.Entities
{
  public class Customer : EntityBase
  {
    public Customer(string name, DateTime birthDate) : base()
    {
      Name = name;
      BirthDate = birthDate;
    }

    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
  }
}
