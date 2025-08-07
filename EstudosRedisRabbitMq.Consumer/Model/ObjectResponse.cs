using MassTransit;

namespace EstudosRedisRabbitMq.RabbitMq.Model
{
    [MessageUrn("response")]
    [EntityName("response")]
    public class ObjectResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
