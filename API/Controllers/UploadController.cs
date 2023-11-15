using AWSS3.Models;
using AWSS3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IStorageService _storageService;

        public UploadController(
            ILogger<UploadController> logger,
            IConfiguration configuration,
            IStorageService storageService
            )
        {
            _logger = logger;
            _configuration = configuration;
            _storageService = storageService;
        }

        [HttpPost(Name = "UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var extension = Path.GetExtension(file.FileName);
            var objectName = $"{Guid.NewGuid()}{extension}";

            var s3Object = new S3Object() 
            {
                Name = objectName,
                InputStream = memoryStream,
                BucketName = _configuration["AWS:S3Bucket"].ToString(),
            };

            var credentials = new AwsCredentials() 
            {
                AwsKey = _configuration["AWS:AccessKey"],
                AwsSecretKey = _configuration["AWS:SecretKey"],
            };

            var result = await _storageService.uploadFileAsync(s3Object, credentials);

            if (result.StatusCode != 200) 
            { 
                return StatusCode(result.StatusCode, result.Message); 
            }

            return Ok(result);
        }
    }
}
