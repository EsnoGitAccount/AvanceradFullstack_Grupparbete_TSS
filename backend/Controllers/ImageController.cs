using Backend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IBlobStorageService _blobStorageService;

        public ImageController(IBlobStorageService blobStorageService)
        {
            _blobStorageService = blobStorageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var blobName = await _blobStorageService.UploadFileAsync(file);

            return Ok(new { blobName });
        }

        [HttpGet("{blobName}")]
        public async Task<IActionResult> GetImage(
        string blobName)
        {
            var image = await _blobStorageService.DownloadAsync(blobName);

            return File(image.Content, image.Details.ContentType);

        }

        [HttpDelete("{blobName}")]
        public async Task<IActionResult> DeleteImage(string blobName)
        {
            await _blobStorageService.DeleteBlobAsync(blobName);
            return NoContent();
        }

    }
}
