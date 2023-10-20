using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using ReferenceArchitecture.Shared.Mediator;
using System.Globalization;
using System.Reflection;

namespace ReferenceArchitecture.Domain.Tests
{
  public class TestBase
  {
    public IMediatorHandler Mediator { get; private set; }

    private const string Locale = "pt_BR";

    private readonly Dictionary<string, object> mocks = new();

    private static readonly Type MockType = Assembly.GetAssembly(typeof(Mock)).GetType("Moq.Mock`1");

    public static readonly CultureInfo Culture = new(Locale);

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      var services = new ServiceCollection();

      services.AddMediatR(configuration =>
      {
        configuration.RegisterServicesFromAssemblies(typeof(IReferenceArchitectureUnitOfWork).Assembly);
      });
      services.AddScoped<IMediatorHandler, MediatorHandler>();

      ConfigureApplicationServices(services);

      var provider = services.BuildServiceProvider();
      Mediator = provider.GetRequiredService<IMediatorHandler>();
    }

    [TearDown]
    public void TearDown()
    {
      mocks
        .Select(x => x.Value)
        .Cast<Mock>()
        .ToList()
        .ForEach(x => x.Reset());
    }

    protected static Faker<T> GetFaker<T>() where T : class => new(Locale);

    protected static Faker GetFaker() => new(Locale);

    private void ConfigureApplicationServices(ServiceCollection services)
    {
      
    }
  }
}
