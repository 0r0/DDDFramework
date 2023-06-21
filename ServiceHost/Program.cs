using Autofac;
using Autofac.Extensions.DependencyInjection;
using DDDFramework.Infrastructure.Config;
using Grpc.Net.Client;
using Microsoft.OpenApi.Models;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersInGateways();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddGrpc();



builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo {Title = "gRPC transcoding", Version = "v1"});
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
var eventStorSettings = new Settings();
builder.Configuration.GetSection("EventStoreConnection").Bind(eventStorSettings);
builder.Services.AddEventStoreClient(new Uri(eventStorSettings.Url ??
                                             throw new InvalidOperationException("event store url is null")));
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
Console.Write(eventStorSettings);
builder.Host.ConfigureContainer<ContainerBuilder>(autofacBuilder =>
    autofacBuilder.RegisterModule(new OrderModule(eventStorSettings.Url)));
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