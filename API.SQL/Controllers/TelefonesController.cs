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
	public class TelefonesController : ControllerBase
	{
		private readonly postgresContext _context;

		public TelefonesController(postgresContext context)
		{
			_context = context;
		}

		// GET: api/Telefones
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Telefone>>> GetTelefone()
		{
			return await _context.Telefone.ToListAsync();
		}

		// GET: api/Telefones/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Telefone>> GetTelefone(long id)
		{
			var telefone = await _context.Telefone.FindAsync(id);

			if (telefone == null)
			{
				return NotFound();
			}

			return telefone;
		}

		// PUT: api/Telefones/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTelefone(long id, Telefone telefone)
		{
			if (id != telefone.Numero)
			{
				return BadRequest();
			}

			_context.Entry(telefone).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TelefoneExists(id))
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

		// POST: api/Telefones
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Telefone>> PostTelefone(Telefone telefone)
		{
			_context.Telefone.Add(telefone);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (TelefoneExists(telefone.Numero))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetTelefone", new { id = telefone.Numero }, telefone);
		}

		// DELETE: api/Telefones/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Telefone>> DeleteTelefone(long id)
		{
			var telefone = await _context.Telefone.FindAsync(id);
			if (telefone == null)
			{
				return NotFound();
			}

			_context.Telefone.Remove(telefone);
			await _context.SaveChangesAsync();

			return telefone;
		}

		private bool TelefoneExists(long id)
		{
			return _context.Telefone.Any(e => e.Numero == id);
		}
	}
}
