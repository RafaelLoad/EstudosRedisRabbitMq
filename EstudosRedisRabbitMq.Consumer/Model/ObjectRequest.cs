using MassTransit;

namespace EstudosRedisRabbitMq.RabbitMq.Model
{
    [MessageUrn("request")]
    [EntityName("request")]
    public class ObjectRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
