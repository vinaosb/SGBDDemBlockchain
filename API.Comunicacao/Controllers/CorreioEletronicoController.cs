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
	public class CorreioEletronicoController : ControllerBase
	{
		private string uri;
		public CorreioEletronicoController(string u = "localhost/api/CorreioEletronico")
		{
			uri = u;
		}

		// GET: api/CorreioEletronicoes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CorreioEletronico>>> GetCorreioEletronico()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<CorreioEletronico>> ret = null;
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<CorreioEletronico>>>(t);
				}
				return ret;
			}
		}

		// GET: api/CorreioEletronicoes/5
		[HttpGet("{ano}/{id}")]
		public async Task<ActionResult<CorreioEletronico>> GetCorreioEletronico(short ano, long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<CorreioEletronico> ret = null;
				var response = await client.GetAsync(uri + "/" + ano + "/" + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<CorreioEletronico>>(t);
				}
				return ret;
			}
		}

		// PUT: api/CorreioEletronicoes/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{ano}/{id}")]
		public async Task<IActionResult> PutCorreioEletronico(short ano, long id, CorreioEletronico correioEletronico)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(correioEletronico));
				var response = await client.PutAsync(uri + "/" + ano + "/" + id, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}

		// POST: api/CorreioEletronicoes
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<CorreioEletronico>> PostCorreioEletronico(CorreioEletronico correioEletronico)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<CorreioEletronico> ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(correioEletronico));
				var response = await client.PostAsync(uri, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<CorreioEletronico>>(t);
				}
				return ret;
			}
		}

		// DELETE: api/CorreioEletronicoes/5
		[HttpDelete("{ano}/{id}")]
		public async Task<ActionResult<CorreioEletronico>> DeleteCorreioEletronico(short ano, long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<CorreioEletronico> ret = null;
				var response = await client.DeleteAsync(uri + "/" + ano + "/" + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<CorreioEletronico>>(t);
				}
				return ret;
			}
		}
	}
}
