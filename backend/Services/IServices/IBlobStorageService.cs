using Azure.Storage.Blobs.Models;

namespace Backend.Services.IServices
{
    public interface IBlobStorageService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task DeleteBlobAsync(string blobName);
        Task<BlobDownloadStreamingResult> DownloadAsync(string blobName);
    }
}
