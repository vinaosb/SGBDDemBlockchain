using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedLibrary.BlockchainToBD;
using SharedLibrary.BlockchainToBD.ContractDefinition;
using System.Net.Http;
using System.Numerics;
using System.Threading.Tasks;

namespace API.Comm.Controllers
{
	[Route("api/Comm/[controller]")]
	[ApiController]
	public class AttributesController : ControllerBase
	{
		private string uri;
		public AttributesController(string u = "localhost/api/Attributes")
		{
			uri = u;
		}

		// POST: api/Attributes
		[HttpPost]
		public async Task<BigInteger> Post(AddAttributeFunction att)
		{
			using (HttpClient client = new HttpClient())
			{
				BigInteger ret = 0;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(att));
				var response = await client.PostAsync(uri + "/", cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<BigInteger>(t);
				}
				return ret;
			}
		}

		// PUT: api/Attributes/5
		[HttpPut]
		public async Task Put(LinkDataToAttFunction linker)
		{
			using (HttpClient client = new HttpClient())
			{
				StringContent cont = new StringContent(JsonConvert.SerializeObject(linker));
				var response = await client.PutAsync(uri + "/", cont);
			}
		}

	}
}
