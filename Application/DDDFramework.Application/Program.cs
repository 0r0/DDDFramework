using DDDFramework.Application;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

AddingConfig(builder);

// Add services to the container.

builder.Services.AddControllersInGateways();
builder.Services.AddOcelot();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

 app.UseOcelot().Wait();

app.Run();

void AddingConfig(WebApplicationBuilder webApplicationBuilder)
{
    webApplicationBuilder.Host.ConfigureServices(s => s.AddSingleton(webApplicationBuilder))
        .ConfigureAppConfiguration(ic => ic.AddJsonFile(Path.Combine("",
            "configuration.json")));
}

