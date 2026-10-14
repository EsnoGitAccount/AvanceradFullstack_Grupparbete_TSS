namespace Backend.Services.IServices
{
	public interface IBlobStorageService
	{
		Task<string> UploadFileAsync(IFormFile file, string? fileNameWithExtension = "");
		Task DeleteBlobAsync(string blobUrl);
	}
}
