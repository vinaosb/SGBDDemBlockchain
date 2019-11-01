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
	public class CensoEscolasController : ControllerBase
	{
		private string uri;
		public CensoEscolasController(string u = "localhost/api/CensoEscolas")
		{
			uri = u;
		}

		// GET: api/CensoEscolas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CensoEscola>>> GetCensoEscola()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<CensoEscola>> ret = null;
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<CensoEscola>>>(t);
				}
				return ret;
			}
		}

		// GET: api/CensoEscolas/2018/101010
		[HttpGet("{ano}/{id}")]
		public async Task<ActionResult<CensoEscola>> GetCensoEscola(short ano, long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<CensoEscola> ret = null;
				var response = await client.GetAsync(uri + "/" + ano + "/" + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<CensoEscola>>(t);
				}
				return ret;
			}
		}

		// PUT: api/CensoEscolas/2018/101010
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{ano}/{id}")]
		public async Task<IActionResult> PutCensoEscola(short ano, long id, CensoEscola censoEscola)
		{
			using (HttpClient client = new HttpClient())
			{
				IActionResult ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(censoEscola));
				var response = await client.PutAsync(uri + "/" + ano + "/" + id, cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<IActionResult>(t);
				}
				return ret;
			}
		}

		// POST: api/CensoEscolas
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<CensoEscola>> PostCensoEscola(CensoEscola censoEscola)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<CensoEscola> ret = null;
				StringContent cont = new StringContent(JsonConvert.SerializeObject(censoEscola));
				var response = await client.PostAsync(uri + "/", cont);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<CensoEscola>>(t);
				}
				return ret;
			}
		}

		// DELETE: api/CensoEscolas/2019/101010
		[HttpDelete("{ano}/{id}")]
		public async Task<ActionResult<CensoEscola>> DeleteCensoEscola(short ano, long id)
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<CensoEscola> ret = null;
				var response = await client.DeleteAsync(uri + "/" + ano + "/" + id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<CensoEscola>>(t);
				}
				return ret;
			}
		}
	}
}
