using API.SQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SQL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CensoEscolasController : ControllerBase
	{
		private readonly postgresContext _context;

		public CensoEscolasController(postgresContext context)
		{
			_context = context;
		}

		// GET: api/CensoEscolas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CensoEscola>>> GetCensoEscola()
		{
			return await _context.CensoEscola.ToListAsync();
		}

		// GET: api/CensoEscolas/2018/101010
		[HttpGet("{ano}/{id}")]
		public async Task<ActionResult<CensoEscola>> GetCensoEscola(short ano, long id)
		{
			var censoEscola = await _context.CensoEscola.Where(ce => ce.Ano == ano && ce.CodEntidade == id).FirstAsync();

			if (censoEscola == null)
			{
				return NotFound();
			}

			return censoEscola;
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
