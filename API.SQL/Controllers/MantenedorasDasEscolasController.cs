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
	public class MantenedorasDasEscolasController : ControllerBase
	{
		private readonly postgresContext _context;

		public MantenedorasDasEscolasController(postgresContext context)
		{
			_context = context;
		}

		// GET: api/MantenedorasDasEscolas
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MantenedoraDaEscola>>> GetMantenedoraDaEscola()
		{
			return await _context.MantenedoraDaEscola.ToListAsync();
		}

		// GET: api/MantenedorasDasEscolas/5
		[HttpGet("{id}")]
		public async Task<ActionResult<MantenedoraDaEscola>> GetMantenedoraDaEscola(long id)
		{
			var mantenedoraDaEscola = await _context.MantenedoraDaEscola.FindAsync(id);

			if (mantenedoraDaEscola == null)
			{
				return NotFound();
			}

			return mantenedoraDaEscola;
		}

		// PUT: api/MantenedorasDasEscolas/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMantenedoraDaEscola(long id, MantenedoraDaEscola mantenedoraDaEscola)
		{
			if (id != mantenedoraDaEscola.CodEntidade)
			{
				return BadRequest();
			}

			_context.Entry(mantenedoraDaEscola).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MantenedoraDaEscolaExists(id))
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

		// POST: api/MantenedorasDasEscolas
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<MantenedoraDaEscola>> PostMantenedoraDaEscola(MantenedoraDaEscola mantenedoraDaEscola)
		{
			_context.MantenedoraDaEscola.Add(mantenedoraDaEscola);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (MantenedoraDaEscolaExists(mantenedoraDaEscola.CodEntidade))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetMantenedoraDaEscola", new { id = mantenedoraDaEscola.CodEntidade }, mantenedoraDaEscola);
		}

		// DELETE: api/MantenedorasDasEscolas/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<MantenedoraDaEscola>> DeleteMantenedoraDaEscola(long id)
		{
			var mantenedoraDaEscola = await _context.MantenedoraDaEscola.FindAsync(id);
			if (mantenedoraDaEscola == null)
			{
				return NotFound();
			}

			_context.MantenedoraDaEscola.Remove(mantenedoraDaEscola);
			await _context.SaveChangesAsync();

			return mantenedoraDaEscola;
		}

		private bool MantenedoraDaEscolaExists(long id)
		{
			return _context.MantenedoraDaEscola.Any(e => e.CodEntidade == id);
		}
	}
}
