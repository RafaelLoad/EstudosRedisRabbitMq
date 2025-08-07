using EstudosRedisAndRabbitMq.Interfaces;
using EstudosRedisAndRabbitMq.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICachingService, CachingService>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddStackExchangeRedisCache(x =>
{
    x.InstanceName = "Redis";
    x.Configuration = "localhost:6379,password=guest";
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
