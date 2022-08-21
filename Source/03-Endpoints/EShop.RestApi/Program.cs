using ApplicationServices;
using DataAccess;
using DomainServices;
using EShop.RestApi.Swagger.Examples;
using Framework.Middlewares;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EShop", Version = "v1" });

    c.ExampleFilters();

    var documentPath = Path.Combine(Directory.GetCurrentDirectory(), "EShop.RestApi.xml");
    c.IncludeXmlComments(documentPath);
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<CreateUserCommandExample>();

builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddDataAccess(builder.Configuration.GetConnectionString("EShop"));

var app = builder.Build();

app.UseMiddleware<ExceptionHandler>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
