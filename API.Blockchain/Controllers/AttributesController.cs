using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using SharedLibrary.BlockchainToBD;
using SharedLibrary.BlockchainToBD.ContractDefinition;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace API.Blockchain.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AttributesController : ControllerBase
	{
		public BlockchainToBDService Service { get; set; }
		public AttributesController(BlockchainToBDService service)
		{
			Service = service;
		}

		// POST: api/Attributes
		[HttpPost]
		public async Task<BigInteger> Post(AddAttributeFunction att)
		{
			var receipt = await Service.AddAttributeRequestAndWaitForReceiptAsync(att);
			var attEvent = receipt.DecodeAllEvents<AttAddedEventDTO>();

			return attEvent.LastOrDefault().Event.AttId;
		}

		// PUT: api/Attributes/5
		[HttpPut]
		public async Task Put(LinkDataToAttFunction linker)
		{
			var _ = await Service.LinkDataToAttRequestAndWaitForReceiptAsync(linker);
		}

	}
}
