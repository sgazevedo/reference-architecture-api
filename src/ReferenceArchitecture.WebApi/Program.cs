using ReferenceArchitecture.Domain;
using ReferenceArchitecture.Shared.Mediator;
using ReferenceArchitecture.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
//var isDevelopment = environmentName.Equals("Development", StringComparison.OrdinalIgnoreCase);

var configuration = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json")
  .AddJsonFile($"appsettings.{environmentName}.json", true)
  .AddEnvironmentVariables()
  .Build();

builder.Services.RegisterDependencies(configuration);

builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();
builder.Services.AddMediatR(configuration =>
{
  configuration.RegisterServicesFromAssemblies(typeof(IReferenceArchitectureUnitOfWork).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
