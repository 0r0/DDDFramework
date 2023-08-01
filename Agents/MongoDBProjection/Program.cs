using Autofac;
using Autofac.Extensions.DependencyInjection;
using MongoDBProjection;

;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(autofacBuilder =>
    autofacBuilder.RegisterModule(new ProjectionModule()));
var app = builder.Build();
app.Run();



