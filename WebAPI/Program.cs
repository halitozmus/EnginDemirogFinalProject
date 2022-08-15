using Autofac;
using Business.DependencyResolvers.Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder=>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

// Add services to the container.

builder.Services.AddControllers();
//Autofac,Ninject,CastleWindsor,StructureMap,LightInject,DryInject--->IoC Container
//AOP Bütün metotlarda iþlem yapmak(Exp Log) istersen kullan.Exp[LogAspect][Validate][Cache][Transaction]
//builder.Services.AddSingleton<IProductService,ProductManager>();
//builder.Services.AddSingleton<IProductDal,EfProductDal>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
