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
	public class EstadosController : ControllerBase
	{
		private string uri;

		public EstadosController(string u = "localhost/api/Estados")
		{
			uri = u;
		}

		// GET: api/Estados
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Estado>>> GetEstado()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<Estado>> ret = null;
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<Estado>>>(t);
				}
				return ret;
			}
		}

		// GET: api/Estados/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Estado>> GetEstado(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Estado> ret = null;
				var response = await client.GetAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Estado>>(t);
				}
				return ret;
			}
		}

		// PUT: api/Estados/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEstado(long id, Estado estado)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(estado));
				var response = await client.PutAsync(uri + id, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}

		// POST: api/Estados
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Estado>> PostEstado(Estado estado)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Estado> ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(estado));
				var response = await client.PostAsync(uri, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Estado>>(t);
				}
				return ret;
			}
		}

		// DELETE: api/Estados/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Estado>> DeleteEstado(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Estado> ret = null;
				var response = await client.DeleteAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Estado>>(t);
				}
				return ret;
			}
		}
	}
}
