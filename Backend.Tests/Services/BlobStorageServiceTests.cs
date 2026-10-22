using Azure.Storage.Blobs;
using Backend.Options;
using Backend.Services;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Tests.Services
{
	public class BlobStorageServiceTests
	{
		[Fact]
		public async Task TestUploadFileAsync()
		{
			// Arrange
			// Use the Azure Storage Emulator connection string for testing
			string connectionString = "UseDevelopmentStorage=true";
			// Create a unique container name for testing
			BlobServiceClient client = new BlobServiceClient(connectionString);
			// Generate a unique container name to avoid conflicts
			string testContainerName = $"test-{Guid.NewGuid():N}";
			// Create the container client
			BlobContainerClient container = client.GetBlobContainerClient(testContainerName);
			// Set up the BlobStorageOptions with the test container name
			BlobStorageOptions blobStorageOptions = new BlobStorageOptions
			{
				ConnectionString = connectionString,
				ContainerName = container.Name
			};
			// Mock the IOptions<BlobStorageOptions> to return the test options
			var options = new Mock<IOptions<BlobStorageOptions>>();
			// Set up the mock to return the blobStorageOptions when Value is accessed
			options.Setup(o => o.Value).Returns(blobStorageOptions);

			await container.CreateAsync();
			// Create an instance of the BlobStorageService with the mocked options
			BlobStorageService blobStorageService = new BlobStorageService(options.Object);

			//Test Data
			var content = Encoding.UTF8.GetBytes("test image");
			var stream = new MemoryStream(content);

			var file = new FormFile(
				stream,
				0,
				stream.Length,
				"file",
				"test.jpg"
			);
			// Set the headers and content type for the FormFile
			file.Headers = new HeaderDictionary();
			file.ContentType = "image/jpeg";

			//We use a try-finally block to ensure that the container is deleted after the test,
			//even if the test fails
			try
			{
				// Act
				var blobName = await blobStorageService.UploadFileAsync(file);
				BlobClient blobClient = container.GetBlobClient(blobName);

				// Assert
				Assert.NotEmpty(blobName);
				Assert.True((await blobClient.ExistsAsync()).Value);
			}
			finally
			{

				//Finally, clean up by deleting the container

				await container.DeleteIfExistsAsync();

			}


		}

		[Fact]
		public async Task TestDownloadFileAsync()
		{
			// Arrange
			string connectionString = "UseDevelopmentStorage=true";
			BlobServiceClient client = new BlobServiceClient(connectionString);
			string testContainerName = $"test-{Guid.NewGuid():N}";
			BlobContainerClient container = client.GetBlobContainerClient(testContainerName);
			BlobStorageOptions blobStorageOptions = new BlobStorageOptions
			{
				ConnectionString = connectionString,
				ContainerName = container.Name
			};
			var options = new Mock<IOptions<BlobStorageOptions>>();
			options.Setup(o => o.Value).Returns(blobStorageOptions);

			await container.CreateAsync();

			BlobStorageService blobStorageService = new BlobStorageService(options.Object);

			//Test Data
			var content = Encoding.UTF8.GetBytes("test image");
			var stream = new MemoryStream(content);

			var file = new FormFile(
				stream,
				0,
				stream.Length,
				"file",
				"test.jpg"
			);
			file.Headers = new HeaderDictionary();
			file.ContentType = "image/jpeg";


			try
			{
				//Act
				var blobName = await blobStorageService.UploadFileAsync(file);
				var downloadResult = await blobStorageService.DownloadAsync(blobName);
				// Read downloaded content
				using var reader = new StreamReader(downloadResult.Content);
				var downloadedContent = await reader.ReadToEndAsync();
				// Assert
				Assert.Equal(file.ContentType, downloadResult.Details.ContentType);
				Assert.Equal("test image", downloadedContent);
			}
			finally
			{

				//Finally, clean up by deleting the container

				await container.DeleteIfExistsAsync();
			}

		}


		[Fact]
		public async Task DeleteBlobAsync()
		{
			// Arrange
			string connectionString = "UseDevelopmentStorage=true";
			BlobServiceClient client = new BlobServiceClient(connectionString);
			string testContainerName = $"test-{Guid.NewGuid():N}";
			BlobContainerClient container = client.GetBlobContainerClient(testContainerName);
			BlobStorageOptions blobStorageOptions = new BlobStorageOptions
			{
				ConnectionString = connectionString,
				ContainerName = container.Name
			};
			var options = new Mock<IOptions<BlobStorageOptions>>();
			options.Setup(o => o.Value).Returns(blobStorageOptions);

			await container.CreateAsync();

			BlobStorageService blobStorageService = new BlobStorageService(options.Object);


			//Test Data
			var content = Encoding.UTF8.GetBytes("test image");
			var stream = new MemoryStream(content);

			var file = new FormFile(
				stream,
				0,
				stream.Length,
				"file",
				"test.jpg"
			);
			file.Headers = new HeaderDictionary();
			file.ContentType = "image/jpeg";


			try
			{
				//Act
				var blobName = await blobStorageService.UploadFileAsync(file);
				var blobClient = container.GetBlobClient(blobName);
				//Check if the blob exists before deletion
				Assert.True((await blobClient.ExistsAsync()).Value);
				await blobStorageService.DeleteBlobAsync(blobName);
				//Check if the blob exists after deletion
				Assert.False((await blobClient.ExistsAsync()).Value);

			}
			finally
			{

				//Finally, clean up by deleting the container

				await container.DeleteIfExistsAsync();
			}

		}
	}
}
