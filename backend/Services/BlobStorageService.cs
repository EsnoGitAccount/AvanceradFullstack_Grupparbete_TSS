using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Backend.Exceptions;
using Backend.Options;
using Backend.Services.IServices;

namespace Backend.Services
{
	public class BlobStorageService : IBlobStorageService
	{
		private readonly BlobStorageOptions _blobStorage;

		public BlobStorageService(BlobStorageOptions blobStorage)
		{
			_blobStorage = blobStorage;
		}

		public async Task DeleteBlobAsync(string blobUrl)
		{
			string blobName = Path.GetFileName(blobUrl);
			if (string.IsNullOrEmpty(blobName))
			{
				throw new AppValidationException("Invalid blob URL.");
			}

			BlobContainerClient containerClient = new BlobContainerClient(_blobStorage.ConnectionString, _blobStorage.ContainerName);
			BlobClient blobClient = containerClient.GetBlobClient(blobName);
			await blobClient.DeleteIfExistsAsync(snapshotsOption: DeleteSnapshotsOption.IncludeSnapshots);
		}

		public async Task<string> UploadFileAsync(IFormFile file, string? fileNameWithExtension = "")
		{
			if (string.IsNullOrEmpty(fileNameWithExtension))
			{
				var fileExtension = Path.GetExtension(file.FileName)?.ToLowerInvariant();
				fileNameWithExtension=Guid.NewGuid().ToString("N") + fileExtension;
			
			}

			BlobContainerClient containerClient = new BlobContainerClient(_blobStorage.ConnectionString, _blobStorage.ContainerName);
			await containerClient.CreateIfNotExistsAsync();
			BlobClient blobClient = containerClient.GetBlobClient(fileNameWithExtension);
			await using var stream = file.OpenReadStream();
			await blobClient.UploadAsync(stream);
			var blobName = blobClient.Name;
			return blobName;
		}
	}
}
