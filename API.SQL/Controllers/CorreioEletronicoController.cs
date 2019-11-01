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
	public class CorreioEletronicoController : ControllerBase
	{
		private readonly postgresContext _context;

		public CorreioEletronicoController(postgresContext context)
		{
			_context = context;
		}

		// GET: api/CorreioEletronicoes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CorreioEletronico>>> GetCorreioEletronico()
		{
			return await _context.CorreioEletronico.ToListAsync();
		}

		// GET: api/CorreioEletronicoes/5
		[HttpGet("{ano}/{id}")]
		public async Task<ActionResult<CorreioEletronico>> GetCorreioEletronico(short ano, long id)
		{
			var correioEletronico = await _context.CorreioEletronico.Where(ce => ce.Ano == ano && ce.CodEntidade == id).FirstAsync();

			if (correioEletronico == null)
			{
				return NotFound();
			}

			return correioEletronico;
		}

		// PUT: api/CorreioEletronicoes/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{ano}/{id}")]
		public async Task<IActionResult> PutCorreioEletronico(short ano, long id, CorreioEletronico correioEletronico)
		{
			if (id != correioEletronico.CodEntidade || ano != correioEletronico.Ano)
			{
				return BadRequest();
			}

			_context.Entry(correioEletronico).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CorreioEletronicoExists(ano, id))
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

		// POST: api/CorreioEletronicoes
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<CorreioEletronico>> PostCorreioEletronico(CorreioEletronico correioEletronico)
		{
			_context.CorreioEletronico.Add(correioEletronico);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (CorreioEletronicoExists(correioEletronico.Ano, correioEletronico.CodEntidade))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetCorreioEletronico", new { ano = correioEletronico.Ano, id = correioEletronico.CodEntidade }, correioEletronico);
		}

		// DELETE: api/CorreioEletronicoes/5
		[HttpDelete("{ano}/{id}")]
		public async Task<ActionResult<CorreioEletronico>> DeleteCorreioEletronico(short ano, long id)
		{
			var correioEletronico = await _context.CorreioEletronico.Where(ce => ce.Ano == ano && ce.CodEntidade == id).FirstAsync();
			if (correioEletronico == null)
			{
				return NotFound();
			}

			_context.CorreioEletronico.Remove(correioEletronico);
			await _context.SaveChangesAsync();

			return correioEletronico;
		}

		private bool CorreioEletronicoExists(short ano, long id)
		{
			return _context.CorreioEletronico.Any(e => e.CodEntidade == id && e.Ano == ano);
		}
	}
}
