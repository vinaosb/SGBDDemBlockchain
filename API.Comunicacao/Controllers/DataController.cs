
using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using Newtonsoft.Json;
using SharedLibrary.BlockchainToBD;
using SharedLibrary.BlockchainToBD.ContractDefinition;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Threading.Tasks;

namespace API.Comm.Controllers
{
	[Route("api/Comm/[controller]")]
	[ApiController]
	public class DataController : ControllerBase
	{
		private readonly string uri;
		public DataController(string u = "localhost/api/Data")
		{
			uri = u;
		}

		// GET: api/Data/db/table/data/hash
		[HttpGet("{dbId}/{tId}/{dId}/{h}")]
		public async Task<bool> Get(uint dbId, ulong tId, BigInteger dId, byte[] h)
		{
			using HttpClient client = new HttpClient();
			bool ret = false;
			var response = await client.GetAsync(uri + "/" + dbId + "/" + tId + "/" + dId + "/" + h);

			if (response.IsSuccessStatusCode)
			{
				var t = await response.Content.ReadAsStringAsync();
				ret = JsonConvert.DeserializeObject<bool>(t);
				return ret;
			}
			return false;
		}

		// POST: api/Data
		[HttpPost]
		public async Task<BigInteger> Post(AddDataFunction Data)
		{
			using HttpClient client = new HttpClient();
			BigInteger ret = 0;
			StringContent cont = new StringContent(JsonConvert.SerializeObject(Data));
			var response = await client.PostAsync(uri + "/", cont);

			if (response.IsSuccessStatusCode)
			{
				var t = await response.Content.ReadAsStringAsync();
				ret = JsonConvert.DeserializeObject<BigInteger>(t);
			}
			return ret;
		}

		// PUT: api/Data
		[HttpPut]
		public async Task<byte[]> Put(UpdateDataFunction update)
		{
			using HttpClient client = new HttpClient();
			byte[] ret = null;
			StringContent cont = new StringContent(JsonConvert.SerializeObject(update));
			var response = await client.PutAsync(uri + "/", cont);

			if (response.IsSuccessStatusCode)
			{
				var t = await response.Content.ReadAsStringAsync();
				ret = JsonConvert.DeserializeObject<byte[]>(t);
			}
			return ret;
		}

		// DELETE: api/Data/del/
		[HttpDelete("del/{dbId}/{tId}/{dId}/{h}")]
		public async Task<bool> Delete(uint dbId, ulong tId, BigInteger dId, byte[] h)
		{
			using HttpClient client = new HttpClient();
			bool ret = false;
			var response = await client.DeleteAsync(uri + "/" + dbId + "/" + tId + "/" + dId + "/" + h);

			if (response.IsSuccessStatusCode)
			{
				var t = await response.Content.ReadAsStringAsync();
				ret = JsonConvert.DeserializeObject<bool>(t);
			}
			return ret;
		}

		// DELETE: api/Data/all/
		[HttpDelete("all/{dbId}/{tId}/{dId}/{h}")]
		public async Task<bool> DeleteAll(uint dbId, ulong tId, BigInteger dId, byte[] h)
		{
			using HttpClient client = new HttpClient();
			bool ret = false;
			var response = await client.DeleteAsync(uri + "/" + dbId + "/" + tId + "/" + dId + "/" + h);

			if (response.IsSuccessStatusCode)
			{
				var t = await response.Content.ReadAsStringAsync();
				ret = JsonConvert.DeserializeObject<bool>(t);
			}
			return ret;
		}
	}
}
