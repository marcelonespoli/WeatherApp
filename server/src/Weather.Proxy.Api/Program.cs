using Microsoft.OpenApi.Models;
using Wheather.Proxy.Infra.Config;
using Wheather.Proxy.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

var apiSettings = builder.Configuration.GetSection("ApiSettings");
builder.Services.Configure<ApiSettings>(apiSettings);

DependencyContainer.Register(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather Proxy Service", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather Proxy Service V1");
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();
