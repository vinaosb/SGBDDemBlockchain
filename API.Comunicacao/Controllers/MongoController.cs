using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedLibrary.Context.Custom;
using SharedLibrary.Entities.Custom;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Comm.Controllers
{
	[Route("api/Comm/[controller]")]
	[ApiController]
	public class MongoController : ControllerBase
	{
		private string uri;

		public MongoController(string u = "localhost/api/Mongo")
		{
			uri = u;
		}

		[HttpGet]
		public async Task<ActionResult<List<ExtrasDaEscola>>> GetExtraAsync()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<List<ExtrasDaEscola>> ret = null;
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<List<ExtrasDaEscola>>>(t);
				}
				return ret;
			}
		}

		[HttpGet("{ano}/{cod}")]
		public async Task<ActionResult<ExtrasDaEscola>> GetExtra(short ano, long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<ExtrasDaEscola> ret = null;
				var response = await client.GetAsync(uri + "/" + ano + "/" + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<ExtrasDaEscola>>(t);
				}
				return ret;
			}
		}

		[HttpPost]
		public async Task<ActionResult<ExtrasDaEscola>> PostExtra(ExtrasDaEscola extra)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<ExtrasDaEscola> ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(extra));
				var response = await client.PostAsync(uri, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<ExtrasDaEscola>>(t);
				}
				return ret;
			}
		}

		[HttpPut]
		public async Task<IActionResult> PutExtra(ExtrasDaEscola extra)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(extra));
				var response = await client.PutAsync(uri, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteExtra(short ano, long id)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				var response = await client.DeleteAsync(uri + "/" + ano + "/" + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}
	}
}
