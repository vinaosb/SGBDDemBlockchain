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
	public class EstadosController : ControllerBase
	{
		private readonly postgresContext _context;

		public EstadosController(postgresContext context)
		{
			_context = context;
		}

		// GET: api/Estados
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Estado>>> GetEstado()
		{
			return await _context.Estado.ToListAsync();
		}

		// GET: api/Estados/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Estado>> GetEstado(long id)
		{
			var estado = await _context.Estado.FindAsync(id);

			if (estado == null)
			{
				return NotFound();
			}

			return estado;
		}

		// PUT: api/Estados/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutEstado(long id, Estado estado)
		{
			if (id != estado.CodEstado)
			{
				return BadRequest();
			}

			_context.Entry(estado).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!EstadoExists(id))
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

		// POST: api/Estados
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Estado>> PostEstado(Estado estado)
		{
			_context.Estado.Add(estado);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (EstadoExists(estado.CodEstado))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetEstado", new { id = estado.CodEstado }, estado);
		}

		// DELETE: api/Estados/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Estado>> DeleteEstado(long id)
		{
			var estado = await _context.Estado.FindAsync(id);
			if (estado == null)
			{
				return NotFound();
			}

			_context.Estado.Remove(estado);
			await _context.SaveChangesAsync();

			return estado;
		}

		private bool EstadoExists(long id)
		{
			return _context.Estado.Any(e => e.CodEstado == id);
		}
	}
}
