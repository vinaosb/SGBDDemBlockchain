
using API.Comunicacao;
using Microsoft.AspNetCore.Mvc;
using Nethereum.Contracts;
using Newtonsoft.Json;
using SharedLibrary.BlockchainToBD;
using SharedLibrary.BlockchainToBD.ContractDefinition;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Comm.Controllers
{
	[Route("api/Comm/[controller]")]
	[ApiController]
	public class TablesController : ControllerBase
	{
		private string uri;
		public TablesController(string u = "localhost/api/Tables")
		{
			uri = u;
		}

		// POST: api/Tables
		[HttpPost]
		public async Task<ulong> Post(AddTableFunction addTable, Type ty)
		{
			using (HttpClient client = new HttpClient())
			{
				ulong ret = 0;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(addTable));
				var response = await client.PostAsync(uri + "/", cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ulong>(t);
				}
				Globals.AddTable(ret, ty);
				return ret;
			}
		}
	}
}
