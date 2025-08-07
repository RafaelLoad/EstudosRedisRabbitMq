using EstudosRedisRabbitMq.RabbitMq.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace EstudosRedisRabbitMq.RabbitMq.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RabbitMqProducerController : ControllerBase
    {

        private readonly IRequestClient<ObjectRequest> _requestClient;

        public RabbitMqProducerController(IRequestClient<ObjectRequest> requestClient)
        => _requestClient = requestClient;

        [HttpPost]
        public async Task<IActionResult> PostRedis(string key, string value)
        {
            var request = new ObjectRequest
            {
                Id = Convert.ToInt32(key),
                Name = value
            };
            var response = await _requestClient.GetResponse<ObjectResponse>(request);
            return Ok(response.Message);
        }
    }
}
