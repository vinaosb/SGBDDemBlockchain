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
	public class TelefonesController : ControllerBase
	{
		private string uri;
		public TelefonesController(string u = "localhost/api/Telefones")
		{
			uri = u;
		}

		// GET: api/Telefones
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Telefone>>> GetTelefone()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<Telefone>> ret = null;
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<Telefone>>>(t);
				}
				return ret;
			}
		}

		// GET: api/Telefones/2018/101010
		[HttpGet("{ano}/{id}")]
		public async Task<ActionResult<IEnumerable<Telefone>>> GetTelefone(short ano, long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<Telefone>> ret = null;
				var response = await client.GetAsync(uri + "/" + ano + "/" + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<Telefone>>>(t);
				}
				return ret;
			}
		}

		// GET: api/Telefones/33333333/2018/101010
		[HttpGet("{num}/{ano}/{id}")]
		public async Task<ActionResult<Telefone>> GetTelefone(long num, short ano, long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Telefone> ret = null;
				var response = await client.GetAsync(uri + "/" + num + "/" + ano + "/" + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Telefone>>(t);
				}
				return ret;
			}
		}

		// PUT: api/Telefones/33333333/2018/101010
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{num}/{ano}/{id}")]
		public async Task<IActionResult> PutTelefone(long num, short ano, long id, Telefone telefone)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(telefone));
				var response = await client.PutAsync(uri + "/" + num + "/" + ano + "/" + id, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}

		// POST: api/Telefones
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Telefone>> PostTelefone(Telefone telefone)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Telefone> ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(telefone));
				var response = await client.PostAsync(uri + "/", cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Telefone>>(t);
				}
				return ret;
			}
		}

		// DELETE: api/Telefones/33333333/2018/101010
		[HttpDelete("{num}/{ano}/{id}")]
		public async Task<ActionResult<Telefone>> DeleteTelefone(long num, short ano, long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<Telefone> ret = null;
				var response = await client.DeleteAsync(uri + "/" + num + "/" + ano + "/" + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<Telefone>>(t);
				}
				return ret;
			}
		}
	}
}
