using EstudosRedisAndRabbitMq.Interfaces;
using EstudosRedisRabbitMq.RabbitMq.Model;
using MassTransit;

namespace FOURBIO.MENSAGERIA.COMUNICACAO.Consumers
{
    public class Consumer
    (
        ILogger<Consumer> logger,
        ICachingService cache
    ) : IConsumer<ObjectRequest>
    {
        private readonly ILogger<Consumer> _logger = logger;
        private readonly ICachingService _cache = cache;

        public async Task Consume(ConsumeContext<ObjectRequest> context)
        {
            try
            {
                var request = context.Message;

                await _cache.SetAsync(request.Id.ToString(), request.Name);

                await context.RespondAsync(new ObjectResponse
                {
                    IsSuccess = true,
                    Message = "Processamento feito com sucesso"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao processar request: {ex.Message}");

                await context.RespondAsync(new ObjectResponse
                {
                    IsSuccess = false,
                    Message = "Ocorreu um erro durante o processamento"
                });
            }
        }
    }
}