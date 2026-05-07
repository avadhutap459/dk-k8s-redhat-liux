using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dk_k8s_redhat_liux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ConfigController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // 🔹 Read Environment Variable
            var envValue = Environment.GetEnvironmentVariable("MY_ENV");

            // 🔹 Read using Configuration
            var configValue = _config["MY_ENV"];

            // 🔹 Read Arguments
            var argsValue = _config["myArg"];

            return Ok(new
            {
                EnvironmentVariable = envValue,
                ConfigValue = configValue,
                ArgumentValue = argsValue
            });
        }
    }
}
