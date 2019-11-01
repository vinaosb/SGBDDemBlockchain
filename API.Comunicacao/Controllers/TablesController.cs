
using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using SharedLibrary.BlockchainToBD;
using SharedLibrary.BlockchainToBD.ContractDefinition;
using System.Linq;
using System.Threading.Tasks;

namespace API.Blockchain.Controllers
{
	[Route("api/Comm/[controller]")]
	[ApiController]
	public class TablesController : ControllerBase
	{
		public BlockchainToBDService Service { get; set; }
		public TablesController(BlockchainToBDService service)
		{
			Service = service;
		}

		// POST: api/Tables
		[HttpPost]
		public async Task<ulong> Post(AddTableFunction addTable)
		{
			var receipt = await Service.AddTableRequestAndWaitForReceiptAsync(addTable);
			var addTableEvent = receipt.DecodeAllEvents<TableCreatedEventDTO>();

			return addTableEvent.LastOrDefault().Event.TId;
		}
	}
}
