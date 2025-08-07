using EstudosRedisAndRabbitMq.Interfaces;
using EstudosRedisAndRabbitMq.Services;
using EstudosRedisRabbitMq.RabbitMq.Model;
using FOURBIO.MENSAGERIA.COMUNICACAO.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICachingService, CachingService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<Consumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("request", e =>
        {
            e.ConfigureConsumer<Consumer>(context);
        });

    });

    x.AddRequestClient<ObjectRequest>();
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseSwagger();
//app.UseSwaggerUI();

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
