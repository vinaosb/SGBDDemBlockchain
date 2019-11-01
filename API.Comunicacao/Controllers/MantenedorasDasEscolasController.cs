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
	public class MantenedorasDasEscolasController : ControllerBase
	{
		private string uri;

		public MantenedorasDasEscolasController(string u = "localhost/api/MantenedorasDasEscolas")
		{
			uri = u;
		}

		// GET: api/MantenedorasDasEscolas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MantenedoraDaEscola>>> GetMantenedoraDaEscola()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<MantenedoraDaEscola>> ret = null;
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<MantenedoraDaEscola>>>(t);
				}
				return ret;
			}
		}

		// GET: api/MantenedorasDasEscolas/5
		[HttpGet("{id}")]
		public async Task<ActionResult<MantenedoraDaEscola>> GetMantenedoraDaEscola(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<MantenedoraDaEscola> ret = null;
				var response = await client.GetAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<MantenedoraDaEscola>>(t);
				}
				return ret;
			}
		}

		// PUT: api/MantenedorasDasEscolas/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMantenedoraDaEscola(long id, MantenedoraDaEscola mantenedoraDaEscola)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(mantenedoraDaEscola));
				var response = await client.PutAsync(uri + id, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}

		// POST: api/MantenedorasDasEscolas
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<MantenedoraDaEscola>> PostMantenedoraDaEscola(MantenedoraDaEscola mantenedoraDaEscola)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<MantenedoraDaEscola> ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(mantenedoraDaEscola));
				var response = await client.PostAsync(uri, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<MantenedoraDaEscola>>(t);
				}
				return ret;
			}
		}

		// DELETE: api/MantenedorasDasEscolas/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<MantenedoraDaEscola>> DeleteMantenedoraDaEscola(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<MantenedoraDaEscola> ret = null;
				var response = await client.DeleteAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<MantenedoraDaEscola>>(t);
				}
				return ret;
			}
		}
	}
}
