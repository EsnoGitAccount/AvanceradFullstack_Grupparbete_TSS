using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Backend.Exceptions;
using Backend.Options;
using Backend.Services.IServices;
using Microsoft.Extensions.Options;


namespace Backend.Services
{
	public class BlobStorageService : IBlobStorageService
	{
		//Set a maximum file size limit (e.g., 5 MB) and allowed file types (JPEG, PNG, WEBP)
		private const long MaxFileSize = 5 * 1024 * 1024; // 5 MB
		// Allowed file types
		private static readonly HashSet<string> AllowedTypes = new(StringComparer.OrdinalIgnoreCase)
		{
			"image/jpeg",
			"image/png",
			"image/webp",
		};

		private readonly BlobStorageOptions _blobStorage;

		public BlobStorageService(IOptions<BlobStorageOptions> blobStorage)
		{
			_blobStorage = blobStorage.Value;
		}

		// Uploads a file to Azure Blob Storage and returns the blob name.
		public async Task<string> UploadFileAsync(IFormFile file)
		{
			// Validate the file before uploading
			ValidateFile(file);

			// Generate a unique blob name using a GUID
			var blobName = $"{Guid.NewGuid():N}";

			// Create a BlobContainerClient to interact with the specified container in Azure Blob Storage
			var blobContainerClient = new BlobContainerClient(_blobStorage.ConnectionString, _blobStorage.ContainerName);
		
			//Get a BlobClient for the specified blob name
			var blobClient = blobContainerClient.GetBlobClient(blobName);
		
			// Open a read stream for the uploaded file and upload it to Azure Blob Storage
			await using var stream = file.OpenReadStream();
			
			// Upload the file to Azure Blob Storage with the specified content type
			await blobClient.UploadAsync(stream, new BlobUploadOptions
			{
				HttpHeaders = new BlobHttpHeaders
				{
					ContentType = file.ContentType
				}
			});
			
			// Return the generated blob name to the caller
			return blobName;
		}

		public async Task DeleteBlobAsync(string blobName)
		{

			if (string.IsNullOrEmpty(blobName))
			{
				throw new AppValidationException("Invalid blob name.");
			}

			BlobContainerClient containerClient = new BlobContainerClient(_blobStorage.ConnectionString, _blobStorage.ContainerName);
			BlobClient blobClient = containerClient.GetBlobClient(blobName);

			await blobClient.DeleteIfExistsAsync(snapshotsOption: DeleteSnapshotsOption.IncludeSnapshots);
		}


		// Downloads a blob from Azure Blob Storage and returns the streaming result.
		public async Task<BlobDownloadStreamingResult> DownloadAsync(string blobName)
		{
			// Validate the blob name before attempting to download
			if (string.IsNullOrEmpty(blobName))
			{
				throw new AppValidationException("Invalid blob name.");
			}

			// Create a BlobContainerClient to interact with the specified container in Azure Blob Storage
			BlobContainerClient containerClient = new BlobContainerClient(_blobStorage.ConnectionString, _blobStorage.ContainerName);
			
			// Get a BlobClient for the specified blob name
			BlobClient blobClient = containerClient.GetBlobClient(blobName);

			try
			{
				// Attempt to download the blob and return the streaming result
				var response = await blobClient.DownloadStreamingAsync();
				// Return the BlobDownloadStreamingResult to the caller
				return response.Value;
			}
			catch (Azure.RequestFailedException ex) when(ex.Status==404)
			{
				// If the blob is not found, throw a NotFoundException with a descriptive message
				throw new NotFoundException("Blob not found.");
			}
		}


		// Validates the uploaded file for size and type constraints.
		private void ValidateFile(IFormFile file)
		{
			// Check if the file is null or empty
			if (file == null || file.Length == 0)
			{
				throw new AppValidationException("File is empty.");
			}
			// Check if the file size exceeds the maximum limit
			if (file.Length > MaxFileSize)
			{
				throw new AppValidationException($"File size exceeds the maximum limit of {MaxFileSize / (1024 * 1024)} MB.");
			}
			// Check if the file type is allowed
			if (!AllowedTypes.Contains(file.ContentType))
			{
				throw new AppValidationException("Invalid file type. Only JPEG, PNG, and WEBP are allowed.");
			}
		}
	}
}
