
using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using SharedLibrary.BlockchainToBD;
using SharedLibrary.BlockchainToBD.ContractDefinition;
using System.Linq;
using System.Threading.Tasks;

namespace API.Blockchain.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DatabaseController : ControllerBase
	{
		public BlockchainToBDService Service { get; set; }
		public DatabaseController(BlockchainToBDService service)
		{
			Service = service;
		}

		// GET: api/DataBase/5
		[HttpGet("{id}")]
		public async Task<byte[]> Get(string id)
		{
			return await Service.GetIPAddrQueryAsync(id);
		}

		// POST: api/DataBase
		[HttpPost]
		public async Task<uint> PostAsync(AddDBFunction addDB)
		{
			var receipt = await Service.AddDBRequestAndWaitForReceiptAsync(addDB);
			var AddDbEvent = receipt.DecodeAllEvents<DbCreatedEventDTO>();

			return AddDbEvent.LastOrDefault().Event.DbId;
		}
	}
}
