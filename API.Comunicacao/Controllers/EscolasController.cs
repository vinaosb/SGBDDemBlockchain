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
	public class EscolasController : ControllerBase
	{
		private string uri;
		public EscolasController(string u = "localhost/api/Escolas")
		{
			uri = u;
		}

		// GET: api/Escolas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Escola>>> GetEscola()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<Escola>> ret = null;
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<Escola>>>(t);
				}
				return ret;
			}
		}

		// GET: api/Escolas/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Escola>> GetEscola(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Escola> ret = null;
				var response = await client.GetAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Escola>>(t);
				}
				return ret;
			}
		}

		// PUT: api/Escolas/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEscola(long id, Escola escola)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(escola));
				var response = await client.PutAsync(uri + id, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}

		// POST: api/Escolas
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Escola>> PostEscola(Escola escola)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Escola> ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(escola));
				var response = await client.PostAsync(uri, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Escola>>(t);
				}
				return ret;
			}
		}

		// DELETE: api/Escolas/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Escola>> DeleteEscola(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Escola> ret = null;
				var response = await client.DeleteAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Escola>>(t);
				}
				return ret;
			}
		}
	}
}
