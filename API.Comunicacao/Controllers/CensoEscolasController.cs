using API.SQL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.SQL.Controllers
{
	[Route("api/Comm/[controller]")]
	[ApiController]
	public class CensoEscolasController : ControllerBase
	{
		public CensoEscolasController()
		{
		}

		// GET: api/CensoEscolas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CensoEscola>>> GetCensoEscola()
		{
			using (HttpClient client = new HttpClient())
			{
				ActionResult<IEnumerable<CensoEscola>> ret = null;
				var response = await client.GetAsync("localhost/api/CensoEscolas");

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
				ActionResult<IEnumerable<CensoEscola>> ret = null;
				var response = await client.GetAsync("localhost/api/CensoEscolas/{Ano}/{Id}", Ano => ano, id);

				if (response.IsSuccessStatusCode)
				{
					var t = await response.Content.ReadAsStringAsync();
					ret = JsonConvert.DeserializeObject<ActionResult<IEnumerable<CensoEscola>>>(t);
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
			if (id != censoEscola.CodEntidade || ano != censoEscola.Ano)
			{
				return BadRequest();
			}

			_context.Entry(censoEscola).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CensoEscolaExists(ano, id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/CensoEscolas
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<CensoEscola>> PostCensoEscola(CensoEscola censoEscola)
		{
			_context.CensoEscola.Add(censoEscola);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (CensoEscolaExists(censoEscola.Ano, censoEscola.CodEntidade))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetCensoEscola", new { ano = censoEscola.Ano, id = censoEscola.Ano }, censoEscola);
		}

		// DELETE: api/CensoEscolas/2019/101010
		[HttpDelete("{ano}/{id}")]
		public async Task<ActionResult<CensoEscola>> DeleteCensoEscola(short ano, long id)
		{
			var censoEscola = await _context.CensoEscola.Where(ce => ce.Ano == ano && ce.CodEntidade == id).FirstAsync();
			if (censoEscola == null)
			{
				return NotFound();
			}

			_context.CensoEscola.Remove(censoEscola);
			await _context.SaveChangesAsync();

			return censoEscola;
		}

		private bool CensoEscolaExists(short ano, long id)
		{
			return _context.CensoEscola.Any(e => e.Ano == ano && e.CodEntidade == id);
		}
	}
}
