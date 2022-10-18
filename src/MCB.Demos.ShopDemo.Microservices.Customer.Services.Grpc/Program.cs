using MCB.Demos.ShopDemo.Microservices.Customer.Services.Grpc.HealthCheck;
using MCB.Demos.ShopDemo.Microservices.Customer.Services.Grpc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services

builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(majorVersion: 1, minorVersion: 0);
    options.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MCB.Demos.ShopDemo.Microservices.Customer",
        Description = "API Microservices Customer",
        Contact = new OpenApiContact() { 
            Name = "Marcelo Castelo Branco", 
            Email = "marcelo.castelo@outlook.com", 
            Url = new Uri("https://www.linkedin.com/in/marcelocastelobranco/")
        }
    });
});
builder.Services.AddHealthChecks().AddCheck<DefaultHealthCheck>("Default");

#endregion

#region Configure Pipeline

var app = builder.Build();

app.MapGrpcService<GreeterService>();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.UseHttpsRedirection();
app.MapControllers();
app.MapHealthChecks("/health"); 

#endregion

app.Run();
