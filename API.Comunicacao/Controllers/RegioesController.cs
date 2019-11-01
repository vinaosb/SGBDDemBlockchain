using API.SQL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Comm.Controllers
{
	[Route("api/Comm/[controller]")]
	[ApiController]
	public class RegioesController : ControllerBase
	{
		private string uri;
		public RegioesController(string u = "localhost/api/Regioes")
		{
			uri = u;
		}

		// GET: api/Regioes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Regiao>>> GetRegiao()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<Regiao>> ret = null;
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<Regiao>>>(t);
				}
				return ret;
			}
		}

		// GET: api/Regioes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Regiao>> GetRegiao(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Regiao> ret = null;
				var response = await client.GetAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Regiao>>(t);
				}
				return ret;
			}
		}

		// PUT: api/Regioes/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutRegiao(long id, Regiao regiao)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(regiao));
				var response = await client.PutAsync(uri + id, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}

		// POST: api/Regioes
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Regiao>> PostRegiao(Regiao regiao)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Regiao> ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(regiao));
				var response = await client.PostAsync(uri, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Regiao>>(t);
				}
				return ret;
			}
		}

		// DELETE: api/Regioes/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Regiao>> DeleteRegiao(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Regiao> ret = null;
				var response = await client.DeleteAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Regiao>>(t);
				}
				return ret;
			}
		}
	}
}
