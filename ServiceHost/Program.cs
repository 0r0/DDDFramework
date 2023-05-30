using Autofac;
using Autofac.Extensions.DependencyInjection;
using DDDFramework.Infrastructure.Config;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllersInGateways();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true)
    .AddEnvironmentVariables();
var eventStorSettings = new Settings();
 builder.Configuration.GetSection("EventStoreConnection").Bind(eventStorSettings);
Console.Write(eventStorSettings);
builder.Host.ConfigureContainer<ContainerBuilder>(autofacBuilder => autofacBuilder.RegisterModule(new OrderModule()));
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