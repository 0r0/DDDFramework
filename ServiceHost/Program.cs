using System.Diagnostics;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DDDFramework.Core;
using DDDFramework.Infrastructure.Config;
using DDDFramework.Infrastructure.Config.SettingModels;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersInGateways();

builder.Services.AddQuartzService();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
// builder.Services.AddHealthChecksUI(setupSettings: setup =>
// {
//     setup.SetEvaluationTimeInSeconds(5);
//     setup.AddHealthCheckEndpoint("infrastructure", "https://localhost:7257/healthz");
// }).AddInMemoryStorage();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
var eventStoreSettings = new EventStoreSettings();
var mongoDbSettings = new MongoDbSettings();
builder.Configuration.GetSection("EventStoreConnection").Bind(eventStoreSettings);
builder.Configuration.GetSection("MongoDBConnection").Bind(mongoDbSettings);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.Configure<EventStoreOptions>(builder.Configuration.GetSection("EventStoreStream"));

builder.Host.ConfigureContainer<ContainerBuilder>(autofacBuilder =>
    autofacBuilder.RegisterModule(new OrderModule(eventStoreSettings, mongoDbSettings)));

Debug.Assert(eventStoreSettings.Url != null, "eventStoreSettings.Url != null");
Debug.Assert(mongoDbSettings.Url != null, "mongoDbSettings.Url != null");
// builder.Services.AddHealthChecks().AddEventStore(eventStoreSettings.Url);
    // .AddMongoHealthCheck(mongoDbSettings.Url);

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
// /healthchecks-ui address
// app
//     .UseRouting()
//     .UseEndpoints(config =>
//     {
//         config.MapHealthChecks("/healthz", new HealthCheckOptions
//         {
//             Predicate = _ => true,
//             ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//         });
//         config.MapHealthChecksUI(setup => { setup.AddCustomStylesheet("styles/dotnet.css"); });
//     });

app.Run();