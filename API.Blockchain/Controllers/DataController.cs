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
	public class DataController : ControllerBase
	{
		public BlockchainToBDService _service { get; set; }
		public DataController(BlockchainToBDService service)
		{
			_service = service;
		}

		// GET: api/Data/db/table/data/hash
		[HttpGet("{dbId}/{tId}/{dId}/{h}")]
		public async Task<bool> Get(uint dbId, ulong tId, BigInteger dId, byte[] h)
		{
			return await _service.VerifyQueryAsync(dbId, tId, dId, h);
		}

		// POST: api/Data
		[HttpPost]
		public async Task<BigInteger> Post(AddDataFunction Data)
		{
			var receipt = await _service.AddDataRequestAndWaitForReceiptAsync(Data);
			var AddDataEvent = receipt.DecodeAllEvents<DataModifiedEventDTO>();

			return AddDataEvent.LastOrDefault().Event.DId;
		}

		// PUT: api/Data
		[HttpPut]
		public async Task<byte[]> Put(UpdateDataFunction update)
		{
			var receipt = await _service.UpdateDataRequestAndWaitForReceiptAsync(update);
			var AddDataEvent = receipt.DecodeAllEvents<DataModifiedEventDTO>();

			return AddDataEvent.LastOrDefault().Event.NextHash;
		}

		// DELETE: api/Data/del/
		[HttpDelete("del/")]
		public async Task<bool> Delete(uint dbId, ulong tId, BigInteger dId, byte[] h)
		{
			var receipt = await _service.DeleteDataRequestAndWaitForReceiptAsync(dbId, tId, dId, h);
			var DelDataEvent = receipt.DecodeAllEvents<DataDeletedEventDTO>();

			return DelDataEvent.LastOrDefault().Event.DId == dId;
		}

		// DELETE: api/Data/all/
		[HttpDelete("all/")]
		public async Task<bool> DeleteAll(uint dbId, ulong tId, BigInteger dId, byte[] h)
		{
			var receipt = await _service.DeleteDataFromAllRequestAndWaitForReceiptAsync(dbId, tId, dId, h);
			var DelDataEvent = receipt.DecodeAllEvents<DataDeletedEventDTO>();

			return DelDataEvent.LastOrDefault().Event.DId == dId;
		}
	}
}
