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
	public class MunicipiosController : ControllerBase
	{
		private string uri;
		public MunicipiosController(string u = "localhost/api/Municipios")
		{
			uri = u;
		}

		// GET: api/Municipios
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Municipio>>> GetMunicipio()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<Municipio>> ret = null;
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<Municipio>>>(t);
				}
				return ret;
			}
		}

		// GET: api/Municipios/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Municipio>> GetMunicipio(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Municipio> ret = null;
				var response = await client.GetAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Municipio>>(t);
				}
				return ret;
			}
		}

		// PUT: api/Municipios/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMunicipio(long id, Municipio municipio)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(municipio));
				var response = await client.PutAsync(uri + id, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}

		// POST: api/Municipios
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Municipio>> PostMunicipio(Municipio municipio)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Municipio> ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(municipio));
				var response = await client.PostAsync(uri, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Municipio>>(t);
				}
				return ret;
			}
		}

		// DELETE: api/Municipios/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Municipio>> DeleteMunicipio(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Municipio> ret = null;
				var response = await client.DeleteAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Municipio>>(t);
				}
				return ret;
			}
		}
	}
}
