
using API.Comunicacao;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using Newtonsoft.Json;
using SharedLibrary.BlockchainToBD;
using SharedLibrary.BlockchainToBD.ContractDefinition;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Comm.Controllers
{
	[Route("api/Comm/[controller]")]
	[ApiController]
	public class DatabaseController : ControllerBase
	{
		private string uri;
		public DatabaseController(string u = "localhost/api/Database")
		{
			uri = u;
		}

		// GET: api/DataBase/5
		[HttpGet("{id}")]
		public async Task<byte[]> Get(string id)
		{
			using (HttpClient client = new HttpClient())
			{
				byte[] ret;
				StringContent cont = new StringContent(id);
				var response = await client.GetAsync(uri + "/" + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<byte[]>(t);
					return ret;
				}
				return null;
			}
		}

		// POST: api/DataBase
		[HttpPost]
		public async Task<uint> PostAsync(AddDBFunction addDB)
		{
			using (HttpClient client = new HttpClient())
			{
				uint ret = uint.MaxValue;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(addDB));
				var response = await client.PostAsync(uri + "/", cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<uint>(t);
				}
				Globals.AddDB(ret, addDB.IPAddress.ToString());
				return ret;
			}
		}
	}
}
