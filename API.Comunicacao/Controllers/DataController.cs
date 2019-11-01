
using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using SharedLibrary.BlockchainToBD;
using SharedLibrary.BlockchainToBD.ContractDefinition;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace API.Blockchain.Controllers
{
	[Route("api/Comm/[controller]")]
	[ApiController]
	public class DataController : ControllerBase
	{
		public BlockchainToBDService Service { get; set; }
		public DataController(BlockchainToBDService service)
		{
			Service = service;
		}

		// GET: api/Data/db/table/data/hash
		[HttpGet("{verify}")]
		public async Task<bool> Get(VerifyFunction verify)
		{
			return await Service.VerifyQueryAsync(verify);
		}

		// POST: api/Data
		[HttpPost]
		public async Task<BigInteger> Post(AddDataFunction Data)
		{
			var receipt = await Service.AddDataRequestAndWaitForReceiptAsync(Data);
			var AddDataEvent = receipt.DecodeAllEvents<DataModifiedEventDTO>();

			return AddDataEvent.LastOrDefault().Event.DId;
		}

		// PUT: api/Data
		[HttpPut]
		public async Task<byte[]> Put(UpdateDataFunction update)
		{
			var receipt = await Service.UpdateDataRequestAndWaitForReceiptAsync(update);
			var AddDataEvent = receipt.DecodeAllEvents<DataModifiedEventDTO>();

			return AddDataEvent.LastOrDefault().Event.NextHash;
		}

		// DELETE: api/Data/del/
		[HttpDelete("del/")]
		public async Task<bool> Delete(DeleteDataFunction del)
		{
			var receipt = await Service.DeleteDataRequestAndWaitForReceiptAsync(del);
			var DelDataEvent = receipt.DecodeAllEvents<DataDeletedEventDTO>();

			return DelDataEvent.LastOrDefault().Event.DId == del.DId;
		}

		// DELETE: api/Data/all/
		[HttpDelete("all/")]
		public async Task<bool> Delete(DeleteDataFromAllFunction del)
		{
			var receipt = await Service.DeleteDataFromAllRequestAndWaitForReceiptAsync(del);
			var DelDataEvent = receipt.DecodeAllEvents<DataDeletedEventDTO>();

			return DelDataEvent.LastOrDefault().Event.DId == del.DId;
		}
	}
}
