using System.Diagnostics;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DDDFramework.Infrastructure.Config;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersInGateways();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecksUI(setupSettings: setup =>
{
    setup.SetEvaluationTimeInSeconds(5); 
    setup.AddHealthCheckEndpoint("infrastructure", "https://localhost:7257/healthz");

}).AddInMemoryStorage();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
var eventStoreSettings = new Settings();
builder.Configuration.GetSection("EventStoreConnection").Bind(eventStoreSettings);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Host.ConfigureContainer<ContainerBuilder>(autofacBuilder =>
    autofacBuilder.RegisterModule(new OrderModule(eventStoreSettings.Url)));

Debug.Assert(eventStoreSettings.Url != null, "eventStoreSettings.Url != null");
builder.Services.AddHealthChecks().AddEventStore(eventStoreSettings.Url);
    // .AddCheck("event-store",new InfrastructureHealthCheckEventStore(eventStoreSettings.Url))
    // .AddEventStore(eventStoreSettings.Url);
// builder.Services.AddHealthChecksUi.AddInMemoryStorage();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/healths");
app
    .UseRouting()
    .UseEndpoints(config =>
    {
        config.MapHealthChecks("/healthz", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        config.MapHealthChecksUI(setup =>
        {
            setup.AddCustomStylesheet("styles/dotnet.css");
        });
    });

app.Run();