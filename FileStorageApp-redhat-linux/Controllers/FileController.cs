using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileStorageApp_redhat_linux.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly string storagePath = "/app/data";

        [HttpPost("create")]
        public IActionResult CreateFile()
        {
            if (!Directory.Exists(storagePath))
                Directory.CreateDirectory(storagePath);

            string filePath = Path.Combine(storagePath, "sample.txt");

            System.IO.File.WriteAllText(filePath, "Hello from .NET in Kubernetes!");

            return Ok("File created successfully");
        }

        [HttpGet("download")]
        public IActionResult DownloadFile()
        {
            string filePath = Path.Combine(storagePath, "sample.txt");

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");

            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "text/plain", "sample.txt");
        }
    }
}
