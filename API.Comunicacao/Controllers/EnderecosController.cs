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
	public class EnderecosController : ControllerBase
	{
		private string uri;
		public EnderecosController(string u = "localhost/api/Enderecos")
		{
			uri = u;
		}

		// GET: api/Enderecoes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<Endereco>> ret = null;
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<Endereco>>>(t);
				}
				return ret;
			}
		}

		// GET: api/Enderecoes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Endereco>> GetEndereco(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Endereco> ret = null;
				var response = await client.GetAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Endereco>>(t);
				}
				return ret;
			}
		}

		// PUT: api/Enderecoes/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEndereco(long id, Endereco endereco)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(endereco));
				var response = await client.PutAsync(uri + id, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}

		// POST: api/Enderecoes
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Endereco> ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(endereco));
				var response = await client.PostAsync(uri, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Endereco>>(t);
				}
				return ret;
			}
		}

		// DELETE: api/Enderecoes/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Endereco>> DeleteEndereco(long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Endereco> ret = null;
				var response = await client.DeleteAsync(uri + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Endereco>>(t);
				}
				return ret;
			}
		}
	}
}
