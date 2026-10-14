using Azure.Storage.Blobs;
using Backend.Data;
using Backend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class BlobTestController:ControllerBase
	{
		private readonly WhereAreWeDbContext _context;
		private readonly IBlobStorageService _blobStorageService;

		public BlobTestController(WhereAreWeDbContext context, IBlobStorageService blobStorageService)
		{
			_context = context;
			_blobStorageService = blobStorageService;
		}


		[HttpPost]
		public async Task<IActionResult> CreateCity(PersonDto personToCreate)
		{

		}



	}
}
