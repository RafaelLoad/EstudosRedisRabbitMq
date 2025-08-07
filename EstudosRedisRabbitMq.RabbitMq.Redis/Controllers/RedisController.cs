using EstudosRedisAndRabbitMq.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Redis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedisController : ControllerBase
    {
        private readonly ILogger<RedisController> _logger;
        private readonly ICachingService _service;

        public RedisController(ILogger<RedisController> logger, ICachingService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostRedis(string key, string value)
        {
            await _service.SetAsync(key, value);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetRedis(string key)
         => Ok(await _service.GetAsync(key));
    }
}
