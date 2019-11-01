using API.Blockchain.BlockchainToBD;
using API.Blockchain.BlockchainToBD.ContractDefinition;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace API.Blockchain.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TablesController : ControllerBase
	{
		public BlockchainToBDService _service { get; set; }
		public TablesController(BlockchainToBDService service)
		{
			_service = service;
		}

		// POST: api/Tables
		[HttpPost]
		public async Task<ulong> Post(AddTableFunction addTable)
		{
			var receipt = await _service.AddTableRequestAndWaitForReceiptAsync(addTable);
			var addTableEvent = receipt.DecodeAllEvents<TableCreatedEventDTO>();

			return addTableEvent.LastOrDefault().Event.TId;
		}
	}
}
